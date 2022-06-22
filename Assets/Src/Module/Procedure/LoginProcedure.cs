using UnityGameFramework.Runtime;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Event;

public class LoginProcedure : ProcedureBase
{
    private bool _signalSigninPlayerSuccess = false;

    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        MLog.Info(eLogTag.login, "enter login procedure");
        base.OnEnter(procedureOwner);
        EventComponent eventCom = GameEntry.GetComponent<EventComponent>();
        eventCom.Subscribe(NetworkConnectedEventArgs.EventId, OnNetworkConnected);

        BasicModule.LoginCenter.OnCheckRoleInfo += OnCheckRoleInfo;
        BasicModule.LoginCenter.OnRoleReady += OnRoleReady;
        BasicModule.LoginCenter.OnSignPlayer += OnSignPlayer;
        BasicModule.LoginCenter.StartLogin();
    }

    protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
    {
        EventComponent eventCom = GameEntry.GetComponent<EventComponent>();
        eventCom.Unsubscribe(NetworkConnectedEventArgs.EventId, OnNetworkConnected);

        BasicModule.LoginCenter.OnCheckRoleInfo -= OnCheckRoleInfo;
        BasicModule.LoginCenter.OnSignPlayer -= OnSignPlayer;
        BasicModule.LoginCenter.EndLogin();
        base.OnLeave(procedureOwner, isShutdown);
    }

    protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (!_signalSigninPlayerSuccess)
        {
            return;
        }

        procedureOwner.SetData<VarInt32>("nextSceneName", (int)eSceneName.world);
        ChangeState<SceneLoadingProcedure>(procedureOwner);
    }

    private void OnNetworkConnected(object sender, GameEventArgs e)
    {
        NetworkConnectedEventArgs args = e as NetworkConnectedEventArgs;
        MLog.Info(eLogTag.network, $"OnNetworkConnected: {args.NetworkChannel.Name}");
        if (args.NetworkChannel.Name == NetworkDefine.CHANNEL_NAME_GAME)
        {
            BasicModule.LoginCenter.CheckRole();
        }
    }

    private void OnCheckRoleInfo(GetPlayerHttpRspInfo info)
    {
        MLog.Info(eLogTag.login, "check role info");
        if (string.IsNullOrEmpty(info.Id))
        {
            BasicModule.LoginCenter.OpenCreateRoleForm();
        }
        else
        {
            OnRoleReady(info.Id);
        }
    }

    private void OnRoleReady(string roleId)
    {
        MLog.Info(eLogTag.login, "on role ready,start to sign in player");
        SigninPlayerAction.Req(roleId);
        BasicModule.LoginCenter.CloseCreateRoleForm();
    }

    private void OnSignPlayer(Bian.SigninPlayerResponse rsp)
    {
        MLog.Info(eLogTag.login, "on signin player success,start to enter map");
        _signalSigninPlayerSuccess = true;
    }
}
