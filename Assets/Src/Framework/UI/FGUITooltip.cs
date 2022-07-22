/*
 * @Author: mangit
 * @LastEditors: wym
 * @Description: tooltip
 * @Date: 2022-06-22 14:25:03
 * @FilePath: /Assets/Src/Framework/UI/FGUITooltip.cs
 */
using FairyGUI;
using UnityEngine;
/// <summary>
/// tooltip 基类
/// </summary>
public class FGUITooltip : FGUIBase
{
    protected override FitScreen FitScreenMode => FitScreen.None;
    protected TooltipInfo TooltipInfo;
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        TooltipInfo = userData as TooltipInfo;
        if (TooltipInfo == null)
        {
            MLog.Error(eLogTag.ui, "FGUITooltip.OnOpen: userData is not TooltipInfo");
            Close();
            return;
        }

        FitPos();
        Stage.inst.onClick.Add(OnRootClick);
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        Stage.inst.onClick.Remove(OnRootClick);
        base.OnClose(isShutdown, userData);
    }

    /// <summary>
    /// 固定tooltip位置
    /// </summary>
    protected void FitPos()
    {
        if (TooltipInfo == null || TooltipInfo.Reference == null)
        {
            MLog.Warning(eLogTag.ui, "FGUITooltip.FitPos: TooltipInfo or TooltipInfo.Reference is null,Fit to center");
            GCom.x = (UICenter.StageWidth / 2) - (GCom.width / 2);
            GCom.y = (UICenter.StageHeight / 2) - (GCom.height / 2);
            return;
        }

        Debug.Log(Screen.width + " " + Screen.height);
        Rect reference = TooltipInfo.Reference.LocalToGlobal(new Rect(0, 0, TooltipInfo.Reference.width, TooltipInfo.Reference.height));
        switch (TooltipInfo.Dir)
        {
            case eTooltipDir.Top:
                GCom.x = reference.x;
                GCom.y = reference.y - GCom.height;
                break;
            case eTooltipDir.Bottom:
                GCom.x = reference.x;
                GCom.y = reference.y + reference.height;
                break;
            case eTooltipDir.Left:
                GCom.x = reference.x - GCom.width;
                GCom.y = reference.y;
                break;
            case eTooltipDir.Right:
                GCom.x = reference.x + reference.width;
                GCom.y = reference.y;
                break;
            default:
            case eTooltipDir.Auto:
                if (reference.x + GCom.width < UICenter.StageWidth)
                {
                    GCom.x = reference.xMax;
                }
                else
                {
                    GCom.x = reference.xMin - GCom.width;
                }
                if (reference.yMin >= 0)
                {
                    GCom.y = reference.yMin;
                }
                else
                {
                    GCom.y = 0;
                }
                break;
        }
        GCom.x += TooltipInfo.OffsetX;
        GCom.y += TooltipInfo.OffsetY;
    }

    private void OnRootClick()
    {
        if (TooltipInfo.IsTouchRootClose)
        {
            Close();
        }

    }
}
