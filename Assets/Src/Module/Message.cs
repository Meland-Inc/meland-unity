using System;

public static class Message
{
    /// <summary>
    /// 场景改变了
    /// </summary>
    public static Action<string> GameSceneChanged = delegate { };
    public static Action<Bian.EnterMapResponse> EnterMapSuccess = delegate { };
    /// <summary>
    /// 场景实体加载完成
    /// </summary>
    public static Action SceneEntityLoadFinish = delegate { };
    public static Action<GetPlayerHttpRsp> GetPlayerSuccess = delegate { };
    public static Action<Bian.SigninPlayerResponse> SigninPlayerSuccess = delegate { };
    public static Action<Bian.EnterMapResponse> EnterMapSuccess = delegate { };
    public static Action<bool> WebReady = delegate { };
    public static Action<string> RuntimeMessageEmitted = delegate { };
}