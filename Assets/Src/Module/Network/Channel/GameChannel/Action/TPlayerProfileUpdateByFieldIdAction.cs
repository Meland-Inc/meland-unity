/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 角色属性更新
 * @Date: 2022-06-27 19:52:02
 * @FilePath: /Assets/Src/Module/Network/Channel/GameChannel/Action/TPlayerProfileUpdateByFieldIdAction.cs
 */
using Bian;
public class TPlayerProfileUpdateByFieldIdAction : GameChannelNetMsgTActionBase<TPlayerProfileUpdateByFieldIdResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TplayerProfileUpdateByFieldId;
    }

    protected override bool Receive(int errorCode, string errorMsg, TPlayerProfileUpdateByFieldIdResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }

        if (rsp.PlayerId == DataManager.MainPlayer.RoleID)
        {
            DataManager.MainPlayer.UpdateProfile(rsp.ProfileId, rsp.CurrentValue, rsp.CurrentValueStr);
        }
        else
        {
            //TODO:other player
        }
        return true;
    }
}