public class LoginAuthData
{
    public string TimeStamp;
    public string DataHash;
    public string PrivateKey;
    public string Token;

    public static LoginAuthData Create()
    {
        LoginAuthData data = new()
        {
            TimeStamp = (TimeUtil.GetTimeStamp() / TimeDefine.S_2_MS).ToString(),
            DataHash = LoginDefine.DataHash,
            PrivateKey = LoginDefine.PrivateKey
        };
        data.Token = MelandUtil.GetMd5($"{data.DataHash}{data.TimeStamp}{data.PrivateKey}");
        return data;
    }
}