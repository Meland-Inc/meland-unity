
using System.Net.Cache;
using GameFramework.Network;
using UnityGameFramework.Runtime;

public class RemoveMarkFromMinimapAction : GameChannelNetMsgActionBase<Bian.RemoveMarkFromMiniMapRequest, Bian.RemoveMarkFromMiniMapResponse>
{
    public static void Req(string tMapId, string tMarkId)
    {
        Bian.RemoveMarkFromMiniMapRequest req = new();
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

    public override void Receive(Bian.RemoveMarkFromMiniMapResponse rsp)
    {
        // todo 
        Log.Debug("Receive");
    }
}
