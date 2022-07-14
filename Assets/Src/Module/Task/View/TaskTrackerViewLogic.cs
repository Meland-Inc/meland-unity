
using System;
using System.Collections.Generic;
using FairyGUI;

public class TaskTrackerViewLogic : FGUILogicCpt
{
    private readonly List<TaskChainData> _onDoingTaskChainDatas = new();
    private GList _lstTaskTracker;
    private Controller _ctrVisible;
    protected override void OnAdd()
    {
        base.OnAdd();
        _lstTaskTracker = GCom.GetChild("lstTaskTracker") as GList;
        _ctrVisible = GCom.GetController("ctrVisible");

        _lstTaskTracker.numItems = 0;
        _lstTaskTracker.itemRenderer = TrackerItemRender;
        _ctrVisible.selectedPage = "false";
    }

    private void TrackerItemRender(int index, GObject item)
    {
        TaskTrackerItemRender render = (TaskTrackerItemRender)item;
        TaskChainData chainData = _onDoingTaskChainDatas[index];
        render.SetData(chainData);
    }

    public override void OnOpen()
    {
        SceneModule.TaskMgr.OnUpdateTaskChainData += OnUpdateData;
        SceneModule.TaskMgr.OnInitTaskChainData += OnUpdateData;
        OnUpdateData();
    }

    public override void OnClose()
    {
        SceneModule.TaskMgr.OnUpdateTaskChainData -= OnUpdateData;
        SceneModule.TaskMgr.OnInitTaskChainData -= OnUpdateData;
    }

    private void OnUpdateData()
    {
        List<TaskChainData> chainDatas = DataManager.TaskModel.TaskChainList;

        _onDoingTaskChainDatas.Clear();
        chainDatas.ForEach(chainData =>
        {
            if (chainData.TaskState == TaskDefine.eTaskState.ONDOING)
            {
                _onDoingTaskChainDatas.Add(chainData);
            }
        });

        if (_onDoingTaskChainDatas.Count <= 0)
        {
            _ctrVisible.selectedPage = "false";
            return;
        }

        _ctrVisible.selectedPage = "true";
        _lstTaskTracker.numItems = _onDoingTaskChainDatas.Count;

    }
}