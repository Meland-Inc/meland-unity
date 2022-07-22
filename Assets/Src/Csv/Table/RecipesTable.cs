/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 插槽等级表
 * @Date: 2022-06-24 14:41:06
 * @FilePath: /Assets/Src/Csv/Table/RecipesTable.cs
 */
using GameFramework.DataTable;
using System.Collections.Generic;

public class RecipesTable
{
    private readonly DRRecipes[] _rows;
    private static RecipesTable s_instance;
    public Dictionary<int, DRRecipes> Dic { get; private set; } = new();
    private Dictionary<int, List<DRRecipes>> _dicByType = new();
    public static RecipesTable Inst
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = new RecipesTable();
            }

            return s_instance;
        }
    }

    public RecipesTable()
    {
        IDataTable<DRRecipes> dtAircraft = GFEntry.DataTable.GetDataTable<DRRecipes>();
        _rows = dtAircraft.GetAllDataRows();
        foreach (DRRecipes row in _rows)
        {
            Dic.Add(row.Id, row);
            if (!_dicByType.ContainsKey(row.DisplayType))
            {
                _dicByType.Add(row.DisplayType, new List<DRRecipes>());
            }
            _dicByType[row.DisplayType].Add(row);
        }
    }

    /// <summary>
    /// 获取接口限定好枚举类型的参数就好，防止业务处传非法类型
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public List<DRRecipes> GetRecipeIDListWithDisplayType(PlayerCraftModule.eRecipeDisplayType type)
    {
        if (_dicByType.ContainsKey((int)type))
        {
            return _dicByType[(int)type];
        }

        return null;
    }
}