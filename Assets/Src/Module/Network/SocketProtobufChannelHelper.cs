using System;
using System.IO;
using GameFramework.Network;
using Google.Protobuf;
using UnityGameFramework.Runtime;

/// <summary>
/// 走socket io下protobuf解析的频道
/// </summary>
public abstract class SocketProtobufChannelHelper<TEnvelope> : INetworkChannelHelper
{
    public abstract int PacketHeaderLength { get; }
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
        Log.Info($"DeserializePacket envelope: {envelope}");

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

    public abstract void PrepareForConnecting();

    public virtual bool SendHeartBeat()
    {
        Log.Debug("GameSocketChannelHelper.SendHeartBeat");
        return false;
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
        for (int i = 0; i < 4; i++)
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

    public abstract void Shutdown();
}