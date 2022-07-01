/*
 * @Author: mangit
 * @LastEditTime: 2022-06-30 22:33:34
 * @LastEditors: mangit
 * @Description: 背包更新协议
 * @Date: 2022-06-16 17:39:06
 * @FilePath: /Assets/Src/Module/Network/Channel/GameChannel/Action/TItemUpdatedAction.cs
 */
using Bian;

public class TItemUpdatedAction : GameChannelNetMsgTActionBase<TItemUpdateResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TitemUpdate;
    }

    protected override bool Receive(int errorCode, string errorMsg, TItemUpdateResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }

        DataManager.Backpack.UpdateData(rsp.Items);
        return true;
    }
}