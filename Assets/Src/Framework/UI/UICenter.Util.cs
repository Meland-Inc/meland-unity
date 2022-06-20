/*
 * @Author: mangit
 * @LastEditTime: 2022-06-15 16:43:42
 * @LastEditors: mangit
 * @Description: UI 工具类
 * @Date: 2022-06-15 16:19:22
 * @FilePath: /Assets/Src/Framework/UI/UICenter.Util.cs
 */
using UnityGameFramework.Runtime;

public partial class UICenter
{
    public static string GetFormAsset<T>() where T : FGUIForm, new()
    {
        return GetFormAsset(typeof(T).Name);
    }

    public static string GetFormAsset(string formName)
    {
        return $"{FORM_ASSET_PREFIX}{formName}.prefab";
    }

    public static int OpenUIForm<T>() where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Form, null);
    }

    public static int OpenUIForm<T>(object userData) where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Form, userData);
    }

    public static int OpenUITooltip<T>() where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Tooltip, null);
    }

    public static int OpenUITooltip<T>(object userData) where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Tooltip, userData);
    }

    public static int OpenUIToast<T>() where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Toast, null);
    }

    public static int OpenUIToast<T>(object userData) where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Toast, userData);
    }

    public static int OpenUIAlert<T>() where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Alert, null);
    }

    public static int OpenUIAlert<T>(object userData) where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Alert, userData);
    }

    public static int OpenUIDialog<T>() where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Dialog, null);
    }

    public static int OpenUIDialog<T>(object userData) where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Dialog, userData);
    }

    public static int OpenUILog<T>() where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Log, null);
    }

    public static int OpenUILog<T>(object userData) where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Log, userData);
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
    public static int OpenUIForm<T>(eUIGroup group) where T : FGUIForm, new()
    {
        return OpenUIForm<T>(group, null);
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
    public static int OpenUIForm<T>(eUIGroup group, object userData) where T : FGUIForm, new()
    {
        string assetName = GetFormAsset<T>();
        if (string.IsNullOrEmpty(assetName))
        {
            MLog.Error(eLogTag.ui, "asset name is empty,formID: " + assetName);
            return -1;
        }

        UIComponent uiCom = GFEntry.UI;
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
    public static void CloseUIForm<T>(bool disposed = false) where T : FGUIForm, new()
    {
        int serialID = BasicModule.UICenter.GetFormCacheID<T>();
        CloseUIForm(serialID, disposed);
    }

    public static void CloseUIForm(int serialID, bool disposed = false)
    {
        if (serialID == -1)
        {
            MLog.Error(eLogTag.ui, $"can't find form cache id,formID:{serialID}");
            return;
        }
        GFEntry.UI.CloseUIForm(serialID, disposed);
    }

    public static T GetUIForm<T>() where T : FGUIForm, new()
    {
        int serialID = BasicModule.UICenter.GetFormCacheID<T>();
        return GFEntry.UI.GetUIForm(serialID) as T;
    }
}