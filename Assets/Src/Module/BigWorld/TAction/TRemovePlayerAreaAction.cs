
using Bian;

public class TRemovePlayerAreaAction : GameChannelNetMsgTActionBase<TRemovePlayerAreaResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TremovePlayerArea;
    }

    protected override bool Receive(int errorCode, string errorMsg, TRemovePlayerAreaResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }
        DataManager.BigWorld.RemovePlayerAreaData(rsp.Area.OwnerId);
        return true;
    }
}
