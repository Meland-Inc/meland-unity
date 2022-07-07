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
public class DRTask : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取任务ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取任务等级。*/
    /// </summary>
    public int Level
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务名。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务描述。*/
    /// </summary>
    public string Decs
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务链体系。*/
    /// </summary>
    public int[] SubSystem
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务类型。*/
    /// </summary>
    public int Type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取道具需求。*/
    /// </summary>
    public int[][] Item
    {
        get;
        private set;
    }

    /// <summary>
  /**获取使用道具。*/
    /// </summary>
    public int[][] UseItem
    {
        get;
        private set;
    }

    /// <summary>
  /**获取怪物需求。*/
    /// </summary>
    public int[][] Monster
    {
        get;
        private set;
    }

    /// <summary>
  /**获取坐标需求。*/
    /// </summary>
    public int[][] MoveTo
    {
        get;
        private set;
    }

    /// <summary>
  /**获取quiz需求。*/
    /// </summary>
    public int[][] Quiz
    {
        get;
        private set;
    }

    /// <summary>
  /**获取地块需求。*/
    /// </summary>
    public int RequestLand
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务道具奖励。*/
    /// </summary>
    public int ItemReward
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务Ditamin奖励。*/
    /// </summary>
    public int DitaminReward
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务Exp奖励。*/
    /// </summary>
    public int ExpReward
    {
        get;
        private set;
    }

    /// <summary>
  /**获取难度系数（预留）。*/
    /// </summary>
    public int Difficulty
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Level = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Name = columnStrings[index++];
        Decs = columnStrings[index++];
        SubSystem = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        Type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Item = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        UseItem = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        Monster = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        MoveTo = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        Quiz = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        RequestLand = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ItemReward = DataTableParseUtil.ParseInt(columnStrings[index++]);
        DitaminReward = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ExpReward = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Difficulty = DataTableParseUtil.ParseInt(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Level = binaryReader.Read7BitEncodedInt32();
                Name = binaryReader.ReadString();
                Decs = binaryReader.ReadString();
                SubSystem = binaryReader.ReadArray<Int32>();
                Type = binaryReader.Read7BitEncodedInt32();
                Item = binaryReader.ReadArrayList<Int32>();
                UseItem = binaryReader.ReadArrayList<Int32>();
                Monster = binaryReader.ReadArrayList<Int32>();
                MoveTo = binaryReader.ReadArrayList<Int32>();
                Quiz = binaryReader.ReadArrayList<Int32>();
                RequestLand = binaryReader.Read7BitEncodedInt32();
                ItemReward = binaryReader.Read7BitEncodedInt32();
                DitaminReward = binaryReader.Read7BitEncodedInt32();
                ExpReward = binaryReader.Read7BitEncodedInt32();
                Difficulty = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

