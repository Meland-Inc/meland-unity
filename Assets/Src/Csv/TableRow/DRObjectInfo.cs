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
public class DRObjectInfo : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取流水。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取类型。*/
    /// </summary>
    public int Type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取信息ID。*/
    /// </summary>
    public int InfoId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取名称。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取类型。*/
    /// </summary>
    public string InfoType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取图标资源。*/
    /// </summary>
    public string InfoIcon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取标题1。*/
    /// </summary>
    public string InfoTitle1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取描述1。*/
    /// </summary>
    public string InfoDescribe1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取标题2。*/
    /// </summary>
    public string InfoTitle2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取描述2。*/
    /// </summary>
    public string InfoDescribe2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取标题3。*/
    /// </summary>
    public string InfoTitle3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取描述3。*/
    /// </summary>
    public string InfoDescribe3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取标题4。*/
    /// </summary>
    public string InfoTitle4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取描述4。*/
    /// </summary>
    public string InfoDescribe4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取标题5。*/
    /// </summary>
    public string InfoTitle5
    {
        get;
        private set;
    }

    /// <summary>
  /**获取描述5。*/
    /// </summary>
    public string InfoDescribe5
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        InfoId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Name = columnStrings[index++];
        index++;
        InfoType = columnStrings[index++];
        InfoIcon = columnStrings[index++];
        InfoTitle1 = columnStrings[index++];
        InfoDescribe1 = columnStrings[index++];
        InfoTitle2 = columnStrings[index++];
        InfoDescribe2 = columnStrings[index++];
        InfoTitle3 = columnStrings[index++];
        InfoDescribe3 = columnStrings[index++];
        InfoTitle4 = columnStrings[index++];
        InfoDescribe4 = columnStrings[index++];
        InfoTitle5 = columnStrings[index++];
        InfoDescribe5 = columnStrings[index++];

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
                InfoId = binaryReader.Read7BitEncodedInt32();
                Name = binaryReader.ReadString();
                InfoType = binaryReader.ReadString();
                InfoIcon = binaryReader.ReadString();
                InfoTitle1 = binaryReader.ReadString();
                InfoDescribe1 = binaryReader.ReadString();
                InfoTitle2 = binaryReader.ReadString();
                InfoDescribe2 = binaryReader.ReadString();
                InfoTitle3 = binaryReader.ReadString();
                InfoDescribe3 = binaryReader.ReadString();
                InfoTitle4 = binaryReader.ReadString();
                InfoDescribe4 = binaryReader.ReadString();
                InfoTitle5 = binaryReader.ReadString();
                InfoDescribe5 = binaryReader.ReadString();
            }
        }

        return true;
    }
}

