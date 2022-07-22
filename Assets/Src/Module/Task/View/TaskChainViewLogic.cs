
using FairyGUI;

/// <summary>
/// 任务链视图逻辑
/// </summary>
public class TaskChainViewLogic : FGUILogicCpt
{
    private TaskChainData _taskChainData;
    private TaskDefine.eTaskChainState _chainState;
    private GButton _btnBox;
    private Controller _ctrBtnBoxState;
    private Controller _ctrShow;
    // 任务进度
    private GProgressBar _progressBar;
    // 任务倒计时
    private GTextField _tfTime;
    // 小摇晃动画
    private Transition _transLittleRock;
    // 大摇晃动画
    private Transition _transBigRock;

    protected override void OnAdd()
    {
        base.OnAdd();
        _btnBox = GCom.GetChild("btnBox") as GButton;
        _ctrBtnBoxState = _btnBox.GetController("state");
        _tfTime = _btnBox.GetChild("tfTime") as GTextField;

        _ctrShow = GCom.GetController("ctrShow");
        _progressBar = GCom.GetChild("progress") as GProgressBar;
        _transLittleRock = GCom.GetTransition("littleRock");
        _transBigRock = GCom.GetTransition("bigRock");
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
        _btnBox.onClick.Add(onBtnBoxClick);

    }

    private void RemoveEvent()
    {
        _btnBox.onClick.Remove(onBtnBoxClick);
        Message.OnEnterFrame -= OnFrameTimer;
    }

    public void SetData(TaskChainData taskChainData)
    {
        if (taskChainData == null)
        {
            _ctrShow.selectedPage = "false";
            return;
        }
        _taskChainData = taskChainData;
        _chainState = _taskChainData.TaskChainState;

        checkFrameTimer();
        OnUpdateTimeUI(0);
        OnUpdateUI();
    }

    private void checkFrameTimer()
    {
        Message.OnEnterFrame -= OnFrameTimer;
        if (_chainState == TaskDefine.eTaskChainState.ONDOING && _taskChainData.TaskChainKind == MelandGame3.TaskListType.TaskListTypeDaily)
        {
            Message.OnEnterFrame += OnFrameTimer;
        }
    }

    private void onBtnBoxClick(EventContext context)
    {
        // 可领取 请求领取
        if (_chainState == TaskDefine.eTaskChainState.AVAILABLE)
        {
            TaskChainRewardReceiveAction.Req(_taskChainData.TaskChainKind);
            return;
        }
        // 正在进行 弹框展示奖励
        if (_chainState == TaskDefine.eTaskChainState.ONDOING)
        {
            DRLanguage dRLanguage = GFEntry.DataTable.GetDataTable<DRLanguage>().GetDataRow(10090018);
            string content = dRLanguage != null ? dRLanguage.Value : "";
            FormRewardData formVo = new("REWARDS", content, null, null, _taskChainData.TaskChainRewards);
            _ = UICenter.OpenUIForm<FormReward>(formVo);
            return;
        }
    }

    private void OnUpdateUI()
    {
        // show or hide
        if (_chainState == TaskDefine.eTaskChainState.NONE)
        {
            _ctrShow.selectedPage = "false";
            return;
        }
        _ctrShow.selectedPage = "true";

        // 进度条
        _progressBar.max = _taskChainData.MaxTaskChainRate;
        _progressBar.value = _taskChainData.CurTaskChainRate;
        // 宝箱展示样式
        _ctrBtnBoxState.selectedIndex = (int)_chainState;

        _transLittleRock.Stop();
        _transBigRock.Stop();
        if (_chainState == TaskDefine.eTaskChainState.ONDOING)
        {
            _transLittleRock.Play(-1, 0.2f, null);
        }
        else if (_chainState == TaskDefine.eTaskChainState.AVAILABLE)
        {
            _transBigRock.Play(-1, 0.2f, null);
        }
    }

    private void OnFrameTimer(float deltaTime)
    {
        long mSeconds = _taskChainData.TaskChainEndTimeStamp - TimeUtil.GetServerTimeStamp();
        long seconds;
        if (mSeconds <= 0)
        {
            seconds = 0;
            Message.OnEnterFrame -= OnFrameTimer;
        }
        else
        {
            seconds = mSeconds / 1000;
        }

        OnUpdateTimeUI((int)seconds);
    }
    private void OnUpdateTimeUI(int seconds)
    {
        if (seconds <= 0)
        {
            _tfTime.text = "";
            return;
        }
        // 宝箱展示倒计时
        if (_chainState == TaskDefine.eTaskChainState.ONDOING && _taskChainData.TaskChainKind == MelandGame3.TaskListType.TaskListTypeDaily)
        {
            _tfTime.text = TimeUtil.SecondsToHMS(seconds);
            return;
        }
        _tfTime.text = "";

    }
}