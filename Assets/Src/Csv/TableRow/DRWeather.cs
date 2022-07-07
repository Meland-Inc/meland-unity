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
public class DRWeather : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取天气ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取天气类型。*/
    /// </summary>
    public int WeatherType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取动画资源。*/
    /// </summary>
    public string AmiRes
    {
        get;
        private set;
    }

    /// <summary>
  /**获取动画类型。*/
    /// </summary>
    public bool AmiType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取天气图标。*/
    /// </summary>
    public string WeatherIcon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取影响图标。*/
    /// </summary>
    public string EffectIcon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取影响文字。*/
    /// </summary>
    public string EffectDesc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取完整描述。*/
    /// </summary>
    public string FullDesc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取温度的变化量。*/
    /// </summary>
    public int TempChange
    {
        get;
        private set;
    }

    /// <summary>
  /**获取饥渴值变化量。*/
    /// </summary>
    public int ThirstyChange
    {
        get;
        private set;
    }

    /// <summary>
  /**获取饥饿值变化量。*/
    /// </summary>
    public int HungryChange
    {
        get;
        private set;
    }

    /// <summary>
  /**获取BUFF_ID。*/
    /// </summary>
    public int BuffId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取添加BUFF的间隔时间(毫秒)。*/
    /// </summary>
    public int Interval
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        WeatherType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        index++;
        AmiRes = columnStrings[index++];
        AmiType = DataTableParseUtil.ParseBool(columnStrings[index++]);
        WeatherIcon = columnStrings[index++];
        EffectIcon = columnStrings[index++];
        EffectDesc = columnStrings[index++];
        FullDesc = columnStrings[index++];
        TempChange = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ThirstyChange = DataTableParseUtil.ParseInt(columnStrings[index++]);
        HungryChange = DataTableParseUtil.ParseInt(columnStrings[index++]);
        BuffId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Interval = DataTableParseUtil.ParseInt(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                WeatherType = binaryReader.Read7BitEncodedInt32();
                AmiRes = binaryReader.ReadString();
                AmiType = binaryReader.ReadBoolean();
                WeatherIcon = binaryReader.ReadString();
                EffectIcon = binaryReader.ReadString();
                EffectDesc = binaryReader.ReadString();
                FullDesc = binaryReader.ReadString();
                TempChange = binaryReader.Read7BitEncodedInt32();
                ThirstyChange = binaryReader.Read7BitEncodedInt32();
                HungryChange = binaryReader.Read7BitEncodedInt32();
                BuffId = binaryReader.Read7BitEncodedInt32();
                Interval = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

