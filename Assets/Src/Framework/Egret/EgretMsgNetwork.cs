/*
 * @Author: xiang huan
 * @Date: 2022-05-28 10:09:05
 * @LastEditTime: 2022-05-28 20:09:52
 * @LastEditors: xiang huan
 * @Description: 白鹭通讯
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/EgretMsgNetwork.cs
 * 
 */
using System;
using GameFramework;
using GameFramework.Network;
using Vuplex.WebView;
using UnityEngine;

public class EgretMsgNetwork
{
    private readonly CanvasWebViewPrefab _canvasWebView;
    private readonly EgretMsgNetworkHelper _egretMsgNetworkHelper;

    private readonly EventPool<Packet> _receivePacketPool;
    private int _seqId;
    public EgretMsgNetwork(CanvasWebViewPrefab canvasWebView)
    {
        _seqId = EgretDefine.EGRET_MIN_SEQ_ID;
        _receivePacketPool = new EventPool<Packet>(EventPoolMode.Default);
        _canvasWebView = canvasWebView;
        _canvasWebView.WebView.MessageEmitted += OnEgretMessage;

        _egretMsgNetworkHelper = new EgretMsgNetworkHelper();
        _egretMsgNetworkHelper.Initialize(this);
    }
    public void ExecuteSend(IEgretMsgAction action)
    {
        action.InitSeqId(GetSeqId());
        RegisterHandler(action);
        Send(action.GetReqPacket());
    }
    public void Send<T>(T packet) where T : Packet
    {
        try
        {
            Egret.Message message = (packet as EgretGamePacket).TransferData;
            string messageJson = JsonUtility.ToJson(message);
            _canvasWebView.WebView.PostMessage(messageJson);
        }
        catch (Exception)
        {
            MLog.Error(eLogTag.egret, $"EgretMsgNetwork Send Error: {packet.Id}");
            throw;
        }
    }

    private void OnEgretMessage(object sender, EventArgs<string> e)
    {
        try
        {
            Egret.Message message = JsonUtility.FromJson<Egret.Message>(e.Value);
            EgretGamePacket packet = new();
            packet.SetTransferData(message);
            if (packet != null)
            {
                _receivePacketPool.Fire(this, packet);
            }
        }
        catch (Exception)
        {
            MLog.Error(eLogTag.egret, $"OnEgretMessage  Error");
            throw;
        }

    }

    public virtual void Update(float elapseSeconds, float realElapseSeconds)
    {
        _receivePacketPool.Update(elapseSeconds, realElapseSeconds);
    }

    public virtual void Shutdown()
    {
        _receivePacketPool.Shutdown();
    }

    public void RegisterHandler(IPacketHandler handler)
    {
        if (handler == null)
        {
            throw new GameFrameworkException("RegisterHandler Packet handler is invalid.");
        }

        _receivePacketPool.Subscribe(handler.Id, handler.Handle);
    }

    public void UnRegisterHandler(IPacketHandler handler)
    {
        if (handler == null)
        {
            throw new GameFrameworkException("UnRegisterHandler Packet handler is invalid.");
        }

        _receivePacketPool.Unsubscribe(handler.Id, handler.Handle);
    }

    public void SetDefaultHandler(EventHandler<Packet> handler)
    {
        _receivePacketPool.SetDefaultHandler(handler);
    }

    private int GetSeqId()
    {
        return _seqId++;
    }
    public void Destroy()
    {
        _receivePacketPool.Clear();
    }
}
