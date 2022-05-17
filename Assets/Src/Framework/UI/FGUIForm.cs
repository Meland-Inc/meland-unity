using UnityEngine;
using UnityGameFramework.Runtime;
using FairyGUI;

[RequireComponent(typeof(UIPanel))]
public abstract class FGUIForm : UIFormLogic
{
    protected GComponent GCom;
    protected virtual bool Batching => true;//该界面是否开启批次合并
    protected virtual HitTestMode HitTestMode => HitTestMode.Default;//点击模式
    protected virtual RenderMode RenderMode => RenderMode.ScreenSpaceOverlay;//渲染模式
    protected virtual FitScreen FitScreenMode => FitScreen.FitSize;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        gameObject.layer = LayerMask.NameToLayer("UI");
        UIPanel uiPanel = GetComponent<UIPanel>();
        GCom = uiPanel.ui;
        if (GCom == null)
        {
            Debug.Log("FguiView is null,please set package name and component name in the plane");
        }
    }

    protected override void OnRecycle()
    {
        base.OnRecycle();
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        FGUILogicCpt[] cpts = GetComponentsInChildren<FGUILogicCpt>();
        if (cpts == null)
        {
            return;
        }

        foreach (FGUILogicCpt cpt in cpts)
        {
            cpt.OnOpen();
        }
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        FGUILogicCpt[] cpts = GetComponentsInChildren<FGUILogicCpt>();
        if (cpts == null)
        {
            return;
        }

        foreach (FGUILogicCpt cpt in cpts)
        {
            cpt.OnClose();
        }
        base.OnClose(isShutdown, userData);
    }

    protected override void OnPause()
    {
        base.OnPause();
        FGUILogicCpt[] cpts = GetComponentsInChildren<FGUILogicCpt>();
        if (cpts == null)
        {
            return;
        }

        foreach (FGUILogicCpt cpt in cpts)
        {
            cpt.OnPause();
        }
    }

    protected override void OnResume()
    {
        base.OnResume();
        FGUILogicCpt[] cpts = GetComponentsInChildren<FGUILogicCpt>();
        if (cpts == null)
        {
            return;
        }

        foreach (FGUILogicCpt cpt in cpts)
        {
            cpt.OnResume();
        }
    }

    protected override void OnCover()
    {
        base.OnCover();
        FGUILogicCpt[] cpts = GetComponentsInChildren<FGUILogicCpt>();
        if (cpts == null)
        {
            return;
        }

        foreach (FGUILogicCpt cpt in cpts)
        {
            cpt.OnCover();
        }
    }

    protected override void OnReveal()
    {
        base.OnReveal();
        FGUILogicCpt[] cpts = GetComponentsInChildren<FGUILogicCpt>();
        if (cpts == null)
        {
            return;
        }

        foreach (FGUILogicCpt cpt in cpts)
        {
            cpt.OnReveal();
        }
    }

    protected override void OnRefocus(object userData)
    {
        base.OnRefocus(userData);
        FGUILogicCpt[] cpts = GetComponentsInChildren<FGUILogicCpt>();
        if (cpts == null)
        {
            return;
        }

        foreach (FGUILogicCpt cpt in cpts)
        {
            cpt.OnRefocus();
        }
    }

    protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);
        // GetComponentInChildren<FGUILogicCpt>()?.OnUpdate(elapseSeconds, realElapseSeconds);
    }

    protected override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
    {
        base.OnDepthChanged(uiGroupDepth, depthInUIGroup);
        FGUILogicCpt[] cpts = GetComponentsInChildren<FGUILogicCpt>();
        if (cpts == null)
        {
            return;
        }

        foreach (FGUILogicCpt cpt in cpts)
        {
            cpt.OnDepthChanged(uiGroupDepth, depthInUIGroup);
        }
    }

    protected override void InternalSetVisible(bool visible)
    {
        base.InternalSetVisible(visible);
        FGUILogicCpt[] cpts = GetComponentsInChildren<FGUILogicCpt>();
        if (cpts == null)
        {
            return;
        }

        foreach (FGUILogicCpt cpt in cpts)
        {
            cpt.InternalSetVisible(visible);
        }
    }

    public T AddSubForm<T>() where T : FGUIForm
    {
        GameObject go = new();
        go.transform.SetParent(gameObject.transform);
        return go.AddComponent<T>();
    }

    public GObject AddFguiObject(GObject gobj)
    {
        return GCom.AddChild(gobj);
    }

    public GObject AddFguiObjectAt(GObject gobj, int index)
    {
        return GCom.AddChildAt(gobj, index);
    }

    // 给子对象添加逻辑组件
    public T AddUILogicCpt<T>(string childName) where T : FGUILogicCpt, new()
    {
        if (GCom.GetChild(childName) is GComponent child)
        {
            return AddUILogicCpt<T>(child);
        }
        return null;
    }

    public T AddUILogicCpt<T>(GComponent child) where T : FGUILogicCpt, new()
    {
        T cpt = child.displayObject.gameObject.AddComponent<T>();
        return cpt;
    }

    public T RemoveUILogicCpt<T>(GComponent child) where T : FGUILogicCpt, new()
    {
        T cpt = child.displayObject.gameObject.AddComponent<T>();
        if (cpt == null)
        {
            return null;
        }
        Destroy(cpt);
        return cpt;
    }

    public T RemoveUILogicCpt<T>(string childName) where T : FGUILogicCpt, new()
    {
        GComponent child = GCom.GetChild(childName).asCom;
        return RemoveUILogicCpt<T>(child);
    }
}
