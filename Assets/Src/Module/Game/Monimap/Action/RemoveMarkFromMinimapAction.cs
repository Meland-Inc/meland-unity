
using UnityGameFramework.Runtime;

public class RemoveMarkFromMinimapAction : GameChannelNetMsgRActionBase<Bian.RemoveMarkFromMiniMapRequest, Bian.RemoveMarkFromMiniMapResponse>
{
    public static void Req(string tMapId, string tMarkId)
    {
        Bian.RemoveMarkFromMiniMapRequest req = GenerateReq();
        req.MapId = tMapId;
        req.MarkId = tMarkId;
        SendAction<RemoveMarkFromMinimapAction>(req);
    }

    protected override string GetEnvelopeReqName()
    {
        return "RemoveMarkFromMinimapRequest";
    }

    protected override Bian.EnvelopeType GetEnvelopeType()
    {
        return Bian.EnvelopeType.RemoveMarkFromMiniMap;
    }

    protected override bool Receive(int errorCode, string errorMsg, Bian.RemoveMarkFromMiniMapResponse rsp, Bian.RemoveMarkFromMiniMapRequest req)
    {
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            return false;
        }

        Log.Debug("RemoveMarkFromMiniMapResponse: {0}", rsp.ToString());
        return true;
    }
}
