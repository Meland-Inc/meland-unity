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
public class DRMapSign : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取标记id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取标记名。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取标记图标。*/
    /// </summary>
    public string Icon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取斜视角材质。*/
    /// </summary>
    public string Texture
    {
        get;
        private set;
    }

    /// <summary>
  /**获取正视角材质。*/
    /// </summary>
    public string RectTexture
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
        Icon = columnStrings[index++];
        Texture = columnStrings[index++];
        RectTexture = columnStrings[index++];

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
                Icon = binaryReader.ReadString();
                Texture = binaryReader.ReadString();
                RectTexture = binaryReader.ReadString();
            }
        }

        return true;
    }
}

