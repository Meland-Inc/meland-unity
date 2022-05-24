public static class LoginDefine
{
    public enum eLoginChannel
    {
        DEBUG = 0,
    }
    public static string DataHash = "e163a857a34975465532b5f1ece0cf54";
    public static string PrivateKey = "a6a004e72ad8909f50b721e2da8ad551";
}

public class LoginAutoData
{
    public string TimeStamp;
    public string DataHash;
    public string PrivateKey;
    public string Token;

    public static LoginAutoData Create()
    {
        LoginAutoData data = new()
        {
            TimeStamp = (TimeUtil.GetTimeStamp() / 1000).ToString(),
            DataHash = LoginDefine.DataHash,
            PrivateKey = LoginDefine.PrivateKey
        };
        data.Token = MelandUtil.GetMd5($"{data.DataHash}{data.TimeStamp}{data.PrivateKey}");
        return data;
    }
}