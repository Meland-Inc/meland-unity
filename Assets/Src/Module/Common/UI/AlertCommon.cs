/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 通用弹窗
 * @Date: 2022-07-04 17:24:42
 * @FilePath: /Assets/Src/Module/Common/UI/AlertCommon.cs
 */
using FairyGUI;
public class AlertCommon : FGUIBase
{
    private GButton _btnOK;
    private GTextField _tfTitle;
    private GTextField _tfContent;
    private string _oriOkBtnText;
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        _btnOK = GCom.GetChild("btnOK") as GButton;
        _tfTitle = GCom.GetChild("tfTitle") as GTextField;
        _tfContent = GCom.GetChild("tfContent") as GTextField;
        _oriOkBtnText = _btnOK.text;

        _btnOK.onClick.Add(Close);
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
}