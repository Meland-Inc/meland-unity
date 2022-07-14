
using System;
using System.Collections.Generic;
using Bian;
using Google.Protobuf.Collections;

public class TaskChainData
{
    // 服务器下发原始数据
    private TaskList _rawSvrData;
    public DRTaskList DRTaskList;
    // 对应任务配置
    public DRTask DRTask { get; private set; }
    // 对应任务链名称
    public string TaskChainName;
    // 任务链结束时间
    public DateTime TaskChainEndTime;
    // 任务链奖励
    public List<RewardNftData> TaskChainRewards;
    // 任务需要提交的道具
    public List<RewardNftData> TaskSubmitItems;
    // 当前任务奖励
    public List<RewardNftData> CurTaskRewards;
    // Objective
    public List<TaskDefine.TaskObjectData> CurTaskObjectives;
    // 寻路任务
    public TaskDefine.TaskObjectData CurTaskObjectivePathFind;
    // 最大进度
    public int MaxChainRate;
    // 当前进度
    public int CurChainRate => _rawSvrData.Rate;
    // 当前任务
    public Task CurTask => _rawSvrData.CurTask;
    // 任务链类型
    public TaskListType TaskChainKind => _rawSvrData.Kind;
    // 任务链ID
    public int TaskChainId => _rawSvrData.Id;
    // 任务链盒子状态
    public TaskDefine.eTaskChainBoxState ChainBoxState
    {
        get
        {
            long timeEnd = TimeUtil.DataTime2TimeStamp(TaskChainEndTime);
            long curTime = TimeUtil.GetServerTimeStamp();
            // 超时结束
            if (curTime > timeEnd)
            {
                return TaskDefine.eTaskChainBoxState.NONE;
            }

            if (_rawSvrData.Kind == TaskListType.TaskListTypeDaily)
            {
                // 是否已领取
                if (_rawSvrData.ReceiveReward > 0)
                {
                    return TaskDefine.eTaskChainBoxState.HADRECEIVE;
                }
                // 未领取且可领取
                if (_rawSvrData.Rate >= MaxChainRate)
                {
                    return TaskDefine.eTaskChainBoxState.AVAILABLE;
                }
            }
            else if (_rawSvrData.Kind == TaskListType.TaskListTypeRewarded)
            {
                // 是否已经领取
                if (_rawSvrData.ReceiveReward >= MaxChainRate)
                {
                    return TaskDefine.eTaskChainBoxState.HADRECEIVE;
                }

                // 未领取且可领取
                if ((_rawSvrData.ReceiveReward == 0 && _rawSvrData.Rate >= 50)
                    || (_rawSvrData.ReceiveReward == 50 && _rawSvrData.Rate >= MaxChainRate)
                )
                {
                    return TaskDefine.eTaskChainBoxState.AVAILABLE;
                }
            }

            return TaskDefine.eTaskChainBoxState.ONDOING;
        }
    }
    // 任务状态
    public TaskDefine.eTaskState TaskState
    {
        get
        {
            if (_rawSvrData.CurTask == null)
            {
                return TaskDefine.eTaskState.UNSTART;
            }
            long timeEnd = TimeUtil.DataTime2TimeStamp(TaskChainEndTime);
            long curTime = TimeUtil.GetServerTimeStamp();
            // 任务链超时
            if (curTime > timeEnd)
            {
                return TaskDefine.eTaskState.UNSTART;
            }
            // 任务链奖励已经领取
            if (_rawSvrData.ReceiveReward >= MaxChainRate)
            {
                return TaskDefine.eTaskState.FINISH;
            }

            return TaskDefine.eTaskState.ONDOING;
        }
    }

    private static List<RewardNftData> GenerateTaskSubmitItems(TaskList rawTaskList)
    {
        List<RewardNftData> taskSubmitItems = new();
        RepeatedField<TaskOption> options = rawTaskList.CurTask.Options;
        for (int i = 0; i < options.Count; i++)
        {
            TaskOption option = options[i];
            TaskOptionCnf optionCfg = option.OptionCnf;
            if (optionCfg.DataCase == TaskOptionCnf.DataOneofCase.Item)
            {
                RewardNftData submitItem = TaskUtil.CreateRewardNftDataByItemId(optionCfg.Item.ItemCid, optionCfg.Item.Num);
                taskSubmitItems.Add(submitItem);
            }
        }
        return taskSubmitItems;
    }

    private static List<TaskDefine.TaskObjectData> GenerateObjectiveItems(TaskList rawTaskList, DRTask dRTask)
    {
        List<TaskDefine.TaskObjectData> curTaskObjectives = new();
        RepeatedField<TaskOption> options = rawTaskList.CurTask.Options;
        string templateStr = dRTask.Decs; // todo
        int maxRate = 1;
        for (int i = 0; i < options.Count; i++)
        {
            TaskDefine.TaskObjectData taskObjective = new();

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
            taskObjective.Decs = templateStr;
            taskObjective.CurRate = option.Rate;
            taskObjective.MaxRate = maxRate;
            taskObjective.Option = option;
            curTaskObjectives.Add(taskObjective);
        }
        return curTaskObjectives;
    }

    public TaskChainData UpdateData(TaskList rawTaskList)
    {
        // 获取任务链配置
        DRTaskList drTaskList = GFEntry.DataTable.GetDataTable<DRTaskList>().GetDataRow(rawTaskList.Id);
        // 链名称
        string chainName = TaskDefine.TaskSystemId2Name[drTaskList.System];
        // 获取任务配置
        DRTask dRTask = GFEntry.DataTable.GetDataTable<DRTask>().GetDataRow(rawTaskList.CurTask.TaskId);
        // 任务链奖励
        List<RewardNftData> taskChainRewards = TaskUtil.GetRewardNftDataByDropId(drTaskList.ItemReward, drTaskList.DitaminReward, drTaskList.ExpReward);
        // 当前任务奖励
        List<RewardNftData> curTaskRewards = TaskUtil.GetRewardNftDataByDropId(dRTask.ItemReward, dRTask.DitaminReward, dRTask.ExpReward);
        // 需要提交的物品
        List<RewardNftData> taskSubmitItems = GenerateTaskSubmitItems(rawTaskList);
        // 子任务
        List<TaskDefine.TaskObjectData> curTaskObjectives = GenerateObjectiveItems(rawTaskList, dRTask);

        // 寻路子任务
        TaskDefine.TaskObjectData curTaskObjectivePathFind = null;
        if (curTaskObjectives != null && curTaskObjectives.Count > 0)
        {
            curTaskObjectivePathFind = curTaskObjectives.Find(obj => obj.Option.OptionCnf.DataCase == TaskOptionCnf.DataOneofCase.TarPos);
        }
        // CurTaskObjective
        // 任务链结束时间
        DateTime chainEndTime;
        // 最大进度
        int maxChainRate;
        if (rawTaskList.Kind == TaskListType.TaskListTypeDaily)
        {
            chainEndTime = TimeUtil.GetDayEndTime();
            maxChainRate = TaskDefine.DAILY_MAX_RATE;
        }
        else
        {
            chainEndTime = TimeUtil.GetWeekEndTime();
            maxChainRate = TaskDefine.REWARD_MAX_RATE;
        }

        _rawSvrData = rawTaskList;
        DRTaskList = drTaskList;
        DRTask = dRTask;
        TaskChainRewards = taskChainRewards;
        CurTaskRewards = curTaskRewards;
        TaskChainName = chainName;
        TaskChainEndTime = chainEndTime;
        MaxChainRate = maxChainRate;
        TaskSubmitItems = taskSubmitItems;
        CurTaskObjectives = curTaskObjectives;
        CurTaskObjectivePathFind = curTaskObjectivePathFind;
        return this;
    }
}