/*
 * @Author: xiang huan
 * @Date: 2022-05-28 11:00:53
 * @LastEditTime 2022-06-08 13:51:20
 * @LastEditors Please set LastEditors
 * @Description: 通知类action
 * @FilePath /Assets/Src/Framework/Runtime/RuntimeMsgTActionBase.cs
 * 
 */
using GameFramework.Network;
using UnityEngine;

public abstract class RuntimeMsgTActionBase<TRsp> : INetMsgAction where TRsp : RuntimeMessage
{
    public string ChannelName => NetworkDefine.CHANEL_NAME_RUNTIME;
    public virtual int Id => -(int)GetEnvelopeType();

    public string Name => GetEnvelopeType().ToString();

    public static TAction GetAction<TAction>() where TAction : RuntimeMsgTActionBase<TRsp>, new()
    {
        TAction action = new();
        return action;
    }

    protected abstract RuntimeDefine.eRuntimeEnvelopeType GetEnvelopeType();

    protected virtual bool Receive(int errorCode, string errorMsg, TRsp rsp)
    {
        return true;
    }

    public virtual void Handle(object sender, Packet packet)
    {

        TRsp message = JsonUtility.FromJson<TRsp>((packet as RuntimePacket).DataJson);
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
public class RuntimeMessage
{
    public int SeqId;
    public int Type;
    public int ErrorCode;
    public string ErrorMsg;
}