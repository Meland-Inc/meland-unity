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
public class DRRobot : DataRowBase
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
  /**获取等级适配分组。*/
    /// </summary>
    public int LvType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取机器类型。*/
    /// </summary>
    public int Type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取技能1的ID。*/
    /// </summary>
    public int Skill1Id
    {
        get;
        private set;
    }

    /// <summary>
  /**获取技能2的ID。*/
    /// </summary>
    public int Skill2Id
    {
        get;
        private set;
    }

    /// <summary>
  /**获取普通攻击。*/
    /// </summary>
    public int[] SkillSequence
    {
        get;
        private set;
    }

    /// <summary>
  /**获取采集技能。*/
    /// </summary>
    public int Acquisitionskills
    {
        get;
        private set;
    }

    /// <summary>
  /**获取默认皮肤ID。*/
    /// </summary>
    public int RobotSkinId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取代码库ID。*/
    /// </summary>
    public int RobotCodeBlockId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取机器人列表代码块显示。*/
    /// </summary>
    public int[] RobotListCodeShow
    {
        get;
        private set;
    }

    /// <summary>
  /**获取背包格子数。*/
    /// </summary>
    public int BagGridNum
    {
        get;
        private set;
    }

    /// <summary>
  /**获取燃料上限。*/
    /// </summary>
    public int FuelCeiling
    {
        get;
        private set;
    }

    /// <summary>
  /**获取机器人ICON。*/
    /// </summary>
    public string RobotIcon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取机器人slogan。*/
    /// </summary>
    public string Slogan
    {
        get;
        private set;
    }

    /// <summary>
  /**获取机器人描述。*/
    /// </summary>
    public string Description
    {
        get;
        private set;
    }

    /// <summary>
  /**获取皮肤1ID。*/
    /// </summary>
    public int Skin1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取皮肤2ID。*/
    /// </summary>
    public int Skin2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取皮肤3ID。*/
    /// </summary>
    public int Skin3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取皮肤4ID。*/
    /// </summary>
    public int Skin4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否显示在机器人列表。*/
    /// </summary>
    public int IfElseRobotList
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
  /**获取点亮半径。*/
    /// </summary>
    public int LightRadius
    {
        get;
        private set;
    }

    /// <summary>
  /**获取骨架资源。*/
    /// </summary>
    public string ArmatureRes
    {
        get;
        private set;
    }

    /// <summary>
  /**获取机器人默认AVATAR ID。*/
    /// </summary>
    public int[] RobotAvatarId
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
        LvType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Skill1Id = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Skill2Id = DataTableParseUtil.ParseInt(columnStrings[index++]);
        SkillSequence = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        Acquisitionskills = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RobotSkinId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RobotCodeBlockId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RobotListCodeShow = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        BagGridNum = DataTableParseUtil.ParseInt(columnStrings[index++]);
        FuelCeiling = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RobotIcon = columnStrings[index++];
        Slogan = columnStrings[index++];
        Description = columnStrings[index++];
        Skin1 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Skin2 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Skin3 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Skin4 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        IfElseRobotList = DataTableParseUtil.ParseInt(columnStrings[index++]);
        BodyCapacity = DataTableParseUtil.ParseInt(columnStrings[index++]);
        LightRadius = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ArmatureRes = columnStrings[index++];
        RobotAvatarId = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);

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
                LvType = binaryReader.Read7BitEncodedInt32();
                Type = binaryReader.Read7BitEncodedInt32();
                Skill1Id = binaryReader.Read7BitEncodedInt32();
                Skill2Id = binaryReader.Read7BitEncodedInt32();
                SkillSequence = binaryReader.ReadArray<Int32>();
                Acquisitionskills = binaryReader.Read7BitEncodedInt32();
                RobotSkinId = binaryReader.Read7BitEncodedInt32();
                RobotCodeBlockId = binaryReader.Read7BitEncodedInt32();
                RobotListCodeShow = binaryReader.ReadArray<Int32>();
                BagGridNum = binaryReader.Read7BitEncodedInt32();
                FuelCeiling = binaryReader.Read7BitEncodedInt32();
                RobotIcon = binaryReader.ReadString();
                Slogan = binaryReader.ReadString();
                Description = binaryReader.ReadString();
                Skin1 = binaryReader.Read7BitEncodedInt32();
                Skin2 = binaryReader.Read7BitEncodedInt32();
                Skin3 = binaryReader.Read7BitEncodedInt32();
                Skin4 = binaryReader.Read7BitEncodedInt32();
                IfElseRobotList = binaryReader.Read7BitEncodedInt32();
                BodyCapacity = binaryReader.Read7BitEncodedInt32();
                LightRadius = binaryReader.Read7BitEncodedInt32();
                ArmatureRes = binaryReader.ReadString();
                RobotAvatarId = binaryReader.ReadArray<Int32>();
            }
        }

        return true;
    }
}

