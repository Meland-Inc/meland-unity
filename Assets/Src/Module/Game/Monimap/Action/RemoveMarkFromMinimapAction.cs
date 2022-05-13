
using UnityGameFramework.Runtime;

public class RemoveMarkFromMinimapAction : GameChannelNetMsgRActionBase<Bian.RemoveMarkFromMiniMapRequest, Bian.RemoveMarkFromMiniMapResponse>
{
    public static void Req(string tMapId, string tMarkId)
    {
        Bian.RemoveMarkFromMiniMapRequest req = GetReq();
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

    protected override void Receive(Bian.RemoveMarkFromMiniMapResponse rsp, Bian.RemoveMarkFromMiniMapRequest req)
    {
        // todo 
        Log.Debug("Receive");
    }
}
