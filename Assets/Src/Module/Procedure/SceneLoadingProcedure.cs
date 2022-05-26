using System;
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

    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        GFEntry.Event.Subscribe(LoadSceneSuccessEventArgs.EventId, onLoadSceneSuccess);
        Message.SceneEntityLoadFinish += OnSceneEntityLoadFinish;
        Message.RspMapEnterFinish += OnRspMapEnterFinish;

        ShowLoadingUI();

        // 先切换到loading场景中 loading场景好了才卸载之前的场景
        GFEntry.Scene.LoadScene(Resource.GetSceneAssetPath(eSceneResName.SceneLoading.ToString()));
    }

    protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
    {
        GFEntry.Event.Unsubscribe(LoadSceneSuccessEventArgs.EventId, onLoadSceneSuccess);
        Message.SceneEntityLoadFinish -= OnSceneEntityLoadFinish;
        Message.RspMapEnterFinish -= OnRspMapEnterFinish;

        HideLoadingUI();

        GFEntry.Scene.UnloadScene(Resource.GetSceneAssetPath(eSceneResName.SceneLoading.ToString()));

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

        if (loadedScene == Resource.GetSceneAssetPath(eSceneResName.SceneLoading.ToString()))
        {
            OnLoadingSceneLoaded();
        }
        else if (loadedScene == Resource.GetSceneAssetPath(model.CurSceneResName))
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
        if (!string.IsNullOrEmpty(sceneModel.CurSceneResName))
        {
            GFEntry.Scene.UnloadScene(Resource.GetSceneAssetPath(sceneModel.CurSceneResName));
            sceneModel.CurSceneResName = null;
        }

        LoadGameScene();
    }

    /// <summary>
    /// 开始加载游戏场景
    /// </summary>
    private void LoadGameScene()
    {
        SceneModel sceneModel = DataManager.GetModel<SceneModel>();
        sceneModel.CurSceneResName = eSceneResName.Game.ToString();
        GFEntry.Scene.LoadScene(Resource.GetSceneAssetPath(sceneModel.CurSceneResName));
    }

    /// <summary>
    /// 游戏场景加载完成
    /// </summary>
    private void OnGameSceneLoaded()
    {
        _isSceneLoadFinish = true;

        // EnterMapAction.Req();
    }

    private void OnRspMapEnterFinish(EnterMapResponse rsp)
    {
        SceneModule.EntityMgr.NetInitMainRole(rsp.Me, rsp.Location);
    }
}