/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 插槽升级信息
 * @Date: 2022-06-28 13:49:44
 * @FilePath: /Assets/Src/Module/MainPlayerRole/Data/SlotUpgradeInfo.cs
 */
using System;
using System.Collections.Generic;

public struct SlotUpgradeInfo
{
    // public SlotUpgradeInfo()
    // {
    //     var drSlot = SlotLvTable.Inst.GetDataRow((int)pos, lv);
    // }
    public string AttrName;
    public int CurValue;
    public int NextValue;

    public static List<SlotUpgradeInfo> GetUpgradeInfoList(Bian.AvatarPosition pos, int lv)
    {
        DRSlotLv curSlot = SlotLvTable.Inst.GetDataRow((int)pos, lv);
        DRSlotLv nextSlot = SlotLvTable.Inst.GetDataRow((int)pos, lv + 1);
        if (nextSlot == null)
        {
            return null;
        }
        List<SlotUpgradeInfo> list = new();
        foreach (string attrName in Enum.GetNames(typeof(TableDefine.eRoleAttrName)))
        {
            try
            {
                int curAttr = Convert.ToInt32(curSlot.GetType().GetProperty(attrName).GetValue(curSlot));
                int nextAttr = Convert.ToInt32(nextSlot.GetType().GetProperty(attrName).GetValue(nextSlot));
                if (curAttr != nextAttr)
                {
                    list.Add(new SlotUpgradeInfo()
                    {
                        AttrName = attrName.ToLower(),//TODO:to be optimized
                        CurValue = curAttr,
                        NextValue = nextAttr
                    });
                }
            }
            catch (Exception e)
            {
                MLog.Error(eLogTag.test, e.Message);
                return null;
            }
        }

        return list;
    }
}