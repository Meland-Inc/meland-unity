
using System.Collections.Generic;
using FairyGUI;
public class FormTask : FGUIForm
{
    private List<TaskChainData> _taskChains;
    private TaskChainData _curTaskChain;
    private GList _lstTaskMenu;
    private TaskChainViewLogic _taskChainViewLogic;
    private TaskContentViewLogic _taskContentViewLogic;
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        _lstTaskMenu = GetList("lstTaskMenu");
        _taskChainViewLogic = GCom.AddSubUILogic<TaskChainViewLogic>("comTaskChain");
        _taskContentViewLogic = GCom.AddSubUILogic<TaskContentViewLogic>("comTaskContent");

        _lstTaskMenu.itemRenderer = ListItemRenderer;
        _lstTaskMenu.numItems = 0;
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        AddUIEvent();
        InitData();
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        RemoveUIEvent();
        base.OnClose(isShutdown, userData);
    }

    private void InitData()
    {
        _taskChains = DataManager.TaskModel.TaskChainList;
        _curTaskChain = _taskChains[0];
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

    private void OnTaskMenuItemClick(EventContext context)
    {
        if (context.data is not TaskMenuItemRender taskMenuItemRender)
        {
            return;
        }

        _curTaskChain = taskMenuItemRender.TaskChainData;
        taskMenuItemRender.setSelected(true);
    }

    private void OnUpdateUI()
    {
        _lstTaskMenu.numItems = _taskChains.Count;
        _taskContentViewLogic.SetData(_curTaskChain);
        _taskChainViewLogic.setData(_curTaskChain);
    }

    private void ListItemRenderer(int index, GObject item)
    {

        TaskChainData taskChainData = _taskChains[index];
        if (taskChainData == null)
        {
            return;
        }

        TaskMenuItemRender taskMenuItemRender = item as TaskMenuItemRender;
        taskMenuItemRender.setData(taskChainData);
        taskMenuItemRender.setSelected(taskChainData == _curTaskChain);
    }
}