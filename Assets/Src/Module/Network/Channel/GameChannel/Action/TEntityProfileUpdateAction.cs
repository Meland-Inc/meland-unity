/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 实体属性更新
 * @Date: 2022-06-27 17:17:12
 * @FilePath: /Assets/Src/Module/Network/Channel/GameChannel/Action/TEntityProfileUpdateAction.cs
 */
using MelandGame3;
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
            foreach (EntityProfileUpdate item in rsp.Profiles)
            {
                DataManager.MainPlayer.UpdateProfile(item.Field, item.CurValue, item.CurValueStr);
            }
        }
        return true;
    }
}