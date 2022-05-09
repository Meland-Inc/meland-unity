

using UnityGameFramework.Runtime;

public class SendHeartBreakAction : GameChannelNetMsgActionBase<Bian.PingRequest, Bian.PingResponse>
{
    public static void Req()
    {
        Bian.PingRequest req = new();
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

    public override void Receive(Bian.PingResponse packet)
    {
        Log.Debug("SendHeartBreakAction");
    }
}
