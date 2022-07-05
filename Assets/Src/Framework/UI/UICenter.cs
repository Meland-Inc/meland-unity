using System.Collections.Generic;
using FairyGUI;
using UnityGameFramework.Runtime;
public partial class UICenter : GameFrameworkComponent
{
    public const string FORM_ASSET_PREFIX = "Assets/Res/Prefab/UI/";
    public const string UI_ASSET_PREFIX = "Assets/Res/Fairygui/";
    private Dictionary<string, List<int>> _dicFormCacheID;
    private void Start()
    {
        _dicFormCacheID = new();
        InitFont();
        InitConfig();
        InitPackage();
        InitFguiExtension();
    }

    public static void InitConfig()
    {
        DontDestroyOnLoad(Stage.inst.GetRenderCamera().gameObject);
        //init config
    }

    public int GetFormCacheID<T>() where T : FGUIForm, new()
    {
        return GetFormCacheID(typeof(T).Name);
    }

    public int GetFormCacheID(string assetName)
    {
        int id = CheckFormCacheID(assetName);
        if (id == -1)
        {
            MLog.Error(eLogTag.ui, "can't find form cache id,assetName: " + assetName);
        }
        return id;
    }

    public int CheckFormCacheID(string assetName)
    {
        if (_dicFormCacheID.TryGetValue(assetName, out List<int> value))
        {
            return value[0];
        }

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
        if (!_dicFormCacheID.TryGetValue(formName, out List<int> value))
        {
            value = new List<int>();
            _dicFormCacheID.Add(formName, value);
        }
        value.Add(serialID);
    }

    public void RemoveFromCacheID<T>() where T : FGUIForm, new()
    {
        RemoveFromCacheID(typeof(T).Name);
    }

    public void RemoveFromCacheID(string formName)
    {
        if (_dicFormCacheID.ContainsKey(formName))
        {
            List<int> value = _dicFormCacheID[formName];
            value.Clear();
        }
        else
        {
            MLog.Error(eLogTag.ui, "can't find form cache id,assetName: " + formName);
        }
    }
}

