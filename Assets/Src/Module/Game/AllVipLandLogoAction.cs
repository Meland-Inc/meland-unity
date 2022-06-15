using Bian;

class AllVipLandLogoAction : GameChannelNetMsgRActionBase<Bian.AllVipLandLogoRequest, Bian.AllVipLandLogoResponse>
{
    protected override string GetEnvelopeReqName()
    {
        return "AllVipLandLogoRequest";
    }

    protected override EnvelopeType GetEnvelopeType()
    {
        return Bian.EnvelopeType.AllVipLandLogo;
    }

    protected override bool Receive(int errorCode, string errorMsg, AllVipLandLogoResponse rsp, AllVipLandLogoRequest req)
    {
        if (base.Receive(errorCode, errorMsg, rsp))
        {
            DataManager.WorldMap.SetAllVipLandLogoInfo(rsp.VipLandLogos);
            return true;
        }

        return false;
    }

    public static void Req()
    {
        AllVipLandLogoRequest req = GenerateReq();
        SendAction<AllVipLandLogoAction>(req);
    }
}