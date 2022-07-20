using System.Linq;
using System.Collections.Generic;
using System.IO;
using Bian;
using Google.Protobuf.Collections;

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
        string templateStr = dRTask.Decs; // todo
        int maxRate = 1;
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
                    templateStr = StringUtil.ReplaceTemplate(templateStr, dRItem.Name, maxRate.ToString());
                    break;
                case TaskOptionCnf.DataOneofCase.MonInfo:
                    maxRate = optionCfg.MonInfo.Num;
                    DRMonster dRMonster = GFEntry.DataTable.GetDataTable<DRMonster>().GetDataRow(optionCfg.MonInfo.MonCid);
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
            taskSubItem.Decs = templateStr;
            taskSubItem.CurRate = option.Rate;
            taskSubItem.MaxRate = maxRate;
            taskSubItem.Option = option;
            taskSubItems.Add(taskSubItem);
        }
        return taskSubItems;
    }

    public static void TaskListAddRange<T>(List<T> originList, List<T> beAddLsit)
    {
        originList.Clear();
        originList.AddRange(beAddLsit);
    }
}