/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: craftSkill 表
 * @Date: 2022-06-30 16:42:01
 * @FilePath: /Assets/Src/Csv/Table/CraftSkillTable.cs
 */
using GameFramework.DataTable;
using System.Collections.Generic;

public class CraftSkillTable
{
    private readonly DRCraftSkill[] _rows;
    private static CraftSkillTable s_instance;
    public Dictionary<int, List<DRCraftSkill>> Dic { get; private set; } = new();
    public static CraftSkillTable Inst
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = new CraftSkillTable();
            }

            return s_instance;
        }
    }

    public CraftSkillTable()
    {
        IDataTable<DRCraftSkill> dtAircraft = GFEntry.DataTable.GetDataTable<DRCraftSkill>();
        _rows = dtAircraft.GetAllDataRows();
        foreach (DRCraftSkill row in _rows)
        {
            if (!Dic.ContainsKey(row.SkillId))
            {
                Dic.Add(row.SkillId, new List<DRCraftSkill>());
            }
            Dic[row.SkillId].Add(row);
        }
    }

    /// <summary>
    /// 通过skillID和等级获取数据
    /// </summary>
    /// <param name="skillId"></param>
    /// <param name="lv"></param>
    /// <returns></returns>
    public DRCraftSkill GetRow(int skillId, int lv)
    {
        if (!Dic.ContainsKey(skillId))
        {
            return null;
        }

        List<DRCraftSkill> list = Dic[skillId];
        return list.Find(skill => skill.Level == lv);
    }

    public List<int> GetSkillRecipes(int skillId)
    {
        List<int> recipesList = new();
        List<DRCraftSkill> rowList = Dic[skillId];
        for (int i = 0; i < rowList.Count; i++)
        {
            foreach (int id in rowList[i].RecipeIds)
            {
                recipesList.Add(id);
            }
        }

        return recipesList;
    }

    public DRCraftSkill GetNextLvRow(int skillID, int curLv)
    {
        if (!Dic.ContainsKey(skillID))
        {
            return null;
        }

        List<DRCraftSkill> rowList = Dic[skillID];
        for (int i = 0; i < rowList.Count; i++)
        {
            if (rowList[i].Level == curLv)
            {
                if (i + 1 < rowList.Count)
                {
                    return rowList[i + 1];
                }
            }
        }

        return null;
    }
}