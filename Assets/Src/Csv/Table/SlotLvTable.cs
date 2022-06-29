/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 插槽等级表
 * @Date: 2022-06-24 14:41:06
 * @FilePath: /Assets/Src/Csv/Table/SlotLvTable.cs
 */
using GameFramework.DataTable;
using System.Collections.Generic;

public class SlotLvTable
{
    private readonly DRSlotLv[] _rows;
    private static SlotLvTable s_instance;
    public Dictionary<int, DRSlotLv> Dic { get; private set; } = new();
    public static SlotLvTable Inst
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = new SlotLvTable();
            }

            return s_instance;
        }
    }

    public SlotLvTable()
    {
        IDataTable<DRSlotLv> dtAircraft = GFEntry.DataTable.GetDataTable<DRSlotLv>();
        _rows = dtAircraft.GetAllDataRows();
        foreach (var row in _rows)
        {
            Dic.Add(CreateSlotCfgID(row.Slot, row.Lv), row);
        }

    }

    private int CreateSlotCfgID(int slot, int lv)
    {
        return slot * 10000 + lv;
    }

    public DRSlotLv GetDataRow(int slot, int lv)
    {
        int id = CreateSlotCfgID(slot, lv);
        return Dic[id];
    }
}