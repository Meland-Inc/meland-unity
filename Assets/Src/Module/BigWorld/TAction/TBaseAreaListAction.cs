
using Bian;

public class TBaseAreaListAction : GameChannelNetMsgTActionBase<TBaseAreaListResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TbaseAreaList;
    }

    protected override bool Receive(int errorCode, string errorMsg, TBaseAreaListResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }
        if (rsp.SelfArea != null)
        {
            _ = DataManager.BigWorld.GetAddPlayerAreaData(rsp.SelfArea);
        }
        if (rsp.SystemArea != null && rsp.SystemArea.Count > 0)
        {
            DataManager.BigWorld.InitSystemAreaData(rsp.SystemArea);
        }
        return true;
    }
}
