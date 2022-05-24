using UnityGameFramework.Runtime;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;

/// <summary>
/// 启动流程
/// </summary>
public class LaunchProcedure : ProcedureBase
{
    private bool _needLogin = false;

    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        MLog.Debug(eLogTag.unknown, "hello GF debug");
        // BasicModule.NetMsgCenter.ConnectChannel(NetworkDefine.CHANNEL_NAME_GAME, "127.0.0.1", 9000);

        _needLogin = true;
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

        if (_needLogin)
        {
            ChangeState<LoginProcedure>(procedureOwner);
        }

        ChangeState<ProcedurePreload>(procedureOwner);
    }
}