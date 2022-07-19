using MelandGame3;

/// <summary>
/// 进游戏场景
/// </summary>
public class EnterMapAction : GameChannelNetMsgRActionBase<EnterMapRequest, EnterMapResponse>
{
    public static void Req()
    {
        EnterMapRequest req = GenerateReq();
        SendAction<EnterMapAction>(req);
    }

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
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            return false;
        }

        DataManager.Map.InitSvrData(rsp.Map);
        Message.RspMapEnterFinish.Invoke(rsp);

        // NetLoadingManager.instance.sendNextMsgAfterMap();
        return true;
    }
}