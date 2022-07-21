using System.Collections.Generic;
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
        OnUpdateUI();
    }

    // 更新提交按钮状态
    private void OnUpdateBtnSubmit()
    {
        bool isCanTouch;
        string btnName = TaskDefine.eTaskButton.RECEIVE.ToString();

        TaskDefine.TaskSubItemData curTaskSubSubmitItem = _taskChainData.CurTaskSubSubmitItem;
        // 子任务有 提交道具类型，且任务未完成，需要打开界面去提交，名称为 SUBMIT
        if (curTaskSubSubmitItem != null && curTaskSubSubmitItem.CurRate < curTaskSubSubmitItem.MaxRate)
        {
            btnName = TaskDefine.eTaskButton.SUBMIT.ToString();
            isCanTouch = true;
        }
        else
        {
            isCanTouch = CheckIfAllSubItemMeet();
        }

        _btnSubmit.GetController("ctrColor").selectedPage = isCanTouch ? "yellow" : "gray";
        _btnSubmit.GetController("ctrStr").selectedPage = btnName;
        _btnSubmit.touchable = isCanTouch;
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
        _tfTitle.text = _taskChainData.DRTask.Name;

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
        GLoader glIcon = gItem.GetChild("icon") as GLoader;
        Controller ctrHasIcon = gItem.GetController("ctrHasIcon");

        ctrHasIcon.selectedPage = string.IsNullOrEmpty(objectData.Icon) ? "false" : "true";
        glIcon.icon = objectData.Icon;

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
        _lstTaskChainReward.onClickItem.Add(OnListRewardItemClick);
        _lstTaskReward.onClickItem.Add(OnListRewardItemClick);
    }

    private void RemoveEvent()
    {
        _btnReceive.onClick.Remove(OnBtnReceiveClick);
        _btnAbandon.onClick.Remove(OnBtnAbandonClick);
        _btnSubmit.onClick.Remove(OnBtnSubmitClick);
        _lstTaskChainReward.onClickItem.Remove(OnListRewardItemClick);
        _lstTaskReward.onClickItem.Remove(OnListRewardItemClick);
    }

    private void OnListRewardItemClick(EventContext context)
    {
        RewardNftItemRenderer itemRenderer = (RewardNftItemRenderer)context.data;
        _ = UICenter.OpenUITooltip<TooltipItem>(new TooltipInfo(itemRenderer, itemRenderer.ItemData.Cid, eTooltipDir.Right));
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
            // if (_taskChainData.DRTaskList.CostMELD > SceneModule.Recharge.Meld)
            // {
            //     _ = UICenter.OpenUIToast<ToastCommon>("Meld insufficient");
            //     return;
            // }
            TaskAcceptAction.Req(_taskChainData.TaskChainKind);
        }
    }
}
