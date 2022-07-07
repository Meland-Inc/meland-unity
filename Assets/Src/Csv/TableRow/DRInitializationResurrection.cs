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
public class DRInitializationResurrection : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取传送点ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取复活点名字。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取地图1。*/
    /// </summary>
    public int MapId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取X(像素)。*/
    /// </summary>
    public int X
    {
        get;
        private set;
    }

    /// <summary>
  /**获取Y(像素)。*/
    /// </summary>
    public int Y
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否为初始复活点。*/
    /// </summary>
    public int InitializationResurrection
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Name = columnStrings[index++];
        MapId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        X = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Y = DataTableParseUtil.ParseInt(columnStrings[index++]);
        InitializationResurrection = DataTableParseUtil.ParseInt(columnStrings[index++]);
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
                Name = binaryReader.ReadString();
                MapId = binaryReader.Read7BitEncodedInt32();
                X = binaryReader.Read7BitEncodedInt32();
                Y = binaryReader.Read7BitEncodedInt32();
                InitializationResurrection = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

