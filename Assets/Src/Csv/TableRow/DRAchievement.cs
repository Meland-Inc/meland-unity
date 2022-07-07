//------------------------------------------------------------
// 此文件由工具自动生成
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityGameFramework.Runtime;


/// <summary>
/** __DATA_TABLE_COMMENT__*/
/// </summary>
public class DRAchievement : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取成就ID2。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取成就类型
1.探索
2.打怪
3.建造
4.采集
5.合成
6.代码块使用
7.机器人采集
8.机器人打怪
9.机器人合成
10.机器人建造
。*/
    /// </summary>
    public int Type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取对应ID
(为0则代表对应类型总量)
1.SceneID
2.MonsterID
3.EntityObjectID
。*/
    /// </summary>
    public int LinkId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取对应数量。*/
    /// </summary>
    public int[] Number
    {
        get;
        private set;
    }

    /// <summary>
  /**获取成就奖励
（读reward）。*/
    /// </summary>
    public int[] AchieveReward
    {
        get;
        private set;
    }

    /// <summary>
  /**获取成就名称。*/
    /// </summary>
    public string[] AchieveName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取成就描述。*/
    /// </summary>
    public string[] AchieveDiscribe
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        LinkId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Number = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        AchieveReward = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        AchieveName = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        AchieveDiscribe = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Type = binaryReader.Read7BitEncodedInt32();
                LinkId = binaryReader.Read7BitEncodedInt32();
                Number = binaryReader.ReadArray<Int32>();
                AchieveReward = binaryReader.ReadArray<Int32>();
                AchieveName = binaryReader.ReadArray<String>();
                AchieveDiscribe = binaryReader.ReadArray<String>();
            }
        }

        return true;
    }
}

