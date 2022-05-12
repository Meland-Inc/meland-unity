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
    private Dictionary<string, int> _channelSeqIdMap;

    private void Start()
    {
        InitChannel();

        GFEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
        GFEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkClosedEventArgs.EventId, OnNetworkClosed);
        GFEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs.EventId, OnNetworkMissHeartBeat);
        GFEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkErrorEventArgs.EventId, OnNetworkError);
        GFEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkCustomErrorEventArgs.EventId, OnNetworkCustomError);
    }

    private void OnDestroy()
    {

        GFEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
        GFEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkClosedEventArgs.EventId, OnNetworkClosed);
        GFEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs.EventId, OnNetworkMissHeartBeat);
        GFEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkErrorEventArgs.EventId, OnNetworkError);
        GFEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkCustomErrorEventArgs.EventId, OnNetworkCustomError);
    }

    public void SendMsg(INetMsgAction action)
    {
        ExecuteSend(action);
    }

    private void ExecuteSend(INetMsgAction action)
    {
        if (!_channelMap.ContainsKey(action.ChannelName))
        {
            Log.Error($"ExecuteSend channelName not found = {action.ChannelName}");
            return;
        }

        INetworkChannel channel = _channelMap[action.ChannelName];

        GameChannelPacket packet = action.GetReqPacket() as GameChannelPacket;
        packet.SetTransferDataSeqId(getIncrementalSeqId(action.ChannelName));
        // 注册监听
        channel.RegisterHandler(action);
        channel.Send(packet);
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
        _channelSeqIdMap = new();

        INetworkChannel channel = GFEntry.Network.CreateNetworkChannel(NetworkDefine.CHANNEL_NAME_GAME, ServiceType.Tcp, new GameChannelHelper());
        _channelMap.Add(NetworkDefine.CHANNEL_NAME_GAME, channel);
        channel.HeartBeatInterval = NetworkDefine.CHANEL_HEART_BRAT_INTERVAL; // 心跳间隔
    }

    private void OnNetworkConnected(object sender, GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkConnectedEventArgs args = e as UnityGameFramework.Runtime.NetworkConnectedEventArgs;
        Log.Info($"OnNetworkConnected: {args.NetworkChannel.Name}");

        // test
        // RemoveMarkFromMinimapAction.Req("1", "2");
        // RemoveMarkFromMinimapAction.Req("1", "2");
    }

    private void OnNetworkClosed(object sender, GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkClosedEventArgs args = e as UnityGameFramework.Runtime.NetworkClosedEventArgs;
        Log.Info($"OnNetworkClosed: {args.NetworkChannel.Name}");
    }

    private void OnNetworkMissHeartBeat(object sender, GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs args = (UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs)e;

        Log.Info($"Network channel '{args.NetworkChannel.Name}' miss heart beat '{args.MissCount}' times.");

        if (args.MissCount < 2)
        {
            return;
        }

        args.NetworkChannel.Close();
    }

    private void OnNetworkError(object sender, GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkErrorEventArgs args = (UnityGameFramework.Runtime.NetworkErrorEventArgs)e;
        Log.Warning($"Network channel '{args.NetworkChannel.Name}' error, error code is '{args.ErrorCode}', error message is '{args.ErrorMessage}'.");

        args.NetworkChannel.Close();
    }

    private void OnNetworkCustomError(object sender, GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkCustomErrorEventArgs args = (UnityGameFramework.Runtime.NetworkCustomErrorEventArgs)e;
        Log.Warning($"Network channel '{args.NetworkChannel.Name}' error, error data= '{args.CustomErrorData}'");
    }

    /// <summary>
    /// 根据渠道获取发送消息的递增序列号
    /// </summary>
    /// <param name="channelName"></param>
    /// <returns></returns>
    private int getIncrementalSeqId(string channelName)
    {
        if (_channelSeqIdMap.TryGetValue(channelName, out int seqId))
        {
            seqId++;
        }
        else
        {
            Random rd = new();
            seqId = rd.Next(NetworkDefine.CHANEL_RANDOM_MIN_SEQ_ID, NetworkDefine.CHANEL_RANDOM_MAX_SEQ_ID);
            _channelSeqIdMap.Add(channelName, seqId);
        }
        _channelSeqIdMap[channelName] = seqId;

        return seqId;
    }
}
