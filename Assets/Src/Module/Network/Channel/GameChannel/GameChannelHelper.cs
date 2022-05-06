using System;
using System.Text;
using System.IO;
using GameFramework.Network;
using UnityGameFramework.Runtime;

public class GameChannelHelper : SocketProtobufChannelHelper
{
    public override int PacketHeaderLength => 4;

    public override Packet DeserializePacket(IPacketHeader packetHeader, Stream source, out object customErrorData)
    {
        //FIXME: 临时测试
        byte[] data = new byte[1024 * 4];
        Span<byte> dataSpan = new(data, 0, (int)source.Length);
        _ = source.Read(dataSpan);
        string str = Encoding.ASCII.GetString(dataSpan);

        customErrorData = null;

        GameChannelPacketBase packet = new();
        packet.SetID(1);
        packet.Info = str;
        return packet;
    }

    public override IPacketHeader DeserializePacketHeader(Stream source, out object customErrorData)
    {
        //FIXME: 临时测试
        byte[] data = new byte[4];
        _ = source.Read(data, 0, 4);
        int length = BitConverter.ToInt32(data, 0);

        customErrorData = null;

        GameChannelPacketHeader head = new()
        {
            ByteLength = length
        };
        return head;
    }

    public override void Initialize(INetworkChannel networkChannel)
    {
        Log.Debug("GameSocketChannelHelper.Initialize");
    }

    public override void PrepareForConnecting()
    {
        Log.Debug("GameSocketChannelHelper.PrepareForConnecting");
    }

    public override bool SendHeartBeat()
    {
        Log.Debug("GameSocketChannelHelper.SendHeartBeat");
        return true;
    }

    public override bool Serialize<T>(T packet, Stream destination)
    {
        throw new NotImplementedException();
    }

    public override void Shutdown()
    {
        throw new NotImplementedException();
    }
}