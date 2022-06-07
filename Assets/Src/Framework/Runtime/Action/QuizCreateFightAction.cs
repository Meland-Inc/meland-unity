/*
 * @Author: xiang huan
 * @Date: 2022-05-28 19:45:03
 * @LastEditTime: 2022-06-06 17:19:40
 * @LastEditors: xiang huan
 * @Description: 请求战斗
 * @FilePath: /meland-unity/Assets/Src/Framework/Runtime/Action/QuizCreateFightAction.cs
 * 
 */

namespace Runtime
{
    public class QuizCreateFightAction : RuntimeMsgRActionBase<QuizCreateFightRequest, RuntimeMessage>
    {
        public static void Req(string sessionID)
        {
            QuizCreateFightRequest req = GenerateReq();
            req.SessionID = sessionID;
            SendAction<QuizCreateFightAction>(req);
        }

        protected override RuntimeDefine.eRuntimeEnvelopeType GetEnvelopeType()
        {
            return RuntimeDefine.eRuntimeEnvelopeType.QuizCreateFight;
        }

        protected override bool Receive(int errorCode, string errorMsg, RuntimeMessage rsp, QuizCreateFightRequest req)
        {
            if (errorCode != RuntimeDefine.SUCCESS_CODE)
            {
                return false;
            }
            return true;
        }
    }

    public class QuizCreateFightRequest : RuntimeMessage
    {
        public string SessionID;
    }
}