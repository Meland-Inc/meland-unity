using GameFramework.Network;

public class GameChannelPacketHeader : IPacketHeader
{
    public int ByteLength;
    public int PacketLength => ByteLength;
}