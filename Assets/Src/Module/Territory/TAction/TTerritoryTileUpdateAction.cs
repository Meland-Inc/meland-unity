
using MelandGame3;

public class TTerritoryTileUpdateAction : GameChannelNetMsgTActionBase<TBigWorldTileUpdateResponse>
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
        DataManager.Territory.UpdateGridData(rsp.TilePro);
        return true;
    }
}
