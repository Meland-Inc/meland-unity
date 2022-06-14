using HttpPacketDefine;

public class GetPlayersAction : AccountHttpActionBase<EmptyHttpReq, GetPlayerHttpRsp>
{
    protected override string Api => "getplayer";

    protected override void Receive(GetPlayerHttpRsp rsp, EmptyHttpReq req)
    {
        if (rsp.Code == 0)
        {
            BasicModule.LoginCenter.OnCheckRoleInfo(rsp.Info);
        }
    }

    public static void Req()
    {
        EmptyHttpReq req = GenerateReq();
        SendAction<GetPlayersAction>(req);
    }
}

public class GetPlayerHttpRsp : HttpRspBase
{
    public int Code;
    public string Msg;
    public GetPlayerHttpRspInfo Info;
}

[System.Serializable]
public class GetPlayerHttpRspInfo
{
    public int AccountId;
    public string Id;
    public string Feature;
    public string Gender;
    public string Name;
    public string RoleIcon;
    public int RoleId;
}