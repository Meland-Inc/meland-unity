/*
 * @Author: xiang huan
 * @Date: 2022-05-20 10:05:43
 * @LastEditTime: 2022-05-23 16:41:07
 * @LastEditors: xiang huan
 * @Description: 如果想要自己添加方法查询表，可以像这样定义一个单例去取表数据然后添加方法查询
 * @FilePath: /meland-unity/Assets/Src/Csv/Table/AchievementTable.cs
 * 
 */


using GameFramework.DataTable;

public class AchievementTable
{
    private readonly DRAchievement[] _rows;
    private static AchievementTable s_instance;
    public static AchievementTable Inst
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = new AchievementTable();
            }

            return s_instance;
        }
    }

    public AchievementTable()
    {
        IDataTable<DRAchievement> dtAircraft = GFEntry.DataTable.GetDataTable<DRAchievement>();
        _rows = dtAircraft.GetAllDataRows();
    }
}