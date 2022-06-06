/*
 * @Author: xiang huan
 * @Date: 2022-05-28 19:45:03
 * @LastEditTime: 2022-06-06 17:29:40
 * @LastEditors: xiang huan
 * @Description: 请求登入
 * @FilePath: /meland-unity/Assets/Src/Framework/Runtime/Action/LoginAction.cs
 * 
 */

namespace Runtime
{
    public class LoginAction : RuntimeMsgRActionBase<RuntimeMessage, LoginResponse>
    {
        public static void Req()
        {
            RuntimeMessage req = GenerateReq();
            SendAction<LoginAction>(req);
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
            BasicModule.LoginCenter.SetUserID(rsp.UserId);
            BasicModule.LoginCenter.ConnectGameServer();
            return true;
        }
    }

    public class LoginResponse : RuntimeMessage
    {
        public string UserId;
    }

}