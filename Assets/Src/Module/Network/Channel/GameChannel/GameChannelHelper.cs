using GameFramework.Network;
using UnityGameFramework.Runtime;
public class GameChannelHelper : SocketProtobufChannelHelper<Bian.Envelope>
{
    public override int PacketHeaderLength => 4;

    public override void Initialize(INetworkChannel networkChannel)
    {
        Log.Debug("GameSocketChannelHelper.Initialize");
        networkChannel.RegisterHandler(SendHeartBreakAction.GetAction<SendHeartBreakAction>(null));
        networkChannel.RegisterHandler(RemoveMarkFromMinimapAction.GetAction<RemoveMarkFromMinimapAction>(null));
    }

    public override void PrepareForConnecting()
    {
        Log.Debug("GameSocketChannelHelper.PrepareForConnecting");
    }

    public override bool SendHeartBeat()
    {
        SendHeartBreakAction.Req();
        return true;
    }

    public override void Shutdown()
    {
        // throw new NotImplementedException();
    }
}