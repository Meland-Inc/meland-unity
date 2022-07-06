/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: toast 基类
 * @Date: 2022-07-06 09:51:37
 * @FilePath: /Assets/Src/Framework/UI/FGUIToast.cs
 */
/// <summary>
/// 子类具体实现效果和关闭时序
/// </summary>
public class FGUIToast : FGUIBase
{
    // protected virtual float FadeTime => 1.0f;
    // private float _curTime = 0;
    // private bool _faded = false;
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        GCom.touchable = false;
    }
    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        // _curTime = 0;
    }

    // protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    // {
    //     base.OnUpdate(elapseSeconds, realElapseSeconds);
    //     _curTime += elapseSeconds;
    //     if (!_faded && _curTime >= FadeTime)
    //     {
    //         _faded = true;
    //         OnFade();
    //     }
    // }

    protected virtual void OnFade()
    {
        //开始隐藏toast，隐藏结束后调用Close();
    }
}