
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
        AlertRewardData alertData = _alertData as AlertRewardData;
        RewardNftItemRenderer renderer = (RewardNftItemRenderer)item;
        renderer.SetData(alertData.Rewards[index]);
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        AlertRewardData alertData = _alertData as AlertRewardData;
        _lstReward.numItems = alertData.Rewards.Count;
    }
}