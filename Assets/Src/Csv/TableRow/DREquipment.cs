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
public class DREquipment : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取装备ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取装备类型
。*/
    /// </summary>
    public int GearType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取耐久度上限。*/
    /// </summary>
    public int GearDurabilityMax
    {
        get;
        private set;
    }

    /// <summary>
  /**获取键ICON展示。*/
    /// </summary>
    public string KeyIcon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取avatar资源。*/
    /// </summary>
    public int GearAvatar
    {
        get;
        private set;
    }

    /// <summary>
  /**获取挂载技能。*/
    /// </summary>
    public int GivenSkillId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取备注。*/
    /// </summary>
    public string Null
    {
        get;
        private set;
    }

    /// <summary>
  /**获取增加血量。*/
    /// </summary>
    public int[][] GearAddHp
    {
        get;
        private set;
    }

    /// <summary>
  /**获取增加生命恢复。*/
    /// </summary>
    public int[][] GearAddHpRec
    {
        get;
        private set;
    }

    /// <summary>
  /**获取增加普通攻击。*/
    /// </summary>
    public int[][] GearAddAtt
    {
        get;
        private set;
    }

    /// <summary>
  /**获取增加攻击速度。*/
    /// </summary>
    public int[][] GearAddAttSpd
    {
        get;
        private set;
    }

    /// <summary>
  /**获取增加普通防御。*/
    /// </summary>
    public int[][] GearAddDef
    {
        get;
        private set;
    }

    /// <summary>
  /**获取增加暴击点数。*/
    /// </summary>
    public int[][] GearAddCritRate
    {
        get;
        private set;
    }

    /// <summary>
  /**获取增加暴击伤害点数。*/
    /// </summary>
    public int[][] GearAddCritDmg
    {
        get;
        private set;
    }

    /// <summary>
  /**获取增加命中点数。*/
    /// </summary>
    public int[][] GearAddHitPoint
    {
        get;
        private set;
    }

    /// <summary>
  /**获取增加闪避点数。*/
    /// </summary>
    public int[][] GearAddMissPoint
    {
        get;
        private set;
    }

    /// <summary>
  /**获取移动速度。*/
    /// </summary>
    public int[][] GearAddSpeed
    {
        get;
        private set;
    }

    /// <summary>
  /**获取装备音效。*/
    /// </summary>
    public string EquipMusic
    {
        get;
        private set;
    }

    /// <summary>
  /**获取攻击音效。*/
    /// </summary>
    public string AttackSound
    {
        get;
        private set;
    }

    /// <summary>
  /**获取点亮半径增加(像素)。*/
    /// </summary>
    public int LightRadiusAdd
    {
        get;
        private set;
    }

    /// <summary>
  /**获取修理材料。*/
    /// </summary>
    public int[][] RepairNeed
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        GearType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        index++;
        GearDurabilityMax = DataTableParseUtil.ParseInt(columnStrings[index++]);
        KeyIcon = columnStrings[index++];
        GearAvatar = DataTableParseUtil.ParseInt(columnStrings[index++]);
        GivenSkillId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Null = columnStrings[index++];
        GearAddHp = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        GearAddHpRec = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        GearAddAtt = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        GearAddAttSpd = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        GearAddDef = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        GearAddCritRate = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        GearAddCritDmg = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        GearAddHitPoint = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        GearAddMissPoint = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        GearAddSpeed = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        EquipMusic = columnStrings[index++];
        AttackSound = columnStrings[index++];
        LightRadiusAdd = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RepairNeed = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                GearType = binaryReader.Read7BitEncodedInt32();
                GearDurabilityMax = binaryReader.Read7BitEncodedInt32();
                KeyIcon = binaryReader.ReadString();
                GearAvatar = binaryReader.Read7BitEncodedInt32();
                GivenSkillId = binaryReader.Read7BitEncodedInt32();
                Null = binaryReader.ReadString();
                GearAddHp = binaryReader.ReadArrayList<Int32>();
                GearAddHpRec = binaryReader.ReadArrayList<Int32>();
                GearAddAtt = binaryReader.ReadArrayList<Int32>();
                GearAddAttSpd = binaryReader.ReadArrayList<Int32>();
                GearAddDef = binaryReader.ReadArrayList<Int32>();
                GearAddCritRate = binaryReader.ReadArrayList<Int32>();
                GearAddCritDmg = binaryReader.ReadArrayList<Int32>();
                GearAddHitPoint = binaryReader.ReadArrayList<Int32>();
                GearAddMissPoint = binaryReader.ReadArrayList<Int32>();
                GearAddSpeed = binaryReader.ReadArrayList<Int32>();
                EquipMusic = binaryReader.ReadString();
                AttackSound = binaryReader.ReadString();
                LightRadiusAdd = binaryReader.Read7BitEncodedInt32();
                RepairNeed = binaryReader.ReadArrayList<Int32>();
            }
        }

        return true;
    }
}

