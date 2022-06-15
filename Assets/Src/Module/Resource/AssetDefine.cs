using System;
using System.IO;

public static class AssetDefine
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
    public static readonly string PATH_ROLE = Path.Combine(PATH_ROOT, "Prefab/Role");
    public static readonly string PATH_TEXTURE = Path.Combine(PATH_ROOT, "Texture");
    public static readonly string PATH_SPRITE = Path.Combine(PATH_ROOT, "Sprite");
    public static readonly string PATH_DRAGON_BONES = Path.Combine(PATH_ROOT, "DragonBones");
    public static readonly string PATH_UI = Path.Combine(PATH_ROOT, "Fairygui");
}

/// <summary>
/// 资源加载优先级 有默认 Low Normal High 也能自定义
/// </summary>
public enum eLoadPriority : int
{
    Low = 1000,
    Normal = 2000,
    SceneElement,
    PlayerRole,
    High = 3000,
    Terrain,
}
