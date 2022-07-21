

using System;
using System.Collections.Generic;
using FairyGUI;

public class FormTaskReward : FGUIForm
{
    private List<RewardNftData> _itemDatas;
    private GButton _btnConfirm;
    private GList _lstItem;
    private Transition _show;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        _btnConfirm = GetButton("btnConfirm");
        _lstItem = GetList("lstItem");
        _show = GCom.GetTransition("show");
        _lstItem.numItems = 0;
        _lstItem.itemRenderer = OnRenderItem;
    }

    private void OnRenderItem(int index, GObject item)
    {
        RewardNftItemRenderer render = (RewardNftItemRenderer)item;
        render.SetData(_itemDatas[index]);
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        _show.Play();
        AddUIEvent();
        if (userData == null)
        {
            return;
        }
        _itemDatas = userData as List<RewardNftData>;
        UpdateUI();
    }


    protected override void OnClose(bool isShutdown, object userData)
    {
        RemoveUIEvent();
        base.OnClose(isShutdown, userData);
    }

    private void UpdateUI()
    {
        _lstItem.numItems = _itemDatas.Count;
    }

    private void AddUIEvent()
    {
        _btnConfirm.onClick.Add(Close);
    }

    private void RemoveUIEvent()
    {
        _btnConfirm.onClick.Add(Close);
    }
}