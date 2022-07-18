using System.Globalization;
/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 
 * @Date: 2022-07-03 16:24:15
 * @FilePath: /Assets/Src/Framework/Runtime/Action/GetUserGameInternalTokenAction.cs
 */
namespace Runtime
{
    public class GetUserGameInternalTokenAction : RuntimeMsgRActionBase<RuntimeMessage, GetUserGameInternalTokenResponse>
    {
        protected override RuntimeDefine.eRuntimeEnvelopeType GetEnvelopeType()
        {
            return RuntimeDefine.eRuntimeEnvelopeType.GetUserGameInternalToken;
        }

        protected override bool Receive(int errorCode, string errorMsg, GetUserGameInternalTokenResponse rsp, RuntimeMessage req)
        {
            if (!base.Receive(errorCode, errorMsg, rsp, req))
            {
                return false;
            }

            SceneModule.Craft.SetMeldCount(rsp.TokenCount);
            return true;
        }

        public static void Req()
        {
            RuntimeMessage req = GenerateReq();
            SendAction<GetUserGameInternalTokenAction>(req);
        }
    }

    public class GetUserGameInternalTokenResponse : RuntimeMessage
    {
        public int TokenCount;
    }
}