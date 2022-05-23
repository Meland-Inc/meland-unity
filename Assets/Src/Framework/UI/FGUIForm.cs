using UnityEngine;
using UnityGameFramework.Runtime;
using FairyGUI;
using System;

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
        ForeachChildrenCpt((FGUILogicCpt cpt) =>
        {
            cpt.OnOpen();
        });
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        ForeachChildrenCpt((FGUILogicCpt cpt) =>
        {
            cpt.OnClose();
        });
        base.OnClose(isShutdown, userData);
    }

    protected override void OnPause()
    {
        base.OnPause();
        ForeachChildrenCpt((FGUILogicCpt cpt) =>
        {
            cpt.OnPause();
        });
    }

    protected override void OnResume()
    {
        base.OnResume();
        ForeachChildrenCpt((FGUILogicCpt cpt) =>
        {
            cpt.OnResume();
        });
    }

    protected override void OnCover()
    {
        base.OnCover();
        ForeachChildrenCpt((FGUILogicCpt cpt) =>
        {
            cpt.OnCover();
        });
    }

    protected override void OnReveal()
    {
        base.OnReveal();
        ForeachChildrenCpt((FGUILogicCpt cpt) =>
        {
            cpt.OnReveal();
        });
    }

    protected override void OnRefocus(object userData)
    {
        base.OnRefocus(userData);
        ForeachChildrenCpt((FGUILogicCpt cpt) =>
        {
            cpt.OnRefocus();
        });
    }

    protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);
        // ForeachChildrenCpt((FGUILogicCpt cpt) =>
        //  {
        //      cpt.OnUpdate(elapseSeconds, realElapseSeconds);
        //  });
    }

    protected override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
    {
        base.OnDepthChanged(uiGroupDepth, depthInUIGroup);
        ForeachChildrenCpt((FGUILogicCpt cpt) =>
        {
            cpt.OnDepthChanged(uiGroupDepth, depthInUIGroup);
        });
    }

    protected override void InternalSetVisible(bool visible)
    {
        base.InternalSetVisible(visible);
        ForeachChildrenCpt((FGUILogicCpt cpt) =>
        {
            cpt.InternalSetVisible(visible);
        });
    }

    protected void ForeachChildrenCpt(Action<FGUILogicCpt> callback)
    {
        FGUILogicCpt[] cpts = GetComponentsInChildren<FGUILogicCpt>();
        if (cpts == null)
        {
            return;
        }

        foreach (FGUILogicCpt cpt in cpts)
        {
            callback.Invoke(cpt);
        }
    }

    public GObject AddFguiObject(GObject gobj)
    {
        return GCom.AddChild(gobj);
    }

    public GObject AddFguiObjectAt(GObject gobj, int index)
    {
        return GCom.AddChildAt(gobj, index);
    }
}
