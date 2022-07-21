

using FairyGUI;
using FairyGUI.Utils;

/// <summary>
/// 子任务  
/// </summary>

public class TaskSubItemRender : GComponent
{
    public TaskDefine.TaskSubItemData subItemData;
    private Controller ctrState;
    private GTextField tfTitle;
    public GLoader glIcon;
    private Controller ctrHasIcon;
    public override void ConstructFromXML(XML xml)
    {
        base.ConstructFromXML(xml);
        ctrState = GetController("ctrState");
        tfTitle = GetChild("title") as GTextField;
        glIcon = GetChild("icon") as GLoader;
        ctrHasIcon = GetController("ctrHasIcon");
    }

    public void SetData(TaskDefine.TaskSubItemData objectData)
    {
        if (objectData == null)
        {
            return;
        }
        subItemData = objectData;
        OnUpdateUI();
    }


    private void OnUpdateUI()
    {

        ctrHasIcon.selectedPage = string.IsNullOrEmpty(subItemData.Icon) ? "false" : "true";
        glIcon.icon = subItemData.Icon;

        tfTitle.SetVar("title", subItemData.Decs)
            .SetVar("cur", subItemData.CurRate.ToString())
            .SetVar("max", subItemData.MaxRate.ToString())
            .FlushVars();

        ctrState.selectedPage = subItemData.CurRate >= subItemData.MaxRate ? "finished" : "unfinished";
    }
}