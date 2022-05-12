
using Bian;
using UnityGameFramework.Runtime;

public class TRemoveMarkFromMinimapAction : GameChannelNetMsgTActionBase<Bian.RemoveMarkFromMiniMapResponse>
{
    public override EnvelopeType GetEnvelopeType()
    {
        return Bian.EnvelopeType.RemoveMarkFromMiniMap;
    }

    public override void Receive(RemoveMarkFromMiniMapResponse rsp)
    {
        Log.Debug("Receive");
    }
}
