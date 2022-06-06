/*
 * @Author: xiang huan
 * @Date: 2022-05-30 15:34:35
 * @LastEditTime: 2022-06-06 17:19:42
 * @LastEditors: xiang huan
 * @Description: 通知界面显示和隐藏
 * @FilePath: /meland-unity/Assets/Src/Framework/Runtime/TAtion/TWebViewEnableModeAction.cs
 * 
 */

namespace Runtime
{
    public class TWebViewEnableModeAction : RuntimeMsgTActionBase<TWebViewEnableMode>
    {
        protected override RuntimeDefine.eRuntimeEnvelopeType GetEnvelopeType()
        {
            return RuntimeDefine.eRuntimeEnvelopeType.TWebViewEnableMode;
        }
        protected override bool Receive(int errorCode, string errorMsg, TWebViewEnableMode rsp)
        {
            if (errorCode != RuntimeDefine.SUCCESS_CODE)
            {
                return false;
            }
            BasicModule.RuntimeGameCenter.EnableMode((RuntimeDefine.eEgretEnableMode)rsp.Mode, rsp.Enable);
            return true;
        }
    }
    public class TWebViewEnableMode : RuntimeMessage
    {
        public int Mode;
        public bool Enable;
    }
}