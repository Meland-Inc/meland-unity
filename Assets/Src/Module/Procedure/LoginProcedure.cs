using UnityGameFramework.Runtime;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Event;

public class LoginProcedure : ProcedureBase
{
    private bool _signalSigninPlayerSuccess = false;

    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        Log.Info("enter login procedure", eLogTag.login);
        base.OnEnter(procedureOwner);
        EventComponent eventCom = GameEntry.GetComponent<EventComponent>();
        eventCom.Subscribe(NetworkConnectedEventArgs.EventId, OnNetworkConnected);

        Message.GetPlayerSuccess += OnGetPlayerSuccess;
        Message.SigninPlayerSuccess += OnSigninPlayerSuccess;

        //_ = GFEntry.UI.OpenUIForm<FormLogin>();
        Runtime.LoginAction.Req();
    }

    protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
    {
        EventComponent eventCom = GameEntry.GetComponent<EventComponent>();
        eventCom.Unsubscribe(NetworkConnectedEventArgs.EventId, OnNetworkConnected);
        Message.GetPlayerSuccess -= OnGetPlayerSuccess;
        Message.SigninPlayerSuccess -= OnSigninPlayerSuccess;

        //GFEntry.UI.CloseUIForm<FormLogin>();

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
        Log.Info($"OnNetworkConnected: {args.NetworkChannel.Name}", eLogTag.network);
        if (args.NetworkChannel.Name == NetworkDefine.CHANNEL_NAME_GAME)
        {
            BasicModule.LoginCenter.GetPlayerInfo();
        }
    }

    private void OnGetPlayerSuccess(GetPlayerHttpRsp rsp)
    {
        Log.Info("get player success,start to sign in player", eLogTag.login);
        SigninPlayerAction.Req(rsp.Info.Id);
    }

    private void OnSigninPlayerSuccess(Bian.SigninPlayerResponse rsp)
    {
        Log.Info("signin player success,start to enter map", eLogTag.login);
        _signalSigninPlayerSuccess = true;
    }
}
