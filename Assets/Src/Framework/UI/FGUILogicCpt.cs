
using UnityEngine;
using FairyGUI;
public abstract class FGUILogicCpt : MonoBehaviour
{
    protected GComponent GCom;
    protected void Awake()
    {
        DisplayObjectInfo info = GetComponent<DisplayObjectInfo>();
        if (info)
        {
            GCom = GRoot.inst.DisplayObjectToGObject(info.displayObject).asCom;
        }
        else
        {
            MLog.Error(eLogTag.ui, "can't not find fgui display view");
        }
        OnAdd();
    }

    protected void OnDestroy()
    {
        OnRemove();
    }

    protected virtual void OnAdd()
    {

    }

    protected virtual void OnRemove()
    {

    }

    public virtual void OnOpen()
    {
        //
    }

    public virtual void OnClose()
    {
        //
    }

    public virtual void OnPause()
    {
        //
    }

    public virtual void OnResume()
    {

    }

    public virtual void OnCover()
    {

    }

    public virtual void OnReveal()
    {

    }

    public virtual void OnRefocus()
    {

    }

    public virtual void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {

    }

    public virtual void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
    {

    }

    public virtual void InternalSetVisible(bool visible)
    {

    }
}