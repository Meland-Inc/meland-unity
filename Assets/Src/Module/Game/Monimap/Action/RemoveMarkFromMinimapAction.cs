
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

    public override string GetEnvelopeReqName()
    {
        return "RemoveMarkFromMinimapRequest";
    }

    public override Bian.EnvelopeType GetEnvelopeType()
    {
        return Bian.EnvelopeType.RemoveMarkFromMiniMap;
    }

    public override void Receive(Bian.RemoveMarkFromMiniMapResponse rsp, Bian.RemoveMarkFromMiniMapRequest req)
    {
        // todo 
        Log.Debug("Receive");
    }
}
