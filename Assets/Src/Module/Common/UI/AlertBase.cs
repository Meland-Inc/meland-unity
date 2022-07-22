
using System;
using FairyGUI;
public class AlertBase : FGUIBase
{
    protected AlertData AlertData;
    protected override FitScreen FitScreenMode => FitScreen.FitSize;//弹窗类型，默认适应屏幕大小
    private GButton _btnOK;
    private GButton _btnClose;
    private GTextField _tfTitle;
    private GTextField _tfContent;
    private string _oriOkBtnText;
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        _btnOK = GCom.GetChild("btnOK") as GButton;
        _btnClose = GCom.GetChild("btnClose") as GButton;
        _tfTitle = GCom.GetChild("tfTitle") as GTextField;
        _tfContent = GCom.GetChild("tfContent") as GTextField;
        _oriOkBtnText = _btnOK.text;
    }



    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        if (userData is AlertData alertData)
        {
            AlertData = alertData;
            if (!string.IsNullOrEmpty(alertData.OKBtnText))
            {
                _btnOK.text = alertData.OKBtnText;
            }
            else
            {
                _btnOK.text = _oriOkBtnText;
            }

            _tfTitle.text = string.IsNullOrEmpty(alertData.Title) ? _tfTitle.text : alertData.Title;
            _tfContent.text = string.IsNullOrEmpty(alertData.Content) ? _tfContent.text : alertData.Content;

        }
        AddUIEvent();

    }

    private void AddUIEvent()
    {
        _btnOK.onClick.Add(onBtnOkClick);
        _btnClose.onClick.Add(Close);
    }
    private void RemoveUIEvent()
    {
        _btnOK.onClick.Remove(onBtnOkClick);
        _btnClose.onClick.Remove(Close);
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        RemoveUIEvent();
        base.OnClose(isShutdown, userData);
    }

    private void onBtnOkClick()
    {
        AlertData.OKBtnCb?.Invoke();
        Close();
    }
}