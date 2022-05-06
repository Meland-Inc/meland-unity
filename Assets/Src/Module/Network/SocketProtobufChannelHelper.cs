using System.IO;
using GameFramework.Network;

/// <summary>
/// 走socket io下protobuf解析的频道
/// </summary>
public abstract class SocketProtobufChannelHelper : INetworkChannelHelper
{
    public abstract int PacketHeaderLength { get; }

    public virtual Packet DeserializePacket(IPacketHeader packetHeader, Stream source, out object customErrorData)
    {
        throw new System.NotImplementedException();
    }

    public virtual IPacketHeader DeserializePacketHeader(Stream source, out object customErrorData)
    {
        throw new System.NotImplementedException();
    }

    public abstract void Initialize(INetworkChannel networkChannel);

    public abstract void PrepareForConnecting();

    public abstract bool SendHeartBeat();

    public virtual bool Serialize<T>(T packet, Stream destination) where T : Packet
    {
        throw new System.NotImplementedException();
    }

    public abstract void Shutdown();
}