public class GameChannelPacket : ChannelPacket<Bian.Envelope>
{
    // 此值与handler id 需要一致，接收到响应的时候，用来匹配对应的handler处理
    // 而Handler有两种，一种是请求式R-Action,一种是通知式T-Action
    // 没有SeqId的包，属于通知式action的Packet
    // TransferData.Type    范围 min ~ -1
    // GetTransferDataSeqId 范围 1 ~ Max
    public override int Id => TransferData.SeqId == 0 ? -(int)TransferData.Type : GetTransferDataSeqId();

    public override int GetTransferDataSeqId()
    {
        return TransferData.SeqId;
    }

    public override void SetTransferDataSeqId(int id)
    {
        TransferData.SeqId = id;
    }
}