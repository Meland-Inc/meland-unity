using GameFramework.Network;

/// <summary>
/// 白鹭消息处理器
/// </summary>
public interface IEgretMsgAction : IPacketHandler
{
    abstract Packet GetReqPacket();
    abstract void InitSeqId(int id);
}