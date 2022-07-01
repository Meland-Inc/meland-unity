public class LoginChannelDebug : LoginChannelBase
{
    public override LoginDefine.eLoginChannel Channel => LoginDefine.eLoginChannel.DEBUG;
    public override string Token => GetToken();

    private string GetToken()
    {
        LoginAuthData data = LoginAuthData.Create();
        return $"{data.Token} {data.DataHash} {UserID} {data.TimeStamp}";
    }
    public override void Start()
    {
        _ = UICenter.OpenUIForm<FormLoginDebug>(this);
    }

    public void ConfirmLogin(string userID)
    {
        UserID = userID;
        OnLoginSuccess.Invoke();
        UICenter.CloseUIForm<FormLoginDebug>();
    }
}