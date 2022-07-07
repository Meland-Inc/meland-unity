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
public class DRArchFormula : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取配方ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取配方名字。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取注释。*/
    /// </summary>
    public string Desc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取配方分类(客户端用)。*/
    /// </summary>
    public int Type
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
  /**获取合成耗时。*/
    /// </summary>
    public int Time
    {
        get;
        private set;
    }

    /// <summary>
  /**获取合成的物品id。*/
    /// </summary>
    public int ProductId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取合成物品类型(1是物品，2是怪物，3是资源)。*/
    /// </summary>
    public int ProductType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取合成素材1。*/
    /// </summary>
    public int MatItemId1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取所需数量1。*/
    /// </summary>
    public int MatItemNum1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取合成素材2。*/
    /// </summary>
    public int MatItemId2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取所需数量2。*/
    /// </summary>
    public int MatItemNum2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取合成素材3。*/
    /// </summary>
    public int MatItemId3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取所需数量3。*/
    /// </summary>
    public int MatItemNum3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取合成素材4。*/
    /// </summary>
    public int MatItemId4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取所需数量4。*/
    /// </summary>
    public int MatItemNum4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取合成素材5。*/
    /// </summary>
    public int MatItemId5
    {
        get;
        private set;
    }

    /// <summary>
  /**获取所需数量5。*/
    /// </summary>
    public int MatItemNum5
    {
        get;
        private set;
    }

    /// <summary>
  /**获取合成素材6。*/
    /// </summary>
    public int MatItemId6
    {
        get;
        private set;
    }

    /// <summary>
  /**获取所需数量6。*/
    /// </summary>
    public int MatItemNum6
    {
        get;
        private set;
    }

    /// <summary>
  /**获取合成素材7。*/
    /// </summary>
    public int MatItemId7
    {
        get;
        private set;
    }

    /// <summary>
  /**获取所需数量7。*/
    /// </summary>
    public int MatItemNum7
    {
        get;
        private set;
    }

    /// <summary>
  /**获取合成素材8。*/
    /// </summary>
    public int MatItemId8
    {
        get;
        private set;
    }

    /// <summary>
  /**获取所需数量8。*/
    /// </summary>
    public int MatItemNum8
    {
        get;
        private set;
    }

    /// <summary>
  /**获取合成素材9。*/
    /// </summary>
    public int MatItemId9
    {
        get;
        private set;
    }

    /// <summary>
  /**获取所需数量9。*/
    /// </summary>
    public int MatItemNum9
    {
        get;
        private set;
    }

    /// <summary>
  /**获取合成素材10。*/
    /// </summary>
    public int MatItemId10
    {
        get;
        private set;
    }

    /// <summary>
  /**获取所需数量10。*/
    /// </summary>
    public int MatItemNum10
    {
        get;
        private set;
    }

    /// <summary>
  /**获取变化时间系数0。*/
    /// </summary>
    public int Time0
    {
        get;
        private set;
    }

    /// <summary>
  /**获取变化object0。*/
    /// </summary>
    public int Time0Object
    {
        get;
        private set;
    }

    /// <summary>
  /**获取变化时间系数1。*/
    /// </summary>
    public int Time1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取变化object1。*/
    /// </summary>
    public int Time1Object
    {
        get;
        private set;
    }

    /// <summary>
  /**获取变化时间系数2。*/
    /// </summary>
    public int Time2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取变化object2。*/
    /// </summary>
    public int Time2Object
    {
        get;
        private set;
    }

    /// <summary>
  /**获取变化时间系数3。*/
    /// </summary>
    public int Time3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取变化object3。*/
    /// </summary>
    public int Time3Object
    {
        get;
        private set;
    }

    /// <summary>
  /**获取奖励
（rewardId）。*/
    /// </summary>
    public int RewardId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取配方来源
（客户端）。*/
    /// </summary>
    public string Source
    {
        get;
        private set;
    }

    /// <summary>
  /**获取解锁后的合成途径描述。*/
    /// </summary>
    public string SourceText
    {
        get;
        private set;
    }

    /// <summary>
  /**获取排序优先级。*/
    /// </summary>
    public int Sort
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
        Desc = columnStrings[index++];
        Type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        UnlockType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        UnlockCondition = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Time = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ProductId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ProductType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemId1 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemNum1 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemId2 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemNum2 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemId3 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemNum3 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemId4 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemNum4 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemId5 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemNum5 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemId6 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemNum6 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemId7 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemNum7 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemId8 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemNum8 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemId9 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemNum9 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemId10 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MatItemNum10 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Time0 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Time0Object = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Time1 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Time1Object = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Time2 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Time2Object = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Time3 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Time3Object = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RewardId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Source = columnStrings[index++];
        SourceText = columnStrings[index++];
        Sort = DataTableParseUtil.ParseInt(columnStrings[index++]);

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
                Desc = binaryReader.ReadString();
                Type = binaryReader.Read7BitEncodedInt32();
                UnlockType = binaryReader.Read7BitEncodedInt32();
                UnlockCondition = binaryReader.Read7BitEncodedInt32();
                Time = binaryReader.Read7BitEncodedInt32();
                ProductId = binaryReader.Read7BitEncodedInt32();
                ProductType = binaryReader.Read7BitEncodedInt32();
                MatItemId1 = binaryReader.Read7BitEncodedInt32();
                MatItemNum1 = binaryReader.Read7BitEncodedInt32();
                MatItemId2 = binaryReader.Read7BitEncodedInt32();
                MatItemNum2 = binaryReader.Read7BitEncodedInt32();
                MatItemId3 = binaryReader.Read7BitEncodedInt32();
                MatItemNum3 = binaryReader.Read7BitEncodedInt32();
                MatItemId4 = binaryReader.Read7BitEncodedInt32();
                MatItemNum4 = binaryReader.Read7BitEncodedInt32();
                MatItemId5 = binaryReader.Read7BitEncodedInt32();
                MatItemNum5 = binaryReader.Read7BitEncodedInt32();
                MatItemId6 = binaryReader.Read7BitEncodedInt32();
                MatItemNum6 = binaryReader.Read7BitEncodedInt32();
                MatItemId7 = binaryReader.Read7BitEncodedInt32();
                MatItemNum7 = binaryReader.Read7BitEncodedInt32();
                MatItemId8 = binaryReader.Read7BitEncodedInt32();
                MatItemNum8 = binaryReader.Read7BitEncodedInt32();
                MatItemId9 = binaryReader.Read7BitEncodedInt32();
                MatItemNum9 = binaryReader.Read7BitEncodedInt32();
                MatItemId10 = binaryReader.Read7BitEncodedInt32();
                MatItemNum10 = binaryReader.Read7BitEncodedInt32();
                Time0 = binaryReader.Read7BitEncodedInt32();
                Time0Object = binaryReader.Read7BitEncodedInt32();
                Time1 = binaryReader.Read7BitEncodedInt32();
                Time1Object = binaryReader.Read7BitEncodedInt32();
                Time2 = binaryReader.Read7BitEncodedInt32();
                Time2Object = binaryReader.Read7BitEncodedInt32();
                Time3 = binaryReader.Read7BitEncodedInt32();
                Time3Object = binaryReader.Read7BitEncodedInt32();
                RewardId = binaryReader.Read7BitEncodedInt32();
                Source = binaryReader.ReadString();
                SourceText = binaryReader.ReadString();
                Sort = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

