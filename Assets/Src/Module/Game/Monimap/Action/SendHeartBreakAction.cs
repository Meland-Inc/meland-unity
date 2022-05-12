

using Bian;
using UnityGameFramework.Runtime;

public class SendHeartBreakAction : GameChannelNetMsgRActionBase<Bian.PingRequest, Bian.PingResponse>
{
    public static void Req()
    {
        Bian.PingRequest req = GetReq();
        SendAction<SendHeartBreakAction>(req);
    }

    public override string GetEnvelopeReqName()
    {
        return "PingRequest";
    }

    public override Bian.EnvelopeType GetEnvelopeType()
    {
        return Bian.EnvelopeType.Ping;
    }

    public override void Receive(PingResponse rsp, PingRequest req)
    {
        // throw new System.NotImplementedException();
        Log.Debug("Receive");
    }
}
