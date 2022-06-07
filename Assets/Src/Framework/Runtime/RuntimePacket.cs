/*
 * @Author: xiang huan
 * @Date: 2022-05-28 11:51:43
 * @LastEditTime: 2022-06-06 17:21:27
 * @LastEditors: xiang huan
 * @Description: runtime通讯包
 * @FilePath: /meland-unity/Assets/Src/Framework/Runtime/RuntimePacket.cs
 * 
 */
public class RuntimePacket : ChannelPacket<RuntimeMessage>
{
    // 此值与handler id 需要一致，接收到响应的时候，用来匹配对应的handler处理
    // 而Handler有两种，一种是请求式R-Action,一种是通知式T-Action
    // 没有SeqId的包，属于通知式action的Packet
    // TransferData.Type    范围 min ~ -1
    // GetTransferDataSeqId 范围 1 ~ Max
    public override int Id => TransferData.SeqId == 0 ? -TransferData.Type : GetTransferDataSeqId();
    public string DataJson;

    public override int GetTransferDataSeqId()
    {
        return TransferData.SeqId;
    }

    public override void SetTransferDataSeqId(int id)
    {
        TransferData.SeqId = id;
    }

    public void SetTransferDataType(int type)
    {
        TransferData.Type = type;
    }
}