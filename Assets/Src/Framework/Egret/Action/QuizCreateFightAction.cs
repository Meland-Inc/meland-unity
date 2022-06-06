/*
 * @Author: xiang huan
 * @Date: 2022-05-28 19:45:03
 * @LastEditTime: 2022-06-06 14:43:43
 * @LastEditors: xiang huan
 * @Description: 请求战斗
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/Action/QuizCreateFightAction.cs
 * 
 */

namespace Egret
{
    public class QuizCreateFightAction : EgretMsgRActionBase<QuizCreateFightRequest, EgretMessage>
    {
        public static void Req(string sessionID)
        {
            QuizCreateFightRequest req = GenerateReq();
            req.SessionID = sessionID;
            SendAction<QuizCreateFightAction>(req);
        }

        protected override EgretDefine.eEgretEnvelopeType GetEnvelopeType()
        {
            return EgretDefine.eEgretEnvelopeType.QuizCreateFight;
        }

        protected override bool Receive(int errorCode, string errorMsg, EgretMessage rsp, QuizCreateFightRequest req)
        {
            if (errorCode != EgretDefine.SUCCESS_CODE)
            {
                return false;
            }
            return true;
        }
    }

    public class QuizCreateFightRequest : EgretMessage
    {
        public string SessionID;
    }
}