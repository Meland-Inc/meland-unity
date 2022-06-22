using HttpPacketDefine;

public class GetPlayersAction : AccountHttpActionBase<EmptyHttpReq, AccountRsp<GetPlayerHttpRspInfo>>
{
    protected override string Api => "getplayer";

    protected override void Receive(AccountRsp<GetPlayerHttpRspInfo> rsp, EmptyHttpReq req)
    {
        if (rsp.Code == 0)
        {
            BasicModule.Login.OnCheckRoleInfo(rsp.Info);
        }
    }

    public static void Req()
    {
        EmptyHttpReq req = GenerateReq();
        SendAction<GetPlayersAction>(req);
    }
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