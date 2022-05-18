using FairyGUI;
using UnityEngine;
public static class FGUIExtension
{
    /// <summary>
    /// 给当前fgui组件添加UI逻辑组件
    /// </summary>
    /// <param name="gcom"></param>
    /// <typeparam name="T">FGUILogicCpt的派生类</typeparam>
    /// <returns></returns>
    public static T AddUILogicCpt<T>(this GComponent gcom) where T : FGUILogicCpt, new()
    {
        return gcom.displayObject.gameObject.AddComponent<T>();
    }

    /// <summary>
    /// 给当前fgui组件移除UI逻辑组件
    /// </summary>
    /// <param name="gcom"></param>
    /// <typeparam name="T">FGUILogicCpt的派生类</typeparam>
    /// <returns></returns>
    public static T RemoveUILogicCpt<T>(this GComponent gcom) where T : FGUILogicCpt, new()
    {
        T cpt = gcom.displayObject.gameObject.AddComponent<T>();
        if (cpt == null)
        {
            return null;
        }
        Object.Destroy(cpt);
        return cpt;
    }
}