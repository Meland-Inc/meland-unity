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
public class DRArchProduction : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取工作台Id1。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取工作台类型。*/
    /// </summary>
    public int Type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取工作台数据在那张表1。*/
    /// </summary>
    public int WorkbenchFrom
    {
        get;
        private set;
    }

    /// <summary>
  /**获取哪些是这个容器的燃料。*/
    /// </summary>
    public int[] NeedFuel
    {
        get;
        private set;
    }

    /// <summary>
  /**获取配方id数组。*/
    /// </summary>
    public int[] FormulaIds
    {
        get;
        private set;
    }

    /// <summary>
  /**获取存储格子数量。*/
    /// </summary>
    public int StorageNum
    {
        get;
        private set;
    }

    /// <summary>
  /**获取燃烧效率。*/
    /// </summary>
    public int BuningRatio
    {
        get;
        private set;
    }

    /// <summary>
  /**获取提示框最大字数。*/
    /// </summary>
    public int MaxChars
    {
        get;
        private set;
    }

    /// <summary>
  /**获取提示框默认内容。*/
    /// </summary>
    public string DefaultContent
    {
        get;
        private set;
    }

    /// <summary>
  /**获取提示框每次显示时间。*/
    /// </summary>
    public int DisplayTime
    {
        get;
        private set;
    }

    /// <summary>
  /**获取提示框触发范围(像素)。*/
    /// </summary>
    public int TriggerRange
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        index++;
        Type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        WorkbenchFrom = DataTableParseUtil.ParseInt(columnStrings[index++]);
        NeedFuel = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        FormulaIds = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        StorageNum = DataTableParseUtil.ParseInt(columnStrings[index++]);
        BuningRatio = DataTableParseUtil.ParseInt(columnStrings[index++]);
        index++;
        MaxChars = DataTableParseUtil.ParseInt(columnStrings[index++]);
        DefaultContent = columnStrings[index++];
        DisplayTime = DataTableParseUtil.ParseInt(columnStrings[index++]);
        TriggerRange = DataTableParseUtil.ParseInt(columnStrings[index++]);

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
                WorkbenchFrom = binaryReader.Read7BitEncodedInt32();
                NeedFuel = binaryReader.ReadArray<Int32>();
                FormulaIds = binaryReader.ReadArray<Int32>();
                StorageNum = binaryReader.Read7BitEncodedInt32();
                BuningRatio = binaryReader.Read7BitEncodedInt32();
                MaxChars = binaryReader.Read7BitEncodedInt32();
                DefaultContent = binaryReader.ReadString();
                DisplayTime = binaryReader.Read7BitEncodedInt32();
                TriggerRange = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

