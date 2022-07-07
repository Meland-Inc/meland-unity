using System;
/*
 * @Author: xiang huan
 * @Date: 2022-05-28 19:45:03
 * @LastEditTime: 2022-07-07 10:24:08
 * @LastEditors: mangit
 * @Description: 请求登入
 * @FilePath: /Assets/Src/Framework/Runtime/Action/LoginAction.cs
 * 
 */

namespace Runtime
{
    public class LoginAction : RuntimeMsgRActionBase<RuntimeMessage, LoginResponse>
    {
        public static LoginAction Req()
        {
            RuntimeMessage req = GenerateReq();
            return SendAction<LoginAction>(req);
        }

        protected override RuntimeDefine.eRuntimeEnvelopeType GetEnvelopeType()
        {
            return RuntimeDefine.eRuntimeEnvelopeType.Login;
        }

        protected override bool Receive(int errorCode, string errorMsg, LoginResponse rsp, RuntimeMessage req)
        {
            if (errorCode != RuntimeDefine.SUCCESS_CODE)
            {
                return false;
            }
            BasicModule.RuntimeGameCenter.EnableMode(RuntimeDefine.eEgretEnableMode.Login, false);
            return true;
        }
    }

    public class LoginResponse : RuntimeMessage
    {
        public string UserId;
    }

}