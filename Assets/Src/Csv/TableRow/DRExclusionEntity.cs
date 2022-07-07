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
public class DRExclusionEntity : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取互斥ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取物件ID。*/
    /// </summary>
    public int Cid
    {
        get;
        private set;
    }

    /// <summary>
  /**获取互斥类型不建造。*/
    /// </summary>
    public int ExTypeNotBuild
    {
        get;
        private set;
    }

    /// <summary>
  /**获取互斥Cid列表。*/
    /// </summary>
    public string ExNotBuildCids
    {
        get;
        private set;
    }

    /// <summary>
  /**获取互斥类型删除。*/
    /// </summary>
    public int ExTypeDel
    {
        get;
        private set;
    }

    /// <summary>
  /**获取互斥Cid列表。*/
    /// </summary>
    public string ExDelCids
    {
        get;
        private set;
    }

    /// <summary>
  /**获取互斥类型移动。*/
    /// </summary>
    public int ExTypeMove
    {
        get;
        private set;
    }

    /// <summary>
  /**获取互斥Cid列表。*/
    /// </summary>
    public string ExMoveCids
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Cid = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ExTypeNotBuild = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ExNotBuildCids = columnStrings[index++];
        ExTypeDel = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ExDelCids = columnStrings[index++];
        ExTypeMove = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ExMoveCids = columnStrings[index++];

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Cid = binaryReader.Read7BitEncodedInt32();
                ExTypeNotBuild = binaryReader.Read7BitEncodedInt32();
                ExNotBuildCids = binaryReader.ReadString();
                ExTypeDel = binaryReader.Read7BitEncodedInt32();
                ExDelCids = binaryReader.ReadString();
                ExTypeMove = binaryReader.Read7BitEncodedInt32();
                ExMoveCids = binaryReader.ReadString();
            }
        }

        return true;
    }
}

