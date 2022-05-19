using System;
using System.Net;
using System.Net.Sockets;
using GameFramework;
using GameFramework.Network;
using UnityWebSocket;
using UnityGameFramework.Runtime;
public class WebsocketNetworkChannel : INetworkChannel
{
    private const float DEFAULT_HEART_BEAT_INTERVAL = 30f;
    private readonly EventPool<Packet> _receivePacketPool;
    private readonly INetworkChannelByteHelper _networkChannelHelper;
    private IWebSocket _socket;
    private object _userData;

    public string Name { get; }

    public string LocalAddress => "None";

    public string RemoteAddress => _socket != null ? _socket.Address : "None";

    public bool Connected => _socket != null && _socket.ReadyState == WebSocketState.Open;

    public ServiceType ServiceType => ServiceType.Websocket;

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


    public WebsocketNetworkChannel(string name, INetworkChannelByteHelper networkChannelHelper)
    {
        Name = name ?? string.Empty;
        _receivePacketPool = new EventPool<Packet>(EventPoolMode.Default);
        _networkChannelHelper = networkChannelHelper;
        HeartBeatInterval = DEFAULT_HEART_BEAT_INTERVAL;
        SentPacketCount = 0;
        ReceivedPacketCount = 0;
        HeartBeatElapseSeconds = 0f;

        NetworkChannelConnected = null;
        NetworkChannelClosed = null;
        NetworkChannelMissHeartBeat = null;
        NetworkChannelError = null;
        NetworkChannelCustomError = null;

        if (networkChannelHelper.PacketHeaderLength > 0)
        {
            Log.Error($"websocket packet header is invalid,channel={Name},header length={networkChannelHelper.PacketHeaderLength}");
        }

        networkChannelHelper.Initialize(this);
    }

    public void Connect(IPAddress ipAddress, int port)
    {
        Connect(ipAddress, port, null);
    }

    public void Connect(IPAddress ipAddress, int port, object userData)
    {
        if (_socket != null)
        {
            Close();
            _socket = null;
        }

        try
        {
            _userData = userData;
            string url = $"{ipAddress}:{port}{userData ?? ""}";
            url = UrlUtil.GetWebsocketFullUrl(url);
            Log.Info($"web socket channel connect={url},channel={Name}");
            _socket = new WebSocket(url);
        }
        catch (Exception)
        {
            NetworkChannelError?.Invoke(this, NetworkErrorCode.ConnectError, SocketError.Success, $"init socket fail,channel={Name}");
            throw;
        }

        _socket.OnOpen += OnSocketOpen;
        _socket.OnMessage += OnSocketMessage;
        _socket.OnClose += OnSocketClose;
        _socket.OnError += OnSocketError;

        _networkChannelHelper.PrepareForConnecting();

        _socket.ConnectAsync();
    }

    public void Close()
    {
        if (_socket != null)
        {
            _socket.OnOpen -= OnSocketOpen;
            _socket.OnMessage -= OnSocketMessage;
            _socket.OnClose -= OnSocketClose;
            _socket.OnError -= OnSocketError;
            _socket.CloseAsync();
            _socket = null;

            NetworkChannelClosed?.Invoke(this);
        }
        SentPacketCount = 0;
        ReceivedPacketCount = 0;
        HeartBeatElapseSeconds = 0f;

        _receivePacketPool.Clear();
    }

    private void OnSocketOpen(object sender, OpenEventArgs e)
    {
        NetworkChannelConnected?.Invoke(this, _userData);
    }

    public void Send<T>(T packet) where T : Packet
    {
        bool serializeResult = false;
        try
        {
            serializeResult = _networkChannelHelper.Serialize(packet, out byte[] destination);
            _socket.SendAsync(destination);
        }
        catch (Exception exception)
        {
            NetworkChannelError?.Invoke(this, NetworkErrorCode.SerializeError, SocketError.Success, exception.ToString());

            throw;
        }

        if (!serializeResult)
        {
            string errorMessage = $"Serialized packet failure.channel={Name}";
            NetworkChannelError?.Invoke(this, NetworkErrorCode.SerializeError, SocketError.Success, errorMessage);

            throw new GameFrameworkException(errorMessage);
        }

        SentPacketCount++;
    }

    private void OnSocketMessage(object sender, MessageEventArgs e)
    {
        try
        {
            Packet packet = _networkChannelHelper.DeserializePacket(null, e.RawData, out object errorData);
            if (errorData != null)
            {
                NetworkChannelCustomError?.Invoke(this, errorData);
            }

            if (packet != null)
            {
                _receivePacketPool.Fire(this, packet);
            }
        }
        catch (Exception exception)
        {
            NetworkChannelError?.Invoke(this, NetworkErrorCode.DeserializePacketError, SocketError.Success, exception.ToString());
            throw;
        }

        ReceivedPacketCount += 1;
    }

    private void OnSocketClose(object sender, CloseEventArgs e)
    {
        string msg = $"websocket close,channel={Name},StatusCode={e.StatusCode},Reason={e.Reason}";
        NetworkChannelError?.Invoke(this, NetworkErrorCode.ConnectError, SocketError.Success, msg);
    }

    private void OnSocketError(object sender, ErrorEventArgs e)
    {
        string msg = $"websocket error,channel={Name},errorMsg={e.Message}";
        NetworkChannelError?.Invoke(this, NetworkErrorCode.ConnectError, SocketError.Success, msg);
    }

    /// <summary>
    /// 网络频道轮询。
    /// </summary>
    /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
    /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
    public virtual void Update(float elapseSeconds, float realElapseSeconds)
    {
        if (!Connected)
        {
            return;
        }

        _receivePacketPool.Update(elapseSeconds, realElapseSeconds);

        HeartBeatElapseSeconds += realElapseSeconds;
        if (HeartBeatElapseSeconds >= HeartBeatInterval)
        {
            HeartBeatElapseSeconds = 0f;
            _ = _networkChannelHelper.SendHeartBeat();
        }
    }

    /// <summary>
    /// 关闭网络频道。
    /// </summary>
    public virtual void Shutdown()
    {
        Close();
        _receivePacketPool.Shutdown();
        _networkChannelHelper.Shutdown();
    }

    /// <summary>
    /// 注册网络消息包处理函数。
    /// </summary>
    /// <param name="handler">要注册的网络消息包处理函数。</param>
    public void RegisterHandler(IPacketHandler handler)
    {
        if (handler == null)
        {
            throw new GameFrameworkException("RegisterHandler Packet handler is invalid.");
        }

        _receivePacketPool.Subscribe(handler.Id, handler.Handle);
    }

    /// <summary>
    /// 反注册网络消息包处理函数。
    /// </summary>
    /// <param name="handler"></param>
    public void UnRegisterHandler(IPacketHandler handler)
    {
        if (handler == null)
        {
            throw new GameFrameworkException("UnRegisterHandler Packet handler is invalid.");
        }

        _receivePacketPool.Unsubscribe(handler.Id, handler.Handle);
    }

    /// <summary>
    /// 设置默认事件处理函数。
    /// </summary>
    /// <param name="handler">要设置的默认事件处理函数。</param>
    public void SetDefaultHandler(EventHandler<Packet> handler)
    {
        _receivePacketPool.SetDefaultHandler(handler);
    }
}
