using System.Security.Cryptography.X509Certificates;
using System.Net.Http;
using System.Collections.Generic;
using GameFramework.Network;
[System.Serializable]
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