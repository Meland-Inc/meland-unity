using GameFramework.Network;

public class HttpChannelHelper : INetworkChannelHelper
{
    public int PacketHeaderLength => 4;

    public void Initialize(INetworkChannel networkChannel)
    {
        // throw new System.NotImplementedException();
    }

    public void PrepareForConnecting()
    {
        // throw new System.NotImplementedException();
    }

    public bool SendHeartBeat()
    {
        // throw new System.NotImplementedException();
        return false;
    }

    public void Shutdown()
    {
        // throw new System.NotImplementedException();
    }
}