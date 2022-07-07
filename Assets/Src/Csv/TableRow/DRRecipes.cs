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
public class DRRecipes : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取图鉴ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取图鉴归属技能。*/
    /// </summary>
    public int CraftSkill
    {
        get;
        private set;
    }

    /// <summary>
  /**获取图鉴ICON。*/
    /// </summary>
    public string Icon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取图鉴名字。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取图鉴备注。*/
    /// </summary>
    public string Desc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取图鉴分类(客户端用)。*/
    /// </summary>
    public int Type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取图鉴等级。*/
    /// </summary>
    public int Level
    {
        get;
        private set;
    }

    /// <summary>
  /**获取排序优先。*/
    /// </summary>
    public int RecipesSort
    {
        get;
        private set;
    }

    /// <summary>
  /**获取图鉴展示类型。*/
    /// </summary>
    public int DisplayType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取解锁类型。*/
    /// </summary>
    public int UnlockType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取解锁条件1。*/
    /// </summary>
    public int UnlockCondition
    {
        get;
        private set;
    }

    /// <summary>
  /**获取合成物。*/
    /// </summary>
    public int[][] ProductId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取合成物品质。*/
    /// </summary>
    public int[][] ProductQuality
    {
        get;
        private set;
    }

    /// <summary>
  /**获取品质概率。*/
    /// </summary>
    public int[][] QualityPro
    {
        get;
        private set;
    }

    /// <summary>
  /**获取合成途径描述。*/
    /// </summary>
    public int SourceText
    {
        get;
        private set;
    }

    /// <summary>
  /**获取合成素材。*/
    /// </summary>
    public int[][] MatItemId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取使用Ditamin数量。*/
    /// </summary>
    public int UseDitamin
    {
        get;
        private set;
    }

    /// <summary>
  /**获取使用MELD数量。*/
    /// </summary>
    public int UseMELD
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        CraftSkill = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Icon = columnStrings[index++];
        Name = columnStrings[index++];
        Desc = columnStrings[index++];
        Type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Level = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RecipesSort = DataTableParseUtil.ParseInt(columnStrings[index++]);
        DisplayType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        UnlockType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        UnlockCondition = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ProductId = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        ProductQuality = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        QualityPro = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        SourceText = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemId = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        UseDitamin = DataTableParseUtil.ParseInt(columnStrings[index++]);
        UseMELD = DataTableParseUtil.ParseInt(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                CraftSkill = binaryReader.Read7BitEncodedInt32();
                Icon = binaryReader.ReadString();
                Name = binaryReader.ReadString();
                Desc = binaryReader.ReadString();
                Type = binaryReader.Read7BitEncodedInt32();
                Level = binaryReader.Read7BitEncodedInt32();
                RecipesSort = binaryReader.Read7BitEncodedInt32();
                DisplayType = binaryReader.Read7BitEncodedInt32();
                UnlockType = binaryReader.Read7BitEncodedInt32();
                UnlockCondition = binaryReader.Read7BitEncodedInt32();
                ProductId = binaryReader.ReadArrayList<Int32>();
                ProductQuality = binaryReader.ReadArrayList<Int32>();
                QualityPro = binaryReader.ReadArrayList<Int32>();
                SourceText = binaryReader.Read7BitEncodedInt32();
                MatItemId = binaryReader.ReadArrayList<Int32>();
                UseDitamin = binaryReader.Read7BitEncodedInt32();
                UseMELD = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

