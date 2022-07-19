/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 获取装备插槽数据
 * @Date: 2022-06-23 14:25:15
 * @FilePath: /Assets/Src/Module/Network/Channel/GameChannel/Action/GetItemSlotAction.cs
 */
using MelandGame3;

public class GetItemSlotAction : GameChannelNetMsgRActionBase<GetItemSlotRequest, GetItemSlotResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.GetItemSlot;
    }

    protected override bool Receive(int errorCode, string errorMsg, GetItemSlotResponse rsp, GetItemSlotRequest req)
    {
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            return false;
        }

        DataManager.MainPlayer.SetItemSlot(rsp.Slots);
        return true;
    }

    public static void Req()
    {
        GetItemSlotRequest req = GenerateReq();
        _ = SendAction<GetItemSlotAction>(req);
    }
}