﻿//------------------------------------------------------------
// 此文件由工具自动生成
// 生成时间：2022-05-23 15:59:48.117
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
public class DRMonsterAttribute : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取属性自适应类型
。*/
    /// </summary>
    public int MonAttriType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性自适应等级。*/
    /// </summary>
    public int Lv
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

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        MonAttriType = DataTableExtension.ParseInt(columnStrings[index++]);
        index++;
        Lv = DataTableExtension.ParseInt(columnStrings[index++]);
        Hp = DataTableExtension.ParseInt(columnStrings[index++]);
        Att = DataTableExtension.ParseInt(columnStrings[index++]);
        AttSpd = DataTableExtension.ParseInt(columnStrings[index++]);
        Def = DataTableExtension.ParseInt(columnStrings[index++]);
        CritRate = DataTableExtension.ParseInt(columnStrings[index++]);
        CritDmg = DataTableExtension.ParseInt(columnStrings[index++]);
        HitPoint = DataTableExtension.ParseInt(columnStrings[index++]);
        MissPoint = DataTableExtension.ParseInt(columnStrings[index++]);
        MoveSpeed = DataTableExtension.ParseInt(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                MonAttriType = binaryReader.Read7BitEncodedInt32();
                Lv = binaryReader.Read7BitEncodedInt32();
                Hp = binaryReader.Read7BitEncodedInt32();
                Att = binaryReader.Read7BitEncodedInt32();
                AttSpd = binaryReader.Read7BitEncodedInt32();
                Def = binaryReader.Read7BitEncodedInt32();
                CritRate = binaryReader.Read7BitEncodedInt32();
                CritDmg = binaryReader.Read7BitEncodedInt32();
                HitPoint = binaryReader.Read7BitEncodedInt32();
                MissPoint = binaryReader.Read7BitEncodedInt32();
                MoveSpeed = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

