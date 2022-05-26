using Bian;

public class EnterMapAction : GameChannelNetMsgRActionBase<EnterMapRequest, EnterMapResponse>
{
    protected override string GetEnvelopeReqName()
    {
        return "EnterMapRequest";
    }
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.EnterMap;
    }

    protected override bool Receive(int errorCode, string errorMsg, EnterMapResponse rsp, EnterMapRequest req)
    {
        Message.EnterMapSuccess?.Invoke(rsp);
        return true;
    }

    public static void Req()
    {
        EnterMapRequest req = GenerateReq();
        SendAction<EnterMapAction>(req);
    }
}