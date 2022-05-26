using System.Security.Cryptography.X509Certificates;
using System.Net.Http;
using System.Collections.Generic;
using GameFramework.Network;
public class HttpChannelReqPacket : Packet
{
    public string Url;
    public HttpMethod Method;
    public KeyValuePair<string, string>[] Params;
    public KeyValuePair<string, string>[] FormData;
    public KeyValuePair<string, string>[] Headers;
    public string DataStr;
    public override int Id => Url.GetHashCode();
    public override void Clear()
    {

    }
}