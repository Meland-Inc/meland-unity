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
public class DREntitySceneForce : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取实体cid。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取备注。*/
    /// </summary>
    public string Desc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取作用力/s。*/
    /// </summary>
    public int Force
    {
        get;
        private set;
    }

    /// <summary>
  /**获取默认方向。*/
    /// </summary>
    public int[] Dir
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Desc = columnStrings[index++];
        Force = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Dir = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Desc = binaryReader.ReadString();
                Force = binaryReader.Read7BitEncodedInt32();
                Dir = binaryReader.ReadArray<Int32>();
            }
        }

        return true;
    }
}

