

using FairyGUI;
using FairyGUI.Utils;

/// <summary>
/// 任务菜单选项  
/// </summary>

public class TaskMenuItemRender : GButton
{
    public TaskChainData TaskChainData;
    private GTextField _tfSelectedTitle;
    private GTextField _tfNormalTitle;
    private Controller _ctrSelected;
    public override void ConstructFromXML(XML xml)
    {
        base.ConstructFromXML(xml);
        _tfSelectedTitle = GetChild("selectedTitle") as GTextField;
        _tfNormalTitle = GetChild("normalTitle") as GTextField;
        _ctrSelected = GetController("selected");

    }

    public void SetData(TaskChainData taskChainData)
    {
        if (taskChainData == null)
        {
            return;
        }
        TaskChainData = taskChainData;
        OnUpdateUI();
    }

    public void SetSelected(bool isSelected)
    {
        _ctrSelected.selectedPage = isSelected ? "true" : "false";
    }

    private void OnUpdateUI()
    {
        _tfSelectedTitle.text = TaskChainData.TaskChainName;
        _tfNormalTitle.text = TaskChainData.TaskChainName;
    }
}