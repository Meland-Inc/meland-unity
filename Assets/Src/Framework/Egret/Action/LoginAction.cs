/*
 * @Author: xiang huan
 * @Date: 2022-05-28 19:45:03
 * @LastEditTime: 2022-05-31 15:21:01
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

        protected override bool Receive(int errorCode, string errorMsg, LoginResponse rsp, Message req)
        {
            if (errorCode != EgretDefine.SUCCESS_CODE)
            {
                return false;
            }
            BasicModule.LoginCenter.SetUserID(rsp.UserId);
            BasicModule.LoginCenter.ConnectGameServer();
            return true;
        }
    }
}