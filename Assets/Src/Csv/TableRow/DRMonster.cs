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
public class DRMonster : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取名字。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取Moster的描述。*/
    /// </summary>
    public string Desc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取Moster的Icon1。*/
    /// </summary>
    public string Icon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取RoleAssetID。*/
    /// </summary>
    public int RoleAssetID
    {
        get;
        private set;
    }

    /// <summary>
  /**获取身体大小(半径像素)。*/
    /// </summary>
    public int BodyCapacity
    {
        get;
        private set;
    }

    /// <summary>
  /**获取等级。*/
    /// </summary>
    public int Lv
    {
        get;
        private set;
    }

    /// <summary>
  /**获取击杀经验。*/
    /// </summary>
    public int Exp
    {
        get;
        private set;
    }

    /// <summary>
  /**获取血量。*/
    /// </summary>
    public int Hp
    {
        get;
        private set;
    }

    /// <summary>
  /**获取普通攻击。*/
    /// </summary>
    public int Att
    {
        get;
        private set;
    }

    /// <summary>
  /**获取攻击速度。*/
    /// </summary>
    public int AttSpd
    {
        get;
        private set;
    }

    /// <summary>
  /**获取防御。*/
    /// </summary>
    public int Def
    {
        get;
        private set;
    }

    /// <summary>
  /**获取暴击。*/
    /// </summary>
    public int CritRate
    {
        get;
        private set;
    }

    /// <summary>
  /**获取暴击伤害。*/
    /// </summary>
    public int CritDmg
    {
        get;
        private set;
    }

    /// <summary>
  /**获取命中。*/
    /// </summary>
    public int HitPoint
    {
        get;
        private set;
    }

    /// <summary>
  /**获取闪避。*/
    /// </summary>
    public int MissPoint
    {
        get;
        private set;
    }

    /// <summary>
  /**获取移动速度。*/
    /// </summary>
    public int MoveSpeed
    {
        get;
        private set;
    }

    /// <summary>
  /**获取怪物AI
1主动攻击型
2被动攻击型
3不攻击型。*/
    /// </summary>
    public int AttType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取锁敌范围。*/
    /// </summary>
    public int LockEnemyRange
    {
        get;
        private set;
    }

    /// <summary>
  /**获取脱战距离。*/
    /// </summary>
    public int CombatDist
    {
        get;
        private set;
    }

    /// <summary>
  /**获取击退伤害。*/
    /// </summary>
    public int PushDmg
    {
        get;
        private set;
    }

    /// <summary>
  /**获取击退距离。*/
    /// </summary>
    public int PushDist
    {
        get;
        private set;
    }

    /// <summary>
  /**获取掉落配置。*/
    /// </summary>
    public int DropId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取技能释放序列。*/
    /// </summary>
    public int[] SkillSequence
    {
        get;
        private set;
    }

    /// <summary>
  /**获取不显示在代码块下拉中。*/
    /// </summary>
    public bool NoShowCode
    {
        get;
        private set;
    }

    /// <summary>
  /**获取建筑背包分类。*/
    /// </summary>
    public int ObjectBagType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取代码库ID。*/
    /// </summary>
    public int CodeBlockId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取类型
1生物
2用锄头采集的资源
3用斧头采集的资源
4不用工具采集的资源
。*/
    /// </summary>
    public int Type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取怪物阵营。*/
    /// </summary>
    public int Camp
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性控件。*/
    /// </summary>
    public int AttWidget
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
        Icon = columnStrings[index++];
        RoleAssetID = DataTableParseUtil.ParseInt(columnStrings[index++]);
        BodyCapacity = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Lv = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Exp = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Hp = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Att = DataTableParseUtil.ParseInt(columnStrings[index++]);
        AttSpd = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Def = DataTableParseUtil.ParseInt(columnStrings[index++]);
        CritRate = DataTableParseUtil.ParseInt(columnStrings[index++]);
        CritDmg = DataTableParseUtil.ParseInt(columnStrings[index++]);
        HitPoint = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MissPoint = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MoveSpeed = DataTableParseUtil.ParseInt(columnStrings[index++]);
        AttType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        LockEnemyRange = DataTableParseUtil.ParseInt(columnStrings[index++]);
        CombatDist = DataTableParseUtil.ParseInt(columnStrings[index++]);
        PushDmg = DataTableParseUtil.ParseInt(columnStrings[index++]);
        PushDist = DataTableParseUtil.ParseInt(columnStrings[index++]);
        DropId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        SkillSequence = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        NoShowCode = DataTableParseUtil.ParseBool(columnStrings[index++]);
        ObjectBagType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        CodeBlockId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Camp = DataTableParseUtil.ParseInt(columnStrings[index++]);
        AttWidget = DataTableParseUtil.ParseInt(columnStrings[index++]);

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
                Icon = binaryReader.ReadString();
                RoleAssetID = binaryReader.Read7BitEncodedInt32();
                BodyCapacity = binaryReader.Read7BitEncodedInt32();
                Lv = binaryReader.Read7BitEncodedInt32();
                Exp = binaryReader.Read7BitEncodedInt32();
                Hp = binaryReader.Read7BitEncodedInt32();
                Att = binaryReader.Read7BitEncodedInt32();
                AttSpd = binaryReader.Read7BitEncodedInt32();
                Def = binaryReader.Read7BitEncodedInt32();
                CritRate = binaryReader.Read7BitEncodedInt32();
                CritDmg = binaryReader.Read7BitEncodedInt32();
                HitPoint = binaryReader.Read7BitEncodedInt32();
                MissPoint = binaryReader.Read7BitEncodedInt32();
                MoveSpeed = binaryReader.Read7BitEncodedInt32();
                AttType = binaryReader.Read7BitEncodedInt32();
                LockEnemyRange = binaryReader.Read7BitEncodedInt32();
                CombatDist = binaryReader.Read7BitEncodedInt32();
                PushDmg = binaryReader.Read7BitEncodedInt32();
                PushDist = binaryReader.Read7BitEncodedInt32();
                DropId = binaryReader.Read7BitEncodedInt32();
                SkillSequence = binaryReader.ReadArray<Int32>();
                NoShowCode = binaryReader.ReadBoolean();
                ObjectBagType = binaryReader.Read7BitEncodedInt32();
                CodeBlockId = binaryReader.Read7BitEncodedInt32();
                Type = binaryReader.Read7BitEncodedInt32();
                Camp = binaryReader.Read7BitEncodedInt32();
                AttWidget = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

