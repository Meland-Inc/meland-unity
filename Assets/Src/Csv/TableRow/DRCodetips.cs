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
public class DRCodetips : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取代码块ID1。*/
    /// </summary>
    public int CodeblockId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取描述Desc。*/
    /// </summary>
    public string Tips
    {
        get;
        private set;
    }

    /// <summary>
  /**获取描述图片名字。*/
    /// </summary>
    public string Image
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        CodeblockId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Tips = columnStrings[index++];
        Image = columnStrings[index++];

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                CodeblockId = binaryReader.Read7BitEncodedInt32();
                Tips = binaryReader.ReadString();
                Image = binaryReader.ReadString();
            }
        }

        return true;
    }
}

