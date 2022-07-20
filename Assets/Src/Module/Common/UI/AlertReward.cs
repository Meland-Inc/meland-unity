
using FairyGUI;
public class AlertReward : AlertBase
{
    private GList _lstReward;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        _lstReward = GCom.GetChild("lstReward") as GList;
        _lstReward.numItems = 0;
        _lstReward.SetVirtual();
        _lstReward.itemRenderer = OnRenderRewardItem;
    }

    private void OnRenderRewardItem(int index, GObject item)
    {
        AlertRewardData alertData = AlertData as AlertRewardData;
        RewardNftItemRenderer renderer = (RewardNftItemRenderer)item;
        renderer.SetData(alertData.Rewards[index]);
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        AddUIEvent();
        AlertRewardData alertData = AlertData as AlertRewardData;
        _lstReward.numItems = alertData.Rewards.Count;
    }



    protected override void OnClose(bool isShutdown, object userData)
    {
        RemoveUIEvent();
        base.OnClose(isShutdown, userData);
    }


    private void AddUIEvent()
    {
        _lstReward.onClickItem.Add(OnListRewardItemClick);
    }
    private void RemoveUIEvent()
    {
        _lstReward.onClickItem.Remove(OnListRewardItemClick);
    }

    private void OnListRewardItemClick(EventContext context)
    {
        RewardNftItemRenderer itemRenderer = (RewardNftItemRenderer)context.data;
        _ = UICenter.OpenUITooltip<TooltipItem>(new TooltipInfo(itemRenderer, itemRenderer.ItemData.Cid, eTooltipDir.Left));
    }
}