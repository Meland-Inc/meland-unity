
using Bian;

public class TBigWorldTileAction : GameChannelNetMsgTActionBase<TBigWorldTileResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TbigWorldTile;
    }

    protected override bool Receive(int errorCode, string errorMsg, TBigWorldTileResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }
        BigWorldUtil.HandleAddRemoveBigWorldGrid(rsp.AddTilePros, rsp.PressTileRcIndexList);
        return true;
    }
}
