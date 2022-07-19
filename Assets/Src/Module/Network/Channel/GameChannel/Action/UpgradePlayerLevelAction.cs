using System.Net.Http.Headers;
/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 请求角色升级
 * @Date: 2022-06-23 14:24:58
 * @FilePath: /Assets/Src/Module/Network/Channel/GameChannel/Action/UpgradePlayerLevelAction.cs
 */
using MelandGame3;

public class UpgradePlayerLevelAction : GameChannelNetMsgRActionBase<UpgradePlayerLevelRequest, UpgradePlayerLevelResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.UpgradePlayerLevel;
    }

    protected override bool Receive(int errorCode, string errorMsg, UpgradePlayerLevelResponse rsp, UpgradePlayerLevelRequest req)
    {
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            return false;
        }

        DataManager.MainPlayer.UpdateProfile(EntityProfileField.EntityProfileFieldLv, rsp.CurLevel);
        DataManager.MainPlayer.UpdateProfile(EntityProfileField.EntityProfileFieldExp, 0, rsp.CurExp);
        SceneModule.RoleLevel.OnRoleUpgraded.Invoke();
        return true;
    }

    public static UpgradePlayerLevelAction Req()
    {
        UpgradePlayerLevelRequest req = GenerateReq();
        return SendAction<UpgradePlayerLevelAction>(req);
    }
}