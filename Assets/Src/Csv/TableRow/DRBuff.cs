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
public class DRBuff : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取BUFF ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取BUFF效果1。*/
    /// </summary>
    public int BuffEffect
    {
        get;
        private set;
    }

    /// <summary>
  /**获取BUFF组ID。*/
    /// </summary>
    public int BuffGroupId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取替换优先级
越大越高。*/
    /// </summary>
    public int BuffPriority
    {
        get;
        private set;
    }

    /// <summary>
  /**获取BUFF参数。*/
    /// </summary>
    public int[] BuffPara
    {
        get;
        private set;
    }

    /// <summary>
  /**获取总时间。*/
    /// </summary>
    public int TotleTime
    {
        get;
        private set;
    }

    /// <summary>
  /**获取触发间隔
毫秒。*/
    /// </summary>
    public int TriggerInterval
    {
        get;
        private set;
    }

    /// <summary>
  /**获取Buff名。*/
    /// </summary>
    public string BuffName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取描述。*/
    /// </summary>
    public string BuffDesc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取展示icon。*/
    /// </summary>
    public string BuffIcon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取特效。*/
    /// </summary>
    public string BuffAnimation
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        BuffEffect = DataTableParseUtil.ParseInt(columnStrings[index++]);
        BuffGroupId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        BuffPriority = DataTableParseUtil.ParseInt(columnStrings[index++]);
        BuffPara = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        TotleTime = DataTableParseUtil.ParseInt(columnStrings[index++]);
        TriggerInterval = DataTableParseUtil.ParseInt(columnStrings[index++]);
        BuffName = columnStrings[index++];
        BuffDesc = columnStrings[index++];
        BuffIcon = columnStrings[index++];
        BuffAnimation = columnStrings[index++];

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                BuffEffect = binaryReader.Read7BitEncodedInt32();
                BuffGroupId = binaryReader.Read7BitEncodedInt32();
                BuffPriority = binaryReader.Read7BitEncodedInt32();
                BuffPara = binaryReader.ReadArray<Int32>();
                TotleTime = binaryReader.Read7BitEncodedInt32();
                TriggerInterval = binaryReader.Read7BitEncodedInt32();
                BuffName = binaryReader.ReadString();
                BuffDesc = binaryReader.ReadString();
                BuffIcon = binaryReader.ReadString();
                BuffAnimation = binaryReader.ReadString();
            }
        }

        return true;
    }
}

