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
public class DREntitySound : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取名字。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取类型。*/
    /// </summary>
    public int Type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取资源名。*/
    /// </summary>
    public string SourceName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取格式。*/
    /// </summary>
    public string Format
    {
        get;
        private set;
    }

    /// <summary>
  /**获取时长(毫秒）。*/
    /// </summary>
    public int Time
    {
        get;
        private set;
    }

    /// <summary>
  /**获取描述。*/
    /// </summary>
    public string Desc
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
        Type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        SourceName = columnStrings[index++];
        Format = columnStrings[index++];
        Time = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Desc = columnStrings[index++];

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
                Type = binaryReader.Read7BitEncodedInt32();
                SourceName = binaryReader.ReadString();
                Format = binaryReader.ReadString();
                Time = binaryReader.Read7BitEncodedInt32();
                Desc = binaryReader.ReadString();
            }
        }

        return true;
    }
}

