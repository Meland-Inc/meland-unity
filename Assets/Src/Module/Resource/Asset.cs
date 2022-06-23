using System.Linq;
using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameFramework;
using GameFramework.Resource;
using UnityGameFramework.Runtime;
/// <summary>
/// 游戏资源
/// </summary>
public class Asset<T> : IReference
    where T : class
{
    private string _assetName;
    private T _asset;
    private bool _isDisposed;
    /// <summary>
    /// 加载等待promise列表 key:UID
    /// </summary>
    private Dictionary<long, UniTaskCompletionSource<T>> _loadPromiseMap;
    /// <summary>
    /// 使用资源的表 key为 UID
    /// </summary>
    private HashSet<long> _useMap;
    private int _loadPriority;
    private ResourceComponent _gfResource;
    private bool _isLoading;//正在加载中

    public bool IsInUse => _useMap.Count > 0;

    public void Init(ResourceComponent gfResource, string assetName)
    {
        _gfResource = gfResource;
        _assetName = assetName;
        _isLoading = false;
        _isDisposed = false;
        _loadPromiseMap = new();
        _useMap = new();
    }

    public void Dispose()
    {
        if (_asset != null)
        {
            RealUnload();
        }

        if (_loadPromiseMap.Count > 0)
        {
            if (!_isLoading)
            {
                MLog.Error(eLogTag.asset, $"asset {_assetName} {typeof(T).Name} not loading but has {_loadPromiseMap.Count} load promise");
            }

            foreach (UniTaskCompletionSource<T> promise in _loadPromiseMap.Values)
            {
                _ = promise.TrySetCanceled();
            }
        }

        _loadPromiseMap = null;
        _useMap = null;
        _isDisposed = true;

        //由于已经在加载无法停止 所以也不能里面回池 需要等到资源加载完成才能回池
        if (!_isLoading)
        {
            ReferencePool.Release(this);
        }
    }

    public void Clear()
    {
        _assetName = null;
        _isDisposed = false;
        _isLoading = false;
        _gfResource = null;
        _loadPriority = 0;
    }

    /// <summary>
    /// 加载一次引用
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="priority"></param>
    /// <returns></returns>
    public UniTask<T> LoadAsset(long uid, int priority = 0)
    {
        if (!_useMap.Add(uid))
        {
            MLog.Error(eLogTag.asset, $"asset {_assetName} {typeof(T).Name} use map add uid {uid} fail");
            return UniTask.FromCanceled<T>();
        }

        //已经加载完毕直接返回
        if (_asset != null)
        {
            return UniTask.FromResult(_asset);
        }

        //需要加载
        UniTaskCompletionSource<T> _loadTaskSource = new();
        _loadPromiseMap.Add(uid, _loadTaskSource);

        if (!_isLoading)
        {
            _loadPriority = priority;
            StartRealLoad();
        }

        return _loadTaskSource.Task;
    }

    /// <summary>
    /// 卸载一次引用
    /// </summary>
    /// <param name="uid"></param>
    public void UnloadAsset(long uid)
    {
        if (_loadPromiseMap.Count > 0 && _loadPromiseMap.TryGetValue(uid, out UniTaskCompletionSource<T> promise))
        {
            _ = _loadPromiseMap.Remove(uid);
            _ = promise.TrySetCanceled();
        }

        if (!_useMap.Remove(uid))
        {
            MLog.Error(eLogTag.asset, $"asset {_assetName} {typeof(T).Name} use map remove uid {uid} fail");
        }
    }

    /// <summary>
    /// 开始真实加载
    /// </summary>
    private void StartRealLoad()
    {
        MLog.Debug(eLogTag.asset, $"asset real load start {_assetName} {typeof(T).Name}");
        if (_asset != null)
        {
            MLog.Error(eLogTag.asset, $"asset {_assetName} {typeof(T).Name} already loaded");
            return;
        }

        if (_isLoading)
        {
            return;
        }
        _isLoading = true;

        LoadAssetCallbacks loadCB = new(OnRealLoadSuccess, OnRealLoadFail);
        _gfResource.LoadAsset(_assetName, typeof(T), _loadPriority, loadCB);
    }

    /// <summary>
    /// 正常情况下的真实卸载
    /// </summary>
    private void RealUnload()
    {
        if (_asset == null)
        {
            return;
        }

        MLog.Debug(eLogTag.asset, $"asset real unload {_assetName} {typeof(T).Name}");
        _gfResource.UnloadAsset(_asset);
        _asset = null;

        if (_loadPromiseMap.Count > 0)
        {
            MLog.Error(eLogTag.asset, $"asset unload {_assetName} {typeof(T).Name} exist but has {_loadPromiseMap.Count} load promise");
        }
    }


    private void OnRealLoadSuccess(string assetName, object asset, float duration, object userData)
    {
        _isLoading = false;

        //加载成功时已经释放了 需要直接卸载回池 由于GF加载器本身有引用计数 我只要卸载本任务加载的即可
        if (_isDisposed)
        {
            MLog.Debug(eLogTag.asset, $"asset real unload after already dispose {_assetName} {typeof(T).Name}");
            _gfResource.UnloadAsset(asset);
            ReferencePool.Release(this);
            return;
        }

        _asset = asset as T;

        if (_asset == null)
        {
            MLog.Debug(eLogTag.asset, $"asset real unload after error type {_assetName} {typeof(T).Name}");
            _gfResource.UnloadAsset(asset);
            MLog.Error(eLogTag.asset, $"asset {_assetName} {typeof(T).Name} load asset type error real type={asset.GetType().Name}");
            ExecuteAllPromise((promise) => promise.TrySetException(new AssetLoadException(assetName, typeof(T), LoadResourceStatus.AssetError, "load asset type error real type")));
        }
        else
        {
            ExecuteAllPromise((promise) => promise.TrySetResult(_asset));
        }
    }

    private void OnRealLoadFail(string assetName, LoadResourceStatus status, string errorMessage, object userData)
    {
        _isLoading = false;

        MLog.Warning(eLogTag.asset, $"asset {_assetName} {typeof(T).Name} load fail status={status} error={errorMessage}");
        ExecuteAllPromise((promise) => promise.TrySetException(new AssetLoadException(assetName, typeof(T), status, errorMessage)));
    }

    private void ExecuteAllPromise(Action<UniTaskCompletionSource<T>> execute)
    {
        if (_loadPromiseMap.Count == 0)
        {
            return;
        }

        // 不能直接foreach map，需要先转数组 因为极端情况下一加载立马卸载时会改变map结构
        UniTaskCompletionSource<T>[] values = _loadPromiseMap.Values.ToArray();
        foreach (UniTaskCompletionSource<T> promise in values)
        {
            try
            {
                execute(promise);
            }
            catch (System.Exception)
            {
                continue;
            }
        }

        //为什么这里还要判断为空？极端情况下 上面的execute时 有可能执行完成后没有引用计数直接dispose了 导致这里为空 极端如一加载完成立马卸载
        if (_loadPromiseMap != null)
        {
            _loadPromiseMap.Clear();
        }
    }
}