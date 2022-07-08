using UnityEngine;
using UnityGameFramework.Runtime;
using FairyGUI;
using System;
/// <summary>
/// fgui窗体基类，所有fgui窗体都要继承这个类
/// </summary>
[RequireComponent(typeof(UIPanel))]
public abstract class FGUIBase : UIFormLogic
{
    protected GComponent GCom;
    protected UIPanel UIPanel;
    protected virtual bool Batching => true;//该界面是否开启批次合并
    protected virtual HitTestMode HitTestMode => HitTestMode.Default;//点击模式
    protected virtual RenderMode RenderMode => RenderMode.ScreenSpaceOverlay;//渲染模式
    protected virtual FitScreen FitScreenMode => FitScreen.None;

    /// <summary>
    /// 界面初始化，只会调用一次，和OnDispose成对
    /// </summary>
    /// <param name="userData"></param>
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        gameObject.layer = LayerMask.NameToLayer("UI");
        UIPanel = GetComponent<UIPanel>();
        GCom = UIPanel.ui;
        if (GCom == null)
        {
            MLog.Error(eLogTag.ui, "GCom is null,please set package name and component name in the panel");
        }

        UIPanel.fitScreen = FitScreenMode;
        UIPanel.SetHitTestMode(HitTestMode);
        UIPanel.container.fairyBatching = Batching;
        UIPanel.container.renderMode = RenderMode;
    }

    /// <summary>
    /// 界面销毁，只会调用一次，和OnInit成对
    /// </summary>
    protected override void OnDispose()
    {
        base.OnDispose();
    }

    /// <summary>
    /// 界面回收，入池，每次关闭都会调用，在OnClose之后
    /// </summary>
    protected override void OnRecycle()
    {
        base.OnRecycle();
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        GCom.onSizeChanged.Add(OnStageResize);
        CalcFormSorting();
        OnStageResize();
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
        GCom.onSizeChanged.Remove(OnStageResize);
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

    protected virtual void OnStageResize()
    {
    }

    protected virtual void OnResize(float w, float h)
    {
        //
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
        //带上参数true，把未激活的子组件也获取到
        FGUILogicCpt[] cpts = GetComponentsInChildren<FGUILogicCpt>(true);
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

    public void Close()
    {
        UICenter.CloseUIForm(UIForm.SerialId);
    }

    protected GObject GetChild(string name)
    {
        return GCom.GetChild(name);
    }

    protected GObject GetChildAt(int index)
    {
        return GCom.GetChildAt(index);
    }

    protected GButton GetButton(string name)
    {
        return GCom.GetChild(name) as GButton;
    }

    protected GLabel GetLabel(string name)
    {
        return GCom.GetChild(name) as GLabel;
    }

    protected GProgressBar GetProgressBar(string name)
    {
        return GCom.GetChild(name) as GProgressBar;
    }

    protected GSlider GetSlider(string name)
    {
        return GCom.GetChild(name) as GSlider;
    }

    protected GComboBox GetComboBox(string name)
    {
        return GCom.GetChild(name) as GComboBox;
    }

    protected GList GetList(string name)
    {
        return GCom.GetChild(name) as GList;
    }

    protected GGraph GetGraph(string name)
    {
        return GCom.GetChild(name) as GGraph;
    }

    protected GImage GetImage(string name)
    {
        return GCom.GetChild(name) as GImage;
    }

    protected MLoader GetLoader(string name)
    {
        return GCom.GetChild(name) as MLoader;
    }

    protected GLoader3D GetLoader3D(string name)
    {
        return GCom.GetChild(name) as GLoader3D;
    }

    protected GGroup GetGroup(string name)
    {
        return GCom.GetChild(name) as GGroup;
    }

    protected GComponent GetCom(string name)
    {
        return GCom.GetChild(name) as GComponent;
    }

    protected GTextField GetTextField(string name)
    {
        return GCom.GetChild(name) as GTextField;
    }

    protected GTextInput GetTextInput(string name)
    {
        return GCom.GetChild(name) as GTextInput;
    }

    protected Controller GetController(string name)
    {
        return GCom.GetController(name);
    }

    /// <summary>
    /// 初始化
    /// </summary>
    private void InitDefaultUIFunc()
    {
        GButton btnClose = GetButton("btnClose");
        if (btnClose != null)
        {
            btnClose.onClick.Add(OnBtnCloseClick);
        }
    }

    private void OnBtnCloseClick()
    {
        Close();
    }

    private void CalcFormSorting()
    {
        int sort = (UIDefine.MAX_FORM_NUM_IN_GROUP * UIForm.UIGroup.Depth) + UIForm.UIGroup.UIFormCount;
        UIPanel.SetSortingOrder(sort, true);//设置排序
    }
}
