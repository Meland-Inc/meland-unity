using System;
/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description:角色信息组件
 * @Date: 2022-06-22 15:46:49
 * @FilePath: /Assets/Src/Module/MainPlayerRole/view/ComRoleInfoLogic.cs
 */
using FairyGUI;
public class ComRoleInfoLogic : FGUILogicCpt
{
    private GTextField _tfWallet;
    private GButton _btnCopy;
    private GButton _btnUpgrade;
    private GProgressBar _comExp;
    private GList _lstAttr;

    protected override void OnAdd()
    {
        base.OnAdd();
        _tfWallet = GCom.GetChild("tfWallet") as GTextField;
        _btnCopy = GCom.GetChild("btnCopy") as GButton;
        _btnUpgrade = GCom.GetChild("btnUpgrade") as GButton;
        _comExp = GCom.GetChild("comExp") as GProgressBar;
        _lstAttr = GCom.GetChild("lstAttr") as GList;
    }

    public override void OnOpen()
    {
        base.OnOpen();
        RefreshSlotList();
        AddMessage();
    }

    public override void OnClose()
    {
        base.OnClose();
        RemoveMessage();
    }

    private void AddMessage()
    {
        SceneModule.BackpackMgr.OnWearableDataUpdated += OnAvatarUpdated;
    }

    private void RemoveMessage()
    {
        SceneModule.BackpackMgr.OnWearableDataUpdated -= OnAvatarUpdated;
    }

    private void RefreshSlotList()
    {

    }

    private void OnAvatarUpdated()
    {
        RefreshSlotList();
    }
}