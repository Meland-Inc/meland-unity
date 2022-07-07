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
public class DRhelp : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取使用系统。*/
    /// </summary>
    public int UseSystem
    {
        get;
        private set;
    }

    /// <summary>
  /**获取图片1。*/
    /// </summary>
    public string Picture1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取描述文本1。*/
    /// </summary>
    public string Text1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取图片2。*/
    /// </summary>
    public string Picture2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取描述文本2。*/
    /// </summary>
    public string Text2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取图片3。*/
    /// </summary>
    public string Picture3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取描述文本3。*/
    /// </summary>
    public string Text3
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        UseSystem = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Picture1 = columnStrings[index++];
        Text1 = columnStrings[index++];
        Picture2 = columnStrings[index++];
        Text2 = columnStrings[index++];
        Picture3 = columnStrings[index++];
        Text3 = columnStrings[index++];

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                UseSystem = binaryReader.Read7BitEncodedInt32();
                Picture1 = binaryReader.ReadString();
                Text1 = binaryReader.ReadString();
                Picture2 = binaryReader.ReadString();
                Text2 = binaryReader.ReadString();
                Picture3 = binaryReader.ReadString();
                Text3 = binaryReader.ReadString();
            }
        }

        return true;
    }
}

