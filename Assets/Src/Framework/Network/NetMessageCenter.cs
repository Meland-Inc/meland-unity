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

        EventComponent eventCom = GameEntry.GetComponent<EventComponent>();
        eventCom.Subscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
        eventCom.Subscribe(UnityGameFramework.Runtime.NetworkClosedEventArgs.EventId, OnNetworkClosed);
        eventCom.Subscribe(UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs.EventId, OnNetworkMissHeartBeat);
        eventCom.Subscribe(UnityGameFramework.Runtime.NetworkErrorEventArgs.EventId, OnNetworkError);
        eventCom.Subscribe(UnityGameFramework.Runtime.NetworkCustomErrorEventArgs.EventId, OnNetworkCustomError);
    }

    private void OnDestroy()
    {
        EventComponent eventCom = GameEntry.GetComponent<EventComponent>();
        eventCom.Unsubscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
        eventCom.Unsubscribe(UnityGameFramework.Runtime.NetworkClosedEventArgs.EventId, OnNetworkClosed);
        eventCom.Unsubscribe(UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs.EventId, OnNetworkMissHeartBeat);
        eventCom.Unsubscribe(UnityGameFramework.Runtime.NetworkErrorEventArgs.EventId, OnNetworkError);
        eventCom.Unsubscribe(UnityGameFramework.Runtime.NetworkCustomErrorEventArgs.EventId, OnNetworkCustomError);
    }

    public void SendMsg(INetMsgAction action)
    {
        ExecuteSend(action);
    }

    private void ExecuteSend(INetMsgAction action)
    {
        if (!_channelMap.ContainsKey(action.ChannelName))
        {
            MLog.Error(eLogTag.network, $"ExecuteSend channelName not found = {action.ChannelName}");
            return;
        }

        INetworkChannel channel = _channelMap[action.ChannelName];

        action.InitSeqId(GetIncrementalSeqId(action.ChannelName));
        // 注册监听
        channel.RegisterHandler(action);
        channel.Send(action.GetReqPacket());
    }

    public void ConnectChannel(string channelName, string ip, int port)
    {
        if (!_channelMap.ContainsKey(channelName))
        {
            MLog.Fatal(eLogTag.network, $"ConnectChannel channelName not found = {channelName}");
            return;
        }

        MLog.Info(eLogTag.network, $"ConnectChannel channelName = {channelName} ip = {ip} port = {port}");
        INetworkChannel channel = _channelMap[channelName];
#if UNITY_WEBGL
        channel.Connect(ip);
#else
        channel.Connect(System.Net.IPAddress.Parse(ip), port);
#endif
    }

    public void CloseChannel(string channelName)
    {
        if (!_channelMap.ContainsKey(channelName))
        {
            MLog.Fatal(eLogTag.network, $"CloseChannel channelName not found = {channelName}");
            return;
        }

        MLog.Info(eLogTag.network, $"CloseChannel channelName = {channelName}");
        INetworkChannel channel = _channelMap[channelName];
        channel.Close();
    }

    private void InitChannel()
    {
        _channelMap = new();
        _channelSeqIdMap = new();
        NetworkComponent network = GameEntry.GetComponent<NetworkComponent>();
#if UNITY_WEBGL
        INetworkChannel channel = new WebsocketNetworkChannel(NetworkDefine.CHANNEL_NAME_GAME, new GameChannelHelper());
        network.AddNetworkChannel(channel);
#else
        Log.Info("init socket io");
        INetworkChannel channel = network.CreateNetworkChannel(NetworkDefine.CHANNEL_NAME_GAME, ServiceType.Tcp, new GameChannelHelper());
#endif
        INetworkChannel httpChannel = new WebHttpNetworkChannel(NetworkDefine.CHANEL_NAME_HTTP, new HttpChannelHelper());
        network.AddNetworkChannel(httpChannel);
        _channelMap.Add(NetworkDefine.CHANNEL_NAME_GAME, channel);
        _channelMap.Add(NetworkDefine.CHANEL_NAME_HTTP, httpChannel);
        channel.HeartBeatInterval = NetworkDefine.CHANEL_HEART_BRAT_INTERVAL; // 心跳间隔
    }

    private void OnNetworkConnected(object sender, GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkConnectedEventArgs args = e as UnityGameFramework.Runtime.NetworkConnectedEventArgs;
        MLog.Info(eLogTag.network, $"OnNetworkConnected: {args.NetworkChannel.Name}");

        // test
        // RemoveMarkFromMinimapAction.Req("1", "2");
        // RemoveMarkFromMinimapAction.Req("1", "2");
    }

    private void OnNetworkClosed(object sender, GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkClosedEventArgs args = e as UnityGameFramework.Runtime.NetworkClosedEventArgs;
        MLog.Info(eLogTag.network, $"OnNetworkClosed: {args.NetworkChannel.Name}");
    }

    private void OnNetworkMissHeartBeat(object sender, GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs args = (UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs)e;

        MLog.Info(eLogTag.network, $"Network channel '{args.NetworkChannel.Name}' miss heart beat '{args.MissCount}' times.");

        if (args.MissCount < 2)
        {
            return;
        }

        args.NetworkChannel.Close();
    }

    private void OnNetworkError(object sender, GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkErrorEventArgs args = (UnityGameFramework.Runtime.NetworkErrorEventArgs)e;
        MLog.Warning(eLogTag.network, $"Network channel '{args.NetworkChannel.Name}' error, error code is '{args.ErrorCode}', error message is '{args.ErrorMessage}'.");

        args.NetworkChannel.Close();
    }

    private void OnNetworkCustomError(object sender, GameEventArgs e)
    {
        UnityGameFramework.Runtime.NetworkCustomErrorEventArgs args = (UnityGameFramework.Runtime.NetworkCustomErrorEventArgs)e;
        MLog.Warning(eLogTag.network, $"Network channel '{args.NetworkChannel.Name}' error, error data= '{args.CustomErrorData}'");
    }

    /// <summary>
    /// 根据渠道获取发送消息的递增序列号
    /// </summary>
    /// <param name="channelName"></param>
    /// <returns></returns>
    private int GetIncrementalSeqId(string channelName)
    {
        if (_channelSeqIdMap.TryGetValue(channelName, out int seqId))
        {
            seqId++;
        }
        else
        {
            seqId = NetworkDefine.CHANEL_MIN_SEQ_ID;
            _channelSeqIdMap.Add(channelName, seqId);
        }
        _channelSeqIdMap[channelName] = seqId;

        return seqId;
    }
}
