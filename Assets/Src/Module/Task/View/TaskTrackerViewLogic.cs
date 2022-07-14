
using System;
using System.Collections.Generic;
using FairyGUI;

public class TaskTrackerViewLogic : FGUILogicCpt
{
    private List<TaskChainData> _taskChainDatas;
    private GList _lstTaskTracker;
    private Controller _ctrVisible;
    protected override void OnAdd()
    {
        base.OnAdd();
        _lstTaskTracker = GCom.GetChild("lstTaskTracker") as GList;
        _ctrVisible = GCom.GetController("ctrVisible");

        _lstTaskTracker.numItems = 0;
        _lstTaskTracker.itemRenderer = trackerItemRender;
        _ctrVisible.selectedPage = "false";
    }

    private void trackerItemRender(int index, GObject item)
    {
        TaskTrackerItemRender render = (TaskTrackerItemRender)item;
        TaskChainData chainData = _taskChainDatas[index];
        render.SetData(chainData);
    }

    public override void OnOpen()
    {
        SceneModule.TaskMgr.OnUpdateTaskChainData += OnUpdateData;
    }

    public override void OnClose()
    {
        SceneModule.TaskMgr.OnUpdateTaskChainData -= OnUpdateData;
    }

    private void OnUpdateData()
    {
        _taskChainDatas = DataManager.TaskModel.TaskChainList;
        if (_taskChainDatas == null || _taskChainDatas.Count <= 0)
        {
            _ctrVisible.selectedPage = "false";
            return;
        }

        _ctrVisible.selectedPage = "true";
        _lstTaskTracker.numItems = _taskChainDatas.Count;

    }
}