using System;
using GameFramework.Network;
using Google.Protobuf;
using UnityGameFramework.Runtime;

#if !UNITY_WEBGL
using System.IO;
#endif

/// <summary>
/// 走socket io下protobuf解析的频道
/// </summary>
#if UNITY_WEBGL
public abstract class SocketProtobufChannelHelper<TEnvelope> : INetworkChannelByteHelper
#else
public abstract class SocketProtobufChannelHelper<TEnvelope> : INetworkChannelStreamHelper
# endif
{
    public abstract int PacketHeaderLength { get; }

#if UNITY_WEBGL
    public virtual void Initialize(INetworkChannel networkChannel)
    {
        //
    }

    public virtual Packet DeserializePacket(IPacketHeader packetHeader, byte[] source, out object customErrorData)
    {
        Bian.Envelope envelope = Bian.Envelope.Parser.ParseFrom(source);

        customErrorData = null;
        GameChannelPacket packet = new();
        packet.SetTransferData(envelope);
        return packet;
    }

    public virtual IPacketHeader DeserializePacketHeader(byte[] source, out object customErrorData)
    {
        int length = BitConverter.ToInt32(source, 0);

        customErrorData = null;

        GameChannelPacketHeader head = new()
        {
            ByteLength = length
        };
        return head;
    }

    public virtual bool Serialize<T>(T packet, out byte[] destination) where T : Packet
    {
        Bian.Envelope envelope = (packet as GameChannelPacket).TransferData;
        int envelopLength = envelope.CalculateSize();
        byte[] headerBytes = BitConverter.GetBytes(envelopLength);
        if (PacketHeaderLength < 0 || (PacketHeaderLength > 0 && headerBytes.Length != PacketHeaderLength))
        {
            Log.Fatal($"protobuf Serialize head size error,cur={headerBytes.Length} expected={PacketHeaderLength}");
            destination = null;
            return false;
        }

        destination = new byte[PacketHeaderLength + envelopLength];
        Span<byte> envelopBytes = new(destination, PacketHeaderLength, destination.Length - PacketHeaderLength);
        envelope.WriteTo(envelopBytes);

        //需要写入头
        if (PacketHeaderLength > 0)
        {
            for (int i = 0; i < PacketHeaderLength; i++)
            {
                destination[i] = headerBytes[i];
            }
        }

        return true;
    }
#else
    private byte[] _packetBytes;        // 缓存包内容信息
    private byte[] _packetHeaderBytes;  // 缓存包头信息

    public virtual void Initialize(INetworkChannel networkChannel)
    {
        _packetBytes = new byte[1024 * 4];
        _packetHeaderBytes = new byte[PacketHeaderLength];
    }

    public virtual Packet DeserializePacket(IPacketHeader packetHeader, Stream source, out object customErrorData)
    {
        Span<byte> dataSpan = new(_packetBytes, 0, (int)source.Length);
        _ = source.Read(dataSpan);

        Bian.Envelope envelope = Bian.Envelope.Parser.ParseFrom(dataSpan);

        customErrorData = null;
        GameChannelPacket packet = new();
        packet.SetTransferData(envelope);
        return packet;
    }

    public virtual IPacketHeader DeserializePacketHeader(Stream source, out object customErrorData)
    {
        _ = source.Read(_packetHeaderBytes, 0, PacketHeaderLength);
        int length = BitConverter.ToInt32(_packetHeaderBytes, 0);

        customErrorData = null;

        GameChannelPacketHeader head = new()
        {
            ByteLength = length
        };
        return head;
    }

    public virtual bool Serialize<T>(T packet, Stream destination) where T : Packet
    {
        Bian.Envelope envelope = (packet as GameChannelPacket).TransferData;
        byte[] envelopeBytes = new byte[envelope.CalculateSize()];
        CodedOutputStream codedOutputStream = new(envelopeBytes);
        envelope.WriteTo(codedOutputStream);

        int register = envelopeBytes.Length;
        byte[] headerBytes = BitConverter.GetBytes(register);

        // 写入协议内容长度
        for (int i = 0; i < PacketHeaderLength; i++)
        {
            destination.WriteByte(headerBytes[i]);
        }

        // 写入协议内容
        for (int i = 0; i < envelopeBytes.Length; i++)
        {
            destination.WriteByte(envelopeBytes[i]);
        }

        return true;
    }
#endif

    public abstract void PrepareForConnecting();

    public virtual bool SendHeartBeat()
    {
        Log.Debug("GameSocketChannelHelper.SendHeartBeat");
        return false;
    }

    public abstract void Shutdown();
}