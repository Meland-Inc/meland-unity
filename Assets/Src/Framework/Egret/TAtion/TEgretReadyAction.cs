/*
 * @Author: xiang huan
 * @Date: 2022-05-30 15:34:35
 * @LastEditTime: 2022-05-30 22:16:18
 * @LastEditors: xiang huan
 * @Description: egret消息机制初始化完成，可以开始通讯
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/TAtion/TEgretReadyAction.cs
 * 
 */

namespace Egret
{
    public class TEgretReadyAction : EgretMsgTActionBase<Message>
    {
        protected override EgretDefine.eEgretEnvelopeType GetEnvelopeType()
        {
            return EgretDefine.eEgretEnvelopeType.EgretReady;
        }
        protected override bool Receive(int errorCode, string errorMsg, Message rsp)
        {
            if (errorCode != EgretDefine.SUCCESS_CODE)
            {
                return false;
            }
            BasicModule.EgretGameCenter.EgretReady();
            return true;
        }
    }
}