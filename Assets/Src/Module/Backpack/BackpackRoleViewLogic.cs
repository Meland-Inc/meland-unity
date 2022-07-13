/*
 * @Author: mangit
 * @LastEditors Please set LastEditors
 * @Description: 背包角色视图逻辑
 * @Date: 2022-06-21 13:54:14
 * @FilePath /Assets/Src/Module/Backpack/BackpackRoleViewLogic.cs
 */
using MelandGame3;
using FairyGUI;
using System.Collections.Generic;
using System.IO;

public class BackpackRoleViewLogic : FGUILogicCpt
{
    private GTextField _tfRoleName;
    private ComUIAvatar _comUIAvatar;
    private GComponent _comHp;
    private GComponent _comDef;
    private GComponent _comAttack;
    private GComponent _comAttackSpeed;
    private Dictionary<AvatarPosition, EquipmentSlot> slotDic;

    protected override void OnAdd()
    {
        base.OnAdd();
        _tfRoleName = GCom.GetChild("tfRoleName") as GTextField;
        _comUIAvatar = GCom.GetChild("comUIAvatar") as ComUIAvatar;
        _comHp = GCom.GetChild("comHp") as GComponent;
        _comDef = GCom.GetChild("comDef") as GComponent;
        _comAttack = GCom.GetChild("comAttack") as GComponent;
        _comAttackSpeed = GCom.GetChild("comAttackSpeed") as GComponent;

        InitSlotDic();
    }

    public override void OnOpen()
    {
        base.OnOpen();
        AddMessage();
        AddUIEvent();
        UpdateRoleAttr();
        UpdateSlotView();
        UpdateRoleView();
    }

    public override void OnClose()
    {
        RemoveMessage();
        RemoveUIEvent();
        base.OnClose();
    }

    private void AddMessage()
    {
        SceneModule.BackpackMgr.OnWearableDataUpdated += OnAvatarDataUpdated;
    }

    private void RemoveMessage()
    {
        SceneModule.BackpackMgr.OnWearableDataUpdated -= OnAvatarDataUpdated;
    }

    private void AddUIEvent()
    {

    }

    private void RemoveUIEvent()
    {

    }

    private void InitSlotDic()
    {
        slotDic = new();
        AddSlot(AvatarPosition.AvatarPositionHead, "equipHead");
        AddSlot(AvatarPosition.AvatarPositionCoat, "equipCoat");
        AddSlot(AvatarPosition.AvatarPositionPant, "equipPant");
        AddSlot(AvatarPosition.AvatarPositionShoe, "equipShoe");
        AddSlot(AvatarPosition.AvatarPositionHand, "equipHand");
        AddSlot(AvatarPosition.AvatarPositionWeapon, "equipWeapon");
    }

    private void AddSlot(AvatarPosition pos, string slotName)
    {
        EquipmentSlot slot = GCom.GetChild(slotName) as EquipmentSlot;
        slotDic.Add(pos, slot);
    }

    private void UpdateSlotView()
    {
        foreach (KeyValuePair<AvatarPosition, EquipmentSlot> item in slotDic)
        {
            _ = DataManager.Backpack.WearableItemDic.TryGetValue(item.Key, out BpWearableNftItem avatarItem);
            item.Value.SetNftData(avatarItem);
            item.Value.SetSlotData(DataManager.MainPlayer.ItemSlotDic[item.Key]);
        }
    }
    private void OnAvatarDataUpdated()
    {
        UpdateSlotView();
        //update avatar view
    }

    private void UpdateRoleAttr()
    {
        _tfRoleName.text = DataManager.MainPlayer.RoleData.Name;
        EntityProfile profile = DataManager.MainPlayer.RoleData.Profile;
        int curHP = profile.HpCurrent;
        int maxHP = profile.HpLimit;
        Controller ctrlHP = GCom.GetController("ctrlHP");
        ctrlHP.SetSelectedPage(curHP < maxHP ? "red" : "normal");
        _comHp.GetChild("title").asTextField
            .SetVar("cur", curHP.ToString())
            .SetVar("max", maxHP.ToString())
            .FlushVars();
        _comDef.text = profile.Def.ToString();
        _comAttack.text = profile.Att.ToString();
        _comAttackSpeed.text = profile.AttSpeed.ToString();
    }

    private void UpdateRoleView()
    {
        if (DataManager.MainPlayer.Role == null)
        {
            return;
        }
        PlayerRoleAvatarData avatarData = DataManager.MainPlayer.Role.GetComponent<PlayerRoleAvatarData>();
        _comUIAvatar.ChangeAvatar(avatarData.RoleCfgID, NetUtil.SvrToClientRoleFeature(avatarData.Feature));
    }
}