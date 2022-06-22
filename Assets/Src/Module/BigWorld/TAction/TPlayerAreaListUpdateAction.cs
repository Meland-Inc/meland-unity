
using Bian;

public class TPlayerAreaListUpdateAction : GameChannelNetMsgTActionBase<TPlayerAreaListUpdateResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TplayerAreaListUpdate;
    }

    protected override bool Receive(int errorCode, string errorMsg, TPlayerAreaListUpdateResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }
        BigWorldUtil.HandleAddRemoveBigWorldPlayerArea(rsp.AddList, rsp.RemoveList);
        return true;
    }
}
