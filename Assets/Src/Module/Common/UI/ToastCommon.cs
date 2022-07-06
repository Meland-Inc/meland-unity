/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 通用toast
 * @Date: 2022-07-06 10:05:57
 * @FilePath: /Assets/Src/Module/Common/UI/ToastCommon.cs
 */
using FairyGUI;
public class ToastCommon : FGUIToast
{
    private GTextField _tfText;
    private Transition _trans;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        _tfText = GetTextField("tfText");
        _trans = GCom.GetTransition("show");
    }
    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        GCom.x = UICenter.StageWidth / 2 - GCom.width / 2;
        GCom.y = UICenter.StageHeight * 0.25f;
        _trans.Play(OnPlayCompleted);
        if (userData is string text)
        {
            _tfText.text = text;
        }
    }

    private void OnPlayCompleted()
    {
        if (IsDisposed)
        {
            return;
        }

        Close();
    }
}