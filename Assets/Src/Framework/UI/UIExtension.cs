using System.Collections.Generic;
using UnityGameFramework.Runtime;
using UnityEngine;
public static class UIExtension
{
    public static int OpenUIForm(this UIComponent uiCom, eFormID formID)
    {
        return uiCom.OpenUIForm(formID, UIGroups.FORM);
    }

    public static int OpenUITooltip(this UIComponent uiCom, eFormID formID)
    {
        return uiCom.OpenUIForm(formID, UIGroups.TOOL_TIP);
    }

    public static int OpenUIToast(this UIComponent uiCom, eFormID formID)
    {
        return uiCom.OpenUIForm(formID, UIGroups.TOAST);
    }

    public static int OpenUIAlert(this UIComponent uiCom, eFormID formID)
    {
        return uiCom.OpenUIForm(formID, UIGroups.DIALOG);
    }

    public static int OpenUIDialog(this UIComponent uiCom, eFormID formID)
    {
        return uiCom.OpenUIForm(formID, UIGroups.ALERT);
    }

    public static int OpenUILog(this UIComponent uiCom, eFormID formID)
    {
        return uiCom.OpenUIForm(formID, UIGroups.LOG);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="uiCom"></param>
    /// <param name="formID">窗体的枚举ID</param>
    /// <param name="groupName">窗体所在的组</param>
    /// <returns>int 窗体的序列号</returns>
    private static int OpenUIForm(this UIComponent uiCom, eFormID formID, string groupName)
    {
        string assetName = BasicModule.FGUIMgrCenter.GetFormAsset(eFormID.main);
        if (string.IsNullOrEmpty(assetName))
        {
            Debug.LogWarning("asset name is empty,formID: " + formID);
            return -1;
        }

        int serialID = uiCom.OpenUIForm(assetName, groupName);
        BasicModule.FGUIMgrCenter.SetFormCacheID(formID, serialID);
        return serialID;
    }
    /// <summary>
    /// 关闭窗体用统一FormID就行了
    /// </summary>
    /// <param name="uiCom"></param>
    /// <param name="formID"></param>
    public static void CloseUIForm(this UIComponent uiCom, eFormID formID)
    {
        int serialID = BasicModule.FGUIMgrCenter.GetFormCacheID(formID);
        uiCom.CloseUIForm(serialID);
    }
}