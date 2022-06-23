using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityGameFramework.Runtime;

/// <summary>
/// 管理资源加载的统一地方 不要直接使用GF加载资源
/// </summary>
public class AssetLoader : GameFrameworkComponent
{
    private ResourceComponent _gfResource;
    /// <summary>
    /// 当前使用的所有的资源表 key:文件路径+typeName value:Asset<object>
    /// </summary>
    private Dictionary<string, object> _assetMap;

    private void Start()
    {
        _gfResource = GameEntry.GetComponent<ResourceComponent>();
        _assetMap = new();
    }

    private void OnDestroy()
    {
        foreach (Asset<object> item in _assetMap.Values.Cast<Asset<object>>())
        {
            item.Dispose();
        }
        _assetMap = null;
        _gfResource = null;
    }

    /// <summary>
    /// 加载资源
    /// </summary>
    /// <param name="assetPath">资源路径</param>
    /// <param name="uid">用户加载ID 使用该UID来取消加载 需要同资源名下唯一 一般直接使用调用对象Hashcode即可 也可以使用TwoIntToUlong将两个hash拼装成一个唯一的</param>
    /// <param name="priority">加载优先级（目前同样的资源只会第一次优先级生效）</param>
    /// <typeparam name="T">unity支持的资源类型 不知道就给object</typeparam>
    /// <returns></returns>
    public UniTask<T> LoadAsset<T>(string assetPath, long uid, int priority = 0)
        where T : class
    {
        string key = GetAssetKey(assetPath, typeof(T));
        Asset<T> typeAsset;
        if (_assetMap.TryGetValue(key, out object asset))
        {
            typeAsset = asset as Asset<T>;
        }
        else
        {
            typeAsset = new Asset<T>();
            typeAsset.Init(_gfResource, assetPath);
            _assetMap.Add(key, typeAsset);
        }

        return typeAsset.LoadAsset(uid, priority);
    }

    /// <summary>
    /// 卸载资源 业务层不必理会加载状态 卸载时如果业务还在await中会catch到OperationCanceledException
    /// </summary>
    /// <param name="assetPath">资源路径</param>
    /// <param name="uid">用户加载ID 需要和加载的一致</param>
    /// <typeparam name="T"></typeparam>
    public void UnloadAsset<T>(string assetPath, long uid)
        where T : class
    {
        string key = GetAssetKey(assetPath, typeof(T));
        if (!_assetMap.TryGetValue(key, out object asset))
        {
            MLog.Error(eLogTag.asset, $"asset {assetPath} type={typeof(T).Name} is not loaded");
            return;
        }

        Asset<T> typeAsset = asset as Asset<T>;
        typeAsset.UnloadAsset(uid);
        if (!typeAsset.IsInUse)
        {
            typeAsset.Dispose();
            _ = _assetMap.Remove(key);
        }
    }

    /// <summary>
    /// 获取资源的key key为资源路径加上期望资源类型
    /// </summary>
    /// <param name="assetPath"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    private string GetAssetKey(string assetPath, Type type)
    {
        return $"{assetPath}_{type.Name}";
    }
}