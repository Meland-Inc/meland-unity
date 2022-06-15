public class LoginChannelDebug : LoginChannelBase
{
    public override LoginDefine.eLoginChannel Channel => LoginDefine.eLoginChannel.DEBUG;
    public override string Token => GetToken();

    private string GetToken()
    {
        LoginAuthData data = LoginAuthData.Create();
        return $"{data.Token} {data.DataHash} {UserID} {data.TimeStamp}";
    }

    public override void Logout()
    {
        throw new System.NotImplementedException();
    }

    public override void Register(string account, string userName, string password)
    {
        throw new System.NotImplementedException();
    }

    public override void Start()
    {
        // _ = UICenter.OpenUIForm<FormLoginDebug>(this);
        _ = UICenter.OpenUIForm<FormWorldMap>(this);
    }

    public override void End()
    {
        MLog.Info(eLogTag.login, "On debug login channel end");
    }

    public void ConfirmLogin(string userID)
    {
        UserID = userID;
        OnLoginSuccess.Invoke();
        UICenter.CloseUIForm<FormLoginDebug>();
    }
}