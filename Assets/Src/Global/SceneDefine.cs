/// <summary>
/// 客户端场景定义
/// </summary>
public static class SceneDefine
{
    public const string SCENE_NAME_WORLD = "world";
    /// <summary>
    /// 场景设计视野宽度
    /// </summary>
    public const int SCENE_VIEW_WIDTH = 30;
    /// <summary>
    /// 场景设计视野高度
    /// </summary>
    public const int SCENE_VIEW_HEIGHT = 17;
}

/// <summary>
/// 场景资源名 直接使用字符串模式
/// </summary>
public enum eSceneResName
{
    Game,
    SceneLoading,
}