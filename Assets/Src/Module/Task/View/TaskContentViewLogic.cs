using System;
using System.Collections.Generic;
using System.IO;
using FairyGUI;
public class TaskContentViewLogic : FGUILogicCpt
{
    private TaskChainData _taskChainData;
    private Controller _ctrTaskState;
    private GTextField _tfTitle;
    private GTextField _tfDesc;
    private GList _lstObject;
    private GList _lstTaskChainReward;
    private GList _lstTaskReward;
    private GButton _btnAbandon;
    private GButton _btnReceive;
    private GButton _btnSubmit;
    protected override void OnAdd()
    {
        base.OnAdd();
        _ctrTaskState = GCom.GetController("ctrTaskState");
        _tfDesc = GCom.GetChild("fDesc") as GTextField;
        _lstObject = GCom.GetChild("lstObject") as GList;
        _lstTaskChainReward = GCom.GetChild("lstTaskChainReward") as GList;
        _lstTaskReward = GCom.GetChild("lstTaskReward") as GList;
        _btnAbandon = GCom.GetChild("btnAbandon") as GButton;
        _btnReceive = GCom.GetChild("btnReceive") as GButton;
        _btnSubmit = GCom.GetChild("btnSubmit") as GButton;

        _lstTaskChainReward.numItems = 0;
        _lstTaskChainReward.itemRenderer = TaskChainRewardItemRenderer;
        _lstTaskReward.numItems = 0;
        _lstTaskReward.itemRenderer = TaskRewardItemRenderer;

        _lstObject.numItems = 0;
        _lstObject.itemRenderer = ListObjectItemRenderer;
    }

    public void SetData(TaskChainData taskChainData)
    {
        _taskChainData = taskChainData;
        OnUpdateUI();
    }

    public void Update()
    {

        if (DataManager.MainPlayer.Role == null)
        {
            return;
        }
        if (_taskChainData == null)
        {
            return;
        }
        if (_taskChainData.CurTaskObjectivePathFind == null)
        {
            return;
        }
        // todo RC
        // DataManager.MainPlayer.Role.Transform.position.x
        // DataManager.MainPlayer.Role.Transform.position.y
        int R = 1;
        int C = 1;
        Bian.TaskOptionMoveTo moveTo = _taskChainData.CurTaskObjectivePathFind.Option.OptionCnf.TarPos;
        if (moveTo.R == R && moveTo.C == C)
        {

        }

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
            .SetVar("cur", _taskChainData.CurChainRate.ToString())
            .SetVar("max", _taskChainData.MaxChainRate.ToString())
            .FlushVars();

        _tfDesc.text = _taskChainData.DRTask.Decs;
        // _lstObject.numItems
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


    private void ListObjectItemRenderer(int index, GObject item)
    {

        TaskDefine.TaskObjectData objectData = _taskChainData.CurTaskObjectives[index];
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
        AddUIEvent();
    }

    public override void OnClose()
    {
        RemoveUIEvent();
        base.OnClose();
    }

    private void AddUIEvent()
    {
        _btnReceive.onClick.Add(OnBtnReceiveClick);
        _btnAbandon.onClick.Add(OnBtnAbandonClick);
        _btnSubmit.onClick.Add(OnBtnSubmitClick);
    }

    private void RemoveUIEvent()
    {
        _btnReceive.onClick.Remove(OnBtnReceiveClick);
        _btnAbandon.onClick.Remove(OnBtnAbandonClick);
        _btnSubmit.onClick.Remove(OnBtnSubmitClick);
    }

    private void OnBtnSubmitClick(EventContext context)
    {
        if (_taskChainData.CurTask.TaskKind == Bian.TaskType.TaskTypeGetItem)
        {
            SceneModule.TaskMgr.OpenTaskSubmit(_taskChainData);
            return;
        }
        TaskRewardReceiveAction.Req(_taskChainData.TaskChainKind, _taskChainData.CurTask.TaskId, _taskChainData.CurTask.TaskKind);
    }

    private void OnBtnAbandonClick(EventContext context)
    {
        AlertData alertData = new("ABANDON", "Are you sure you want to abort the mission?", "", () =>
        {
            TaskAbandonAction.Req(_taskChainData.TaskChainKind, _taskChainData.TaskChainId);
        });
        _ = UICenter.OpenUIAlert<AlertCommon>(alertData);

    }

    private void OnBtnReceiveClick()
    {
        TaskAcceptAction.Req(_taskChainData.TaskChainKind);
    }
}