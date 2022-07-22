/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 实体属性更新
 * @Date: 2022-06-27 17:17:12
 * @FilePath: /Assets/Src/Module/Network/Channel/GameChannel/Action/TEntityProfileUpdateAction.cs
 */
using Bian;
public class TEntityProfileUpdateAction : GameChannelNetMsgTActionBase<TEntityProfileUpdateResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TentityProfileUpdate;
    }

    protected override bool Receive(int errorCode, string errorMsg, TEntityProfileUpdateResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }

        if (rsp.EntityId.Id == DataManager.MainPlayer.RoleID)
        {
            RoleProfileData profileData = DataManager.MainPlayer.Role.GetComponent<RoleProfileData>();
            profileData.UpdateProfile(rsp.Profiles);
        }
        return true;
    }
}