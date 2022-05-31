/*
 * @Author: xiang huan
 * @Date: 2022-05-28 19:45:03
 * @LastEditTime: 2022-05-30 22:25:25
 * @LastEditors: xiang huan
 * @Description: 请求战斗
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/Action/QuizCreateFightAction.cs
 * 
 */

namespace Egret
{
    public class QuizCreateFightAction : EgretMsgRActionBase<QuizCreateFightRequest, Message>
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

        protected override bool Receive(int errorCode, string errorMsg, Message rsp, QuizCreateFightRequest req)
        {
            if (errorCode != EgretDefine.SUCCESS_CODE)
            {
                return false;
            }
            return true;
        }
    }
}