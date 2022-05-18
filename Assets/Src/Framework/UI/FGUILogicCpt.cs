
using UnityEngine;
using FairyGUI;
public abstract class FGUILogicCpt : MonoBehaviour
{
    protected GComponent GCom;
    protected virtual void Awake()
    {
        DisplayObjectInfo info = GetComponent<DisplayObjectInfo>();
        if (info)
        {
            GCom = GRoot.inst.DisplayObjectToGObject(info.displayObject).asCom;
        }
        else
        {
            Debug.LogError("can't not find fgui display view");
        }
    }

    protected virtual void OnDestroy()
    {
        Debug.Log("on ui logic destroy");
    }
    public virtual void OnOpen()
    {
        FGUILogicCpt[] cpts = gameObject.GetComponentsInChildren<FGUILogicCpt>();
        if (cpts != null)
        {
            int len = cpts.Length;
            for (int i = 0; i < len; i++)
            {
                if (cpts[i] == this)//GetComponentsInChildren会把当前gameObject上的FGUILogicCpt也获取到，这里要判断一下避免死循环
                {
                    continue;
                }
                cpts[i].OnOpen();
            }
        }
    }

    public virtual void OnClose()
    {
        FGUILogicCpt[] cpts = gameObject.GetComponentsInChildren<FGUILogicCpt>();
        if (cpts != null)
        {
            int len = cpts.Length;
            for (int i = 0; i < len; i++)
            {
                if (cpts[i] == this)//GetComponentsInChildren会把当前gameObject上的FGUILogicCpt也获取到，这里要判断一下避免死循环
                {
                    continue;
                }
                cpts[i].OnClose();
            }
        }
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