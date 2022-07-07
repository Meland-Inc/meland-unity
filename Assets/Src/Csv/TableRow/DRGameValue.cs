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
public class DRGameValue : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取索引1。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取值。*/
    /// </summary>
    public int Value
    {
        get;
        private set;
    }

    /// <summary>
  /**获取字符串值。*/
    /// </summary>
    public string StrValue
    {
        get;
        private set;
    }

    /// <summary>
  /**获取数组值1。*/
    /// </summary>
    public int[] ValueArray
    {
        get;
        private set;
    }

    /// <summary>
  /**获取数组字符串。*/
    /// </summary>
    public string[] StrValueArray
    {
        get;
        private set;
    }

    /// <summary>
  /**获取备注1(模块)。*/
    /// </summary>
    public string Note1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取备注2。*/
    /// </summary>
    public string Note2
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Value = DataTableParseUtil.ParseInt(columnStrings[index++]);
        StrValue = columnStrings[index++];
        ValueArray = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        StrValueArray = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Note1 = columnStrings[index++];
        Note2 = columnStrings[index++];

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Value = binaryReader.Read7BitEncodedInt32();
                StrValue = binaryReader.ReadString();
                ValueArray = binaryReader.ReadArray<Int32>();
                StrValueArray = binaryReader.ReadArray<String>();
                Note1 = binaryReader.ReadString();
                Note2 = binaryReader.ReadString();
            }
        }

        return true;
    }
}

