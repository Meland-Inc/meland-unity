
using Bian;

public class TBigWorldTileUpdateAction : GameChannelNetMsgTActionBase<TBigWorldTileUpdateResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TbigWorldTileUpdate;
    }

    protected override bool Receive(int errorCode, string errorMsg, TBigWorldTileUpdateResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }
        DataManager.BigWorld.UpdateGridData(rsp.TilePro);
        return true;
    }
}
