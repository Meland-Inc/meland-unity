/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 角色升级属性变更 info
 * @Date: 2022-07-07 18:01:16
 * @FilePath: /Assets/Src/Module/MainPlayerRole/Data/RoleUpgradeAttrDiffInfo.cs
 */
using System;
using System.Collections.Generic;

public class RoleUpgradeAttrDiffInfo
{
    public List<RoleAttrDiffInfo> AttrDiffList { get; private set; }
    public int Lv;
    public static RoleUpgradeAttrDiffInfo GetSlotUpgradeInfo(int slot, int lv)
    {
        DRSlotLv drSlotCur = SlotLvTable.Inst.GetDataRow(slot, lv);
        DRSlotLv drSlotNext = SlotLvTable.Inst.GetDataRow(slot, lv + 1);
        if (drSlotCur == null || drSlotNext == null)
        {
            return null;
        }
        return GetUpgradeInfo(drSlotCur, drSlotNext, lv);
    }

    public static RoleUpgradeAttrDiffInfo GetRoleUpgradeInfo(int lv)
    {
        DRRoleLv drRoleCur = RoleLvTable.Inst.GetRow(lv);
        DRRoleLv drRoleNext = RoleLvTable.Inst.GetRow(lv + 1);
        if (drRoleCur == null || drRoleNext == null)
        {
            return null;
        }

        return GetUpgradeInfo(drRoleCur, drRoleNext, lv);
    }

    private static RoleUpgradeAttrDiffInfo GetUpgradeInfo(object cur, object next, int curLv)
    {
        RoleUpgradeAttrDiffInfo info = new()
        {
            AttrDiffList = new(),
            Lv = curLv
        };
        foreach (string attrName in Enum.GetNames(typeof(TableDefine.eRoleAttrName)))
        {
            try
            {
                int curAttr = Convert.ToInt32(cur.GetType().GetProperty(attrName).GetValue(cur));
                int nextAttr = Convert.ToInt32(next.GetType().GetProperty(attrName).GetValue(next));
                if (curAttr != nextAttr)
                {
                    info.AttrDiffList.Add(new RoleAttrDiffInfo(attrName, curAttr, nextAttr));
                }
            }
            catch (Exception e)
            {
                MLog.Error(eLogTag.test, e.Message);
                return null;
            }
        }


        return info;
    }
}