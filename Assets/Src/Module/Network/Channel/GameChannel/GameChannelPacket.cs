public class GameChannelPacket : ChannelPacket<Bian.Envelope>
{
    public override int Id => (int)TransferData.Type;
    public override void SetTransferDataSeqId(int id)
    {
        TransferData.SeqId = id;
    }
}