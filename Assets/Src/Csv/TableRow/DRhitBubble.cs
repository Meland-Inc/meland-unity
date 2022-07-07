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
public class DRhitBubble : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取受击物件类型。*/
    /// </summary>
    public string HitedType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取对应ID。*/
    /// </summary>
    public int LinkId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取对应名称。*/
    /// </summary>
    public string Linkname
    {
        get;
        private set;
    }

    /// <summary>
  /**获取触发范围。*/
    /// </summary>
    public int TriggeredRange
    {
        get;
        private set;
    }

    /// <summary>
  /**获取发现气泡。*/
    /// </summary>
    public string[] FoundBubble
    {
        get;
        private set;
    }

    /// <summary>
  /**获取气泡0。*/
    /// </summary>
    public string[] Bubble0
    {
        get;
        private set;
    }

    /// <summary>
  /**获取气泡1。*/
    /// </summary>
    public string[] Bubble1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取气泡2。*/
    /// </summary>
    public string[] Bubble2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取气泡3。*/
    /// </summary>
    public string[] Bubble3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取气泡4。*/
    /// </summary>
    public string[] Bubble4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取概率。*/
    /// </summary>
    public int Probability
    {
        get;
        private set;
    }

    /// <summary>
  /**获取怪物残血气泡。*/
    /// </summary>
    public string[] MonsterNoblood
    {
        get;
        private set;
    }

    /// <summary>
  /**获取怪物死亡气泡。*/
    /// </summary>
    public string[] MonsterDiebubble
    {
        get;
        private set;
    }

    /// <summary>
  /**获取玩家残血气泡。*/
    /// </summary>
    public string[] PlayerNoblood
    {
        get;
        private set;
    }

    /// <summary>
  /**获取怪物嘲讽气泡。*/
    /// </summary>
    public string[] MonsterTaunt
    {
        get;
        private set;
    }

    /// <summary>
  /**获取进阶等级。*/
    /// </summary>
    public int[][] Uplevel
    {
        get;
        private set;
    }

    /// <summary>
  /**获取气泡上限。*/
    /// </summary>
    public int BubbleUpper
    {
        get;
        private set;
    }

    /// <summary>
  /**获取气泡冷却。*/
    /// </summary>
    public int BubbleCD
    {
        get;
        private set;
    }

    /// <summary>
  /**获取受击表情资源。*/
    /// </summary>
    public string ExpressionRes
    {
        get;
        private set;
    }

    /// <summary>
  /**获取受击表情播放时间（毫秒）。*/
    /// </summary>
    public int ExpressionTime
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        HitedType = columnStrings[index++];
        LinkId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Linkname = columnStrings[index++];
        TriggeredRange = DataTableParseUtil.ParseInt(columnStrings[index++]);
        FoundBubble = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Bubble0 = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Bubble1 = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Bubble2 = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Bubble3 = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Bubble4 = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Probability = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MonsterNoblood = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        MonsterDiebubble = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        PlayerNoblood = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        MonsterTaunt = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Uplevel = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        BubbleUpper = DataTableParseUtil.ParseInt(columnStrings[index++]);
        BubbleCD = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ExpressionRes = columnStrings[index++];
        ExpressionTime = DataTableParseUtil.ParseInt(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                HitedType = binaryReader.ReadString();
                LinkId = binaryReader.Read7BitEncodedInt32();
                Linkname = binaryReader.ReadString();
                TriggeredRange = binaryReader.Read7BitEncodedInt32();
                FoundBubble = binaryReader.ReadArray<String>();
                Bubble0 = binaryReader.ReadArray<String>();
                Bubble1 = binaryReader.ReadArray<String>();
                Bubble2 = binaryReader.ReadArray<String>();
                Bubble3 = binaryReader.ReadArray<String>();
                Bubble4 = binaryReader.ReadArray<String>();
                Probability = binaryReader.Read7BitEncodedInt32();
                MonsterNoblood = binaryReader.ReadArray<String>();
                MonsterDiebubble = binaryReader.ReadArray<String>();
                PlayerNoblood = binaryReader.ReadArray<String>();
                MonsterTaunt = binaryReader.ReadArray<String>();
                Uplevel = binaryReader.ReadArrayList<Int32>();
                BubbleUpper = binaryReader.Read7BitEncodedInt32();
                BubbleCD = binaryReader.Read7BitEncodedInt32();
                ExpressionRes = binaryReader.ReadString();
                ExpressionTime = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

