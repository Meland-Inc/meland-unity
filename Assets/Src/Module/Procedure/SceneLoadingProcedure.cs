using Bian;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

/// <summary>
/// 场景切换流程
/// </summary>
public class SceneLoadingProcedure : ProcedureBase
{
    private bool _isSceneLoadFinish;
    private eSceneName _needLoadSceneName;

    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        _needLoadSceneName = (eSceneName)procedureOwner.GetData<VarInt32>("nextSceneName").Value;
        _ = procedureOwner.RemoveData("nextSceneName");

        GFEntry.Event.Subscribe(LoadSceneSuccessEventArgs.EventId, onLoadSceneSuccess);
        Message.SceneEntityLoadFinish += OnSceneEntityLoadFinish;
        Message.RspMapEnterFinish += OnRspMapEnterFinish;

        ShowLoadingUI();

        // 先切换到loading场景中 loading场景好了才卸载之前的场景
        GFEntry.Scene.LoadScene(SceneDefine.SceneResPath[eSceneName.sceneLoading]);
    }

    protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
    {
        GFEntry.Event.Unsubscribe(LoadSceneSuccessEventArgs.EventId, onLoadSceneSuccess);
        Message.SceneEntityLoadFinish -= OnSceneEntityLoadFinish;
        Message.RspMapEnterFinish -= OnRspMapEnterFinish;

        HideLoadingUI();

        GFEntry.Scene.UnloadScene(SceneDefine.SceneResPath[eSceneName.sceneLoading]);

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

    private void OnSceneEntityLoadFinish()
    {
        _isSceneLoadFinish = true;
    }

    private void onLoadSceneSuccess(object sender, GameEventArgs e)
    {
        SceneModel model = DataManager.GetModel<SceneModel>();
        string loadedScene = (e as LoadSceneSuccessEventArgs).SceneAssetName;

        if (loadedScene == SceneDefine.SceneResPath[eSceneName.sceneLoading])
        {
            OnLoadingSceneLoaded();
        }
        else if (loadedScene == SceneDefine.SceneResPath[_needLoadSceneName])
        {
            OnGameSceneLoaded();
        }
        else
        {
            MLog.Fatal(eLogTag.scene, $"SceneSwitchProcedure::onLoadSceneSuccess: scene name error cur={model.CurSceneResName} load={loadedScene}");
            throw new System.Exception($"Game scene load error");
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
    /// loading场景加载成功了
    /// </summary>
    private void OnLoadingSceneLoaded()
    {
        SceneModel sceneModel = DataManager.GetModel<SceneModel>();

        //老的需要卸载
        if (sceneModel.CurGameMainScene != eSceneName.none)
        {
            GFEntry.Scene.UnloadScene(SceneDefine.SceneResPath[sceneModel.CurGameMainScene]);
            sceneModel.ChangeToGameMainScene(eSceneName.none);
        }

        GFEntry.Scene.LoadScene(SceneDefine.SceneResPath[_needLoadSceneName]);
    }

    /// <summary>
    /// 游戏场景加载完成
    /// </summary>
    private void OnGameSceneLoaded()
    {
        SceneModel sceneModel = DataManager.GetModel<SceneModel>();
        sceneModel.ChangeToGameMainScene(_needLoadSceneName);

        EnterMapAction.Req();
    }

    private void OnRspMapEnterFinish(EnterMapResponse rsp)
    {
        SceneModule.EntityMgr.NetInitMainRole(rsp.Me, rsp.Location);
    }
}