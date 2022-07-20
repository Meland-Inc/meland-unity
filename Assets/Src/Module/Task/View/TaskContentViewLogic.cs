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
    private Controller _ctrShow;
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
        _ctrShow = GCom.GetController("ctrShow");
        _tfTitle = GCom.GetChild("tfTitle") as GTextField;
        _tfDesc = GCom.GetChild("tfDesc") as GTextField;
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
            _ctrShow.selectedPage = "false";
            return;
        }
        _ctrShow.selectedPage = "true";
        _taskChainData = taskChainData;

        checkPathFindTaskTimer();
        OnUpdateUI();
    }


    private void checkPathFindTaskTimer()
    {
        // 寻路任务，开启定时检查坐标
        Message.OnEnterFrame -= OnFrameCheckPathFind;
        TaskDefine.TaskSubItemData curTaskSubPathFindItem = _taskChainData.CurTaskSubPathFindItem;
        if (curTaskSubPathFindItem != null && curTaskSubPathFindItem.CurRate < curTaskSubPathFindItem.MaxRate)
        {
            Message.OnEnterFrame += OnFrameCheckPathFind;
        }
    }

    private void OnFrameCheckPathFind(float obj)
    {
        OnUpdateBtnSubmit();
    }

    // 更新提交按钮状态
    private void OnUpdateBtnSubmit()
    {
        bool isMeet;
        string btnName = TaskDefine.eTaskButton.RECEIVE.ToString();

        TaskDefine.TaskSubItemData curTaskSubPathFindItem = _taskChainData.CurTaskSubPathFindItem;
        TaskDefine.TaskSubItemData curTaskSubSubmitItem = _taskChainData.CurTaskSubSubmitItem;
        // 子任务有 提交道具类型，且任务未完成，名称为 SUBMIT
        if (curTaskSubSubmitItem != null && curTaskSubSubmitItem.CurRate < curTaskSubSubmitItem.MaxRate)
        {
            btnName = TaskDefine.eTaskButton.SUBMIT.ToString();
            isMeet = true;
        }
        else if (curTaskSubPathFindItem != null && curTaskSubPathFindItem.CurRate < curTaskSubPathFindItem.MaxRate)
        {
            btnName = TaskDefine.eTaskButton.ARRIVE.ToString();
            // DataManager.MainPlayer.Role.Transform.position.x
            // DataManager.MainPlayer.Role.Transform.position.y
            int RoleR = TaskDefine.TEST_R;
            int RoleC = TaskDefine.TEST_C;
            TaskOptionMoveTo moveTo = _taskChainData.CurTaskSubPathFindItem.Option.OptionCnf.TarPos;
            isMeet = moveTo.R == RoleR && moveTo.C == RoleC;
        }
        else
        {
            isMeet = CheckIfAllSubItemMeet();
        }

        _btnSubmit.GetController("ctrColor").selectedPage = isMeet ? "yellow" : "gray";
        _btnSubmit.GetController("ctrStr").selectedPage = btnName;
        _btnSubmit.touchable = isMeet;
    }

    // 检查所有子任务是否全部完成
    private bool CheckIfAllSubItemMeet()
    {
        List<TaskDefine.TaskSubItemData> curTaskSubItems = _taskChainData.CurTaskSubItems;
        for (int i = 0; i < curTaskSubItems.Count; i++)
        {
            TaskDefine.TaskSubItemData objectData = curTaskSubItems[i];
            if (objectData.CurRate < objectData.MaxRate)
            {
                return false;
            }
        }
        return true;
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
        OnUpdateBtnSubmit();
        _tfTitle.SetVar("title", _taskChainData.DRTask.Name)
            .SetVar("cur", _taskChainData.CurTaskChainRate.ToString())
            .SetVar("max", _taskChainData.MaxTaskChainRate.ToString())
            .FlushVars();

        _tfDesc.text = _taskChainData.DRTask.Details;
        _lstTaskSubItem.numItems = _taskChainData.CurTaskSubItems.Count;
        _lstTaskReward.numItems = _taskChainData.CurTaskRewards.Count;

        _lstTaskReward.ResizeToFit();
        _lstTaskSubItem.ResizeToFit();
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
        ResetUI();
    }

    public override void OnClose()
    {
        RemoveEvent();
        base.OnClose();
    }

    private void ResetUI()
    {
        _btnSubmit.GetController("ctrColor").selectedPage = "gray";
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
        Message.OnEnterFrame -= OnFrameCheckPathFind;
    }

    private void OnBtnSubmitClick(EventContext context)
    {
        // 提交道具类型（且未完成），打开提交界面
        TaskDefine.TaskSubItemData curTaskSubSubmitItem = _taskChainData.CurTaskSubSubmitItem;
        if (curTaskSubSubmitItem != null && curTaskSubSubmitItem.CurRate < curTaskSubSubmitItem.MaxRate)
        {
            SceneModule.TaskMgr.OpenTaskSubmit(_taskChainData);
            return;
        }

        TaskDefine.TaskSubItemData curTaskSubPathFindItem = _taskChainData.CurTaskSubPathFindItem;
        if (curTaskSubPathFindItem != null && curTaskSubPathFindItem.CurRate < curTaskSubPathFindItem.MaxRate)
        {
            TaskUpgradeTaskProgressAction.ReqPos(_taskChainData.TaskChainKind, TaskDefine.TEST_R, TaskDefine.TEST_C);
            return;
        }


        // 直接请求完成
        TaskRewardReceiveAction.Req(_taskChainData.TaskChainKind);
    }

    private void OnBtnAbandonClick(EventContext context)
    {
        DRLanguage dRLanguage = GFEntry.DataTable.GetDataTable<DRLanguage>().GetDataRow(10090020);
        string content = dRLanguage != null ? dRLanguage.Value : "";
        AlertData alertData = new("ABANDON", content, "", () =>
        {
            if (TimeUtil.GetServerTimeStamp() <= _taskChainData.TaskCanAbandonTimeStamp)
            {
                DRLanguage fiveMinRLanguage = GFEntry.DataTable.GetDataTable<DRLanguage>().GetDataRow(10090021);
                string fiveMincontent = fiveMinRLanguage != null ? fiveMinRLanguage.Value : "";
                _ = UICenter.OpenUIToast<ToastCommon>(fiveMincontent);
                return;
            }
            TaskAbandonAction.Req(_taskChainData.TaskChainKind);
        });
        _ = UICenter.OpenUIAlert<AlertCommon>(alertData);

    }

    private void OnBtnReceiveClick()
    {
        // 主动领取任务，需要进行meld检查
        if ((!_taskChainData.RawSvrData.Doing && _taskChainData.RawSvrData.CanReceive)
            || (_taskChainData.RawSvrData.Doing && _taskChainData.RawSvrData.CurTask == null))
        {
            // todo
            // if (_taskChainData.DRTaskList.CostMELD > SceneModule.Craft.MeldCount)
            // {
            //     _ = UICenter.OpenUIToast<ToastCommon>("Meld insufficient"); 
            //     return;
            // }
            TaskAcceptAction.Req(_taskChainData.TaskChainKind);
        }
    }
}