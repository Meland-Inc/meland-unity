

using Bian;
using UnityGameFramework.Runtime;

public class SendHeartBreakAction : GameChannelNetMsgRActionBase<PingRequest, PingResponse>
{
    public static void Req()
    {
        PingRequest req = GenerateReq();
        MLog.Warning(eLogTag.network, ">>> Req SendHeartBreakAction");
        SendAction<SendHeartBreakAction>(req);
    }

    protected override string GetEnvelopeReqName()
    {
        return "PingRequest";
    }

    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.Ping;
    }

    protected override bool Receive(int errorCode, string errorMsg, PingResponse rsp, PingRequest req)
    {
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            return false;
        }

        MLog.Warning(eLogTag.network, "<<< Receive SendHeartBreakAction");
        return true;
    }
}
