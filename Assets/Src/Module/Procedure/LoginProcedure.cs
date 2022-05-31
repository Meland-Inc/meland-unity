using UnityGameFramework.Runtime;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Event;

public class LoginProcedure : ProcedureBase
{
    private string _needLoadSceneName;
    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        Log.Info("enter login procedure", eLogTag.login);
        base.OnEnter(procedureOwner);
        EventComponent eventCom = GameEntry.GetComponent<EventComponent>();
        eventCom.Subscribe(NetworkConnectedEventArgs.EventId, OnNetworkConnected);

        Message.GetPlayerSuccess += OnGetPlayerSuccess;
        Message.SigninPlayerSuccess += OnSigninPlayerSuccess;
        Message.EnterMapSuccess += OnEnterMapSuccess;
        Message.GameSceneChanged += OnGameSceneChanged;

        //_ = GFEntry.UI.OpenUIForm<FormLogin>();
        Egret.LoginAction.Req();
    }

    protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
    {
        EventComponent eventCom = GameEntry.GetComponent<EventComponent>();
        eventCom.Unsubscribe(NetworkConnectedEventArgs.EventId, OnNetworkConnected);
        Message.GetPlayerSuccess -= OnGetPlayerSuccess;
        Message.SigninPlayerSuccess -= OnSigninPlayerSuccess;
        Message.EnterMapSuccess -= OnEnterMapSuccess;
        Message.GameSceneChanged -= OnGameSceneChanged;

        //GFEntry.UI.CloseUIForm<FormLogin>();

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
        EnterMapAction.Req();
    }

    private void OnEnterMapSuccess(Bian.EnterMapResponse rsp)
    {
        Log.Info("enter map success,start to enter game scene", eLogTag.login);
        DataManager.GetModel<GameSceneModel>().ChangeToScene(GameSceneModel.SCENE_NAME_WORLD);
    }

    private void OnGameSceneChanged(string sceneName)
    {
        _needLoadSceneName = sceneName;
    }
}
