/*
 * @Author: mangit
 * @LastEditTime: 2022-06-17 14:02:17
 * @LastEditors: mangit
 * @Description: 获取背包数据
 * @Date: 2022-06-16 16:54:30
 * @FilePath: /Assets/Src/Module/Network/Channel/GameChannel/Action/ItemsGetAction.cs
 */
using Bian;
public class ItemsGetAction : GameChannelNetMsgRActionBase<ItemsGetRequest, ItemsGetResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.ItemsGet;
    }

    protected override bool Receive(int errorCode, string errorMsg, ItemsGetResponse rsp, ItemsGetRequest req)
    {
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            return false;
        }
        DataManager.Backpack.InitBpSize(rsp.Sizes[0].Length);
        DataManager.Backpack.InitData(BackpackUtil.SvrItem2ClientItem(rsp.Items));
        return true;
    }

    public static void Req()
    {
        ItemsGetRequest req = GenerateReq();
        req.Holder = DataManager.MainPlayer.RoleID;
        req.Backpacks.Add(BackpackId.BackpackIdBasic);
        SendAction<ItemsGetAction>(req);
    }
}
