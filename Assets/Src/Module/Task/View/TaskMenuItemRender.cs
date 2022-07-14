

using FairyGUI;
using FairyGUI.Utils;

public class TaskMenuItemRender : GButton
{
    public TaskChainData TaskChainData;
    private GTextField tfSelectedTitle;
    private GTextField tfNormalTitle;
    private Controller ctrSelected;
    public override void ConstructFromXML(XML xml)
    {
        base.ConstructFromXML(xml);
        tfSelectedTitle = GetChild("selectedTitle") as GTextField;
        tfNormalTitle = GetChild("normalTitle") as GTextField;
        ctrSelected = GetController("selected");

    }

    public void setData(TaskChainData taskChainData)
    {
        TaskChainData = taskChainData;
        OnUpdateUI();
    }

    public void setSelected(bool isSelected)
    {
        // ctrSelected.selectedPage = taskChainData == _curTaskChain ? "true" : "false";
        ctrSelected.selectedPage = isSelected ? "true" : "false";
    }

    private void OnUpdateUI()
    {
        tfSelectedTitle.text = TaskChainData.TaskChainName;
        tfNormalTitle.text = TaskChainData.TaskChainName;
    }
}