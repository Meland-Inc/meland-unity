using System;
using UnityGameFramework.Runtime;

public class LoginCenter : GameFrameworkComponent
{
    public Action OnLoginSuccess;
    public Action OnLoginFailed;
    public Action OnLogoutSuccess;
    public Action OnLogoutFailed;
    public Action OnRegisterSuccess;
    public Action OnRegisterFailed;
    public Action OnGetUserInfoSuccess;
    public Action OnGetUserInfoFailed;
    public Action OnCreatePlayerSuccess;
    public Action OnCreatePlayerFailed;
    public Action OnSignPlayerSuccess;

    public ILoginChannel LoginChannel { get; private set; }

    private void Start()
    {
        InitLoginChannel();
    }

    public void InitLoginChannel()
    {
        LoginChannel = new LoginChannelDebug();
    }

    public void LoginWithToken(string token)
    {
        LoginChannel.LoginWithToken(token);
    }

    public void ConnectGameServer()
    {
        string url = GetGameWSUrl();
        BasicModule.NetMsgCenter.ConnectChannel(NetworkDefine.CHANNEL_NAME_GAME, url, -1);
    }

    public void GetPlayerInfo()
    {
        LoginChannel.GetPlayerInfo();
    }

    public void LoginGame()
    {
        // SigninPlayerAction.Req(PlayerID);
    }

    public void ReqLogout()
    {
        // LogoutAction.Req();
    }

    public string GetGameWSUrl()
    {
        LoginAuthData data = LoginAuthData.Create();
        return $"ws://{URLConfig.WS_ADDRESS}?token={data.Token}&data_hash={data.DataHash}&userId={LoginChannel.UserID}&timestamp={data.TimeStamp}&channel=bian_lesson";
    }

    public void SetUserID(string id)
    {
        LoginChannel.UserID = id;
    }
}
