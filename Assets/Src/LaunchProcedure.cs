using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class LaunchProcedure : GameFramework.Procedure.ProcedureBase
{
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        Debug.Log("hello unity log");
        Log.Debug("hello GF debug");
        Log.Info("hello GF Info");
        Log.Warning("hello GF Warning");
        Log.Error("hello GF Error");
        Log.Fatal("hello GF Fatal");
    }
}