/// <summary>
/// 主界面
/// </summary>
public class FormMain : FGUIForm
{
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        MLog.Debug(eLogTag.ui, userData);
        _ = GCom.AddSubUILogic<ComMainBagShortcut>();
    }
}