using GameFramework.Network;

/// <summary>
/// 网络消息处理器
/// </summary>
/// <typeparam name="TReq"></typeparam>
/// <typeparam name="TRsp"></typeparam>
public abstract class GameChannelNetMsgActionBase<TReq, TRsp> : INetMsgAction where TReq : new()
{
    public string ChannelName => NetworkDefine.CHANNEL_NAME_GAME;
    // 网络消息包协议编号 
    public int Id => (int)_reqPacket.TransferData.Type;
    private GameChannelPacket _reqPacket;
    public static void SendAction<TAction>(TReq req) where TAction : GameChannelNetMsgActionBase<TReq, TRsp>, new()
    {
        TAction action = GetAction<TAction>(req);
        BasicModule.NetMsgCenter.SendMsg(action);
    }

    public static TAction GetAction<TAction>(TReq req) where TAction : GameChannelNetMsgActionBase<TReq, TRsp>, new()
    {
        TAction action = new();
        action.InitPacket(req);
        return action;
    }

    private void InitPacket(TReq req)
    {
        _reqPacket = CreatePacket(req);
    }

    public abstract string GetEnvelopeReqName();

    public abstract Bian.EnvelopeType GetEnvelopeType();

    private GameChannelPacket CreatePacket(TReq req)
    {
        Bian.Envelope envelope = new();
        envelope.Type = GetEnvelopeType();
        envelope.GetType().GetProperty(GetEnvelopeReqName()).SetValue(envelope, req);
        GameChannelPacket packet = new();
        packet.SetTransferData(envelope);
        return packet;
    }

    public abstract void Receive(TRsp packet);

    public void Handle(object sender, Packet packet)
    {
        // (sender as INetworkChannel).m_ReceivePacketPool(); // remove handler ? no find api

        Bian.Envelope envelope = (packet as GameChannelPacket).TransferData;
        string propertyName = envelope.PayloadCase.ToString();
        TRsp resp = (TRsp)envelope.GetType().GetProperty(propertyName).GetValue(envelope, null);
        Receive(resp);

    }

    Packet INetMsgAction.GetReqPacket()
    {
        return _reqPacket;
    }
}