using GameFramework.Network;

/// <summary>
/// 网络消息处理器
/// </summary>
public interface INetMsgAction : IPacketHandler
{
    /// <summary>
    /// 频道名
    /// </summary>
    /// <value></value>
    string ChannelName { get; }
    /// <summary>
    /// 名字 往往用来打印等debug时使用 用来区分协议号
    /// </summary>
    /// <value></value>
    string Name { get; }
    abstract Packet GetReqPacket();
    abstract void InitSeqId(int id);
}