/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 实体属性字段更新
 * @Date: 2022-06-28 16:37:01
 * @FilePath: /Assets/Src/Module/Network/Channel/GameChannel/Action/TEntityProfileUpdateByFieldIdAction.cs
 */
using Bian;
public class TEntityProfileUpdateByFieldIdAction : GameChannelNetMsgTActionBase<TEntityProfileUpdateByFieldIdResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TentityProfileUpdateByFieldId;
    }

    protected override bool Receive(int errorCode, string errorMsg, TEntityProfileUpdateByFieldIdResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }

        if (rsp.EntityId.Id == DataManager.MainPlayer.RoleID)
        {
            DataManager.MainPlayer.Role.GetComponent<RoleProfileData>().UpdateProfile(rsp.ProfileId, rsp.CurrentValue, rsp.StrValue);
        }
        else
        {
            //TODO:other entity
        }
        return true;
    }
}