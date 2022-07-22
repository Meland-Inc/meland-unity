using System.Linq;
using System.Collections.Generic;
using System.IO;
using MelandGame3;
using Google.Protobuf.Collections;
using System;

public static class TaskUtil
{

    /// <summary>
    /// 读表整理 奖励数据
    /// </summary>
    /// <param name="dropId"></param>
    /// <param name="exp"></param>
    /// <returns></returns>
    public static List<RewardNftData> GetRewardNftData(int dropId, int exp)
    {
        List<RewardNftData> taskRewards = new();
        DRDrop dropItem = GFEntry.DataTable.GetDataTable<DRDrop>().GetDataRow(dropId);
        int[][] dropList = dropItem.DropList;
        for (int i = 0; i < dropList.Length; i++)
        {
            int[] drop = dropList[i];
            int itemId = drop[0];
            int count = drop[2];
            RewardNftData data = CreateRewardNftDataByItemId(itemId, count);
            if (data != null)
            {
                taskRewards.Add(data);
            }

        }

        if (exp > 0)
        {
            RewardNftData data = CreateRewardNftDataByItemId(AssetDefine.ITEMID_EXP, exp);
            if (data != null)
            {
                taskRewards.Add(data);
            }
        }

        return taskRewards;
    }

    /// <summary>
    /// 生成 奖励数据
    /// </summary>
    /// <param name="itemId"></param>
    /// <param name="count"></param>
    /// <param name="quality"></param>
    /// <returns></returns>
    public static RewardNftData CreateRewardNftDataByItemId(int itemId, int count, NFT.eNFTQuality quality = NFT.eNFTQuality.Basic)
    {
        DRItem item = GFEntry.DataTable.GetDataTable<DRItem>().GetDataRow(itemId);
        if (item == null)
        {
            return null;
        }

        string icon = Path.Combine(AssetDefine.PATH_ITEM_ICON, $"{item.Icon}.png");

        // NFT.eNFTQuality itemQuantity;
        // if (quality == null)
        // {
        //     itemQuantity = item.Quality.Length > 0 ? (NFT.eNFTQuality)item.Quality[0] : NFT.eNFTQuality.Basic;
        // }
        // else
        // {
        //     itemQuantity = (NFT.eNFTQuality)quality;
        // }

        RewardNftData data = new()
        {
            Cid = itemId,
            Icon = icon,
            Count = count,
            Quality = quality
        };
        return data;
    }

    /// <summary>
    /// 根据服务器下发的数据 生成所需提交的道具item数据列表
    /// </summary>
    /// <param name="rawTaskList"></param>
    /// <returns></returns>
    public static List<RewardNftData> GenerateTaskSubmitItems(TaskList rawTaskList)
    {
        List<RewardNftData> taskSubmitItems = new();
        RepeatedField<TaskOption> options = rawTaskList.CurTask.Options;
        for (int i = 0; i < options.Count; i++)
        {
            TaskOption option = options[i];
            TaskOptionCnf optionCfg = option.OptionCnf;
            if (optionCfg.DataCase == TaskOptionCnf.DataOneofCase.Item)
            {
                RewardNftData submitItem = CreateRewardNftDataByItemId(optionCfg.Item.ItemCid, optionCfg.Item.Num);
                taskSubmitItems.Add(submitItem);
            }
        }
        return taskSubmitItems;
    }

    internal static TaskDefine.eTaskState getTaskState(TaskList rawSvrData, int curTaskChainRate, int maxTaskChainRate)
    {
        // 任务链奖励已经领取
        // if (RawSvrData.ReceiveReward >= MaxTaskChainRate)
        // {
        //     return TaskDefine.eTaskState.FINISH;
        // }
        // 任务链已到达最大进度 finish || 任务未开始并且不能再接
        if (curTaskChainRate >= maxTaskChainRate || (!rawSvrData.Doing && !rawSvrData.CanReceive))
        {
            return TaskDefine.eTaskState.FINISH;
        }

        // 未开始，且可以领取  || 已经开启，未领取
        if ((!rawSvrData.Doing && rawSvrData.CanReceive) || (rawSvrData.Doing && rawSvrData.CurTask == null))
        {
            return TaskDefine.eTaskState.UNSTART;
        }

        return TaskDefine.eTaskState.ONDOING;
    }

    /// <summary>
    /// 根据服务器下发的数据 生成任务子项数据列表
    /// </summary>
    /// <param name="rawTaskList"></param>
    /// <param name="dRTask"></param>
    /// <returns></returns>
    public static List<TaskDefine.TaskSubItemData> GenerateTaskSubItems(TaskList rawTaskList, DRTask dRTask)
    {
        List<TaskDefine.TaskSubItemData> taskSubItems = new();
        RepeatedField<TaskOption> options = rawTaskList.CurTask.Options;
        string templateStr = dRTask.Decs; // todo 之后这个字段可能会重新被配置为数组 根据策划的来改
        int maxRate = 1;
        string icon = null;
        for (int i = 0; i < options.Count; i++)
        {
            TaskDefine.TaskSubItemData taskSubItem = new();

            TaskOption option = options[i];
            TaskOptionCnf optionCfg = option.OptionCnf;
            switch (optionCfg.DataCase)
            {
                case TaskOptionCnf.DataOneofCase.Num:
                    maxRate = optionCfg.Num;
                    templateStr = StringUtil.ReplaceTemplate(templateStr, maxRate.ToString());
                    break;
                case TaskOptionCnf.DataOneofCase.Item:
                    maxRate = optionCfg.Item.Num;
                    DRItem dRItem = GFEntry.DataTable.GetDataTable<DRItem>().GetDataRow(optionCfg.Item.ItemCid);
                    icon = Path.Combine(AssetDefine.PATH_ITEM_ICON, $"{dRItem.Icon}.png");
                    templateStr = StringUtil.ReplaceTemplate(templateStr, dRItem.Name, maxRate.ToString());
                    break;
                case TaskOptionCnf.DataOneofCase.MonInfo:
                    maxRate = optionCfg.MonInfo.Num;
                    DRMonster dRMonster = GFEntry.DataTable.GetDataTable<DRMonster>().GetDataRow(optionCfg.MonInfo.MonCid);
                    icon = Path.Combine(AssetDefine.PATH_ITEM_ICON, $"{dRMonster.Icon}.png");
                    templateStr = StringUtil.ReplaceTemplate(templateStr, dRMonster.Name, maxRate.ToString());
                    break;
                case TaskOptionCnf.DataOneofCase.TarPos:
                    maxRate = 1;
                    templateStr = StringUtil.ReplaceTemplate(templateStr, $"({optionCfg.TarPos.R},{optionCfg.TarPos.C})");
                    break;
                case TaskOptionCnf.DataOneofCase.QuizInfo:
                    maxRate = optionCfg.QuizInfo.QuizNum;
                    templateStr = StringUtil.ReplaceTemplate(templateStr, TaskDefine.TaskQuizId2Name[optionCfg.QuizInfo.QuizType], maxRate.ToString());
                    break;
                case TaskOptionCnf.DataOneofCase.None:
                    break;
                default:
                    break;
            }
            taskSubItem.Icon = icon;
            taskSubItem.Decs = templateStr;
            taskSubItem.CurRate = option.Rate;
            taskSubItem.MaxRate = maxRate;
            taskSubItem.Option = option;
            taskSubItems.Add(taskSubItem);
        }
        return taskSubItems;
    }

    internal static TaskDefine.eTaskChainState getTaskChainState(TaskList rawSvrData, int maxChainRate)
    {
        if (!rawSvrData.Doing)
        {
            return TaskDefine.eTaskChainState.NONE;
        }

        if (rawSvrData.Kind == TaskListType.TaskListTypeDaily)
        {
            // 是否已领取
            if (rawSvrData.ReceiveReward > 0)
            {
                return TaskDefine.eTaskChainState.HADRECEIVE;
            }
            // 未领取且可领取
            if (rawSvrData.Rate >= maxChainRate)
            {
                return TaskDefine.eTaskChainState.AVAILABLE;
            }
        }
        else if (rawSvrData.Kind == TaskListType.TaskListTypeRewarded)
        {
            // 是否已经领取
            if (rawSvrData.ReceiveReward >= 2)
            {
                return TaskDefine.eTaskChainState.HADRECEIVE;
            }

            // 未领取且可领取
            if ((rawSvrData.ReceiveReward == 0 && rawSvrData.Rate >= 50)
                || (rawSvrData.ReceiveReward == 1 && rawSvrData.Rate >= maxChainRate)
            )
            {
                return TaskDefine.eTaskChainState.AVAILABLE;
            }
        }

        return TaskDefine.eTaskChainState.ONDOING;
    }

    public static void TaskListAddRange<T>(List<T> originList, List<T> beAddLsit)
    {
        originList.Clear();
        originList.AddRange(beAddLsit);
    }
}