using System;
using System.Collections.Generic;
using Bian;
using FairyGUI;
/// <summary>
/// 任务内容面板逻辑
/// </summary>
public class TaskContentViewLogic : FGUILogicCpt
{
    private TaskChainData _taskChainData;
    private Controller _ctrTaskState;
    private GTextField _tfTitle;
    private GTextField _tfDesc;
    private GList _lstTaskSubItem;
    private GList _lstTaskChainReward;
    private GList _lstTaskReward;
    private GButton _btnAbandon;
    private GButton _btnReceive;
    private GButton _btnSubmit;
    protected override void OnAdd()
    {
        base.OnAdd();
        _ctrTaskState = GCom.GetController("ctrTaskState");
        _tfTitle = GCom.GetChild("tfTitle") as GTextField;
        _tfDesc = GCom.GetChild("fDesc") as GTextField;
        _lstTaskSubItem = GCom.GetChild("lstObject") as GList;
        _lstTaskChainReward = GCom.GetChild("lstTaskChainReward") as GList;
        _lstTaskReward = GCom.GetChild("lstTaskReward") as GList;
        _btnAbandon = GCom.GetChild("btnAbandon") as GButton;
        _btnReceive = GCom.GetChild("btnReceive") as GButton;
        _btnSubmit = GCom.GetChild("btnSubmit") as GButton;

        _lstTaskChainReward.numItems = 0;
        _lstTaskChainReward.itemRenderer = TaskChainRewardItemRenderer;
        _lstTaskReward.numItems = 0;
        _lstTaskReward.itemRenderer = TaskRewardItemRenderer;

        _lstTaskSubItem.numItems = 0;
        _lstTaskSubItem.itemRenderer = ListTaskSubItemRenderer;
    }

    public void SetData(TaskChainData taskChainData)
    {
        if (taskChainData == null)
        {
            return;
        }
        _taskChainData = taskChainData;

        // 寻路任务，开启定时检查坐标
        Message.OnEnterFrame -= OnFramePathFind;
        if (_taskChainData.CurTaskSubPathFindItem != null)
        {
            Message.OnEnterFrame += OnFramePathFind;
        }

        OnUpdateUI();
    }

    private void OnFramePathFind(float obj)
    {
        OnUpdateBtnSubmit();
    }

    // 更新提交按钮状态
    private void OnUpdateBtnSubmit()
    {
        bool isMeet = CheckMeetSubmitCondition();

        string btnName = "RECEIVE";
        // 任务为提交道具，名称为 SUBMIT
        List<TaskDefine.TaskSubItemData> curTaskSubItems = _taskChainData.CurTaskSubItems;
        if (curTaskSubItems.Count == 1 && curTaskSubItems[0].Option.OptionCnf.Kind == TaskType.TaskTypeGetItem)
        {
            btnName = "SUBMIT";
        }

        _btnSubmit.GetController("color").selectedPage = isMeet ? "yellow" : "gray";
        _btnSubmit.GetController("str").selectedPage = btnName;
        _btnSubmit.enabled = isMeet;
    }

    private bool CheckMeetSubmitCondition()
    {
        bool isMeet = false;

        List<TaskDefine.TaskSubItemData> curTaskSubItems = _taskChainData.CurTaskSubItems;
        for (int i = 0; i < curTaskSubItems.Count; i++)
        {
            TaskDefine.TaskSubItemData objectData = curTaskSubItems[i];
            TaskOptionCnf optionCfg = objectData.Option.OptionCnf;

            switch (optionCfg.Kind)
            {
                case TaskType.TaskTypeQuiz:
                case TaskType.TaskTypeKillMonster:
                case TaskType.TaskTypeUseItem:
                case TaskType.TaskTypeOccupiedLand:
                    isMeet = objectData.CurRate >= objectData.MaxRate;
                    break;
                case TaskType.TaskTypeMoveTo:
                    if (DataManager.MainPlayer.Role != null)
                    {
                        // todo RC
                        // DataManager.MainPlayer.Role.Transform.position.x
                        // DataManager.MainPlayer.Role.Transform.position.y
                        int RoleR = 1;
                        int RoleC = 1;
                        TaskOptionMoveTo moveTo = _taskChainData.CurTaskSubPathFindItem.Option.OptionCnf.TarPos;
                        isMeet = moveTo.R == RoleR && moveTo.C == RoleC;
                    }
                    break;
                case TaskType.TaskTypeGetItem:
                    isMeet = true;
                    break;
                case TaskType.TaskTypeUnknown:
                default:
                    isMeet = false;
                    break;
            }
        }
        return isMeet;
    }

    private void OnUpdateUI()
    {
        _ctrTaskState.selectedIndex = (int)_taskChainData.TaskState;
        UpdateUnstart();
        UpdateOnDoing();
        UpdateFinish();
    }

    private void UpdateFinish()
    {
        if (_taskChainData.TaskState != TaskDefine.eTaskState.FINISH)
        {
            return;
        }
    }

    private void UpdateOnDoing()
    {
        if (_taskChainData.TaskState != TaskDefine.eTaskState.ONDOING)
        {
            return;
        }
        _tfTitle.SetVar("title", _taskChainData.DRTask.Name)
            .SetVar("cur", _taskChainData.CurTaskChainRate.ToString())
            .SetVar("max", _taskChainData.MaxTaskChainRate.ToString())
            .FlushVars();

        _tfDesc.text = _taskChainData.DRTask.Decs;
        _lstTaskSubItem.numItems = _taskChainData.CurTaskSubItems.Count;
        _lstTaskChainReward.numItems = _taskChainData.CurTaskRewards.Count;
    }

    private void UpdateUnstart()
    {
        if (_taskChainData.TaskState != TaskDefine.eTaskState.UNSTART)
        {
            return;
        }
        _lstTaskChainReward.numItems = _taskChainData.TaskChainRewards.Count;
    }


    private void TaskChainRewardItemRenderer(int index, GObject item)
    {
        RewardNftData rewardData = _taskChainData.TaskChainRewards[index];
        RewardNftItemRenderer itemRenderer = item as RewardNftItemRenderer;
        itemRenderer.SetData(rewardData);
    }

    private void TaskRewardItemRenderer(int index, GObject item)
    {
        RewardNftData rewardData = _taskChainData.CurTaskRewards[index];
        RewardNftItemRenderer itemRenderer = item as RewardNftItemRenderer;
        itemRenderer.SetData(rewardData);
    }


    private void ListTaskSubItemRenderer(int index, GObject item)
    {

        TaskDefine.TaskSubItemData objectData = _taskChainData.CurTaskSubItems[index];
        GComponent gItem = item.asCom;
        Controller ctrState = gItem.GetController("ctrState");
        GTextField tfTitle = gItem.GetChild("title") as GTextField;

        tfTitle.SetVar("title", objectData.Decs)
            .SetVar("cur", objectData.CurRate.ToString())
            .SetVar("max", objectData.MaxRate.ToString())
            .FlushVars();

        ctrState.selectedPage = objectData.CurRate >= objectData.MaxRate ? "finished" : "unfinished";
    }

    public override void OnOpen()
    {
        base.OnOpen();
        AddEvent();
    }

    public override void OnClose()
    {
        RemoveEvent();
        base.OnClose();
    }

    private void AddEvent()
    {
        _btnReceive.onClick.Add(OnBtnReceiveClick);
        _btnAbandon.onClick.Add(OnBtnAbandonClick);
        _btnSubmit.onClick.Add(OnBtnSubmitClick);
    }

    private void RemoveEvent()
    {
        _btnReceive.onClick.Remove(OnBtnReceiveClick);
        _btnAbandon.onClick.Remove(OnBtnAbandonClick);
        _btnSubmit.onClick.Remove(OnBtnSubmitClick);
        Message.OnEnterFrame -= OnFramePathFind;
    }

    private void OnBtnSubmitClick(EventContext context)
    {
        if (_taskChainData.CurTask.TaskKind == TaskType.TaskTypeGetItem)
        {
            SceneModule.TaskMgr.OpenTaskSubmit(_taskChainData);
            return;
        }
        TaskRewardReceiveAction.Req(_taskChainData.TaskChainKind);
    }

    private void OnBtnAbandonClick(EventContext context)
    {
        AlertData alertData = new("ABANDON", "Are you sure you want to abort the mission?", "", () =>
        {
            TaskAbandonAction.Req(_taskChainData.TaskChainKind);
        });
        _ = UICenter.OpenUIAlert<AlertCommon>(alertData);

    }

    private void OnBtnReceiveClick()
    {
        TaskAcceptAction.Req(_taskChainData.TaskChainKind);
    }
}