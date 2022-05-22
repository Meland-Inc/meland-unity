using System;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using UnityEngine;

/// <summary>
/// 场景切换流程
/// </summary>
public class SceneLoadingProcedure : ProcedureBase
{
    private bool _isSceneLoadFinish;

    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        if (Camera.main)
        {
            Object.Destroy(Camera.main.gameObject);
        }

        GFEntry.Event.Subscribe(LoadSceneSuccessEventArgs.EventId, onLoadSceneSuccess);
        Message.SceneEntityLoadFinish += OnSceneEntityLoadFinish;

        ShowLoadingUI();

        // 先切换到laoding场景中 loading场景好了才卸载之前的场景
        GFEntry.Scene.LoadScene(Resource.GetSceneAssetPath(SceneModel.SCENE_RES_SCENE_LOADING));
    }

    protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
    {
        GFEntry.Event.Unsubscribe(LoadSceneSuccessEventArgs.EventId, onLoadSceneSuccess);
        Message.SceneEntityLoadFinish -= OnSceneEntityLoadFinish;

        HideLoadingUI();

        GFEntry.Scene.UnloadScene(Resource.GetSceneAssetPath(SceneModel.SCENE_RES_SCENE_LOADING));

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

        if (loadedScene == Resource.GetSceneAssetPath(SceneModel.SCENE_RES_SCENE_LOADING))
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
        SceneComponent sceneCom = GFEntry.Scene;
        SceneModel sceneModel = DataManager.GetModel<SceneModel>();

        //老的需要卸载
        if (!string.IsNullOrEmpty(sceneModel.CurSceneResName))
        {
            sceneCom.UnloadScene(sceneModel.CurSceneResName);
            sceneModel.CurSceneResName = null;
        }

        LoadGameScene(sceneCom);
    }

    /// <summary>
    /// 开始加载游戏场景
    /// </summary>
    /// <param name="sceneCom"></param>
    private void LoadGameScene(SceneComponent sceneCom)
    {
        SceneModel sceneModel = DataManager.GetModel<SceneModel>();
        sceneModel.CurSceneResName = SceneModel.SCENE_RES_GAME;
        sceneCom.LoadScene(Resource.GetSceneAssetPath(sceneModel.CurSceneResName));
    }

    /// <summary>
    /// 游戏场景加载完成
    /// </summary>
    private void OnGameSceneLoaded()
    {
        // _isSceneLoadFinish = true;

        EnterMapAction.Req();
    }
}