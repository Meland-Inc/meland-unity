using UnityGameFramework.Runtime;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;

/// <summary>
/// 启动流程
/// </summary>
public class LaunchProcedure : ProcedureBase
{
    private string _needLoadSceneName;

    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        Log.Debug("hello GF debug");
        // BasicModule.NetMsgCenter.ConnectChannel(NetworkDefine.CHANNEL_NAME_GAME, "127.0.0.1", 9000);

        Message.GameSceneChanged += OnGameSceneChanged;

        DataManager.GetModel<GameSceneModel>().ChangeToScene(GameSceneModel.SCENE_NAME_WORLD);
    }

    [System.Obsolete]
    protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
    {
        Object.DestroyObject(Camera.main.gameObject);

        base.OnLeave(procedureOwner, isShutdown);
    }

    protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (string.IsNullOrEmpty(_needLoadSceneName))
        {
            return;
        }

        ChangeState<SceneSwitchProcedure>(procedureOwner);
    }

    private void OnGameSceneChanged(string sceneName)
    {
        _needLoadSceneName = sceneName;
    }
}