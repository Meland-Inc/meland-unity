using System.IO;
using System.Collections.Generic;
using UnityEngine;

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
        {eSceneName.launch, Path.Combine(AssetDefine.PATH_SCENE,"Launch"+AssetDefine.SUFFIX_SCENE)},
        {eSceneName.sceneLoading, Path.Combine(AssetDefine.PATH_SCENE,"SceneLoading"+AssetDefine.SUFFIX_SCENE)},
        {eSceneName.world, Path.Combine(AssetDefine.PATH_SCENE,"WorldScene"+AssetDefine.SUFFIX_SCENE)},
    };

    /// <summary>
    /// 场景设计视野宽度
    /// </summary>
    public const int SCENE_VIEW_WIDTH = 30;
    /// <summary>
    /// 场景设计视野高度
    /// </summary>
    public const int SCENE_VIEW_HEIGHT = 17;

    public static readonly Vector3 MainCameraInitFollowMainRoleOffset = new(0.3f, 14.41f, -13.7f);//主相机跟随主角的初始偏移量
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