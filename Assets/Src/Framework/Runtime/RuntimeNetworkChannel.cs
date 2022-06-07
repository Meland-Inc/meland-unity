/*
 * @Author: xiang huan
 * @Date: 2022-05-28 10:09:05
 * @LastEditTime: 2022-06-06 20:04:11
 * @LastEditors: xiang huan
 * @Description: runtime通讯
 * @FilePath: /meland-unity/Assets/Src/Framework/Runtime/RuntimeNetworkChannel.cs
 * 
 */
using System;
using GameFramework;
using GameFramework.Network;
using UnityEngine;
using System.Net.Sockets;
using System.Net;

public class RuntimeNetworkChannel : INetworkChannel
{
    private readonly INetworkChannelHelper _networkChannelHelper;
    private readonly EventPool<Packet> _receivePacketPool;
    public string Name { get; }

    public string LocalAddress => "local";

    public string RemoteAddress => "remote";

    public bool Connected => false;

    public ServiceType ServiceType => ServiceType.Runtime;
    public GameFramework.Network.AddressFamily AddressFamily => GameFramework.Network.AddressFamily.Unknown;

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

    public RuntimeNetworkChannel(string name, INetworkChannelHelper helper)
    {
        Name = name;
        _networkChannelHelper = helper;
        _receivePacketPool = new EventPool<Packet>(EventPoolMode.Default);
        SentPacketCount = 0;
        ReceivedPacketCount = 0;

        Message.RuntimeMessageEmitted += OnMessageEmitted;
        _networkChannelHelper.Initialize(this);
    }

    public void Send<T>(T packet) where T : Packet
    {
        try
        {
            RuntimeMessage message = (packet as RuntimePacket).TransferData;
            string messageJson = JsonUtility.ToJson(message);
            BasicModule.RuntimeGameCenter.SendMsg(messageJson);
            SentPacketCount++;
        }
        catch (Exception)
        {
            MLog.Error(eLogTag.runtime, $"RuntimeNetworkChannel Send Error: {packet.Id}");
            throw;
        }
    }

    private void OnMessageEmitted(string msg)
    {
        try
        {
            RuntimeMessage message = JsonUtility.FromJson<RuntimeMessage>(msg);
            RuntimePacket packet = new();
            packet.SetTransferData(message);
            packet.DataJson = msg;
            if (packet != null)
            {
                _receivePacketPool.Fire(this, packet);
            }
            ReceivedPacketCount++;
        }
        catch (Exception)
        {
            MLog.Error(eLogTag.runtime, $"OnMessageEmitted  Error");
            throw;
        }

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
        throw new GameFrameworkException("RuntimeNetworkChannel can not connect.");
    }

    public void Connect(IPAddress ipAddress, int port, object userData)
    {
        throw new GameFrameworkException("RuntimeNetworkChannel can not connect.");
    }

    public void Connect(string ipAddress)
    {
        throw new GameFrameworkException("RuntimeNetworkChannel can not connect.");
    }

    public void Connect(string targetAddress, object userData)
    {
        throw new GameFrameworkException("RuntimeNetworkChannel can not connect.");
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
