using GameFramework.Network;

/// <summary>
/// 请求类型Action
/// </summary>
/// <typeparam name="TReq"></typeparam>
/// <typeparam name="TRsp"></typeparam>
public abstract class GameChannelNetMsgRActionBase<TReq, TRsp> : INetMsgAction where TReq : new()
{
    public string ChannelName => NetworkDefine.CHANNEL_NAME_GAME;
    // 网络消息包协议编号 (请求类型action可以被多次注册，需要区分每一次请求的id，所以使用SeqId)
    public int Id => _reqPacket.GetTransferDataSeqId();
    // 用于给GF.Network 使用的包
    private GameChannelPacket _reqPacket;
    protected static void SendAction<TAction>(TReq req) where TAction : GameChannelNetMsgRActionBase<TReq, TRsp>, new()
    {
        TAction action = GetAction<TAction>(req);
        BasicModule.NetMsgCenter.SendMsg(action);
    }

    protected static TReq GetReq()
    {
        return new TReq();
    }

    public static TAction GetAction<TAction>(TReq req) where TAction : GameChannelNetMsgRActionBase<TReq, TRsp>, new()
    {
        TAction action = new();
        action.InitReqPacket(req);
        return action;
    }

    private void InitReqPacket(TReq req)
    {
        _reqPacket = CreatePacket(req);
    }

    protected abstract string GetEnvelopeReqName();

    protected abstract Bian.EnvelopeType GetEnvelopeType();

    protected GameChannelPacket CreatePacket(TReq req)
    {
        Bian.Envelope envelope = new();
        envelope.Type = GetEnvelopeType();
        envelope.GetType().GetProperty(GetEnvelopeReqName()).SetValue(envelope, req);
        GameChannelPacket packet = new();
        packet.SetTransferData(envelope);
        return packet;
    }

    protected abstract void Receive(TRsp rsp, TReq req);

    public void Handle(object sender, Packet packet)
    {
        // 移除监听
        (sender as INetworkChannel).UnRegisterHandler(this);

        // 获取请求数据
        Bian.Envelope reqEnvelope = _reqPacket.TransferData;
        TReq req = (TReq)reqEnvelope.GetType().GetProperty(GetEnvelopeReqName()).GetValue(reqEnvelope);

        // 获取响应数据
        Bian.Envelope envelope = (packet as GameChannelPacket).TransferData;
        string propertyName = envelope.PayloadCase.ToString();
        TRsp resp = (TRsp)envelope.GetType().GetProperty(propertyName).GetValue(envelope, null);
        Receive(resp, req);

    }

    Packet INetMsgAction.GetReqPacket()
    {
        return _reqPacket;
    }
}