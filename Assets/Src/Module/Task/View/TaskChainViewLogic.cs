
using System;
using FairyGUI;
public class TaskChainViewLogic : FGUILogicCpt
{
    private TaskChainData _taskChainData;
    private GButton _btnBox;
    private Controller _ctrBtnBoxState;
    private Controller _ctrShow;
    private GProgressBar _progressBar;
    private GTextField _tfTime;


    protected override void OnAdd()
    {
        base.OnAdd();
        _btnBox = GCom.GetChild("btnBox") as GButton;
        _ctrBtnBoxState = _btnBox.GetController("state");
        _tfTime = _btnBox.GetChild("tfTime") as GTextField;

        _ctrShow = GCom.GetController("ctrShow");
        _progressBar = GCom.GetChild("progress") as GProgressBar;
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
        _btnBox.onClick.Add(onBtnBoxClick);
    }

    private void RemoveUIEvent()
    {
        _btnBox.onClick.Remove(onBtnBoxClick);
    }

    private void onBtnBoxClick(EventContext context)
    {
        TaskDefine.eTaskChainBoxState boxState = _taskChainData.ChainBoxState;
        // 已领取
        if (boxState == TaskDefine.eTaskChainBoxState.HADRECEIVE)
        {
            return;
        }
        // 可领取
        if (boxState == TaskDefine.eTaskChainBoxState.AVAILABLE)
        {
            TaskChainRewardReceiveAction.Req(_taskChainData.TaskChainKind);
            return;
        }
        // 正在进行
        if (boxState == TaskDefine.eTaskChainBoxState.ONDOING)
        {
            AlertRewardData alertVo = new("REWARDS", "REWARDS", "", null, _taskChainData.TaskChainRewards);
            _ = UICenter.OpenUIAlert<AlertReward>(alertVo);
            return;
        }

    }

    internal void setData(TaskChainData curTaskChain)
    {
        _taskChainData = curTaskChain;
        OnUpdateUI();
    }

    private void OnUpdateUI()
    {
        TaskDefine.eTaskChainBoxState boxState = _taskChainData.ChainBoxState;

        // show or hide
        if (boxState == TaskDefine.eTaskChainBoxState.NONE)
        {
            _ctrShow.selectedPage = "false";
            return;
        }
        _ctrShow.selectedPage = "true";

        // 进度条
        _progressBar.max = _taskChainData.MaxChainRate;
        _progressBar.value = _taskChainData.CurChainRate;

        // 宝箱展示样式
        _ctrBtnBoxState.selectedIndex = (int)boxState;

        // 宝箱展示倒计时
        if (boxState == TaskDefine.eTaskChainBoxState.ONDOING)
        {
            if (_taskChainData.TaskChainKind == Bian.TaskListType.TaskListTypeRewarded)
            {
                _tfTime.text = "";
            }
            else
            {
                _tfTime.text = "00:00:00";
            }
        }
    }
}