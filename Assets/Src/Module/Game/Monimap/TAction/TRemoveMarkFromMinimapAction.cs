
using Bian;
using UnityGameFramework.Runtime;

public class TRemoveMarkFromMinimapAction : GameChannelNetMsgTActionBase<RemoveMarkFromMiniMapResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.RemoveMarkFromMiniMap;
    }

    protected override bool Receive(int errorCode, string errorMsg, RemoveMarkFromMiniMapResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }

        MLog.Warning(eLogTag.network, "<<< Receive TRemoveMarkFromMinimapAction");
        return true;
    }
}
