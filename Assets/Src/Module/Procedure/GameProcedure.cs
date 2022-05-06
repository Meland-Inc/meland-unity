using System;
using GameFramework.Fsm;
using GameFramework.Procedure;

/// <summary>
/// 正式在场景里游戏流程
/// </summary>
public class GameProcedure : ProcedureBase
{
    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        ShowUI();

        CreateSceneEntity();

        RegisterPlayOperateSystem();
    }

    protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
    {
        HideUI();

        DestroySceneEntity();

        UnregisterPlayOperateSystem();

        base.OnLeave(procedureOwner, isShutdown);
    }

    private void ShowUI()
    {
        throw new NotImplementedException();
    }

    private void HideUI()
    {
        throw new NotImplementedException();
    }

    private void CreateSceneEntity()
    {
        throw new NotImplementedException();
    }

    private void DestroySceneEntity()
    {
        throw new NotImplementedException();
    }

    private void RegisterPlayOperateSystem()
    {
        throw new NotImplementedException();
    }

    private void UnregisterPlayOperateSystem()
    {
        throw new NotImplementedException();
    }
}