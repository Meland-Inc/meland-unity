using GameFramework.Network;

/// <summary>
/// 网络消息处理器
/// </summary>
public interface INetMsgAction : IPacketHandler
{
    string ChannelName { get; }
    abstract Packet GetReqPacket();
    abstract void InitSeqId(int id);
}