using UnityEngine;
using FairyGUI;
/// <summary>
/// fgui窗体基类，所有窗体ui都要继承这个类
/// </summary>
public abstract class FGUIForm : FGUIBase
{
    protected override FitScreen FitScreenMode => FitScreen.FitSize;//窗口类型，默认适应屏幕大小

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        GCom.SetSize(Screen.width, Screen.height);
        InitDefaultUIFunc();
    }

    protected override void OnStageResize()
    {
        GCom.SetSize(Screen.width, Screen.height);
    }

    /// <summary>
    /// 初始化
    /// </summary>
    private void InitDefaultUIFunc()
    {
        GButton btnClose = GetButton("btnClose");
        if (btnClose != null)
        {
            btnClose.onClick.Add(OnBtnCloseClick);
        }
    }

    private void OnBtnCloseClick()
    {
        Close();
    }
}
