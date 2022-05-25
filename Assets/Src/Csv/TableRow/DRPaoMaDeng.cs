﻿//------------------------------------------------------------
// 此文件由工具自动生成
// 生成时间：2022-05-25 14:56:28.717
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
public class DRPaoMaDeng : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取触发等级。*/
    /// </summary>
    public int Triggerlv
    {
        get;
        private set;
    }

    /// <summary>
  /**获取触发文本。*/
    /// </summary>
    public string Text1
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Triggerlv = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Text1 = columnStrings[index++];

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Triggerlv = binaryReader.Read7BitEncodedInt32();
                Text1 = binaryReader.ReadString();
            }
        }

        return true;
    }
}

