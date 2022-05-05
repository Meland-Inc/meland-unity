using GameFramework.Network;

/// <summary>
/// 网络消息处理器
/// </summary>
public interface INetMsgAction
{
    string ChannelName { get; }
    Packet GetReqPacket();
    void Receive(Packet rsp);
}