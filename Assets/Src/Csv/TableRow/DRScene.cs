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
public class DRScene : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取场景名称。*/
    /// </summary>
    public string Scene
    {
        get;
        private set;
    }

    /// <summary>
  /**获取场景标记地块。*/
    /// </summary>
    public string SceneCell
    {
        get;
        private set;
    }

    /// <summary>
  /**获取场景音效。*/
    /// </summary>
    public string[] SceneMusic
    {
        get;
        private set;
    }

    /// <summary>
  /**获取备注。*/
    /// </summary>
    public string Remark
    {
        get;
        private set;
    }

    /// <summary>
  /**获取别称。*/
    /// </summary>
    public string OtherName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取天气类型。*/
    /// </summary>
    public int WeatherType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取天气音效。*/
    /// </summary>
    public string WeatherMusic
    {
        get;
        private set;
    }

    /// <summary>
  /**获取场景点缀特效。*/
    /// </summary>
    public int SceneSpecialEffect
    {
        get;
        private set;
    }

    /// <summary>
  /**获取角色场景说话（男）。*/
    /// </summary>
    public string[] PlayerTalkMan
    {
        get;
        private set;
    }

    /// <summary>
  /**获取角色场景说话（女）。*/
    /// </summary>
    public string[] PlayerTalkWomen
    {
        get;
        private set;
    }

    /// <summary>
  /**获取无操作时间。*/
    /// </summary>
    public int NoOperationTime
    {
        get;
        private set;
    }

    /// <summary>
  /**获取冷却时间。*/
    /// </summary>
    public int CoolingTime
    {
        get;
        private set;
    }

    /// <summary>
  /**获取每日上限。*/
    /// </summary>
    public int DailyUpper
    {
        get;
        private set;
    }

    /// <summary>
  /**获取开始天气概率
（万分率）。*/
    /// </summary>
    public int WeatherStartRate
    {
        get;
        private set;
    }

    /// <summary>
  /**获取结束天气概率
（万分率）。*/
    /// </summary>
    public int WeatherEndRate
    {
        get;
        private set;
    }

    /// <summary>
  /**获取默认温度。*/
    /// </summary>
    public int DefaultTemp
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Scene = columnStrings[index++];
        SceneCell = columnStrings[index++];
        SceneMusic = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Remark = columnStrings[index++];
        OtherName = columnStrings[index++];
        WeatherType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        WeatherMusic = columnStrings[index++];
        SceneSpecialEffect = DataTableParseUtil.ParseInt(columnStrings[index++]);
        PlayerTalkMan = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        PlayerTalkWomen = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        NoOperationTime = DataTableParseUtil.ParseInt(columnStrings[index++]);
        CoolingTime = DataTableParseUtil.ParseInt(columnStrings[index++]);
        DailyUpper = DataTableParseUtil.ParseInt(columnStrings[index++]);
        WeatherStartRate = DataTableParseUtil.ParseInt(columnStrings[index++]);
        WeatherEndRate = DataTableParseUtil.ParseInt(columnStrings[index++]);
        DefaultTemp = DataTableParseUtil.ParseInt(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Scene = binaryReader.ReadString();
                SceneCell = binaryReader.ReadString();
                SceneMusic = binaryReader.ReadArray<String>();
                Remark = binaryReader.ReadString();
                OtherName = binaryReader.ReadString();
                WeatherType = binaryReader.Read7BitEncodedInt32();
                WeatherMusic = binaryReader.ReadString();
                SceneSpecialEffect = binaryReader.Read7BitEncodedInt32();
                PlayerTalkMan = binaryReader.ReadArray<String>();
                PlayerTalkWomen = binaryReader.ReadArray<String>();
                NoOperationTime = binaryReader.Read7BitEncodedInt32();
                CoolingTime = binaryReader.Read7BitEncodedInt32();
                DailyUpper = binaryReader.Read7BitEncodedInt32();
                WeatherStartRate = binaryReader.Read7BitEncodedInt32();
                WeatherEndRate = binaryReader.Read7BitEncodedInt32();
                DefaultTemp = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

