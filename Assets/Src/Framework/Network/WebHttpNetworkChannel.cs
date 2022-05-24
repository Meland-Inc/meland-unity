using System.Net.Http;
using System;
using System.Net;
using System.Net.Sockets;
using GameFramework;
using GameFramework.Network;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;
using UnityEngine;
using System.Collections.Generic;

public class WebHttpNetworkChannel : INetworkChannel
{
    private readonly INetworkChannelHelper _networkChannelHelper;
    private readonly EventPool<Packet> _receivePacketPool;
    public string Name { get; }

    public string LocalAddress => "local";

    public string RemoteAddress => "remote";

    public bool Connected => false;

    public ServiceType ServiceType => ServiceType.Http;
    public GameFramework.Network.AddressFamily AddressFamily => GameFramework.Network.AddressFamily.IPv4;

    public int SendPacketCount => 0;

    public int SentPacketCount { get; private set; }

    public int ReceivePacketCount => 0;

    public int ReceivedPacketCount { get; private set; }

    public bool ResetHeartBeatElapseSecondsWhenReceivePacket { get => false; set => _ = value; }

    public int MissHeartBeatCount => 0;

    public float HeartBeatInterval { get; set; }

    public float HeartBeatElapseSeconds { get; private set; }

    public GameFrameworkAction<INetworkChannel, object> NetworkChannelConnected { get; set; }
    public GameFrameworkAction<INetworkChannel> NetworkChannelClosed { get; set; }
    public GameFrameworkAction<INetworkChannel, int> NetworkChannelMissHeartBeat { get; set; }
    public GameFrameworkAction<INetworkChannel, NetworkErrorCode, SocketError, string> NetworkChannelError { get; set; }
    public GameFrameworkAction<INetworkChannel, object> NetworkChannelCustomError { get; set; }
    public WebHttpNetworkChannel(string name, INetworkChannelHelper helper)
    {
        Name = name;
        _networkChannelHelper = helper;
        _receivePacketPool = new EventPool<Packet>(EventPoolMode.Default);
    }

    public void RegisterHandler(IPacketHandler handler)
    {
        if (handler == null)
        {
            throw new GameFrameworkException("RegisterHandler Packet handler is invalid.");
        }

        _receivePacketPool.Subscribe(handler.Id, handler.Handle);
    }

    public void UnRegisterHandler(IPacketHandler handler)
    {
        if (handler == null)
        {
            throw new GameFrameworkException("UnRegisterHandler Packet handler is invalid.");
        }

        _receivePacketPool.Unsubscribe(handler.Id, handler.Handle);
    }

    public void Send<T>(T packet) where T : Packet
    {
        _ = RealSend(packet as HttpChannelReqPacket);
    }

    private async UniTask RealSend(HttpChannelReqPacket packet)
    {
        if (packet == null)
        {
            Debug.LogError("type of packet is not HttpChannelReqPacket");
            return;
        }

        UnityWebRequest www = GetWWW(packet);

        if (packet.Headers != null)
        {
            foreach (KeyValuePair<string, string> item in packet.Headers)
            {
                www.SetRequestHeader(item.Key, item.Value);
            }
        }
        try
        {
            _ = await www.SendWebRequest();
            HandleResponse(www);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    private void HandleResponse(UnityWebRequest www)
    {
        switch (www.result)
        {
            case UnityWebRequest.Result.ConnectionError:
                break;
            case UnityWebRequest.Result.DataProcessingError:
                break;
            case UnityWebRequest.Result.ProtocolError:
                break;
            case UnityWebRequest.Result.Success:
                OnResponse(www);
                break;
            case UnityWebRequest.Result.InProgress:
                break;
            default:
                break;
        }
    }

    private void OnResponse(UnityWebRequest www)
    {
        HttpChannelRspPacket packet = new()
        {
            TextData = www.downloadHandler.text,
            Url = www.url
        };
        _receivePacketPool.Fire(this, packet);
    }

    private UnityWebRequest GetWWW(HttpChannelReqPacket packet)
    {
        if (packet.Method == HttpMethod.Get)
        {
            return RequestGet(packet);
        }
        else if (packet.Method == HttpMethod.Post)
        {
            return RequestPost(packet);
        }
        else if (packet.Method == HttpMethod.Put)
        {
            return RequestPut(packet);
        }
        else if (packet.Method == HttpMethod.Delete)
        {
            return RequestDelete(packet);
        }
        else
        {
            throw new GameFrameworkException("HttpMethod is not supported.");
        }
    }

    private UnityWebRequest RequestGet(HttpChannelReqPacket packet)
    {
        string url = packet.Url;
        if (packet.Params != null)
        {
            url += "?";
            foreach (KeyValuePair<string, string> item in packet.Params)
            {
                url += item.Key + "=" + item.Value + "&";
            }
        }
        UnityWebRequest www = UnityWebRequest.Get(url);
        return www;
    }

    private UnityWebRequest RequestPost(HttpChannelReqPacket packet)
    {
        WWWForm form = new();
        if (packet.FormData != null)
        {
            foreach (KeyValuePair<string, string> item in packet.FormData)
            {
                form.AddField(item.Key, item.Value);
            }
        }
        return UnityWebRequest.Post(packet.Url, form);
    }

    private UnityWebRequest RequestPut(HttpChannelReqPacket packet)
    {
        UnityWebRequest www = UnityWebRequest.Put(packet.Url, packet.DataStr);
        return www;
    }

    private UnityWebRequest RequestDelete(HttpChannelReqPacket packet)
    {
        UnityWebRequest www = UnityWebRequest.Delete(packet.Url);
        return www;
    }

    public void SetDefaultHandler(EventHandler<Packet> handler)
    {
        _receivePacketPool.SetDefaultHandler(handler);
    }

    public void Close()
    {
        SentPacketCount = 0;
        ReceivedPacketCount = 0;
        _receivePacketPool.Clear();
    }

    public void Connect(IPAddress ipAddress, int port)
    {
        throw new GameFrameworkException("HttpChannel can not connect.");
    }

    public void Connect(IPAddress ipAddress, int port, object userData)
    {
        throw new GameFrameworkException("HttpChannel can not connect.");
    }

    public void Connect(string ipAddress)
    {
        throw new GameFrameworkException("HttpChannel can not connect.");
    }

    public void Connect(string targetAddress, object userData)
    {
        throw new GameFrameworkException("HttpChannel can not connect.");
    }

    public void Shutdown()
    {
        Close();
        _receivePacketPool.Shutdown();
        _networkChannelHelper.Shutdown();
    }

    public void Update(float elapseSeconds, float realElapseSeconds)
    {
        _receivePacketPool.Update(elapseSeconds, realElapseSeconds);
    }
}
