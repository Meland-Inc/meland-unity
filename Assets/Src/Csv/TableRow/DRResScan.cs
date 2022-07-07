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
public class DRResScan : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取搜索id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取搜索类型。*/
    /// </summary>
    public int ScanType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取资源来源id。*/
    /// </summary>
    public int ScanId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取代码块检索字段下标。*/
    /// </summary>
    public string ScanIndex
    {
        get;
        private set;
    }

    /// <summary>
  /**获取类别。*/
    /// </summary>
    public string Category
    {
        get;
        private set;
    }

    /// <summary>
  /**获取链接类型。*/
    /// </summary>
    public string UrlType
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        ScanType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ScanId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ScanIndex = columnStrings[index++];
        Category = columnStrings[index++];
        UrlType = columnStrings[index++];

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                ScanType = binaryReader.Read7BitEncodedInt32();
                ScanId = binaryReader.Read7BitEncodedInt32();
                ScanIndex = binaryReader.ReadString();
                Category = binaryReader.ReadString();
                UrlType = binaryReader.ReadString();
            }
        }

        return true;
    }
}

