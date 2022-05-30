/*
 * @Author: xiang huan
 * @Date: 2022-05-28 19:45:03
 * @LastEditTime: 2022-05-28 20:12:59
 * @LastEditors: xiang huan
 * @Description: 请求登入
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/Action/LoginAction.cs
 * 
 */

namespace Egret
{
    public class LoginAction : EgretMsgRActionBase<Message, LoginResponse>
    {
        public static void Req()
        {
            Message req = GenerateReq();
            SendAction<LoginAction>(req);
        }

        protected override EgretDefine.eEgretEnvelopeType GetEnvelopeType()
        {
            return EgretDefine.eEgretEnvelopeType.Login;
        }

        protected override bool Receive(LoginResponse rsp, Message req)
        {
            return true;
        }
    }
}