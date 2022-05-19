

using Bian;
using UnityGameFramework.Runtime;

public class SendHeartBreakAction : GameChannelNetMsgRActionBase<PingRequest, PingResponse>
{
    public static void Req()
    {
        PingRequest req = GenerateReq();
        Log.Warning(">>> Req SendHeartBreakAction");
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

        Log.Warning("<<< Receive SendHeartBreakAction");
        return true;
    }
}
