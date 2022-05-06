using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class LaunchProcedure : GameFramework.Procedure.ProcedureBase
{
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        Log.Debug("hello GF debug");
        BasicModule.NetMsgCenter.ConnectChannel(NetworkDefine.CHANNEL_NAME_GAME, "127.0.0.1", 9000);
    }
}