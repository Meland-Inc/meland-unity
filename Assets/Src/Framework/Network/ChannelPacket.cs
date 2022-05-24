using GameFramework.Network;
/// <summary>
/// 渠道包
/// </summary>
/// <typeparam name="T">具体渠道的消息类型 例如Bian.Envelope</typeparam>
public abstract class ChannelPacket<T> : Packet where T : class
{
    public T TransferData;
    // public override int Id => (int)Envelope.Type;
    public void SetTransferData(T data)
    {
        TransferData = data;
    }

    public override void Clear()
    {
        //to do
    }

    public abstract void SetTransferDataSeqId(int id);
    public abstract int GetTransferDataSeqId();
}