public class LoginChannelDebug : LoginChannelBase
{
    public override LoginDefine.eLoginChannel Channel => LoginDefine.eLoginChannel.DEBUG;
    public override string Token
    {
        get => GetToken();
        set => SetToken(value);
    }
    public override string UserID
    {
        get => GetUserID();
        set => SetUserID(value);
    }
    private string _token;
    private string _userID;

    private string GetToken()
    {
        LoginAutoData data = LoginAutoData.Create();
        return $"{data.Token} {data.DataHash} {UserID} {data.TimeStamp}";
    }

    private void SetToken(string token)
    {
        _token = token;
    }

    private void SetUserID(string id)
    {
        _userID = id;
    }

    private string GetUserID()
    {
        return _userID;
    }
}