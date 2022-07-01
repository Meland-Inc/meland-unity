public class ComMainBagShortcut : FGUILogicCpt
{
    protected override void OnAdd()
    {
        base.OnAdd();
        GCom.GetChild("btnBag").onClick.Add(OnBtnBagClick);
    }

    protected override void OnRemove()
    {
        base.OnRemove();
    }

    private void OnBtnBagClick()
    {
        MLog.Debug(eLogTag.ui, "OnClickBtnBag");
        SceneModule.BackpackMgr.OpenBackpack();
    }
}