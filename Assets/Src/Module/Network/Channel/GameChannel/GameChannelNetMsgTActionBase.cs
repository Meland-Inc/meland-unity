using GameFramework.Network;

/// <summary>
/// 通知类型Action
/// </summary>
/// <typeparam name="TRsp"></typeparam>
public abstract class GameChannelNetMsgTActionBase<TRsp> : INetMsgAction
{
    public string ChannelName => NetworkDefine.CHANNEL_NAME_GAME;
    // 网络消息包协议编号 (通知类型action只注册一次，并且没有SeqId，使用Envelop的Type区分)
    public virtual int Id => -(int)GetEnvelopeType();
    // 用于给GF.Network 使用的包
    public static TAction GetAction<TAction>() where TAction : GameChannelNetMsgTActionBase<TRsp>, new()
    {
        TAction action = new();
        return action;
    }

    protected abstract Bian.EnvelopeType GetEnvelopeType();

    protected virtual void Receive(TRsp rsp)
    {
        // 
    }

    public virtual void Handle(object sender, Packet packet)
    {
        // 获取响应数据
        Bian.Envelope envelope = (packet as GameChannelPacket).TransferData;
        string propertyName = envelope.PayloadCase.ToString();
        TRsp resp = (TRsp)envelope.GetType().GetProperty(propertyName).GetValue(envelope, null);
        Receive(resp);
    }

    public virtual Packet GetReqPacket()
    {
        return null;
    }
}