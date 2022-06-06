/*
 * @Author: xiang huan
 * @Date: 2022-05-28 19:45:03
 * @LastEditTime: 2022-06-06 14:43:41
 * @LastEditors: xiang huan
 * @Description: 请求登入
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/Action/LoginAction.cs
 * 
 */

namespace Egret
{
    public class LoginAction : EgretMsgRActionBase<EgretMessage, LoginResponse>
    {
        public static void Req()
        {
            EgretMessage req = GenerateReq();
            SendAction<LoginAction>(req);
        }

        protected override EgretDefine.eEgretEnvelopeType GetEnvelopeType()
        {
            return EgretDefine.eEgretEnvelopeType.Login;
        }

        protected override bool Receive(int errorCode, string errorMsg, LoginResponse rsp, EgretMessage req)
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

    public class LoginResponse : EgretMessage
    {
        public string UserId;
    }

}