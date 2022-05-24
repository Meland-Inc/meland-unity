namespace HttpPacketDefine
{
    [System.Serializable]
    public abstract class HttpRspBase
    {
    }
    public class LoginReq
    {

    }

    public class LoginRsp : HttpRspBase
    {
        public int code;
        public string msg;
    }

    public class EmptyReq
    {

    }

    public class GetPlayerReq : EmptyReq
    {
        //todo
    }

    public class GetPlayerRsp : HttpRspBase
    {
        public int Code;
        public string Msg;
        public GetPlayerRspInfo Info;
    }

    [System.Serializable]
    public class GetPlayerRspInfo
    {
        public int AccountId;
        public string Id;
        public string Feature;
        public string Gender;
        public string Name;
        public string RoleIcon;
        public int RoleId;
    }
}