/*
 * @Author: xiang huan
 * @Date: 2022-05-28 19:45:03
 * @LastEditTime: 2022-05-30 22:20:19
 * @LastEditors: xiang huan
 * @Description: 请求答题
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/Action/QuizAnswerAction.cs
 * 
 */

namespace Egret
{
    public class QuizAnswerAction : EgretMsgRActionBase<QuizAnswerRequest, Message>
    {
        public static void Req(int row, int col)
        {
            QuizAnswerRequest req = GenerateReq();
            req.Row = row;
            req.Col = col;
            SendAction<QuizAnswerAction>(req);
        }

        protected override EgretDefine.eEgretEnvelopeType GetEnvelopeType()
        {
            return EgretDefine.eEgretEnvelopeType.QuizAnswer;
        }

        protected override bool Receive(int errorCode, string errorMsg, Message rsp, QuizAnswerRequest req)
        {
            if (errorCode != EgretDefine.SUCCESS_CODE)
            {
                return false;
            }
            return true;
        }
    }
}