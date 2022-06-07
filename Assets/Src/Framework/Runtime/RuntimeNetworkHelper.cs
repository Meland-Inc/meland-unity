/*
 * @Author: xiang huan
 * @Date: 2022-05-28 20:05:52
 * @LastEditTime: 2022-06-06 16:26:39
 * @LastEditors: xiang huan
 * @Description: 注册通知消息
 * @FilePath: /meland-unity/Assets/Src/Framework/Runtime/RuntimeNetworkHelper.cs
 * 
 */
using GameFramework.Network;
using Runtime;
using UnityGameFramework.Runtime;
public class RuntimeNetworkHelper : INetworkChannelHelper
{

    public int PacketHeaderLength => 4;
    public void Initialize(INetworkChannel networkChannel)
    {
        Log.Debug("RuntimeNetworkHelper.Initialize");
        //注册通知类action
        networkChannel.RegisterHandler(TRuntimeReadyAction.GetAction<TRuntimeReadyAction>());
        networkChannel.RegisterHandler(TWebViewEnableModeAction.GetAction<TWebViewEnableModeAction>());
    }
    public void PrepareForConnecting()
    {
        // throw new System.NotImplementedException();
    }

    public bool SendHeartBeat()
    {
        // throw new System.NotImplementedException();
        return false;
    }

    public void Shutdown()
    {
        // throw new System.NotImplementedException();
    }
}