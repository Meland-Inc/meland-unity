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
public class DRTemplateDungeons : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取副本名称。*/
    /// </summary>
    public string DungeonName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取副本等级描述。*/
    /// </summary>
    public string DungeonLevDes
    {
        get;
        private set;
    }

    /// <summary>
  /**获取副本积分描述。*/
    /// </summary>
    public string DungeonPointDes
    {
        get;
        private set;
    }

    /// <summary>
  /**获取基础奖励。*/
    /// </summary>
    public int[] BaseReward
    {
        get;
        private set;
    }

    /// <summary>
  /**获取超级奖励。*/
    /// </summary>
    public string[] SupReward
    {
        get;
        private set;
    }

    /// <summary>
  /**获取超级奖励解锁描述。*/
    /// </summary>
    public string[] SupRewardUnlockDes
    {
        get;
        private set;
    }

    /// <summary>
  /**获取超级奖励tips描述。*/
    /// </summary>
    public string[] SupRewardTipDes
    {
        get;
        private set;
    }

    /// <summary>
  /**获取最终奖励。*/
    /// </summary>
    public int[] FinalReward
    {
        get;
        private set;
    }

    /// <summary>
  /**获取最终奖励描述。*/
    /// </summary>
    public string FinalDes
    {
        get;
        private set;
    }

    /// <summary>
  /**获取最终奖励解锁描述。*/
    /// </summary>
    public string FinalClearDes
    {
        get;
        private set;
    }

    /// <summary>
  /**获取最终奖励展示图。*/
    /// </summary>
    public string FinalRewardImage
    {
        get;
        private set;
    }

    /// <summary>
  /**获取大奖励展示等级。*/
    /// </summary>
    public int[] BigRewardLev
    {
        get;
        private set;
    }

    /// <summary>
  /**获取最高等级。*/
    /// </summary>
    public int MaxLevel
    {
        get;
        private set;
    }

    /// <summary>
  /**获取VIP解锁最高阶段。*/
    /// </summary>
    public int MaxVipClearLv
    {
        get;
        private set;
    }

    /// <summary>
  /**获取升级需要积分。*/
    /// </summary>
    public int LevUpPoint
    {
        get;
        private set;
    }

    /// <summary>
  /**获取购买链接。*/
    /// </summary>
    public string Url
    {
        get;
        private set;
    }

    /// <summary>
  /**获取兑换码标识。*/
    /// </summary>
    public string[][] DunCdKeyFlag
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        DungeonName = columnStrings[index++];
        DungeonLevDes = columnStrings[index++];
        DungeonPointDes = columnStrings[index++];
        BaseReward = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        SupReward = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        SupRewardUnlockDes = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        SupRewardTipDes = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        FinalReward = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        FinalDes = columnStrings[index++];
        FinalClearDes = columnStrings[index++];
        FinalRewardImage = columnStrings[index++];
        BigRewardLev = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        MaxLevel = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MaxVipClearLv = DataTableParseUtil.ParseInt(columnStrings[index++]);
        LevUpPoint = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Url = columnStrings[index++];
        DunCdKeyFlag = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        index++;
        index++;
        index++;
        index++;
        index++;
        index++;
        index++;

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                DungeonName = binaryReader.ReadString();
                DungeonLevDes = binaryReader.ReadString();
                DungeonPointDes = binaryReader.ReadString();
                BaseReward = binaryReader.ReadArray<Int32>();
                SupReward = binaryReader.ReadArray<String>();
                SupRewardUnlockDes = binaryReader.ReadArray<String>();
                SupRewardTipDes = binaryReader.ReadArray<String>();
                FinalReward = binaryReader.ReadArray<Int32>();
                FinalDes = binaryReader.ReadString();
                FinalClearDes = binaryReader.ReadString();
                FinalRewardImage = binaryReader.ReadString();
                BigRewardLev = binaryReader.ReadArray<Int32>();
                MaxLevel = binaryReader.Read7BitEncodedInt32();
                MaxVipClearLv = binaryReader.Read7BitEncodedInt32();
                LevUpPoint = binaryReader.Read7BitEncodedInt32();
                Url = binaryReader.ReadString();
                DunCdKeyFlag = binaryReader.ReadArrayList<String>();
            }
        }

        return true;
    }
}

