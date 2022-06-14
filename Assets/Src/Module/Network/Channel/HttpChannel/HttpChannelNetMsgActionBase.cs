using System.Reflection;
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
    public string Name => Api;
    private HttpChannelReqPacket _reqPacket;
    protected TReq ReqData;
    protected virtual HttpMethod Method => HttpMethod.Get;
    protected abstract string ApiRoot { get; }
    protected abstract string Api { get; }
    protected virtual bool UseFormData => false;
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

    protected static TReq GenerateReq()
    {
        return new TReq();
    }

    private void InitReqPacket(TReq req)
    {
        ReqData = req;
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
            Headers = GetHeaders(),//设置头部信息
            Params = GetParams(),//设置参数
        };
        if (UseFormData)
        {
            packet.FormData = GetFormData();
        }
        else
        {
            packet.StrData = GetStrData();
        }
        return packet;
    }

    public virtual void Handle(object sender, Packet packet)
    {
        BasicModule.NetMsgCenter.OnReceiveMsg(this);

        (sender as INetworkChannel).UnRegisterHandler(this);
        string textData = (packet as HttpChannelRspPacket).TextData;
        TRsp rspPacket = JsonUtility.FromJson<TRsp>(textData);
        try
        {
            Receive(rspPacket, ReqData);
        }
        catch (Exception e)
        {
            MLog.Error(eLogTag.network, e.Message);
            Receive(null, ReqData);
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
        FieldInfo[] fields = ReqData.GetType().GetFields();
        KeyValuePair<string, string>[] paramData = new KeyValuePair<string, string>[fields.Length];
        for (int i = 0; i < fields.Length; i++)
        {
            paramData[i] = new KeyValuePair<string, string>(fields[i].Name, fields[i].GetValue(ReqData).ToString());
        }
        return paramData;
    }

    protected virtual WWWForm GetFormData()
    {
        WWWForm form = new();
        FieldInfo[] fields = ReqData.GetType().GetFields();
        for (int i = 0; i < fields.Length; i++)
        {
            form.AddField(fields[i].Name, fields[i].GetValue(ReqData).ToString());
        }
        return form;
    }

    protected virtual string GetStrData()
    {
        return JsonUtility.ToJson(ReqData);
    }
}