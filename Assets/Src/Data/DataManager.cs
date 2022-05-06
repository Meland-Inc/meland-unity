using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数据管理
/// </summary>
public static class DataManager
{
    private static GameObject s_dataRoot;
    private static readonly Dictionary<string, DataModelBase> s_modelMap = new();

    /// <summary>
    /// 获取某个数据Model
    /// </summary>
    /// <typeparam name="T">要获取的数据类名</typeparam>
    /// <returns>返回数据实例</returns>
    public static T GetModel<T>() where T : DataModelBase
    {
        if (!s_dataRoot)
        {
            s_dataRoot = new GameObject("DataRoot");
            Object.DontDestroyOnLoad(s_dataRoot);
        }

        string modelName = typeof(T).Name;

        if (s_modelMap.TryGetValue(modelName, out DataModelBase model))
        {
            return (T)model;
        }

        GameObject go = new(modelName);
        go.transform.SetParent(s_dataRoot.transform);
        model = go.AddComponent<T>();
        s_modelMap.Add(modelName, model);
        return (T)model;
    }
}