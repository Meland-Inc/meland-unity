using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 游戏加载及路径相关
/// </summary>
public static class Resource
{
    public const string PATH_ROOT = "Assets/Res";
    public static readonly string PATH_CONFIG = Path.Combine(PATH_ROOT, "Config");
    public static readonly string PATH_DATA_TABLE = Path.Combine(PATH_ROOT, "DataTable");
    public static readonly string PATH_SCENE = Path.Combine(PATH_ROOT, "Scene");
    public static readonly string PATH_MUSIC = Path.Combine(PATH_ROOT, "Music");
    public static readonly string PATH_SOUND = Path.Combine(PATH_ROOT, "Sound");
    public static readonly string PATH_FONT = Path.Combine(PATH_ROOT, "Font");
    public static readonly string PATH_MAP_ELEMENT = Path.Combine(PATH_ROOT, "Prefab/MapElement");
    public static readonly string PATH_EFFECT = Path.Combine(PATH_ROOT, "Prefab/Effect");
    public static readonly string PATH_TEXTURE = Path.Combine(PATH_ROOT, "Texture");
    public static readonly string PATH_SPRITE = Path.Combine(PATH_ROOT, "Sprite");
    public static readonly string PATH_DRAGON_BONES = Path.Combine(PATH_ROOT, "DragonBones");

    /// <summary>
    /// 获取场景资源完整路径
    /// </summary>
    /// <param name="assetPath">相对路径 不带后缀</param>
    /// <returns></returns>
    public static string GetSceneAssetPath(string assetPath)
    {
        return Path.Combine(PATH_SCENE, $"{assetPath}.unity");
    }

    /// <summary>
    /// 加载游戏配置
    /// </summary>
    /// <param name="assetPath">相对路径 不带后缀</param>
    /// <param name="priority">优先级 默认0</param>
    /// <returns></returns>
    public static async UniTask<string> LoadConfig(string assetPath, int priority = 0)
    {
        return await GFEntry.Resource.AwaitLoadAsset<string>(Path.Combine(PATH_CONFIG, $"{assetPath}.bin"), priority);
    }

    /// <summary>
    /// 加载Sprite资源
    /// </summary>
    /// <param name="assetPath">相对路径 不带后缀</param>
    /// <param name="priority">优先级 默认0</param>
    /// <returns></returns>
    public static async UniTask<Sprite> LoadSprite(string assetPath, int priority = 0)
    {
        return await GFEntry.Resource.AwaitLoadAsset<Sprite>(Path.Combine(PATH_SPRITE, $"{assetPath}.png"), priority);
    }

    /// <summary>
    /// 加载龙骨资源
    /// </summary>
    /// <param name="assetPath">相对路径 不带后缀</param>
    /// <param name="priority">优先级 默认0</param>
    /// <returns></returns>
    public static async UniTask<GameObject> LoadDragonBones(string assetPath, int priority = 0)
    {
        return await GFEntry.Resource.AwaitLoadAsset<GameObject>(Path.Combine(PATH_DRAGON_BONES, $"{assetPath}.db"), priority);
    }

    /// <summary>
    /// 加载特效预制件
    /// </summary>
    /// <param name="assetPath">相对路径 不带后缀</param>
    /// <param name="priority">优先级 默认0</param>
    /// <returns></returns>
    public static async UniTask<GameObject> LoadEffect(string assetPath, int priority = 0)
    {
        return await GFEntry.Resource.AwaitLoadAsset<GameObject>(Path.Combine(PATH_EFFECT, $"{assetPath}.prefab"), priority);
    }

    /// <summary>
    /// 加载场景物件预制件
    /// </summary>
    /// <param name="assetPath">相对路径 不带后缀</param>
    /// <param name="priority">优先级 默认0</param>
    /// <returns></returns>
    public static async UniTask<GameObject> LoadMapElement(string assetPath, int priority = 0)
    {
        return await GFEntry.Resource.AwaitLoadAsset<GameObject>(Path.Combine(PATH_MAP_ELEMENT, $"{assetPath}.prefab"), priority);
    }
}