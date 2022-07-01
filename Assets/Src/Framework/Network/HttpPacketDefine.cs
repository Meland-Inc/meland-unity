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
}