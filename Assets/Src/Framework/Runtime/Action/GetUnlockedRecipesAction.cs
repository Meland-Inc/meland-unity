/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 获取已解锁配方
 * @Date: 2022-06-29 14:27:43
 * @FilePath: /Assets/Src/Framework/Runtime/Action/GetUnlockedRecipesAction.cs
 */
namespace Runtime
{
    public class GetUnlockedRecipesAction : RuntimeMsgRActionBase<RuntimeMessage, GetUnlockedRecipesResponse>
    {
        protected override RuntimeDefine.eRuntimeEnvelopeType GetEnvelopeType()
        {
            return RuntimeDefine.eRuntimeEnvelopeType.GetUnlockedRecipes;
        }

        protected override bool Receive(int errorCode, string errorMsg, GetUnlockedRecipesResponse rsp, RuntimeMessage req)
        {
            if (!base.Receive(errorCode, errorMsg, rsp, req))
            {
                return false;
            }

            SceneModule.Craft.SetUnlockedRecipes(rsp.RecipesIDList);
            return true;
        }

        public static void Req()
        {
            RuntimeMessage req = GenerateReq();
            SendAction<GetUnlockedRecipesAction>(req);
        }
    }

    public class GetUnlockedRecipesResponse : RuntimeMessage
    {
        public int[] RecipesIDList;
    }
}