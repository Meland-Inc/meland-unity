using GameFramework.Network;
using UnityGameFramework.Runtime;

public class GameChannelPacketHandlerBase : IPacketHandler
{
    public int Id => 1;

    public void Handle(object sender, Packet packet)
    {
        Log.Debug($"GameSocketPacketHandler ={(packet as GameChannelPacketBase).Info}");
    }
}