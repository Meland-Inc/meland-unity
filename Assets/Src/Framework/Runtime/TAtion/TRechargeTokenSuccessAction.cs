/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 充值meld token 成功推送
 * @Date: 2022-07-05 21:57:47
 * @FilePath: /Assets/Src/Framework/Runtime/TAtion/TRechargeTokenSuccessAction.cs
 */
namespace Runtime
{
    public class TRechargeTokenSuccessAction : RuntimeMsgTActionBase<TRechargeTokenSuccessResponse>
    {
        protected override RuntimeDefine.eRuntimeEnvelopeType GetEnvelopeType()
        {
            return RuntimeDefine.eRuntimeEnvelopeType.TRechargeTokenSuccess;
        }

        protected override bool Receive(int errorCode, string errorMsg, TRechargeTokenSuccessResponse rsp)
        {
            if (!base.Receive(errorCode, errorMsg, rsp))
            {
                return false;
            }

            SceneModule.Craft.OnRechargeSuccess(rsp.BlockNum);
            return true;
        }
    }

    public class TRechargeTokenSuccessResponse : RuntimeMessage
    {
        public int BlockNum;
    }
}