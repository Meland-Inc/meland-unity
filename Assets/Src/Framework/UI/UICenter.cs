using System.Collections.Generic;
using FairyGUI;
using UnityGameFramework.Runtime;
public class UICenter : GameFrameworkComponent
{
    public const string FORM_ASSET_PREFIX = "Assets/Res/Prefab/UI/";
    public const string UI_ASSET_PREFIX = "Assets/Res/Fairygui/";
    private Dictionary<string, int> _dicFormCacheID;
    private void Start()
    {
        _dicFormCacheID = new();
        InitConfig();
        InitPackage();
        InitFguiExtension();
    }
    public static void InitConfig()
    {
        DontDestroyOnLoad(Stage.inst.GetRenderCamera().gameObject);
        //init config
    }

    public static void InitPackage()
    {
        _ = UIPackage.AddPackage(UI_ASSET_PREFIX + eFUIPackage.Common.ToString());
    }

    public void InitFguiExtension()
    {
        UIObjectFactory.SetLoaderExtension(typeof(MLoader));//扩展加载器加载资源方式
    }

    public string GetFormAsset<T>() where T : FGUIForm, new()
    {
        return GetFormAsset(typeof(T).Name);
    }

    public string GetFormAsset(string formName)
    {
        return $"{FORM_ASSET_PREFIX}{formName}.prefab";
    }

    public int GetFormCacheID<T>() where T : FGUIForm, new()
    {
        return GetFormCacheID(typeof(T).Name);
    }

    public int GetFormCacheID(string assetName)
    {
        if (_dicFormCacheID.TryGetValue(assetName, out int value))
        {
            return value;
        }

        MLog.Error(eLogTag.ui, "can't find form cache id,assetName: " + assetName);
        return -1;
    }

    public bool CheckFormIsOpen<T>()
    {
        return _dicFormCacheID.ContainsKey(typeof(T).Name);
    }

    public void SetFormCacheID<T>(int serialID) where T : FGUIForm, new()
    {
        SetFormCacheID(typeof(T).Name, serialID);
    }

    public void SetFormCacheID(string formName, int serialID)
    {
        if (_dicFormCacheID.ContainsKey(formName))
        {
            MLog.Warning(eLogTag.ui, "form cache id is exist, formName: " + formName);
            return;
        }
        _dicFormCacheID.Add(formName, serialID);
    }

    public static int OpenUIForm<T>() where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Form);
    }

    public static int OpenUIForm<T>(object userData) where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Form, userData);
    }

    public static int OpenUITooltip<T>() where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Tooltip);
    }

    public static int OpenUITooltip<T>(object userData) where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Tooltip, userData);
    }

    public static int OpenUIToast<T>() where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Toast);
    }

    public static int OpenUIToast<T>(object userData) where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Toast, userData);
    }

    public static int OpenUIAlert<T>() where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Alert);
    }

    public static int OpenUIAlert<T>(object userData) where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Alert, userData);
    }

    public static int OpenUIDialog<T>() where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Dialog);
    }

    public static int OpenUIDialog<T>(object userData) where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Dialog, userData);
    }

    public static int OpenUILog<T>() where T : FGUIForm, new()
    {
        return OpenUIForm<T>(eUIGroup.Log);
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
        if (BasicModule.UICenter.CheckFormIsOpen<T>())
        {
            MLog.Warning(eLogTag.ui, "open form repeatedly, formName: " + typeof(T).Name);
            return -1;
        }

        string assetName = BasicModule.UICenter.GetFormAsset<T>();
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
    public static void CloseUIForm<T>() where T : FGUIForm, new()
    {
        int serialID = BasicModule.UICenter.GetFormCacheID<T>();
        CloseUIForm(serialID);
    }

    public static void CloseUIForm(int serialID)
    {
        if (serialID == -1)
        {
            MLog.Error(eLogTag.ui, $"can't find form cache id,formID:{serialID}");
            return;
        }
        GFEntry.UI.CloseUIForm(serialID);
    }

    public static T GetUIForm<T>() where T : FGUIForm, new()
    {
        int serialID = BasicModule.UICenter.GetFormCacheID<T>();
        return GFEntry.UI.GetUIForm(serialID) as T;
    }
}

