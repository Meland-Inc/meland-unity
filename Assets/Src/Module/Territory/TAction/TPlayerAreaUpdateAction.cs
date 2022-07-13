
using MelandGame3;

public class TPlayerAreaUpdateAction : GameChannelNetMsgTActionBase<TPlayerAreaUpdateResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TplayerAreaUpdate;
    }

    protected override bool Receive(int errorCode, string errorMsg, TPlayerAreaUpdateResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }
        _ = DataManager.Territory.GetAddPlayerAreaData(rsp.Area);
        return true;
    }
}
