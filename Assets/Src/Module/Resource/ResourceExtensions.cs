using Cysharp.Threading.Tasks;
using GameFramework.Resource;
using UnityGameFramework.Runtime;

/// <summary>
/// GF里面的Resource资源模块的扩展
/// </summary>
public static class ResourceExtensions
{
    /// <summary>
    /// 使用await方式的简易加载资源 如果需要使用回调方式或者需要检测update状态请使用LoadAsset
    /// </summary>
    /// <param name="assetName">完整路径</param>
    /// <param name="priority">优先级 默认0</param>
    /// <typeparam name="T">需要加载的类型 默认是object 如果是默认的情况可以直接使用不使用泛型的重载</typeparam>
    /// <returns></returns>
    public static async UniTask<T> AwaitLoadAsset<T>(this ResourceComponent resourceComponent, string assetName, int priority = 0) where T : class
    {
        T resAsset = null;
        bool isLoadedSuccess = false;
        LoadAssetCallbacks loadCB = new(
        (string assetName, object asset, float duration, object userData) =>
        {
            isLoadedSuccess = true;
            resAsset = asset as T;
        },
        (string assetName, LoadResourceStatus status, string errorMessage, object userData) =>
        {
            throw new ResourceLoadException(assetName, status, errorMessage, userData);
        });
        resourceComponent.LoadAsset(assetName, typeof(T), priority, loadCB);
        await UniTask.WaitUntil(() => isLoadedSuccess);
        return resAsset;
    }

    /// <summary>
    /// 使用await方式的简易加载资源 如果需要使用回调方式或者需要检测update状态请使用LoadAsset
    /// </summary>
    /// <param name="assetName">完整路径</param>
    /// <param name="priority">优先级 默认0</param>
    /// <returns></returns>
    public static async UniTask<object> AwaitLoadAsset(this ResourceComponent resourceComponent, string assetName, int priority = 0)
    {
        return await resourceComponent.AwaitLoadAsset<object>(assetName, priority);
    }
}