using UnityEngine;

/// <summary>
/// 场景数据 和当期服务器地图数据无关部分
/// </summary>
public class SceneModel : DataModelBase
{
    [SerializeField]
    private eSceneName _curGameMainScene = eSceneName.none;
    /// <summary>
    /// 当前游戏主场景 不是每个场景Name中的所有枚举 只是各游戏主场景 比如还有登陆 副本等
    /// </summary>
    public eSceneName CurGameMainScene => _curGameMainScene;

    /// <summary>
    /// 改变到某个游戏主场景
    /// </summary>
    /// <param name="sceneName"></param>
    public void ChangeToGameMainScene(eSceneName sceneName)
    {
        if (_curGameMainScene == sceneName)
        {
            return;
        }

        _curGameMainScene = sceneName;

        Message.GameMainSceneChanged.Invoke(_curGameMainScene);
    }
}