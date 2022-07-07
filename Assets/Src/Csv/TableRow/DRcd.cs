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
public class DRcd : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取条件id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取cd类型。*/
    /// </summary>
    public int Cd_type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取值1。*/
    /// </summary>
    public int Value
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否需要同步给前端。*/
    /// </summary>
    public bool Need_sync
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Cd_type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Value = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Need_sync = DataTableParseUtil.ParseBool(columnStrings[index++]);
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
                Cd_type = binaryReader.Read7BitEncodedInt32();
                Value = binaryReader.Read7BitEncodedInt32();
                Need_sync = binaryReader.ReadBoolean();
            }
        }

        return true;
    }
}

