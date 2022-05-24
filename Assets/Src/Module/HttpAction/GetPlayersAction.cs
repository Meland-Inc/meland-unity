using HttpPacketDefine;
using UnityEngine;

public class GetPlayersAction : AccountHttpActionBase<GetPlayerReq, GetPlayerRsp>
{
    protected override string Api => "getplayer";

    protected override void Receive(GetPlayerRsp rsp, GetPlayerReq req)
    {
        Message.GetPlayerSuccess?.Invoke(rsp);
    }

    public static void Req()
    {
        GetPlayerReq req = GetReq();
        SendAction<GetPlayersAction>(req);
    }
}