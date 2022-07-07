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
public class DRCodeblockPy : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取关联代码块id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取代码块描述。*/
    /// </summary>
    public string CodeblockDesc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取python名字。*/
    /// </summary>
    public string Pythonname
    {
        get;
        private set;
    }

    /// <summary>
  /**获取python结构。*/
    /// </summary>
    public string PyStructure
    {
        get;
        private set;
    }

    /// <summary>
  /**获取python描述。*/
    /// </summary>
    public string PyDesc
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        CodeblockDesc = columnStrings[index++];
        Pythonname = columnStrings[index++];
        PyStructure = columnStrings[index++];
        PyDesc = columnStrings[index++];

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                CodeblockDesc = binaryReader.ReadString();
                Pythonname = binaryReader.ReadString();
                PyStructure = binaryReader.ReadString();
                PyDesc = binaryReader.ReadString();
            }
        }

        return true;
    }
}

