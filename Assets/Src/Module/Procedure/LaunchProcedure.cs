using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Network;
using GameFramework.Event;
using networkErrorEvent = UnityGameFramework.Runtime.NetworkErrorEventArgs;

public class LaunchProcedure : GameFramework.Procedure.ProcedureBase
{
    private GameChannelHelper _socketChannelHelper;
    private GameChannelPacketHandlerBase _socketPacketHandler;
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        Log.Debug("hello GF debug");

        _socketChannelHelper = new GameChannelHelper();
        _socketPacketHandler = new GameChannelPacketHandlerBase();
        INetworkChannel channel = GFEntry.Network.CreateNetworkChannel("test", ServiceType.Tcp, _socketChannelHelper);
        channel.RegisterHandler(_socketPacketHandler);
        try
        {
            channel.Connect(System.Net.IPAddress.Parse("127.0.0.1"), 9000);
        }
        catch (System.Exception)
        {
            Log.Error("connect error");
            throw;
        }

        GFEntry.Event.Subscribe(networkErrorEvent.EventId, OnNetworkError);
    }

    private void OnNetworkError(object sender, GameEventArgs e)
    {
        networkErrorEvent args = e as networkErrorEvent;
        Log.Error($"network error msg={args.ErrorMessage} code={args.ErrorCode}");
    }
}