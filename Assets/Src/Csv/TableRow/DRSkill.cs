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
public class DRSkill : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取技能ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取技能名称1。*/
    /// </summary>
    public string SkillName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取影响目标类型
0.未知类型
1.玩家
2.木头
3.草
4.石头
5.建筑
6.机器人
7.怪物
8.开宝箱。*/
    /// </summary>
    public int[] InfluenceTargetType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取技能CD
单位:毫秒。*/
    /// </summary>
    public int SkillCD
    {
        get;
        private set;
    }

    /// <summary>
  /**获取技能ICON。*/
    /// </summary>
    public string SkillIcon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取作用于敌方技能效果。*/
    /// </summary>
    public int[][] EffectEnemy
    {
        get;
        private set;
    }

    /// <summary>
  /**获取作用于己方技能效果。*/
    /// </summary>
    public int[][] EffectSelf
    {
        get;
        private set;
    }

    /// <summary>
  /**获取蓄力时间。*/
    /// </summary>
    public int AccuTime
    {
        get;
        private set;
    }

    /// <summary>
  /**获取蓄力动作。*/
    /// </summary>
    public string AccuAct
    {
        get;
        private set;
    }

    /// <summary>
  /**获取蓄力特效。*/
    /// </summary>
    public int AccuEff
    {
        get;
        private set;
    }

    /// <summary>
  /**获取蓄力是否可以被打断。*/
    /// </summary>
    public bool AccuBreakable
    {
        get;
        private set;
    }

    /// <summary>
  /**获取蓄力条名字。*/
    /// </summary>
    public string AccuTab
    {
        get;
        private set;
    }

    /// <summary>
  /**获取技能释放动作。*/
    /// </summary>
    public string[] ReleaseAct
    {
        get;
        private set;
    }

    /// <summary>
  /**获取技能释放特效。*/
    /// </summary>
    public int ReleaseEff
    {
        get;
        private set;
    }

    /// <summary>
  /**获取技能释放时间。*/
    /// </summary>
    public int ReleaseTime
    {
        get;
        private set;
    }

    /// <summary>
  /**获取技能前摇时间。*/
    /// </summary>
    public int ForwardReleaseTime
    {
        get;
        private set;
    }

    /// <summary>
  /**获取技能范围是否预警。*/
    /// </summary>
    public bool RangeTips
    {
        get;
        private set;
    }

    /// <summary>
  /**获取技能生效范围。*/
    /// </summary>
    public int[] SkillRange
    {
        get;
        private set;
    }

    /// <summary>
  /**获取技能释放距离。*/
    /// </summary>
    public int SkillDistance
    {
        get;
        private set;
    }

    /// <summary>
  /**获取目标指向类型。*/
    /// </summary>
    public bool TargetPointType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取攻击时是否可以移动。*/
    /// </summary>
    public bool AttackCanMove
    {
        get;
        private set;
    }

    /// <summary>
  /**获取动作旋转。*/
    /// </summary>
    public int AnimRotate
    {
        get;
        private set;
    }

    /// <summary>
  /**获取技能是否自动释放。*/
    /// </summary>
    public bool IsAutoUse
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否是子弹型技能。*/
    /// </summary>
    public bool IfBullet
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子弹飞行距离。*/
    /// </summary>
    public int BulletFlyDistance
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子弹飞行速度。*/
    /// </summary>
    public int BulletFlySpeed
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子弹AVATAR资源。*/
    /// </summary>
    public string BulletAvatar
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子弹是否跟踪。*/
    /// </summary>
    public bool IfBulletFollow
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子弹是否穿透。*/
    /// </summary>
    public bool IfBulletPass
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
        SkillName = columnStrings[index++];
        InfluenceTargetType = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        SkillCD = DataTableParseUtil.ParseInt(columnStrings[index++]);
        SkillIcon = columnStrings[index++];
        EffectEnemy = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        EffectSelf = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        AccuTime = DataTableParseUtil.ParseInt(columnStrings[index++]);
        AccuAct = columnStrings[index++];
        AccuEff = DataTableParseUtil.ParseInt(columnStrings[index++]);
        AccuBreakable = DataTableParseUtil.ParseBool(columnStrings[index++]);
        AccuTab = columnStrings[index++];
        ReleaseAct = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        ReleaseEff = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ReleaseTime = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ForwardReleaseTime = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RangeTips = DataTableParseUtil.ParseBool(columnStrings[index++]);
        SkillRange = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        SkillDistance = DataTableParseUtil.ParseInt(columnStrings[index++]);
        TargetPointType = DataTableParseUtil.ParseBool(columnStrings[index++]);
        AttackCanMove = DataTableParseUtil.ParseBool(columnStrings[index++]);
        AnimRotate = DataTableParseUtil.ParseInt(columnStrings[index++]);
        IsAutoUse = DataTableParseUtil.ParseBool(columnStrings[index++]);
        IfBullet = DataTableParseUtil.ParseBool(columnStrings[index++]);
        BulletFlyDistance = DataTableParseUtil.ParseInt(columnStrings[index++]);
        BulletFlySpeed = DataTableParseUtil.ParseInt(columnStrings[index++]);
        BulletAvatar = columnStrings[index++];
        IfBulletFollow = DataTableParseUtil.ParseBool(columnStrings[index++]);
        IfBulletPass = DataTableParseUtil.ParseBool(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                SkillName = binaryReader.ReadString();
                InfluenceTargetType = binaryReader.ReadArray<Int32>();
                SkillCD = binaryReader.Read7BitEncodedInt32();
                SkillIcon = binaryReader.ReadString();
                EffectEnemy = binaryReader.ReadArrayList<Int32>();
                EffectSelf = binaryReader.ReadArrayList<Int32>();
                AccuTime = binaryReader.Read7BitEncodedInt32();
                AccuAct = binaryReader.ReadString();
                AccuEff = binaryReader.Read7BitEncodedInt32();
                AccuBreakable = binaryReader.ReadBoolean();
                AccuTab = binaryReader.ReadString();
                ReleaseAct = binaryReader.ReadArray<String>();
                ReleaseEff = binaryReader.Read7BitEncodedInt32();
                ReleaseTime = binaryReader.Read7BitEncodedInt32();
                ForwardReleaseTime = binaryReader.Read7BitEncodedInt32();
                RangeTips = binaryReader.ReadBoolean();
                SkillRange = binaryReader.ReadArray<Int32>();
                SkillDistance = binaryReader.Read7BitEncodedInt32();
                TargetPointType = binaryReader.ReadBoolean();
                AttackCanMove = binaryReader.ReadBoolean();
                AnimRotate = binaryReader.Read7BitEncodedInt32();
                IsAutoUse = binaryReader.ReadBoolean();
                IfBullet = binaryReader.ReadBoolean();
                BulletFlyDistance = binaryReader.Read7BitEncodedInt32();
                BulletFlySpeed = binaryReader.Read7BitEncodedInt32();
                BulletAvatar = binaryReader.ReadString();
                IfBulletFollow = binaryReader.ReadBoolean();
                IfBulletPass = binaryReader.ReadBoolean();
            }
        }

        return true;
    }
}

