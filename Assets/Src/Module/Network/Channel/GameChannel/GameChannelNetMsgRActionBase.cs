using System;
using GameFramework.Network;

/// <summary>
/// 请求类型Action
/// </summary>
/// <typeparam name="TReq"></typeparam>
/// <typeparam name="TRsp"></typeparam>
public abstract class GameChannelNetMsgRActionBase<TReq, TRsp> : GameChannelNetMsgTActionBase<TRsp> where TReq : new()
{
    protected event Action<TRsp> OnSuccess;
    protected event Action<int, string> OnError;
    // 网络消息包协议编号 (请求类型action可以被多次注册，需要区分每一次请求的id，所以使用SeqId)
    public override int Id => _reqPacket.GetTransferDataSeqId();
    // 用于给GF.Network 使用的包
    private GameChannelPacket _reqPacket;
    protected static TAction SendAction<TAction>(TReq req) where TAction : GameChannelNetMsgRActionBase<TReq, TRsp>, new()
    {
        TAction action = GetAction<TAction>(req);
        BasicModule.NetMsgCenter.SendMsg(action);
        return action;
    }

    /// <summary>
    /// 生成一个请求包
    /// </summary>
    /// <returns></returns>
    protected static TReq GenerateReq()
    {
        return new TReq();
    }

    public static TAction GetAction<TAction>(TReq req) where TAction : GameChannelNetMsgRActionBase<TReq, TRsp>, new()
    {
        TAction action = GetAction<TAction>();
        action.OnSuccess = null;
        action.OnError = null;
        action.InitReqPacket(req);
        return action;
    }

    private void InitReqPacket(TReq req)
    {
        _reqPacket = CreatePacket(req);
    }

    protected virtual string GetEnvelopeReqName()
    {
        return typeof(TReq).Name;
    }

    protected GameChannelPacket CreatePacket(TReq req)
    {
        MelandGame3.Envelope envelope = new();
        envelope.Type = GetEnvelopeType();
        envelope.GetType().GetProperty(GetEnvelopeReqName()).SetValue(envelope, req);
        GameChannelPacket packet = new();
        packet.SetTransferData(envelope);
        return packet;
    }

    protected sealed override bool Receive(int errorCode, string errorMsg, TRsp rsp)
    {
        return base.Receive(errorCode, errorMsg, rsp);
    }

    /// <summary>
    /// 接受到消息
    /// </summary>
    /// <param name="errorCode">错误码 特殊错误码可以查看ErrorCode</param>
    /// <param name="errorMsg"></param>
    /// <param name="rsp"></param>
    /// <param name="req">当时请求的包</param>
    /// <returns>是否成功</returns>
    protected virtual bool Receive(int errorCode, string errorMsg, TRsp rsp, TReq req)
    {
        bool result = Receive(errorCode, errorMsg, rsp);
        if (result)
        {
            OnSuccess?.Invoke(rsp);
        }
        else
        {
            OnError?.Invoke(errorCode, errorMsg);
        }
        return result;
    }

    public override void Handle(object sender, Packet packet)
    {
        BasicModule.NetMsgCenter.OnReceiveMsg(this);

        // 移除监听
        (sender as INetworkChannel).UnRegisterHandler(this);

        // 获取请求数据
        MelandGame3.Envelope reqEnvelope = _reqPacket.TransferData;
        TReq req = (TReq)reqEnvelope.GetType().GetProperty(GetEnvelopeReqName()).GetValue(reqEnvelope);

        MelandGame3.Envelope envelope = (packet as GameChannelPacket).TransferData;
        string propertyName = envelope.PayloadCase.ToString();
        try
        {
            TRsp resp = default;
            if (string.IsNullOrEmpty(propertyName) || propertyName == "None")
            {
                if (envelope.ErrorCode == ErrorCode.SUCCESS_CODE)
                {
                    MLog.Error(eLogTag.network, $"game msg success but propertyName is null,type={envelope.Type}");
                }
            }
            else
            {
                resp = (TRsp)envelope.GetType().GetProperty(propertyName).GetValue(envelope, null);
            }
            _ = Receive(envelope.ErrorCode, envelope.ErrorMessage, resp, req);
        }
        catch (Exception e)
        {
            MLog.Error(eLogTag.network, $"handle parse error type={envelope.Type} propertyName={propertyName} e={e},error stack={e.StackTrace}");
        }
    }

    public override Packet GetReqPacket()
    {
        return _reqPacket;
    }

    public override void InitSeqId(int id)
    {
        _reqPacket.SetTransferDataSeqId(id);
    }

    public void SetCB(Action<TRsp> successCB, Action<int, string> errorCB = null)
    {
        if (successCB != null)
        {
            if (OnSuccess == null)
            {
                OnSuccess = delegate { };
            }

            OnSuccess += successCB;
        }

        if (errorCB != null)
        {
            if (OnError == null)
            {
                OnError = delegate { };
            }

            OnError += errorCB;
        }
    }
}