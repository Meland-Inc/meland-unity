using System.Net.Http;
using System.Collections.Generic;
using GameFramework.Network;
using UnityEngine;

public class HttpChannelReqPacket : Packet
{
    public string Url;
    public HttpMethod Method;
    public KeyValuePair<string, string>[] Params;
    public WWWForm FormData;
    public KeyValuePair<string, string>[] Headers;
    public string StrData;
    public override int Id => Url.GetHashCode();
    public override void Clear()
    {

    }
}