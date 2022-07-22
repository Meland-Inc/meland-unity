
using System.Collections.Generic;
using MelandGame3;

public class TaskChainData
{
    // 服务器下发原始数据
    public TaskList RawSvrData;
    public DRTaskList DRTaskList { get; private set; }
    // 对应任务配置
    public DRTask DRTask { get; private set; }
    // 对应任务链名称
    public string TaskChainName { get; private set; }
    // 任务链结束时间
    public long TaskChainEndTimeStamp { get; private set; }
    // 任务可放弃的结束时间
    public long TaskCanAbandonTimeStamp { get; private set; }
    // 任务链奖励
    public readonly List<RewardNftData> TaskChainRewards = new();
    // 任务需要提交的道具
    public readonly List<RewardNftData> TaskSubmitItems = new();
    // 当前任务奖励
    public readonly List<RewardNftData> CurTaskRewards = new();
    // 子任务集合
    public readonly List<TaskDefine.TaskSubItemData> CurTaskSubItems = new();
    // 子提交任务
    public TaskDefine.TaskSubItemData CurTaskSubSubmitItem => CurTaskSubItems.Find(obj => obj.Option.OptionCnf.DataCase == TaskOptionCnf.DataOneofCase.Item);

    // 最大进度
    public int MaxTaskChainRate => TaskChainKind == TaskListType.TaskListTypeDaily ? TaskDefine.DAILY_MAX_RATE : TaskDefine.REWARD_MAX_RATE;
    // 当前进度
    public int CurTaskChainRate => RawSvrData.Rate;
    // 当前任务
    public Task CurTask => RawSvrData.CurTask;
    // 任务链类型
    public TaskListType TaskChainKind => RawSvrData.Kind;
    // 任务链ID
    public int TaskChainId => RawSvrData.Id;
    // 任务链状态
    public TaskDefine.eTaskChainState TaskChainState;
    // 任务状态
    public TaskDefine.eTaskState TaskState;

    public TaskChainData UpdateData(TaskList rawSvrData)
    {
        RawSvrData = rawSvrData;
        // 任务链配置
        DRTaskList = GFEntry.DataTable.GetDataTable<DRTaskList>().GetDataRow(rawSvrData.Id);
        // 任务链名称
        TaskChainName = TaskDefine.TaskSystemId2Name[DRTaskList.System];
        // 任务链结束时间
        TaskChainEndTimeStamp = 0;
        if (RawSvrData.Doing && rawSvrData.Kind == TaskListType.TaskListTypeDaily)
        {
            TaskChainEndTimeStamp = TimeUtil.DataTime2TimeStamp(TimeUtil.GetDayEndTime());
            // TaskChainEndTimeStamp = TimeUtil.DataTime2TimeStamp(rawSvrData.Kind == TaskListType.TaskListTypeDaily ? TimeUtil.GetDayEndTime() : TimeUtil.GetWeekEndTime());
        }

        // 任务链奖励
        List<RewardNftData> taskChainRewards = TaskUtil.GetRewardNftData(DRTaskList.ItemReward, DRTaskList.ExpReward);
        TaskUtil.TaskListAddRange(TaskChainRewards, taskChainRewards);

        // 任务链状态获取
        TaskChainState = TaskUtil.getTaskChainState(RawSvrData, MaxTaskChainRate);

        // 当前任务状态获取
        TaskState = TaskUtil.getTaskState(RawSvrData, CurTaskChainRate, MaxTaskChainRate);

        // 具体任务
        if (rawSvrData.CurTask != null)
        {
            // 可放弃时间 （任务领取往后5分钟）
            TaskCanAbandonTimeStamp = (rawSvrData.CurTask.CreatedAtSec + (5 * TimeUtil.SecondsOfMinute)) * 1000;
            // 当前任务配置
            DRTask = GFEntry.DataTable.GetDataTable<DRTask>().GetDataRow(rawSvrData.CurTask.TaskId);
            // 当前任务需要提交的物品
            List<RewardNftData> taskSubmitItems = TaskUtil.GenerateTaskSubmitItems(rawSvrData);
            // 当前任务子任务
            List<TaskDefine.TaskSubItemData> curTaskSubItems = TaskUtil.GenerateTaskSubItems(rawSvrData, DRTask);
            // 当前任务奖励
            List<RewardNftData> curTaskRewards = TaskUtil.GetRewardNftData(DRTask.ItemReward, DRTask.ExpReward);

            TaskUtil.TaskListAddRange(TaskSubmitItems, taskSubmitItems);
            TaskUtil.TaskListAddRange(CurTaskSubItems, curTaskSubItems);
            TaskUtil.TaskListAddRange(CurTaskRewards, curTaskRewards);
        }
        return this;
    }
}