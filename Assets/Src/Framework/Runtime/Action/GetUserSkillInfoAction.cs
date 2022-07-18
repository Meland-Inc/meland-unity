/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 通过web view获取
 * @Date: 2022-06-30 14:21:09
 * @FilePath: /Assets/Src/Framework/Runtime/Action/GetUserSkillInfoAction.cs
 */
namespace Runtime
{
    public class GetUserSkillInfoAction : RuntimeMsgRActionBase<RuntimeMessage, GetUserSkillInfoResponse>
    {
        protected override RuntimeDefine.eRuntimeEnvelopeType GetEnvelopeType()
        {
            return RuntimeDefine.eRuntimeEnvelopeType.GetUserSkillInfo;
        }

        protected override bool Receive(int errorCode, string errorMsg, GetUserSkillInfoResponse rsp, RuntimeMessage req)
        {
            if (!base.Receive(errorCode, errorMsg, rsp, req))
            {
                return false;
            }

            SceneModule.Craft.SetSkillInfo(rsp);
            return true;
        }

        public static void Req()
        {
            RuntimeMessage req = GenerateReq();
            _ = SendAction<GetUserSkillInfoAction>(req);
        }
    }

    [System.Serializable]
    public class GetUserSkillInfoResponse : RuntimeMessage
    {
        public UserSkillInfo[] Skills;
        public int RoleExp;
        public int RoleLv;
    }

    [System.Serializable]
    public class UserSkillInfo
    {
        public string Id;
        public int Lv;
        public int Exp;
    }
}