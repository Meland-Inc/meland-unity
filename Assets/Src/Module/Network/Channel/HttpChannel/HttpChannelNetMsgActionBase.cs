using System;
using System.Collections.Generic;
using System.Net.Http;
using GameFramework.Network;
using HttpPacketDefine;
using UnityEngine;

public abstract class HttpChannelNetMsgActionBase<TReq, TRsp> : INetMsgAction where TReq : new() where TRsp : HttpRspBase, new()
{
    public int Id => _reqPacket.Id;
    public string ChannelName => NetworkDefine.CHANEL_NAME_HTTP;
    private HttpChannelReqPacket _reqPacket;
    private TReq _req;
    protected virtual HttpMethod Method => HttpMethod.Get;
    protected virtual string DataStr => "";
    protected abstract string ApiRoot { get; }
    protected abstract string Api { get; }
    public static TAction GetAction<TAction>() where TAction : HttpChannelNetMsgActionBase<TReq, TRsp>, new()
    {
        TAction action = new();
        return action;
    }

    public static void SendAction<TAction>(TReq req) where TAction : HttpChannelNetMsgActionBase<TReq, TRsp>, new()
    {
        TAction action = GetAction<TAction>();
        action.InitReqPacket(req);
        BasicModule.NetMsgCenter.SendMsg(action);
    }

    protected static TReq GetReq()
    {
        return new TReq();
    }

    private void InitReqPacket(TReq req)
    {
        _req = req;
        _reqPacket = CreatePacket();
    }

    public Packet GetReqPacket()
    {
        return _reqPacket;
    }

    protected HttpChannelReqPacket CreatePacket()
    {
        HttpChannelReqPacket packet = new()
        {
            Url = ApiRoot + Api,//设置请求的url
            Method = Method,//设置请求方法
            DataStr = DataStr,//设置请求参数
            Headers = GetHeaders(),//设置头部信息
            Params = GetParams(),//设置参数
            FormData = GetFormData(),//设置表单数据
        };
        return packet;
    }

    public virtual void Handle(object sender, Packet packet)
    {
        (sender as INetworkChannel).UnRegisterHandler(this);
        string textData = (packet as HttpChannelRspPacket).TextData;
        TRsp rspPacket = JsonUtility.FromJson<TRsp>(textData);
        try
        {
            Receive(rspPacket, _req);
        }
        catch (Exception e)
        {
            MLog.Error(eLogTag.network, e.Message);
            Receive(null, _req);
        }
    }

    public void InitSeqId(int id)
    {
        //empty
    }

    protected abstract void Receive(TRsp rsp, TReq req);

    protected virtual KeyValuePair<string, string>[] GetHeaders()
    {
        return null;
    }

    protected virtual KeyValuePair<string, string>[] GetParams()
    {
        return null;
    }

    protected virtual KeyValuePair<string, string>[] GetFormData()
    {
        return null;
    }
}