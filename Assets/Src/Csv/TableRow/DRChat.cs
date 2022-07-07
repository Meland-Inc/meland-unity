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
public class DRChat : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取频道ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取颜色值。*/
    /// </summary>
    public string ChannelRGB
    {
        get;
        private set;
    }

    /// <summary>
  /**获取发言CD（毫秒）。*/
    /// </summary>
    public int TalkCD
    {
        get;
        private set;
    }

    /// <summary>
  /**获取最大展示条数。*/
    /// </summary>
    public int MaxTips
    {
        get;
        private set;
    }

    /// <summary>
  /**获取需要金币。*/
    /// </summary>
    public int TalkNeedGold
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否冒泡。*/
    /// </summary>
    public bool IfBubble
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
        ChannelRGB = columnStrings[index++];
        TalkCD = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MaxTips = DataTableParseUtil.ParseInt(columnStrings[index++]);
        TalkNeedGold = DataTableParseUtil.ParseInt(columnStrings[index++]);
        IfBubble = DataTableParseUtil.ParseBool(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                ChannelRGB = binaryReader.ReadString();
                TalkCD = binaryReader.Read7BitEncodedInt32();
                MaxTips = binaryReader.Read7BitEncodedInt32();
                TalkNeedGold = binaryReader.Read7BitEncodedInt32();
                IfBubble = binaryReader.ReadBoolean();
            }
        }

        return true;
    }
}

