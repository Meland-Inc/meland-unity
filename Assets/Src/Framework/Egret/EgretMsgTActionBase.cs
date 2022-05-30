/*
 * @Author: xiang huan
 * @Date: 2022-05-28 11:00:53
 * @LastEditTime: 2022-05-30 10:34:52
 * @LastEditors: xiang huan
 * @Description: 通知类action
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/EgretMsgTActionBase.cs
 * 
 */
using GameFramework.Network;
public abstract class EgretMsgTActionBase<TRsp> : IEgretMsgAction where TRsp : Egret.Message
{
    public virtual int Id => -(int)GetEnvelopeType();
    public static TAction GetAction<TAction>() where TAction : EgretMsgTActionBase<TRsp>, new()
    {
        TAction action = new();
        return action;
    }

    protected abstract EgretDefine.eEgretEnvelopeType GetEnvelopeType();

    protected virtual bool Receive(TRsp rsp)
    {
        return true;
    }

    public virtual void Handle(object sender, Packet packet)
    {
        TRsp message = (packet as EgretGamePacket).TransferData as TRsp;
        _ = Receive(message);
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