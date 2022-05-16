

using Bian;
using UnityGameFramework.Runtime;

public class SendHeartBreakAction : GameChannelNetMsgRActionBase<Bian.PingRequest, Bian.PingResponse>
{
    public static void Req()
    {
        Bian.PingRequest req = GetReq();
        Log.Warning(">>> Req SendHeartBreakAction");
        SendAction<SendHeartBreakAction>(req);
    }

    protected override string GetEnvelopeReqName()
    {
        return "PingRequest";
    }

    protected override Bian.EnvelopeType GetEnvelopeType()
    {
        return Bian.EnvelopeType.Ping;
    }

    protected override void Receive(PingResponse rsp, PingRequest req)
    {
        // throw new System.NotImplementedException();
        Log.Warning("<<< Receive SendHeartBreakAction");

    }
}
