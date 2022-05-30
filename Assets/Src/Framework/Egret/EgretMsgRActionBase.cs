using System;
/*
 * @Author: xiang huan
 * @Date: 2022-05-28 19:03:58
 * @LastEditTime: 2022-05-30 10:34:21
 * @LastEditors: xiang huan
 * @Description: 请求类aciton
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/EgretMsgRActionBase.cs
 * 
 */
using GameFramework.Network;
public abstract class EgretMsgRActionBase<TReq, TRsp> : EgretMsgTActionBase<TRsp> where TReq : Egret.Message, new() where TRsp : Egret.Message
{
    public override int Id => _reqPacket.GetTransferDataSeqId();
    private EgretGamePacket _reqPacket;
    protected static void SendAction<TAction>(TReq req) where TAction : EgretMsgRActionBase<TReq, TRsp>, new()
    {
        TAction action = GetAction<TAction>(req);
        BasicModule.EgretGameCenter.SendEgretMsg(action);
    }

    /// <summary>
    /// 生成一个请求包
    /// </summary>
    /// <returns></returns>
    protected static TReq GenerateReq()
    {
        return new TReq();
    }
    public static TAction GetAction<TAction>(TReq req) where TAction : EgretMsgRActionBase<TReq, TRsp>, new()
    {
        TAction action = GetAction<TAction>();
        action.InitReqPacket(req);
        return action;
    }

    private void InitReqPacket(TReq req)
    {
        _reqPacket = CreatePacket(req);
    }

    protected EgretGamePacket CreatePacket(TReq req)
    {
        EgretGamePacket packet = new();
        packet.SetTransferData(req);
        packet.SetTransferDataType((int)GetEnvelopeType());
        return packet;
    }

    protected sealed override bool Receive(TRsp rsp)
    {
        return base.Receive(rsp);
    }

    protected virtual bool Receive(TRsp rsp, TReq req)
    {
        return Receive(rsp);
    }

    public override void Handle(object sender, Packet packet)
    {
        // 移除监听
        (sender as EgretMsgNetwork).UnRegisterHandler(this);
        // 获取请求数据
        TReq req = _reqPacket.TransferData as TReq;
        TRsp resp = (packet as EgretGamePacket).TransferData as TRsp;
        _ = Receive(resp, req);
    }

    public override Packet GetReqPacket()
    {
        return _reqPacket;
    }

    public override void InitSeqId(int id)
    {
        _reqPacket.SetTransferDataSeqId(id);
    }
}