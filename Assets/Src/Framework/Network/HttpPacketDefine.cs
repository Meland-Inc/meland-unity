using System;

namespace HttpPacketDefine
{
    [Serializable]
    public abstract class HttpRspBase
    {

    }

    public class EmptyHttpReq
    {

    }

    public class AccountRsp<T> : HttpRspBase
    {
        public int Code;
        public string Msg;
        public T Info;
    }

    public class AccountRspInfo
    {
        //
    }

    public class CreatePlayerReq
    {
        public int roleId;
        public string name;
        public string gender;
        public string feature;
        public int osType;
        public int platform;
        public string roleIcon;

    }

    [Serializable]
    public class CreatePlayerRspInfo
    {
        public string Id;
        public string Gender;
        public string Name;
        public string RoleIcon;
        public string RoleId;
        public string Feature;
    }

    [Serializable]
    public class RoleFeature
    {
        public int hair;
        public int clothes;
        public int glove;
        public int pants;
        public int face;
        // public int eye;
        // public int mouth;
        // public int eyebrow;
        public int shoes;
    }
}