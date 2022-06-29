/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 角色等级表
 * @Date: 2022-06-27 10:42:04
 * @FilePath: /Assets/Src/Csv/Table/RoleLvTable.cs
 */
using System.Collections.Generic;
using GameFramework.DataTable;

public class RoleLvTable
{
    private readonly DRRoleLv[] _rows;
    private static RoleLvTable s_instance;
    public Dictionary<int, DRRoleLv> Dic { get; private set; } = new();
    public static RoleLvTable Inst
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = new RoleLvTable();
            }

            return s_instance;
        }
    }

    public RoleLvTable()
    {
        IDataTable<DRRoleLv> dtAircraft = GFEntry.DataTable.GetDataTable<DRRoleLv>();
        _rows = dtAircraft.GetAllDataRows();
        foreach (DRRoleLv row in _rows)
        {
            Dic.Add(row.Lv, row);
        }
    }

    /// <summary>
    /// 根据等级获取RoleLv表的row数据
    /// </summary>
    /// <param name="lv"></param>
    /// <returns></returns>
    public DRRoleLv GetRow(int lv)
    {
        if (Dic.ContainsKey(lv))
        {
            return Dic[lv];
        }

        return null;
    }
}