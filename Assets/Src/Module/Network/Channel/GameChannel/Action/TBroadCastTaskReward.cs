


using System.Collections.Generic;
using Bian;
using Cysharp.Threading.Tasks;

public class TBroadCastTaskReward : GameChannelNetMsgTActionBase<TBroadCastTaskRewardResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TbroadCastTaskReward;
    }

    protected override bool Receive(int errorCode, string errorMsg, TBroadCastTaskRewardResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }

        List<RewardNftData> curTaskRewards = new();
        for (int i = 0; i < rsp.RewardItem.Count; i++)
        {
            RewardNftData rewardItem = TaskUtil.CreateRewardNftDataByItemId(rsp.RewardItem[i].Cid, rsp.RewardItem[i].Num, (NFT.eNFTQuality)rsp.RewardItem[i].Quality);
            curTaskRewards.Add(rewardItem);
        }
        if (rsp.RewardExp > 0)
        {
            RewardNftData expItem = TaskUtil.CreateRewardNftDataByItemId(AssetDefine.ITEMID_EXP, rsp.RewardExp);
            curTaskRewards.Add(expItem);
        }

        if (curTaskRewards.Count <= 0)
        {
            MLog.Error(eLogTag.task, $"task TBroadCastTaskReward error, TaskListKind:{rsp.TaskListKind} no reward");
            return false;
        }


        if (rsp.IsTaskListReward)
        {
            //todo 任务链奖励 等待迁移完成 再使用奖励弹框
            DRLanguage dRLanguage = GFEntry.DataTable.GetDataTable<DRLanguage>().GetDataRow(10090019);
            string content = dRLanguage != null ? dRLanguage.Value : "";
            AlertRewardData alertVo = new("REWARDS", content, null, null, curTaskRewards);
            _ = UICenter.OpenUIAlert<AlertReward>(alertVo);
        }
        else
        {
            // 小任务奖励 弹字提示
            ShowRewardsToast(curTaskRewards);
        }

        return true;
    }

    // todo 需要为 ToastCommon 添加消息队列功能
    private async void ShowRewardsToast(List<RewardNftData> curTaskRewards)
    {

        for (int i = 0; i < curTaskRewards.Count; i++)
        {
            RewardNftData reward = curTaskRewards[i];
            DRItem dRItem = GFEntry.DataTable.GetDataTable<DRItem>().GetDataRow(reward.Cid);
            if (dRItem != null)
            {
                _ = UICenter.OpenUIToast<ToastCommon>($"{dRItem.Name}x{reward.Count}");
                await UniTask.Delay(200);
            }
        }
    }
}