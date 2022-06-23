/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 插槽信息更新
 * @Date: 2022-06-23 14:27:26
 * @FilePath: /Assets/Src/Module/Network/Channel/GameChannel/Action/TUpdateItemSlotAction.cs
 */
using Bian;
public class TUpdateItemSlotAction : GameChannelNetMsgTActionBase<TUpdateItemSlotResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TupdateItemSlot;
    }

    protected override bool Receive(int errorCode, string errorMsg, TUpdateItemSlotResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }

        DataManager.MainPlayer.SetItemSlot(rsp.Slots);//直接重新覆盖数据
        return true;
    }
}