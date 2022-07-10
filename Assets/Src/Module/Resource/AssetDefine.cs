using System.IO;

public static class AssetDefine
{
    public const string PATH_ROOT = "Assets";
    public static readonly string PATH_ROOT_RES = Path.Combine(PATH_ROOT, "Res");
    public static readonly string PATH_SHARE_RES = Path.Combine(PATH_ROOT, "Plugins", "SharedCore", "Resources");
    public static readonly string PATH_CONFIG = Path.Combine(PATH_ROOT_RES, "Config");
    public static readonly string PATH_DATA_TABLE = Path.Combine(PATH_SHARE_RES, "DataTable");
    public static readonly string PATH_SCENE = Path.Combine(PATH_ROOT_RES, "Scene");
    public static readonly string PATH_MUSIC = Path.Combine(PATH_ROOT_RES, "Music");
    public static readonly string PATH_SOUND = Path.Combine(PATH_ROOT_RES, "Sound");
    public static readonly string PATH_FONT = Path.Combine(PATH_ROOT_RES, "Font");
    public static readonly string PATH_MAP_ELEMENT = Path.Combine(PATH_ROOT_RES, "Prefab/MapElement");
    public static readonly string PATH_EFFECT = Path.Combine(PATH_ROOT_RES, "Prefab/Effect");
    public static readonly string PATH_ROLE = Path.Combine(PATH_ROOT_RES, "Prefab/Role");
    public static readonly string PATH_MONSTER = Path.Combine(PATH_ROOT_RES, "Prefab/Spine/Monster");
    public static readonly string PATH_PUPPET = Path.Combine(PATH_ROOT_RES, "Prefab/Spine/Puppet");
    public static readonly string PATH_ANIM_MAP_ELEMENT = Path.Combine(PATH_ROOT_RES, "Prefab/Spine/MapElement");
    public static readonly string PATH_TEXTURE = Path.Combine(PATH_ROOT_RES, "Texture");
    public static readonly string PATH_SPRITE = Path.Combine(PATH_ROOT_RES, "Sprite");
    public static readonly string PATH_DRAGON_BONES = Path.Combine(PATH_ROOT_RES, "DragonBones");
    public static readonly string PATH_UI = Path.Combine(PATH_ROOT_RES, "Fairygui");

    public const string SUFFIX_SPRITE = ".png";
    public const string SUFFIX_TEXTURE = ".png";
    public const string SUFFIX_SCENE = ".unity";
    public const string SUFFIX_PREFAB = ".prefab";
    public const string SUFFIX_MUSIC = ".mp3";
    public const string SUFFIX_SOUND_EFFECT = ".wav";
    public static readonly string PATH_AVATAR_ICON = Path.Combine(PATH_ROOT_RES, "Sprite/Icon/Avatar");
    public static readonly string PATH_ROLE_NAME = Path.Combine(PATH_ROOT_RES, "Text/RoleName");
    public static readonly string PATH_ITEM_ICON = Path.Combine(PATH_ROOT_RES, "Sprite/Icon/Item");
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
    Monster,
    High = 3000,
    Terrain,
}
