/*
 * @Author: mangit
 * @LastEditTime: 2022-06-16 20:07:10
 * @LastEditors: mangit
 * @Description: 新增nft item数据
 * @Date: 2022-06-16 19:59:42
 * @FilePath: /Assets/Src/Module/Network/Channel/GameChannel/Action/TItemAddAction.cs
 */
using Bian;

public class TItemAddAction : GameChannelNetMsgTActionBase<TItemAddResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TitemAdd;
    }

    protected override bool Receive(int errorCode, string errorMsg, TItemAddResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }

        DataManager.Backpack.AddData(BackpackUtil.SvrItem2ClientItem(rsp.Items));
        return true;
    }
}
