/*
 * @Author: xiang huan
 * @Date: 2022-05-30 15:34:35
 * @LastEditTime: 2022-06-06 17:21:42
 * @LastEditors: xiang huan
 * @Description: runtime消息机制初始化完成，可以开始通讯
 * @FilePath: /meland-unity/Assets/Src/Framework/Runtime/TAtion/TRuntimeReadyAction.cs
 * 
 */

namespace Runtime
{
    public class TRuntimeReadyAction : RuntimeMsgTActionBase<RuntimeMessage>
    {
        protected override RuntimeDefine.eRuntimeEnvelopeType GetEnvelopeType()
        {
            return RuntimeDefine.eRuntimeEnvelopeType.WebReady;
        }
        protected override bool Receive(int errorCode, string errorMsg, RuntimeMessage rsp)
        {
            if (errorCode != RuntimeDefine.SUCCESS_CODE)
            {
                return false;
            }
            Message.WebReady?.Invoke(true);
            return true;
        }
    }
}