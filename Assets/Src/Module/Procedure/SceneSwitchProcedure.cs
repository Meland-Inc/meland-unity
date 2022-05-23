using GameFramework;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

/// <summary>
/// 场景切换流程
/// </summary>
public class SceneSwitchProcedure : ProcedureBase
{
    private bool _isSceneLoadFinish;

    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        GFEntry.Event.Subscribe(LoadSceneSuccessEventArgs.EventId, onLoadSceneSuccess);

        ShowLoadingUI();

        // 先切换到laoding场景中 loading场景好了才卸载之前的场景
        GFEntry.Scene.LoadScene(Resource.GetSceneAssetPath(GameSceneModel.SCENE_RES_SCENE_LOADING));
    }

    protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
    {
        GFEntry.Event.Unsubscribe(LoadSceneSuccessEventArgs.EventId, onLoadSceneSuccess);

        HideLoadingUI();

        GFEntry.Scene.UnloadScene(Resource.GetSceneAssetPath(GameSceneModel.SCENE_RES_SCENE_LOADING));

        base.OnLeave(procedureOwner, isShutdown);
    }

    protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (_isSceneLoadFinish)
        {
            ChangeState<GameProcedure>(procedureOwner);
        }
    }

    private void onLoadSceneSuccess(object sender, GameEventArgs e)
    {
        GameSceneModel model = DataManager.GetModel<GameSceneModel>();
        string loadedScene = (e as LoadSceneSuccessEventArgs).SceneAssetName;

        if (loadedScene == Resource.GetSceneAssetPath(GameSceneModel.SCENE_RES_SCENE_LOADING))
        {
            SwitchScene();
        }
        else if (loadedScene == Resource.GetSceneAssetPath(model.CurSceneResName))
        {
            _isSceneLoadFinish = true;
        }
        else
        {
            MLog.Fatal(eLogTag.scene, $"SceneSwitchProcedure::onLoadSceneSuccess: scene name error cur={model.CurSceneResName} load={loadedScene}");
            _isSceneLoadFinish = true;
        }
    }

    private void ShowLoadingUI()
    {
        //TODO: 
    }

    private void HideLoadingUI()
    {
        //TODO:
    }

    /// <summary>
    /// 正式切换去目标场景
    /// </summary>
    private void SwitchScene()
    {
        SceneComponent sceneCom = GFEntry.Scene;
        GameSceneModel sceneModel = DataManager.GetModel<GameSceneModel>();

        //老的需要卸载
        if (!string.IsNullOrEmpty(sceneModel.CurSceneResName))
        {
            sceneCom.UnloadScene(sceneModel.CurSceneResName);
            sceneModel.CurSceneResName = null;
        }

        sceneModel.CurSceneResName = GameSceneModel.SCENE_RES_GAME;
        //加载新的
        sceneCom.LoadScene(Resource.GetSceneAssetPath(sceneModel.CurSceneResName));
    }
}