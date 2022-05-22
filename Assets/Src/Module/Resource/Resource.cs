using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 游戏加载及路径相关
/// </summary>
public static class Resource
{
    /// <summary>
    /// 获取场景资源完整路径
    /// </summary>
    /// <param name="assetPath">相对路径 不带后缀</param>
    /// <returns></returns>
    public static string GetSceneAssetPath(string assetPath)
    {
        return Path.Combine(ResourceDefine.PATH_SCENE, $"{assetPath}.unity");
    }

    /// <summary>
    /// 加载游戏配置
    /// </summary>
    /// <param name="assetPath">相对路径 不带后缀</param>
    /// <param name="priority">优先级 默认0</param>
    /// <returns></returns>
    public static async UniTask<string> LoadConfig(string assetPath, int priority = 0)
    {
        return await GFEntry.Resource.AwaitLoadAsset<string>(Path.Combine(ResourceDefine.PATH_CONFIG, $"{assetPath}.bin"), priority);
    }

    /// <summary>
    /// 加载Sprite资源
    /// </summary>
    /// <param name="assetPath">相对路径 不带后缀</param>
    /// <param name="priority">优先级 默认0</param>
    /// <returns></returns>
    public static async UniTask<Sprite> LoadSprite(string assetPath, int priority = 0)
    {
        return await GFEntry.Resource.AwaitLoadAsset<Sprite>(Path.Combine(ResourceDefine.PATH_SPRITE, $"{assetPath}.png"), priority);
    }

    /// <summary>
    /// 加载龙骨资源
    /// </summary>
    /// <param name="assetPath">相对路径 不带后缀</param>
    /// <param name="priority">优先级 默认0</param>
    /// <returns></returns>
    public static async UniTask<GameObject> LoadDragonBones(string assetPath, int priority = 0)
    {
        return await GFEntry.Resource.AwaitLoadAsset<GameObject>(Path.Combine(ResourceDefine.PATH_DRAGON_BONES, $"{assetPath}.db"), priority);
    }

    /// <summary>
    /// 加载特效预制件
    /// </summary>
    /// <param name="assetPath">相对路径 不带后缀</param>
    /// <param name="priority">优先级 默认0</param>
    /// <returns></returns>
    public static async UniTask<GameObject> LoadEffect(string assetPath, int priority = 0)
    {
        return await GFEntry.Resource.AwaitLoadAsset<GameObject>(Path.Combine(ResourceDefine.PATH_EFFECT, $"{assetPath}.prefab"), priority);
    }

    /// <summary>
    /// 加载场景物件预制件
    /// </summary>
    /// <param name="assetPath">相对路径 不带后缀</param>
    /// <param name="priority">优先级 默认0</param>
    /// <returns></returns>
    public static async UniTask<GameObject> LoadMapElement(string assetPath, int priority = 0)
    {
        return await GFEntry.Resource.AwaitLoadAsset<GameObject>(Path.Combine(ResourceDefine.PATH_MAP_ELEMENT, $"{assetPath}.prefab"), priority);
    }
}