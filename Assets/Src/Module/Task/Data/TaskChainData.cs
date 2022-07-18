
using System;
using System.Collections.Generic;
using Bian;
using Google.Protobuf.Collections;

public class TaskChainData
{
    // 服务器下发原始数据
    private TaskList _rawSvrData;
    public DRTaskList DRTaskList { get; private set; }
    // 对应任务配置
    public DRTask DRTask { get; private set; }
    // 对应任务链名称
    public string TaskChainName { get; private set; }
    // 任务链结束时间
    public long TaskChainEndTimeStamp { get; private set; }
    // 任务链奖励
    public readonly List<RewardNftData> TaskChainRewards = new();
    // 任务需要提交的道具
    public readonly List<RewardNftData> TaskSubmitItems = new();
    // 当前任务奖励
    public readonly List<RewardNftData> CurTaskRewards = new();
    // 子任务集合
    public readonly List<TaskDefine.TaskSubItemData> CurTaskSubItems = new();
    // 子寻路任务
    public TaskDefine.TaskSubItemData CurTaskSubPathFindItem
    {
        get
        {
            TaskDefine.TaskSubItemData curTaskSubPathFindItem = null;
            if (CurTaskSubItems.Count > 0)
            {
                curTaskSubPathFindItem = CurTaskSubItems.Find(obj => obj.Option.OptionCnf.DataCase == TaskOptionCnf.DataOneofCase.TarPos);
            }
            return curTaskSubPathFindItem;
        }
    }
    // 最大进度
    public int MaxTaskChainRate => TaskChainKind == TaskListType.TaskListTypeDaily ? TaskDefine.DAILY_MAX_RATE : TaskDefine.REWARD_MAX_RATE;
    // 当前进度
    public int CurTaskChainRate => _rawSvrData.Rate;
    // 当前任务
    public Task CurTask => _rawSvrData.CurTask;
    // 任务链类型
    public TaskListType TaskChainKind => _rawSvrData.Kind;
    // 任务链ID
    public int TaskChainId => _rawSvrData.Id;
    // 任务链状态
    public TaskDefine.eTaskChainState TaskChainState
    {
        get
        {
            // 未开始 todo
            if (false)
            {
                return TaskDefine.eTaskChainState.NONE;
            }
            long curTime = TimeUtil.GetServerTimeStamp();
            // 超时结束
            if (curTime > TaskChainEndTimeStamp)
            {
                return TaskDefine.eTaskChainState.NONE;
            }

            if (_rawSvrData.Kind == TaskListType.TaskListTypeDaily)
            {
                // 是否已领取
                if (_rawSvrData.ReceiveReward > 0)
                {
                    return TaskDefine.eTaskChainState.HADRECEIVE;
                }
                // 未领取且可领取
                if (_rawSvrData.Rate >= MaxTaskChainRate)
                {
                    return TaskDefine.eTaskChainState.AVAILABLE;
                }
            }
            else if (_rawSvrData.Kind == TaskListType.TaskListTypeRewarded)
            {
                // 是否已经领取
                if (_rawSvrData.ReceiveReward >= MaxTaskChainRate)
                {
                    return TaskDefine.eTaskChainState.HADRECEIVE;
                }

                // 未领取且可领取
                if ((_rawSvrData.ReceiveReward == 0 && _rawSvrData.Rate >= 50)
                    || (_rawSvrData.ReceiveReward == 50 && _rawSvrData.Rate >= MaxTaskChainRate)
                )
                {
                    return TaskDefine.eTaskChainState.AVAILABLE;
                }
            }

            return TaskDefine.eTaskChainState.ONDOING;
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
            long curTime = TimeUtil.GetServerTimeStamp();
            // 任务链超时
            if (curTime > TaskChainEndTimeStamp)
            {
                return TaskDefine.eTaskState.UNSTART;
            }
            // 任务链奖励已经领取
            if (_rawSvrData.ReceiveReward >= MaxTaskChainRate)
            {
                return TaskDefine.eTaskState.FINISH;
            }

            return TaskDefine.eTaskState.ONDOING;
        }
    }

    public TaskChainData UpdateData(TaskList rawSvrData)
    {
        _rawSvrData = rawSvrData;
        // 任务链配置
        DRTaskList = GFEntry.DataTable.GetDataTable<DRTaskList>().GetDataRow(rawSvrData.Id);
        // 任务链名称
        TaskChainName = TaskDefine.TaskSystemId2Name[DRTaskList.System];
        // 任务链结束时间
        TaskChainEndTimeStamp = TimeUtil.DataTime2TimeStamp(rawSvrData.Kind == TaskListType.TaskListTypeDaily ? TimeUtil.GetDayEndTime() : TimeUtil.GetWeekEndTime());
        // 任务链奖励
        List<RewardNftData> taskChainRewards = TaskUtil.GetRewardNftData(DRTaskList.ItemReward, DRTaskList.DitaminReward, DRTaskList.ExpReward);
        TaskUtil.TaskListAddRange(TaskChainRewards, taskChainRewards);

        // 具体任务
        if (rawSvrData.CurTask != null)
        {
            // 当前任务配置
            DRTask = GFEntry.DataTable.GetDataTable<DRTask>().GetDataRow(rawSvrData.CurTask.TaskId);
            // 当前任务需要提交的物品
            List<RewardNftData> taskSubmitItems = TaskUtil.GenerateTaskSubmitItems(rawSvrData);
            // 当前任务子任务
            List<TaskDefine.TaskSubItemData> curTaskSubItems = TaskUtil.GenerateTaskSubItems(rawSvrData, DRTask);
            // 当前任务奖励
            List<RewardNftData> curTaskRewards = TaskUtil.GetRewardNftData(DRTask.ItemReward, DRTask.DitaminReward, DRTask.ExpReward);

            TaskUtil.TaskListAddRange(TaskSubmitItems, taskSubmitItems);
            TaskUtil.TaskListAddRange(CurTaskSubItems, curTaskSubItems);
            TaskUtil.TaskListAddRange(CurTaskRewards, curTaskRewards);
        }
        return this;
    }
}