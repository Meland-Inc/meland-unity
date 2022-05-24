using System;

public static class Message
{
    public static Action<string> GameSceneChanged = delegate { };
    public static Action<HttpPacketDefine.GetPlayerRsp> GetPlayerSuccess = delegate { };
    public static Action<Bian.SigninPlayerResponse> SigninPlayerSuccess = delegate { };
    public static Action<Bian.EnterMapResponse> EnterMapSuccess = delegate { };
}