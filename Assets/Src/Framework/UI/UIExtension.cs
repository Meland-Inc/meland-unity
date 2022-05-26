using UnityGameFramework.Runtime;
public static class UIExtension
{
    public static int OpenUIForm<T>(this UIComponent uiCom) where T : FGUIForm, new()
    {
        return uiCom.OpenUIForm<T>(eUIGroup.Form);
    }

    public static int OpenUIForm<T>(this UIComponent uiCom, object userData) where T : FGUIForm, new()
    {
        return uiCom.OpenUIForm<T>(eUIGroup.Form, userData);
    }

    public static int OpenUITooltip<T>(this UIComponent uiCom) where T : FGUIForm, new()
    {
        return uiCom.OpenUIForm<T>(eUIGroup.Tooltip);
    }

    public static int OpenUITooltip<T>(this UIComponent uiCom, object userData) where T : FGUIForm, new()
    {
        return uiCom.OpenUIForm<T>(eUIGroup.Tooltip, userData);
    }

    public static int OpenUIToast<T>(this UIComponent uiCom) where T : FGUIForm, new()
    {
        return uiCom.OpenUIForm<T>(eUIGroup.Toast);
    }

    public static int OpenUIToast<T>(this UIComponent uiCom, object userData) where T : FGUIForm, new()
    {
        return uiCom.OpenUIForm<T>(eUIGroup.Toast, userData);
    }

    public static int OpenUIAlert<T>(this UIComponent uiCom) where T : FGUIForm, new()
    {
        return uiCom.OpenUIForm<T>(eUIGroup.Alert);
    }

    public static int OpenUIAlert<T>(this UIComponent uiCom, object userData) where T : FGUIForm, new()
    {
        return uiCom.OpenUIForm<T>(eUIGroup.Alert, userData);
    }

    public static int OpenUIDialog<T>(this UIComponent uiCom) where T : FGUIForm, new()
    {
        return uiCom.OpenUIForm<T>(eUIGroup.Dialog);
    }

    public static int OpenUIDialog<T>(this UIComponent uiCom, object userData) where T : FGUIForm, new()
    {
        return uiCom.OpenUIForm<T>(eUIGroup.Dialog, userData);
    }

    public static int OpenUILog<T>(this UIComponent uiCom) where T : FGUIForm, new()
    {
        return uiCom.OpenUIForm<T>(eUIGroup.Log);
    }

    public static int OpenUILog<T>(this UIComponent uiCom, object userData) where T : FGUIForm, new()
    {
        return uiCom.OpenUIForm<T>(eUIGroup.Log, userData);
    }

    /// <summary>
    /// 通过窗体class name打开窗体
    /// </summary>
    /// <param name="uiCom"></param>
    /// <param name="formID">窗体的枚举ID</param>
    /// <param name="groupName">窗体所在的组</param>
    /// <param name="userData">传递给窗体的数据</param>
    /// <typeparam name="T">窗体class</typeparam> 
    /// <returns>int 窗体的序列号</returns>
    public static int OpenUIForm<T>(this UIComponent uiCom, eUIGroup group) where T : FGUIForm, new()
    {
        return uiCom.OpenUIForm<T>(group, null);
    }

    /// <summary>
    /// 通过窗体class name打开窗体
    /// </summary>
    /// <param name="uiCom"></param>
    /// <param name="formID">窗体的枚举ID</param>
    /// <param name="groupName">窗体所在的组</param>
    /// <param name="userData">传递给窗体的数据</param>
    /// <typeparam name="T">窗体class</typeparam> 
    /// <returns>int 窗体的序列号</returns>
    public static int OpenUIForm<T>(this UIComponent uiCom, eUIGroup group, object userData) where T : FGUIForm, new()
    {
        string assetName = BasicModule.UICenter.GetFormAsset<T>();
        if (string.IsNullOrEmpty(assetName))
        {
            MLog.Error(eLogTag.ui, "asset name is empty,formID: " + assetName);
            return -1;
        }

        string groupName = group.ToString();
        if (!uiCom.HasUIGroup(groupName))
        {
            bool addGroup = uiCom.AddUIGroup(groupName, (int)group);
            if (!addGroup)
            {
                MLog.Error(eLogTag.ui, "add group failed,groupName: " + groupName);
                return -1;
            }
        }

        int serialID = uiCom.OpenUIForm(assetName, groupName, userData);
        BasicModule.UICenter.SetFormCacheID<T>(serialID);
        return serialID;
    }

    /// <summary>
    /// 通过窗体class name关闭窗体
    /// </summary>
    /// <param name="uiCom"></param>
    /// <typeparam name="T">窗体class</typeparam>
    public static void CloseUIForm<T>(this UIComponent uiCom) where T : FGUIForm, new()
    {
        int serialID = BasicModule.UICenter.GetFormCacheID<T>();
        uiCom.CloseUIForm(serialID);
    }
}