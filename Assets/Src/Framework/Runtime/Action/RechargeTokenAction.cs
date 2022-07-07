/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 
 * @Date: 2022-06-30 20:17:23
 * @FilePath: /Assets/Src/Framework/Runtime/Action/RechargeTokenAction.cs
 */
namespace Runtime
{
    public class RechargeTokenAction : RuntimeMsgRActionBase<RechargeTokenRequest, RechargeTokenResponse>
    {
        protected override RuntimeDefine.eRuntimeEnvelopeType GetEnvelopeType()
        {
            return RuntimeDefine.eRuntimeEnvelopeType.RechargeToken;
        }

        protected override bool Receive(int errorCode, string errorMsg, RechargeTokenResponse rsp, RechargeTokenRequest req)
        {
            if (!base.Receive(errorCode, errorMsg, rsp, req))
            {
                return false;
            }

            return true;
        }

        public static RechargeTokenAction Req(int chargeNum)
        {
            RechargeTokenRequest req = GenerateReq();
            req.Num = chargeNum;
            return SendAction<RechargeTokenAction>(req);
        }
    }

    [System.Serializable]
    public class RechargeTokenResponse : RuntimeMessage
    {
        public int BlockNum;
    }

    public class RechargeTokenRequest : RuntimeMessage
    {
        public int Num;
    }
}