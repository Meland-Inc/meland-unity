/*
 * @Author: xiang huan
 * @Date: 2022-05-30 15:34:35
 * @LastEditTime: 2022-06-06 14:47:03
 * @LastEditors: xiang huan
 * @Description: egret消息机制初始化完成，可以开始通讯
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/TAtion/TEgretReadyAction.cs
 * 
 */

namespace Egret
{
    public class TEgretReadyAction : EgretMsgTActionBase<EgretMessage>
    {
        protected override EgretDefine.eEgretEnvelopeType GetEnvelopeType()
        {
            return EgretDefine.eEgretEnvelopeType.EgretReady;
        }
        protected override bool Receive(int errorCode, string errorMsg, EgretMessage rsp)
        {
            if (errorCode != EgretDefine.SUCCESS_CODE)
            {
                return false;
            }
            Message.EgretReady?.Invoke(true);
            //BasicModule.EgretGameCenter.EgretReady();
            return true;
        }
    }
}