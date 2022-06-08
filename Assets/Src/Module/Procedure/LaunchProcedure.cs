using GameFramework.Fsm;
using GameFramework.Procedure;

/// <summary>
/// 启动流程
/// </summary>
public class LaunchProcedure : ProcedureBase
{
    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        MLog.Info(eLogTag.procedure, "enter launch procedure");
        base.OnEnter(procedureOwner);
    }

    protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        ChangeState<ProcedurePreload>(procedureOwner);
    }
}