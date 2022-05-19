using System.Net.Http;
using UnityEngine;
using HttpPacketDefine;

public class LoginAction : HttpChannelNetMsgActionBase<LoginReq, LoginRsp>
{
    protected override string ApiRoot => "localhost:8080/";

    protected override string Api => "login";

    protected override HttpMethod Method => HttpMethod.Get;

    protected override void Receive(LoginRsp rsp, LoginReq req)
    {
        if (rsp.code != 0)
        {
            Debug.Log("Login failed: " + rsp.msg);
        }
        //handle logic
    }

    public static void Req()
    {
        LoginReq req = GetReq();
        SendAction<LoginAction>(req);
    }
}