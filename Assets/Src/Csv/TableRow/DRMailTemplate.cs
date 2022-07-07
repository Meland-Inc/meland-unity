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
public class DRMailTemplate : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取模板标题。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取模板内容。*/
    /// </summary>
    public string Description
    {
        get;
        private set;
    }

    /// <summary>
  /**获取置顶邮件。*/
    /// </summary>
    public int Top
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否初始发送。*/
    /// </summary>
    public int Initial
    {
        get;
        private set;
    }

    /// <summary>
  /**获取邮件发送持续时间（单位秒）。*/
    /// </summary>
    public int Duration
    {
        get;
        private set;
    }

    /// <summary>
  /**获取Reward表奖励组ID。*/
    /// </summary>
    public int RewardGifId
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
        Description = columnStrings[index++];
        Top = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Initial = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Duration = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RewardGifId = DataTableParseUtil.ParseInt(columnStrings[index++]);

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
                Description = binaryReader.ReadString();
                Top = binaryReader.Read7BitEncodedInt32();
                Initial = binaryReader.Read7BitEncodedInt32();
                Duration = binaryReader.Read7BitEncodedInt32();
                RewardGifId = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

