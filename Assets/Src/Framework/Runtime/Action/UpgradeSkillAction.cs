/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 升级技能
 * @Date: 2022-07-03 16:24:34
 * @FilePath: /Assets/Src/Framework/Runtime/Action/UpgradeSkillAction.cs
 */
namespace Runtime
{
    public class UpgradeSkillAction : RuntimeMsgRActionBase<UpgradeSkillRequest, UpgradeSkillResponse>
    {
        protected override RuntimeDefine.eRuntimeEnvelopeType GetEnvelopeType()
        {
            return RuntimeDefine.eRuntimeEnvelopeType.UpgradeSkill;
        }

        protected override bool Receive(int errorCode, string errorMsg, UpgradeSkillResponse rsp, UpgradeSkillRequest req)
        {
            if (!base.Receive(errorCode, errorMsg, rsp, req))
            {
                return false;
            }

            _ = UICenter.OpenUIToast<ToastCommon>("upgrade skill successfully");
            return true;
        }

        public static UpgradeSkillAction Req(string skillId)
        {
            UpgradeSkillRequest req = GenerateReq();
            req.SkillId = skillId;
            return SendAction<UpgradeSkillAction>(req);
        }
    }

    public class UpgradeSkillRequest : RuntimeMessage
    {
        public string SkillId;
    }
    public class UpgradeSkillResponse : RuntimeMessage
    {
        public bool Success;
    }
}

