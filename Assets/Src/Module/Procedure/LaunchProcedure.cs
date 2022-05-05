using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Network;
using GameFramework.Event;
using networkErrorEvent = UnityGameFramework.Runtime.NetworkErrorEventArgs;

public class LaunchProcedure : GameFramework.Procedure.ProcedureBase
{
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        Log.Debug("hello GF debug");
    }
}