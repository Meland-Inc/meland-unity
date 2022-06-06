/*
 * @Author: xiang huan
 * @Date: 2022-05-28 11:00:53
 * @LastEditTime: 2022-06-06 14:50:16
 * @LastEditors: xiang huan
 * @Description: 通知类action
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/EgretMsgTActionBase.cs
 * 
 */
using GameFramework.Network;
using UnityEngine;

public abstract class EgretMsgTActionBase<TRsp> : IEgretMsgAction where TRsp : EgretMessage
{
    public virtual int Id => -(int)GetEnvelopeType();
    public static TAction GetAction<TAction>() where TAction : EgretMsgTActionBase<TRsp>, new()
    {
        TAction action = new();
        return action;
    }

    protected abstract EgretDefine.eEgretEnvelopeType GetEnvelopeType();

    protected virtual bool Receive(int errorCode, string errorMsg, TRsp rsp)
    {
        return true;
    }

    public virtual void Handle(object sender, Packet packet)
    {

        TRsp message = JsonUtility.FromJson<TRsp>((packet as EgretGamePacket).DataJson);
        _ = Receive(message.ErrorCode, message.ErrorMsg, message);
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
public class EgretMessage
{
    public int SeqId;
    public int Type;
    public int ErrorCode;
    public string ErrorMsg;

    public static object EgretReady { get; internal set; }
}