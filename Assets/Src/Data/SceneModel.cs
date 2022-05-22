using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 场景数据
/// </summary>
public class SceneModel : DataModelBase
{
    public const string SCENE_NAME_WORLD = "world";

    public const string SCENE_RES_GAME = "Game";
    public const string SCENE_RES_SCENE_LOADING = "SceneLoading";


    [SerializeField]
    private string _curGameScene;
    /// <summary>
    /// 当前游戏场景 可能是大世界 也可能是地图模板id
    /// </summary>
    public string CurGameScene => _curGameScene;

    /// <summary>
    /// 当前场景资源名 多个场景可能共用同一个场景资源名
    /// </summary>
    public string CurSceneResName;

    /// <summary>
    /// 改变到某个场景
    /// </summary>
    /// <param name="sceneName"></param>
    public void ChangeToScene(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            MLog.Error(eLogTag.scene, $"Scene name is invalid. => {sceneName}");
            return;
        }

        if (_curGameScene == sceneName)
        {
            return;
        }

        _curGameScene = sceneName;

        Message.GameSceneChanged.Invoke(_curGameScene);
    }
}