/*
 * @Author: xiang huan
 * @Date: 2022-05-30 15:34:35
 * @LastEditTime: 2022-05-30 22:28:46
 * @LastEditors: xiang huan
 * @Description: 通知界面显示和隐藏
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/TAtion/TWebViewEnableModeAction.cs
 * 
 */

namespace Egret
{
    public class TWebViewEnableModeAction : EgretMsgTActionBase<TWebViewEnableMode>
    {
        protected override EgretDefine.eEgretEnvelopeType GetEnvelopeType()
        {
            return EgretDefine.eEgretEnvelopeType.TWebViewEnableMode;
        }
        protected override bool Receive(int errorCode, string errorMsg, TWebViewEnableMode rsp)
        {
            if (errorCode != EgretDefine.SUCCESS_CODE)
            {
                return false;
            }
            BasicModule.EgretGameCenter.EnableMode((EgretDefine.eEgretEnableMode)rsp.Mode, rsp.Enable);
            return true;
        }
    }
}