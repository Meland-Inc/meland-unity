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
public class DRTaskReward : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取配方 ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取道具奖励。*/
    /// </summary>
    public int[][] RewardList
    {
        get;
        private set;
    }

    /// <summary>
  /**获取Ditamin奖励。*/
    /// </summary>
    public int Ditamin
    {
        get;
        private set;
    }

    /// <summary>
  /**获取Exp奖励。*/
    /// </summary>
    public int Exp
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
        RewardList = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        Ditamin = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Exp = DataTableParseUtil.ParseInt(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                RewardList = binaryReader.ReadArrayList<Int32>();
                Ditamin = binaryReader.Read7BitEncodedInt32();
                Exp = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

