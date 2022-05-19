using System.Security.Cryptography.X509Certificates;
using System.Net.Http;
using System.Collections.Generic;
using GameFramework.Network;
public class HttpChannelRspPacket : Packet
{
    public override int Id => _id;
    private int _id;
    public int code;
    public string message;
    public object data;

    public void SetID(int id)
    {
        _id = id;
    }
    public override void Clear()
    {

    }
}