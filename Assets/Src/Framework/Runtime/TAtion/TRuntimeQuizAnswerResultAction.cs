

namespace Runtime
{
    public class TRuntimeQuizAnswerResultAction : RuntimeMsgTActionBase<TQuizAnswerResultResponse>
    {
        protected override RuntimeDefine.eRuntimeEnvelopeType GetEnvelopeType()
        {
            return RuntimeDefine.eRuntimeEnvelopeType.TQuizAnswerResult;
        }
        protected override bool Receive(int errorCode, string errorMsg, TQuizAnswerResultResponse rsp)
        {
            if (errorCode != RuntimeDefine.SUCCESS_CODE)
            {
                return false;
            }
            Message.RuntimeQuizAnswerResult?.Invoke(rsp);
            return true;
        }
    }
}