using Bian;

public class AllPlayerLocAction : GameChannelNetMsgRActionBase<Bian.AllPlayerLocRequest, Bian.AllPlayerLocResponse>
{
    protected override string GetEnvelopeReqName()
    {
        return "AllPlayerLocRequest";
    }

    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.AllPlayerLoc;
    }

    protected override bool Receive(int errorCode, string errorMsg, AllPlayerLocResponse rsp, AllPlayerLocRequest req)
    {
        if (base.Receive(errorCode, errorMsg, rsp, req))
        {
            SceneModule.WorldMap.OnPlayerLocUpdated.Invoke(rsp.Locs);
        }

        return false;
    }

    public static void Req()
    {
        AllPlayerLocRequest req = GenerateReq();
        SendAction<AllPlayerLocAction>(req);
    }
}