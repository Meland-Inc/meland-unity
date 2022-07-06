/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: UI 工具类
 * @Date: 2022-06-15 16:19:22
 * @FilePath: /Assets/Src/Framework/UI/UICenter.Util.cs
 */
using UnityGameFramework.Runtime;

public partial class UICenter
{
    public static string GetFormAsset<T>() where T : FGUIBase, new()
    {
        return GetFormAsset(typeof(T).Name);
    }

    public static string GetFormAsset(string formName)
    {
        return $"{FORM_ASSET_PREFIX}{formName}.prefab";
    }

    public static int OpenUIForm<T>() where T : FGUIBase, new()
    {
        return OpenUIForm<T>(eUIGroup.Form, null);
    }

    public static int OpenUIForm<T>(object userData) where T : FGUIBase, new()
    {
        return OpenUIForm<T>(eUIGroup.Form, userData);
    }

    public static int OpenUITooltip<T>() where T : FGUIBase, new()
    {
        return OpenUIForm<T>(eUIGroup.Tooltip, null);
    }

    public static int OpenUITooltip<T>(object userData) where T : FGUIBase, new()
    {
        return OpenUIForm<T>(eUIGroup.Tooltip, userData);
    }

    public static int OpenUIToast<T>() where T : FGUIBase, new()
    {
        return OpenUIForm<T>(eUIGroup.Toast, null);
    }

    public static int OpenUIToast<T>(object userData) where T : FGUIBase, new()
    {
        return OpenUIForm<T>(eUIGroup.Toast, userData);
    }

    public static int OpenUIAlert<T>() where T : FGUIBase, new()
    {
        return OpenUIForm<T>(eUIGroup.Alert, null);
    }

    public static int OpenUIAlert<T>(object userData) where T : FGUIBase, new()
    {
        return OpenUIForm<T>(eUIGroup.Alert, userData);
    }

    public static int OpenUIDialog<T>() where T : FGUIBase, new()
    {
        return OpenUIForm<T>(eUIGroup.Dialog, null);
    }

    public static int OpenUIDialog<T>(object userData) where T : FGUIBase, new()
    {
        return OpenUIForm<T>(eUIGroup.Dialog, userData);
    }

    public static int OpenUILog<T>() where T : FGUIBase, new()
    {
        return OpenUIForm<T>(eUIGroup.Log, null);
    }

    public static int OpenUILog<T>(object userData) where T : FGUIBase, new()
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
    public static int OpenUIForm<T>(eUIGroup group) where T : FGUIBase, new()
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
    public static int OpenUIForm<T>(eUIGroup group, object userData) where T : FGUIBase, new()
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
        return serialID;
    }

    /// <summary>
    /// 通过窗体class,会把所有的该类型所有的窗体都关闭
    /// </summary>
    /// <param name="uiCom"></param>
    /// <typeparam name="T">窗体class</typeparam>
    public static void CloseUIForm<T>(bool disposed = false) where T : FGUIBase, new()
    {
        UIComponent uiCom = GFEntry.UI;
        string assetName = GetFormAsset<T>();
        UIForm[] forms = uiCom.GetUIForms(assetName);
        if (forms == null)
        {
            MLog.Warning(eLogTag.ui, "form is null,assetName: " + assetName);
            return;
        }

        foreach (UIForm form in forms)
        {
            uiCom.CloseUIForm(form.SerialId, disposed);
        }
    }

    /// <summary>
    /// 通过窗体唯一id关闭窗体
    /// </summary>
    /// <param name="serialID"></param>
    /// <param name="disposed"></param>
    public static void CloseUIForm(int serialID, bool disposed = false)
    {
        if (serialID == -1)
        {
            MLog.Error(eLogTag.ui, $"can't find form cache id,formID:{serialID}");
            return;
        }
        GFEntry.UI.CloseUIForm(serialID, disposed);
    }

    public static T[] GetUIForms<T>() where T : FGUIBase, new()
    {
        UIComponent uiCom = GFEntry.UI;
        UIForm[] forms = uiCom.GetUIForms(GetFormAsset<T>());
        if (forms == null)
        {
            MLog.Error(eLogTag.ui, "form is null,assetName: " + GetFormAsset<T>());
            return null;
        }

        T[] uis = new T[forms.Length];
        for (int i = 0; i < forms.Length; i++)
        {
            uis[i] = GetUIForm<T>(forms[i].SerialId);
        }
        return uis;
    }

    public static T GetUIForm<T>(int serialID) where T : FGUIBase, new()
    {
        UIComponent uiCom = GFEntry.UI;
        UIForm form = uiCom.GetUIForm(serialID);
        if (form == null)
        {
            MLog.Error(eLogTag.ui, "form is null,serialID: " + serialID);
            return null;
        }
        return form.Logic as T;
    }
}