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
public class DREduResource : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取资源ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取资源名称。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取资源来源类型。*/
    /// </summary>
    public int SourceType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取资源来源id。*/
    /// </summary>
    public int SourceId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取素材库标签。*/
    /// </summary>
    public int ResourceGroupTag
    {
        get;
        private set;
    }

    /// <summary>
  /**获取资源描述。*/
    /// </summary>
    public string Desc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取素材标签。*/
    /// </summary>
    public string[] ResourceTag
    {
        get;
        private set;
    }

    /// <summary>
  /**获取预览图1。*/
    /// </summary>
    public string Preview1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取预览图2。*/
    /// </summary>
    public string Preview2
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
        SourceType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        SourceId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ResourceGroupTag = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Desc = columnStrings[index++];
        ResourceTag = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Preview1 = columnStrings[index++];
        Preview2 = columnStrings[index++];

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
                SourceType = binaryReader.Read7BitEncodedInt32();
                SourceId = binaryReader.Read7BitEncodedInt32();
                ResourceGroupTag = binaryReader.Read7BitEncodedInt32();
                Desc = binaryReader.ReadString();
                ResourceTag = binaryReader.ReadArray<String>();
                Preview1 = binaryReader.ReadString();
                Preview2 = binaryReader.ReadString();
            }
        }

        return true;
    }
}

