using System.Collections.Generic;
using HttpPacketDefine;

public abstract class AccountHttpActionBase<TReq, TRsp> : HttpChannelNetMsgActionBase<TReq, TRsp> where TReq : new() where TRsp : HttpRspBase, new()
{
    protected override string ApiRoot => URLConfig.ACCOUNT_API_ROOT;
    protected override string Api => "api/account";

    protected override KeyValuePair<string, string>[] GetHeaders()
    {
        string token = System.Web.HttpUtility.UrlPathEncode(BasicModule.LoginCenter.LoginChannel.Token);
        return new[]
        {
            new KeyValuePair<string, string>("channel", "bian_lesson"),
            new KeyValuePair<string, string>("UserType","1"),//to be removed
            new KeyValuePair<string, string>("Authorization",token)//to be removed!
        };
    }
}