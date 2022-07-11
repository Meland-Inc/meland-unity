
using Bian;

public class TAddPlayerAreaAction : GameChannelNetMsgTActionBase<TAddPlayerAreaResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TaddPlayerArea;
    }

    protected override bool Receive(int errorCode, string errorMsg, TAddPlayerAreaResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }
        _ = DataManager.Territory.GetAddPlayerAreaData(rsp.Area);
        return true;
    }
}
