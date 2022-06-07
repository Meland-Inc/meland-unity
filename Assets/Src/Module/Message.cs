using System;

public static class Message
{
    public static Action<string> GameSceneChanged = delegate { };
    public static Action<GetPlayerHttpRsp> GetPlayerSuccess = delegate { };
    public static Action<Bian.SigninPlayerResponse> SigninPlayerSuccess = delegate { };
    public static Action<Bian.EnterMapResponse> EnterMapSuccess = delegate { };
    public static Action<bool> WebReady = delegate { };
    public static Action<string> RuntimeMessageEmitted = delegate { };
}