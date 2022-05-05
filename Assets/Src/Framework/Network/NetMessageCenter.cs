using System;
using System.Collections.Generic;
using GameFramework.Event;
using GameFramework.Network;
using UnityGameFramework.Runtime;

/// <summary>
/// 网络消息中心 业务层都使用本模块派发消息
/// </summary>
public class NetMessageCenter : GameFrameworkComponent
{
    private Dictionary<string, INetworkChannel> _channelMap;

    private void Start()
    {
        InitChannel();

        GFEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
        GFEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkClosedEventArgs.EventId, OnNetworkClosed);
        GFEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs.EventId, OnNetworkMissHeartBeat);
        GFEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkErrorEventArgs.EventId, OnNetworkError);
        GFEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkCustomErrorEventArgs.EventId, OnNetworkCustomError);
    }

    private void OnNetworkCustomError(object sender, GameEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void OnDestroy()
    {

        GFEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
        GFEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkClosedEventArgs.EventId, OnNetworkClosed);
        GFEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs.EventId, OnNetworkMissHeartBeat);
        GFEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkErrorEventArgs.EventId, OnNetworkError);
        GFEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkCustomErrorEventArgs.EventId, OnNetworkCustomError);
    }

    public void SendMsg(INetMsgAction handler)
    {
        ExecuteSend(handler);
    }

    private void ExecuteSend(INetMsgAction handler)
    {
        if (!_channelMap.ContainsKey(handler.ChannelName))
        {
            Log.Error($"ExecuteSend channelName not found = {handler.ChannelName}");
            return;
        }

        INetworkChannel channel = _channelMap[handler.ChannelName];
        channel.Send(handler.GetReqPacket());
    }

    public void ConnectChannel(string channelName, string ip, int port)
    {
        if (!_channelMap.ContainsKey(channelName))
        {
            Log.Fatal($"ConnectChannel channelName not found = {channelName}");
            return;
        }

        Log.Info($"ConnectChannel channelName = {channelName} ip = {ip} port = {port}");
        INetworkChannel channel = _channelMap[channelName];
        channel.Connect(System.Net.IPAddress.Parse(ip), port);
    }

    public void CloseChannel(string channelName)
    {
        if (!_channelMap.ContainsKey(channelName))
        {
            Log.Fatal($"CloseChannel channelName not found = {channelName}");
            return;
        }

        Log.Info($"CloseChannel channelName = {channelName}");
        INetworkChannel channel = _channelMap[channelName];
        channel.Close();
    }

    private void InitChannel()
    {
        _channelMap = new();

        INetworkChannel channel = GFEntry.Network.CreateNetworkChannel(NetworkDefine.CHANNEL_NAME_GAME, ServiceType.Tcp, new GameChannelHelper());
        _channelMap.Add(NetworkDefine.CHANNEL_NAME_GAME, channel);
    }

    private void OnNetworkConnected(object sender, GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkConnectedEventArgs args = e as UnityGameFramework.Runtime.NetworkConnectedEventArgs;
        Log.Info($"OnNetworkConnected: {args.NetworkChannel.Name}");
    }

    private void OnNetworkClosed(object sender, GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkClosedEventArgs arg = e as UnityGameFramework.Runtime.NetworkClosedEventArgs;
        Log.Info($"OnNetworkClosed: {arg.NetworkChannel.Name}");
    }

    private void OnNetworkMissHeartBeat(object sender, GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs ne = (UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs)e;

        Log.Info($"Network channel '{ne.NetworkChannel.Name}' miss heart beat '{ne.MissCount}' times.");

        if (ne.MissCount < 2)
        {
            return;
        }

        ne.NetworkChannel.Close();
    }

    private void OnNetworkError(object sender, GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkErrorEventArgs args = (UnityGameFramework.Runtime.NetworkErrorEventArgs)e;
        Log.Warning("Network channel '{0}' error, error code is '{1}', error message is '{2}'.", args.NetworkChannel.Name, args.ErrorCode.ToString(), args.ErrorMessage);

        args.NetworkChannel.Close();
    }
}
