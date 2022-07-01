/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 请求插槽升级
 * @Date: 2022-06-23 14:25:28
 * @FilePath: /Assets/Src/Module/Network/Channel/GameChannel/Action/UpgradeItemSlotAction.cs
 */
using Bian;

public class UpgradeItemSlotAction : GameChannelNetMsgRActionBase<UpgradeItemSlotRequest, UpgradeItemSlotResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.UpgradeItemSlot;
    }

    protected override bool Receive(int errorCode, string errorMsg, UpgradeItemSlotResponse rsp, UpgradeItemSlotRequest req)
    {
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            return false;
        }

        //todo:show upgrade success tips
        DataManager.MainPlayer.SetItemSlot(rsp.Slots);
        SceneModule.RoleLevel.OnSlotUpgraded.Invoke(req.Position);
        return true;
    }

    public static void Req(AvatarPosition pos)
    {
        UpgradeItemSlotRequest req = GenerateReq();
        req.Position = pos;
        SendAction<UpgradeItemSlotAction>(req);
    }
}