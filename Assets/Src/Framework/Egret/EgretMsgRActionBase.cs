/*
 * @Author: xiang huan
 * @Date: 2022-05-28 19:03:58
 * @LastEditTime: 2022-06-06 14:48:11
 * @LastEditors: xiang huan
 * @Description: 请求类aciton
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/EgretMsgRActionBase.cs
 * 
 */
using GameFramework.Network;
using UnityEngine;

public abstract class EgretMsgRActionBase<TReq, TRsp> : EgretMsgTActionBase<TRsp> where TReq : EgretMessage, new() where TRsp : EgretMessage
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

    protected sealed override bool Receive(int errorCode, string errorMsg, TRsp rsp)
    {
        return base.Receive(errorCode, errorMsg, rsp);
    }

    protected virtual bool Receive(int errorCode, string errorMsg, TRsp rsp, TReq req)
    {
        return Receive(errorCode, errorMsg, rsp);
    }

    public override void Handle(object sender, Packet packet)
    {
        // 移除监听
        (sender as EgretMsgNetwork).UnRegisterHandler(this);
        // 获取请求数据
        TReq req = _reqPacket.TransferData as TReq;
        TRsp resp = JsonUtility.FromJson<TRsp>((packet as EgretGamePacket).DataJson);
        _ = Receive(resp.ErrorCode, resp.ErrorMsg, resp, req);
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