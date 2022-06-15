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
    public static T AddUILogic<T>(this GComponent gcom) where T : FGUILogicCpt, new()
    {
        return gcom.displayObject.gameObject.AddComponent<T>();
    }

    /// <summary>
    /// 给当前fgui组件移除UI逻辑组件
    /// </summary>
    /// <param name="gcom"></param>
    /// <typeparam name="T">FGUILogicCpt的派生类</typeparam>
    /// <returns></returns>
    public static T RemoveUILogic<T>(this GComponent gcom) where T : FGUILogicCpt, new()
    {
        T cpt = gcom.displayObject.gameObject.AddComponent<T>();
        if (cpt == null)
        {
            return null;
        }
        Object.Destroy(cpt);
        return cpt;
    }

    /// <summary>
    /// 根据逻辑类名来获取子组件并添加组件
    /// 注意，child的名字一定要和逻辑类名一致！！！
    /// </summary>
    /// <param name="gcom"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T AddSubUILogic<T>(this GComponent gcom) where T : FGUILogicCpt, new()
    {
        return gcom.AddSubUILogic<T>(typeof(T).Name);
    }

    /// <summary>
    /// 根据逻辑类名来获取子组件并移除组件
    /// 注意，child的名字一定要和逻辑类名一致！！！
    /// </summary>
    /// <param name="gcom"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T RemoveSubUILogic<T>(this GComponent gcom) where T : FGUILogicCpt, new()
    {
        return gcom.RemoveSubUILogic<T>(typeof(T).Name);
    }

    /// <summary>
    /// 根据child name添加逻辑组件
    /// </summary>
    /// <param name="gcom"></param>
    /// <param name="childName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T AddSubUILogic<T>(this GComponent gcom, string childName) where T : FGUILogicCpt, new()
    {
        if (gcom.GetChild(childName) is not GComponent child)
        {
            MLog.Error(eLogTag.ui, $"child {childName} is null");
            return null;
        }

        return child.AddUILogic<T>();
    }

    /// <summary>
    /// 根据child name移除逻辑组件
    /// </summary>
    /// <param name="gcom"></param>
    /// <param name="childName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T RemoveSubUILogic<T>(this GComponent gcom, string childName) where T : FGUILogicCpt, new()
    {
        if (gcom.GetChild(childName) is not GComponent child)
        {
            MLog.Error(eLogTag.ui, $"child {childName} is null");
            return null;
        }

        return child.RemoveUILogic<T>();
    }

    public static Vector2 LocalToLocal(this GObject gobj, GObject target, Vector2 offset)
    {
        Vector2 globalV = gobj.LocalToGlobal(offset);
        return target.GlobalToLocal(globalV);
    }

    public static T GetUILogic<T>(this GComponent gcom) where T : FGUILogicCpt, new()
    {
        return gcom.displayObject.gameObject.GetComponent<T>();
    }

    public static T GetSubUILogic<T>(this GComponent gcom, string childName) where T : FGUILogicCpt, new()
    {
        if (gcom.GetChild(childName) is not GComponent child)
        {
            MLog.Error(eLogTag.ui, $"child {childName} is null");
            return null;
        }

        return child.GetUILogic<T>();
    }
}
