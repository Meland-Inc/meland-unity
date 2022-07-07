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
public class DRMap : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取地图ID。*/
    /// </summary>
    public int MapId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取地图类型。*/
    /// </summary>
    public string MapType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取配对主城。*/
    /// </summary>
    public string CapitalMapId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取配对野外。*/
    /// </summary>
    public string InstanceMapId
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        MapId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MapType = columnStrings[index++];
        CapitalMapId = columnStrings[index++];
        InstanceMapId = columnStrings[index++];

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                MapId = binaryReader.Read7BitEncodedInt32();
                MapType = binaryReader.ReadString();
                CapitalMapId = binaryReader.ReadString();
                InstanceMapId = binaryReader.ReadString();
            }
        }

        return true;
    }
}

