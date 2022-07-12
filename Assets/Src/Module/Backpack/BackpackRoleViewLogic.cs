/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 背包角色视图逻辑
 * @Date: 2022-06-21 13:54:14
 * @FilePath: /Assets/Src/Module/Backpack/BackpackRoleViewLogic.cs
 */
using Bian;
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
            item.Value.SetSlotData(null);//todo:
        }
    }
    private void OnAvatarDataUpdated()
    {
        UpdateSlotView();
        //update avatar view
    }

    private void UpdateRoleAttr()
    {
        _tfRoleName.text = DataManager.MainPlayer.name;
        //to do : update role attr
    }

    private void UpdateRoleView()
    {
        PlayerFeature feature = DataManager.MainPlayer.Feature;
        DRRoleAsset drRoleAsset = GFEntry.DataTable.GetDataTable<DRRoleAsset>().GetDataRow(10001);
        string skeletonAsset = Path.Combine(AssetDefine.PATH_AVATAR_SKELETON, drRoleAsset.ArmatureRes);
        _comUIAvatar.ChangeAvatar(skeletonAsset, new List<int>()
        {
            feature.Hair,
            feature.Face,
            feature.Clothes,
            feature.Pants,
            feature.Glove,
            feature.Shoes,
        });
    }
}