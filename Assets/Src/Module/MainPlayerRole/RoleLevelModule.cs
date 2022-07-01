using System;
/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 角色等级管理模块
 * @Date: 2022-06-23 14:35:38
 * @FilePath: /Assets/Src/Module/MainPlayerRole/RoleLevelModule.cs
 */
using System.Collections.Generic;
using Bian;
using UnityEngine;
public class RoleLevelModule : MonoBehaviour
{
    /// <summary>
    /// 角色最高等级
    /// </summary>
    public const int MAX_ROLE_LV = 100;
    /// <summary>
    /// 插槽最高等级
    /// </summary>
    public const int MAX_SLOT_LV = 100;
    /// <summary>
    /// 插槽和角色的最大等级差
    /// </summary>
    public const int MAX_LV_GAP_BETWEEN_SLOT_AND_ROLE = 4;
    /// <summary>
    /// 角色装备插槽等级大于角色等级-5的最小数量
    /// </summary>
    public const int MIN_NUM_OF_ROLE_LV_BIGGER_SLOT_LV_THAN_NEGATIVE_5 = 4;
    public const int TEST_DITAMIN = 999999;
    /// <summary>
    /// 插槽升级
    /// </summary>
    public Action<AvatarPosition> OnSlotUpgraded = delegate { };
    /// <summary>
    /// 角色升级
    /// </summary>
    public Action OnRoleUpgraded = delegate { };
    public Action<string> OnRoleProfileUpdated = delegate { };

    private void Awake()
    {
        Message.RspMapEnterFinish += OnMapEnterFinish;
    }

    private void OnDestroy()
    {
        Message.RspMapEnterFinish -= OnMapEnterFinish;
    }

    private void OnMapEnterFinish(EnterMapResponse rsp)
    {
        GetItemSlotAction.Req();
    }

    public bool CheckCanUpgradeRole()
    {
        EntityProfile profile = DataManager.MainPlayer.RoleData.Profile;
        if (profile.Lv >= MAX_ROLE_LV)
        {
            return false;
        }

        DRRoleLv drRoleLv = RoleLvTable.Inst.GetRow(profile.Lv);
        if (drRoleLv == null)
        {
            return false;
        }

        if (Convert.ToInt64(profile.Exp) < drRoleLv.Exp)
        {
            return false;
        }

        int count = 0;
        foreach (KeyValuePair<AvatarPosition, ItemSlot> item in DataManager.MainPlayer.ItemSlotDice)
        {
            if (item.Value.Level >= profile.Lv - MAX_LV_GAP_BETWEEN_SLOT_AND_ROLE)
            {
                count++;
            }
        }

        if (count < MIN_NUM_OF_ROLE_LV_BIGGER_SLOT_LV_THAN_NEGATIVE_5)
        {
            return false;
        }

        return true;
    }

    public bool CheckCanUpgradeSlot(AvatarPosition pos)
    {
        EntityProfile profile = DataManager.MainPlayer.RoleData.Profile;
        ItemSlot slotData = DataManager.MainPlayer.ItemSlotDice[pos];
        if (slotData.Level >= MAX_SLOT_LV)
        {
            return false;
        }

        DRSlotLv drSlotLv = SlotLvTable.Inst.GetDataRow((int)slotData.Position, slotData.Level);
        if (drSlotLv == null)
        {
            return false;
        }

        if (Convert.ToInt64(profile.Exp) < drSlotLv.Exp)
        {
            return false;
        }

        if (slotData.Level > profile.Lv + MAX_LV_GAP_BETWEEN_SLOT_AND_ROLE)
        {
            return false;
        }

        if (TEST_DITAMIN < drSlotLv.Ditamin)
        {
            return false;
        }
        return true;
    }

    public bool UpgradeSlot(AvatarPosition pos)
    {
        if (!CheckCanUpgradeSlot(pos))
        {
            return false;
        }

        UpgradeItemSlotAction.Req(pos);
        return true;
    }

    public bool UpgradeRole()
    {
        if (!CheckCanUpgradeRole())
        {
            return false;
        }

        UpgradePlayerLevelAction.Req();
        return true;
    }
}