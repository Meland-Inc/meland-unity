/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 使用配方
 * @Date: 2022-06-29 14:27:06
 * @FilePath: /Assets/Src/Framework/Runtime/Action/UseRecipesAction.cs
 */
namespace Runtime
{
    public class UseRecipesAction : RuntimeMsgRActionBase<UseRecipesRequest, UseRecipesResponse>
    {
        protected override RuntimeDefine.eRuntimeEnvelopeType GetEnvelopeType()
        {
            return RuntimeDefine.eRuntimeEnvelopeType.UseRecipes;
        }

        protected override bool Receive(int errorCode, string errorMsg, UseRecipesResponse rsp, UseRecipesRequest req)
        {
            if (!base.Receive(errorCode, errorMsg, rsp, req))
            {
                return false;
            }

            return true;
        }

        public static UseRecipesAction Req(int recipesID, int num)
        {
            UseRecipesRequest req = GenerateReq();
            req.RecipesID = recipesID;
            req.Num = num;
            return SendAction<UseRecipesAction>(req);
        }
    }

    public class UseRecipesRequest : RuntimeMessage
    {
        public int RecipesID;
        public int Num;
    }

    public class UseRecipesResponse : RuntimeMessage
    {
        public bool Success;
    }
}