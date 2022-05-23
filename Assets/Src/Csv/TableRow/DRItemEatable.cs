//------------------------------------------------------------
// 此文件由工具自动生成
// 生成时间：2022-05-23 15:59:48.101
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
public class DRItemEatable : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取使用CD
毫秒。*/
    /// </summary>
    public int Cd
    {
        get;
        private set;
    }

    /// <summary>
  /**获取调用方法。*/
    /// </summary>
    public string[] CallFunc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取调用方法参数。*/
    /// </summary>
    public int[] Args
    {
        get;
        private set;
    }

    /// <summary>
  /**获取cd组。*/
    /// </summary>
    public int CdType
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        index++;
        Cd = DataTableExtension.ParseInt(columnStrings[index++]);
        CallFunc = DataTableExtension.ParseArray<string>(columnStrings[index++]);
        Args = DataTableExtension.ParseArray<int>(columnStrings[index++]);
        CdType = DataTableExtension.ParseInt(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Cd = binaryReader.Read7BitEncodedInt32();
                CallFunc = binaryReader.ReadArray<String>();
                Args = binaryReader.ReadArray<Int32>();
                CdType = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

