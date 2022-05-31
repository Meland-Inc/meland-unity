/*
 * @Author: xiang huan
 * @Date: 2022-05-28 20:05:52
 * @LastEditTime: 2022-05-31 15:50:59
 * @LastEditors: xiang huan
 * @Description: 注册通知消息
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/EgretMsgNetworkHelper.cs
 * 
 */
using Egret;
using UnityGameFramework.Runtime;
public class EgretMsgNetworkHelper
{

    public void Initialize(EgretMsgNetwork egretMsgNetwork)
    {
        Log.Debug("EgretMsgNetworkHelper.Initialize");
        egretMsgNetwork.RegisterHandler(TEgretReadyAction.GetAction<TEgretReadyAction>());
        egretMsgNetwork.RegisterHandler(TWebViewEnableModeAction.GetAction<TWebViewEnableModeAction>());
        // 注册通知类action
    }
}