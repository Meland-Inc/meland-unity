using System;
using UnityGameFramework.Runtime;

public class LoginCenter : GameFrameworkComponent
{
    public Action OnLoginFailed;
    public Action OnLogoutSuccess;
    public Action OnLogoutFailed;
    public Action OnRegisterSuccess;
    public Action OnRegisterFailed;
    public Action<GetPlayerHttpRspInfo> OnCheckRoleInfo = delegate { };
    public Action OnGetUserInfoFailed;
    public Action OnCreatePlayerSuccess;
    public Action<string> OnCreatePlayerFailed;
    public Action<string> OnRoleReady = delegate { };
    public Action<MelandGame3.SigninPlayerResponse> OnSignPlayer = delegate { };

    public ILoginChannel LoginChannel { get; private set; }

    private void Start()
    {
        InitLoginChannel();
    }

    public void InitLoginChannel()
    {
        LoginChannel = new LoginChannelRuntime();
        LoginChannel.OnLoginSuccess += OnLoginSuccess;
    }

    public void CheckRole()
    {
        MLog.Info(eLogTag.login, "check role");
        GetPlayersAction.Req();
    }

    public void OpenCreateRoleForm()
    {
        MLog.Info(eLogTag.login, "start create role");
        _ = UICenter.OpenUIForm<FormCreateRole>();
    }

    public void CloseCreateRoleForm()
    {
        MLog.Info(eLogTag.login, "close create role");
        UICenter.CloseUIForm<FormCreateRole>();
    }

    public void LoginGame()
    {
        // SigninPlayerAction.Req(PlayerID);
    }

    private string GetGameWSUrl()
    {
        LoginAuthData data = LoginAuthData.Create();
        return $"ws://{URLConfig.WS_ADDRESS}?token={data.Token}&data_hash={data.DataHash}&userId={LoginChannel.UserID}&timestamp={data.TimeStamp}&channel=bian_lesson";
    }

    public void StartLogin()
    {
        MLog.Info(eLogTag.login, $"start login,login channel:{LoginChannel.Channel}");
        LoginChannel.Start();
    }

    public void EndLogin()
    {
        MLog.Info(eLogTag.login, $"end login,login channel:{LoginChannel.Channel}");
    }

    public void OnLoginSuccess()
    {
        MLog.Info(eLogTag.login, $"login success,login channel:{LoginChannel.Channel}");
        string url = GetGameWSUrl();
        BasicModule.NetMsgCenter.ConnectChannel(NetworkDefine.CHANNEL_NAME_GAME, url, -1);
    }
}
