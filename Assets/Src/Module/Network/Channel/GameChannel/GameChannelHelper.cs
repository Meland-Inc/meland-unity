using GameFramework.Network;
using UnityGameFramework.Runtime;
public class GameChannelHelper : SocketProtobufChannelHelper<MelandGame3.Envelope>
{
#if UNITY_WEBGL || WEBSOCKET
    public override int PacketHeaderLength => 0;
#else
    public override int PacketHeaderLength => 4;
#endif
    public override void Initialize(INetworkChannel networkChannel)
    {
        base.Initialize(networkChannel);
        Log.Debug("GameSocketChannelHelper.Initialize");

        // 注册通知类action
        networkChannel.RegisterHandler(TRemoveMarkFromMinimapAction.GetAction<TRemoveMarkFromMinimapAction>());
        networkChannel.RegisterHandler(TInitMapElementAction.GetAction<TInitMapElementAction>());
        networkChannel.RegisterHandler(TMapEntityUpdateAction.GetAction<TMapEntityUpdateAction>());

        networkChannel.RegisterHandler(TAddPlayerAreaAction.GetAction<TAddPlayerAreaAction>());
        networkChannel.RegisterHandler(TBaseAreaListAction.GetAction<TBaseAreaListAction>());
        networkChannel.RegisterHandler(TTerritoryTileAction.GetAction<TTerritoryTileAction>());
        networkChannel.RegisterHandler(TTerritoryTileUpdateAction.GetAction<TTerritoryTileUpdateAction>());
        networkChannel.RegisterHandler(TPlayerAreaListUpdateAction.GetAction<TPlayerAreaListUpdateAction>());
        networkChannel.RegisterHandler(TPlayerAreaUpdateAction.GetAction<TPlayerAreaUpdateAction>());
        networkChannel.RegisterHandler(TRemovePlayerAreaAction.GetAction<TRemovePlayerAreaAction>());
        networkChannel.RegisterHandler(TEntityMoveAction.GetAction<TEntityMoveAction>());
    }

    public override void PrepareForConnecting()
    {
        Log.Debug("GameSocketChannelHelper.PrepareForConnecting");
    }

    public override bool SendHeartBeat()
    {
        _ = base.SendHeartBeat();
        SendHeartBreakAction.Req();
        return true;
    }

    public override void Shutdown()
    {
        //TODO:
    }
}