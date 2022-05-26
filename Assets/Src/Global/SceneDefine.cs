using System.Collections.Generic;
/// <summary>
/// 客户端场景定义
/// </summary>
public static class SceneDefine
{
    /// <summary>
    /// 场景资源路径 只要定义了场景代号的一定要在这里配置资源名 业务层不用检查
    /// </summary>
    /// <returns></returns>
    public static readonly Dictionary<eSceneName, string> SceneResPath = new()
    {
        {eSceneName.launch, Resource.GetSceneAssetPath("Launch")},
        {eSceneName.sceneLoading, Resource.GetSceneAssetPath("SceneLoading")},
        {eSceneName.world, Resource.GetSceneAssetPath("World")},
    };

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
/// 所有的场景名 代号 需要配置场景资源路径 SceneDefine.SceneResName
/// </summary>
public enum eSceneName : int
{
    none,
    launch,//启动场景 不需要加载
    sceneLoading,//场景loading的场景
    world,//大世界场景
}