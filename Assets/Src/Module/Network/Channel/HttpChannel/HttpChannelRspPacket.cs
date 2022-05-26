using GameFramework.Network;
public class HttpChannelRspPacket : Packet
{
    public string Url;
    public override int Id => Url.GetHashCode();
    public string TextData;
    public byte[] BytesData;
    public override void Clear()
    {

    }
}