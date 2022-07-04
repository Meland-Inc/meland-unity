
using UnityGameFramework.Runtime;

public class RemoveMarkFromMinimapAction : GameChannelNetMsgRActionBase<MelandGame3.RemoveMarkFromMiniMapRequest, MelandGame3.RemoveMarkFromMiniMapResponse>
{
    public static void Req(string tMapId, string tMarkId)
    {
        MelandGame3.RemoveMarkFromMiniMapRequest req = GenerateReq();
        req.MapId = tMapId;
        req.MarkId = tMarkId;
        SendAction<RemoveMarkFromMinimapAction>(req);
    }

    protected override string GetEnvelopeReqName()
    {
        return "RemoveMarkFromMinimapRequest";
    }

    protected override MelandGame3.EnvelopeType GetEnvelopeType()
    {
        return MelandGame3.EnvelopeType.RemoveMarkFromMiniMap;
    }

    protected override bool Receive(int errorCode, string errorMsg, MelandGame3.RemoveMarkFromMiniMapResponse rsp, MelandGame3.RemoveMarkFromMiniMapRequest req)
    {
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            return false;
        }

        Log.Debug("RemoveMarkFromMiniMapResponse: {0}", rsp.ToString());
        return true;
    }
}
