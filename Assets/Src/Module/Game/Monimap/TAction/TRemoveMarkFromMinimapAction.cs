
using Bian;
using UnityGameFramework.Runtime;

public class TRemoveMarkFromMinimapAction : GameChannelNetMsgTActionBase<Bian.RemoveMarkFromMiniMapResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return Bian.EnvelopeType.RemoveMarkFromMiniMap;
    }

    protected override void Receive(RemoveMarkFromMiniMapResponse rsp)
    {
        Log.Debug("Receive");
    }
}
