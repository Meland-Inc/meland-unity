using GameFramework.Network;
public class GameChannelPacketBase : Packet
{
    public override int Id => _id;
    private int _id;

    public string Info;
    public void SetID(int id)
    {
        _id = id;
    }

    public override void Clear()
    {

    }
}