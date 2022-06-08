using GameFramework.Network;
using UnityGameFramework.Runtime;

/// <summary>
/// 通知类型Action
/// </summary>
/// <typeparam name="TRsp"></typeparam>
public abstract class GameChannelNetMsgTActionBase<TRsp> : INetMsgAction
{
    public string ChannelName => NetworkDefine.CHANNEL_NAME_GAME;
    public string Name => GetEnvelopeType().ToString();
    // 网络消息包协议编号 (通知类型action只注册一次，并且没有SeqId，使用Envelop的Type区分)
    public virtual int Id => -(int)GetEnvelopeType();
    // 用于给GF.Network 使用的包
    public static TAction GetAction<TAction>() where TAction : GameChannelNetMsgTActionBase<TRsp>, new()
    {
        TAction action = new();
        return action;
    }

    protected abstract Bian.EnvelopeType GetEnvelopeType();

    /// <summary>
    /// 接收到消息
    /// </summary>
    /// <param name="errorCode">错误码 特殊错误码可以查看ErrorCode</param>
    /// <param name="errorMsg"></param>
    /// <param name="rsp"></param>
    /// <returns>是否成功</returns>
    protected virtual bool Receive(int errorCode, string errorMsg, TRsp rsp)
    {
        if (errorCode == ErrorCode.SUCCESS_CODE)
        {
            return true;
        }

        Log.Error($"{GetEnvelopeType()} Receive errorCode:{errorCode} errorMsg:{errorMsg}");
        return false;
    }

    public virtual void Handle(object sender, Packet packet)
    {
        BasicModule.NetMsgCenter.OnReceiveMsg(this);

        // 获取响应数据
        Bian.Envelope envelope = (packet as GameChannelPacket).TransferData;
        string propertyName = envelope.PayloadCase.ToString();
        TRsp resp = (TRsp)envelope.GetType().GetProperty(propertyName).GetValue(envelope, null);
        _ = Receive(envelope.ErrorCode, envelope.ErrorMessage, resp);
    }

    public virtual Packet GetReqPacket()
    {
        return null;
    }

    public virtual void InitSeqId(int id)
    {
        //empty
    }
}