using FairyGUI;
/// <summary>
/// 主界面 大世界界面
/// </summary>
public class ComMainBigWorld : FGUILogicCpt
{
    private GList _lstBtnMenu;

    protected override void OnAdd()
    {
        base.OnAdd();

        _lstBtnMenu = (GList)GCom.GetChild("lstBtnMenu");
        _lstBtnMenu.GetChild("btnSynthetic").onClick.Add(OnBtnSyntheticClick);
    }

    private void OnBtnSyntheticClick()
    {
        SceneModule.Craft.OpenFormCraft();
    }
}