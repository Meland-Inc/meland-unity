
using FairyGUI;
public class AlertBase : FGUIBase
{
    protected AlertData _alertData;
    protected override FitScreen FitScreenMode => FitScreen.FitSize;//弹窗类型，默认适应屏幕大小
    private GButton _btnOK;
    private GTextField _tfTitle;
    private GTextField _tfContent;
    private string _oriOkBtnText;
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        if (userData is AlertData alertData)
        {
            _alertData = userData as AlertData;
        }

        _btnOK = GCom.GetChild("btnOK") as GButton;
        _tfTitle = GCom.GetChild("tfTitle") as GTextField;
        _tfContent = GCom.GetChild("tfContent") as GTextField;
        _oriOkBtnText = _btnOK.text;

        _btnOK.onClick.Add(onBtnOkClick);
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        if (userData is AlertData alertData)
        {
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
    }


    protected override void OnClose(bool isShutdown, object userData)
    {
        _btnOK.onClick.Remove(onBtnOkClick);
        base.OnClose(isShutdown, userData);
    }

    private void onBtnOkClick()
    {
        _alertData.OKBtnCb?.Invoke();
        Close();
    }
}