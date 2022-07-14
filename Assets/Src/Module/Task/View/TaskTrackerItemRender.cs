

using FairyGUI;
using FairyGUI.Utils;

public class TaskTrackerItemRender : GComponent
{

    private TaskChainData _chainData;
    private GTextField _tfTaskChainName;
    private GTextField _tfTaskName;
    private GList _lstObject;
    private Controller _ctrTaskType;
    public override void ConstructFromXML(XML xml)
    {
        base.ConstructFromXML(xml);
        _tfTaskChainName = GetChild("tfTaskChainName") as GTextField;
        _tfTaskName = GetChild("tfTaskName") as GTextField;
        _lstObject = GetChild("lstObject") as GList;
        _ctrTaskType = GetController("ctrTaskType");

        _lstObject.numItems = 0;
        _lstObject.itemRenderer = ObjectiveRender;
    }

    private void ObjectiveRender(int index, GObject item)
    {
        TaskDefine.TaskSubItemData objectData = _chainData.CurTaskSubItems[index];
        GComponent gItem = item.asCom;
        Controller ctrState = gItem.GetController("ctrState");
        GTextField tfTitle = gItem.GetChild("title") as GTextField;

        tfTitle.SetVar("title", objectData.Decs)
            .SetVar("cur", objectData.CurRate.ToString())
            .SetVar("max", objectData.MaxRate.ToString())
            .FlushVars();

        ctrState.selectedPage = objectData.CurRate >= objectData.MaxRate ? "finished" : "unfinished";
    }

    public void SetData(TaskChainData chainData)
    {
        _chainData = chainData;
        // 链名颜色
        _ctrTaskType.selectedPage = _chainData.DRTaskList.System.ToString();
        // 链名
        _tfTaskChainName.SetVar("name", _chainData.TaskChainName).FlushVars();
        // 任务名
        _tfTaskName.SetVar("title", _chainData.DRTask.Name)
            .SetVar("cur", _chainData.CurTaskChainRate.ToString())
            .SetVar("max", _chainData.MaxTaskChainRate.ToString())
            .FlushVars();
        // 小任务列表
        _lstObject.numItems = chainData.CurTaskSubItems.Count;
    }
}