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
public class DRcondition : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取条件id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取条件类型。*/
    /// </summary>
    public int Condition_type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取比较类型1。*/
    /// </summary>
    public int Compare_type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取比较参数。*/
    /// </summary>
    public int Compare_value
    {
        get;
        private set;
    }

    /// <summary>
  /**获取附加参数。*/
    /// </summary>
    public int[] Params
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Condition_type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Compare_type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Compare_value = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Params = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        index++;

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Condition_type = binaryReader.Read7BitEncodedInt32();
                Compare_type = binaryReader.Read7BitEncodedInt32();
                Compare_value = binaryReader.Read7BitEncodedInt32();
                Params = binaryReader.ReadArray<Int32>();
            }
        }

        return true;
    }
}

