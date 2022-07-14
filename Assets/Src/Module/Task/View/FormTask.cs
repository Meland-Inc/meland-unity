
using System.Collections.Generic;
using FairyGUI;
public class FormTask : FGUIForm
{
    private List<TaskChainData> _taskChains;
    private TaskChainData _curSelectedTaskChain;
    private GList _lstTaskMenu;
    private TaskChainViewLogic _taskChainViewLogic;
    private TaskContentViewLogic _taskContentViewLogic;
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        _lstTaskMenu = GetList("lstTaskMenu");
        _taskChainViewLogic = GCom.AddSubUILogic<TaskChainViewLogic>("comTaskChain");
        _taskContentViewLogic = GCom.AddSubUILogic<TaskContentViewLogic>("comTaskContent");

        _lstTaskMenu.itemRenderer = ListMenuItemRenderer;
        _lstTaskMenu.numItems = 0;
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        AddUIEvent();
        AddDataAction();
        UpdateData();
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        RemoveUIEvent();
        RemoveDataAction();
        base.OnClose(isShutdown, userData);
    }

    private void UpdateData()
    {
        _taskChains = DataManager.TaskModel.TaskChainList;
        if (_taskChains == null || _taskChains.Count <= 0)
        {
            return;
        }
        if (_curSelectedTaskChain == null)
        {
            // select default
            _curSelectedTaskChain = _taskChains[0];
        }

        OnUpdateUI();
    }

    private void AddUIEvent()
    {
        _lstTaskMenu.onClickItem.Add(OnTaskMenuItemClick);
    }

    private void RemoveUIEvent()
    {
        _lstTaskMenu.onClickItem.Remove(OnTaskMenuItemClick);
    }

    private void AddDataAction()
    {
        SceneModule.TaskMgr.OnInitTaskChainData += UpdateData;
        SceneModule.TaskMgr.OnUpdateTaskChainData += UpdateData;
    }
    private void RemoveDataAction()
    {
        SceneModule.TaskMgr.OnInitTaskChainData -= UpdateData;
        SceneModule.TaskMgr.OnUpdateTaskChainData -= UpdateData;
    }

    private void OnTaskMenuItemClick(EventContext context)
    {
        TaskMenuItemRender render = (TaskMenuItemRender)context.data;
        render.SetSelected(true);

        _curSelectedTaskChain = render.TaskChainData;
        OnUpdateUI();
    }

    private void OnUpdateUI()
    {
        if (_taskChains == null)
        {
            return;
        }
        _lstTaskMenu.numItems = _taskChains.Count;
        _taskContentViewLogic.SetData(_curSelectedTaskChain);
        _taskChainViewLogic.SetData(_curSelectedTaskChain);
    }

    private void ListMenuItemRenderer(int index, GObject item)
    {
        TaskChainData taskChainData = _taskChains[index];
        TaskMenuItemRender taskMenuItemRender = (TaskMenuItemRender)item;
        taskMenuItemRender.SetData(taskChainData);
        taskMenuItemRender.SetSelected(taskChainData == _curSelectedTaskChain);
    }
}