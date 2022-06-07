/*
 * @Author: xiang huan
 * @Date: 2022-05-28 19:45:03
 * @LastEditTime: 2022-06-06 17:19:27
 * @LastEditors: xiang huan
 * @Description: 请求答题
 * @FilePath: /meland-unity/Assets/Src/Framework/Runtime/Action/QuizAnswerAction.cs
 * 
 */

namespace Runtime
{
    public class QuizAnswerAction : RuntimeMsgRActionBase<QuizAnswerRequest, RuntimeMessage>
    {
        public static void Req(int row, int col)
        {
            QuizAnswerRequest req = GenerateReq();
            req.Row = row;
            req.Col = col;
            SendAction<QuizAnswerAction>(req);
        }

        protected override RuntimeDefine.eRuntimeEnvelopeType GetEnvelopeType()
        {
            return RuntimeDefine.eRuntimeEnvelopeType.QuizAnswer;
        }

        protected override bool Receive(int errorCode, string errorMsg, RuntimeMessage rsp, QuizAnswerRequest req)
        {
            if (errorCode != RuntimeDefine.SUCCESS_CODE)
            {
                return false;
            }
            return true;
        }
    }

    public class QuizAnswerRequest : RuntimeMessage
    {
        public int Row;
        public int Col;
    }
}