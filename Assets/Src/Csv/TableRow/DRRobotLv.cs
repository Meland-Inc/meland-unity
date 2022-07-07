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
public class DRRobotLv : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取等级1。*/
    /// </summary>
    public int Lv
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
  /**获取升级经验。*/
    /// </summary>
    public int Exp
    {
        get;
        private set;
    }

    /// <summary>
  /**获取增加饱食度上限。*/
    /// </summary>
    public int Satiety
    {
        get;
        private set;
    }

    /// <summary>
  /**获取增加饥渴度上限。*/
    /// </summary>
    public int Craving
    {
        get;
        private set;
    }

    /// <summary>
  /**获取增加血量。*/
    /// </summary>
    public int Hp
    {
        get;
        private set;
    }

    /// <summary>
  /**获取增加普通攻击。*/
    /// </summary>
    public int Att
    {
        get;
        private set;
    }

    /// <summary>
  /**获取增加普通防御。*/
    /// </summary>
    public int Def
    {
        get;
        private set;
    }

    /// <summary>
  /**获取火属性攻击。*/
    /// </summary>
    public int FireAtt
    {
        get;
        private set;
    }

    /// <summary>
  /**获取冰属性攻击。*/
    /// </summary>
    public int IceAtt
    {
        get;
        private set;
    }

    /// <summary>
  /**获取雷属性攻击。*/
    /// </summary>
    public int ThunderAtt
    {
        get;
        private set;
    }

    /// <summary>
  /**获取毒属性攻击。*/
    /// </summary>
    public int PoisonAtt
    {
        get;
        private set;
    }

    /// <summary>
  /**获取暗影属性攻击。*/
    /// </summary>
    public int DarkAtt
    {
        get;
        private set;
    }

    /// <summary>
  /**获取火属性防御。*/
    /// </summary>
    public int FireDef
    {
        get;
        private set;
    }

    /// <summary>
  /**获取冰属性防御。*/
    /// </summary>
    public int IceDef
    {
        get;
        private set;
    }

    /// <summary>
  /**获取雷属性防御。*/
    /// </summary>
    public int ThunderDef
    {
        get;
        private set;
    }

    /// <summary>
  /**获取毒属性防御。*/
    /// </summary>
    public int PoisonDef
    {
        get;
        private set;
    }

    /// <summary>
  /**获取暗影属性防御。*/
    /// </summary>
    public int DarkDef
    {
        get;
        private set;
    }

    /// <summary>
  /**获取闪避率
（万分率）。*/
    /// </summary>
    public int MissRate
    {
        get;
        private set;
    }

    /// <summary>
  /**获取 暴击率
（万分率）。*/
    /// </summary>
    public int CritRate
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
        Lv = DataTableParseUtil.ParseInt(columnStrings[index++]);
        LvType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Exp = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Satiety = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Craving = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Hp = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Att = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Def = DataTableParseUtil.ParseInt(columnStrings[index++]);
        FireAtt = DataTableParseUtil.ParseInt(columnStrings[index++]);
        IceAtt = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ThunderAtt = DataTableParseUtil.ParseInt(columnStrings[index++]);
        PoisonAtt = DataTableParseUtil.ParseInt(columnStrings[index++]);
        DarkAtt = DataTableParseUtil.ParseInt(columnStrings[index++]);
        FireDef = DataTableParseUtil.ParseInt(columnStrings[index++]);
        IceDef = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ThunderDef = DataTableParseUtil.ParseInt(columnStrings[index++]);
        PoisonDef = DataTableParseUtil.ParseInt(columnStrings[index++]);
        DarkDef = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MissRate = DataTableParseUtil.ParseInt(columnStrings[index++]);
        CritRate = DataTableParseUtil.ParseInt(columnStrings[index++]);
        MoveSpeed = DataTableParseUtil.ParseInt(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Lv = binaryReader.Read7BitEncodedInt32();
                LvType = binaryReader.Read7BitEncodedInt32();
                Exp = binaryReader.Read7BitEncodedInt32();
                Satiety = binaryReader.Read7BitEncodedInt32();
                Craving = binaryReader.Read7BitEncodedInt32();
                Hp = binaryReader.Read7BitEncodedInt32();
                Att = binaryReader.Read7BitEncodedInt32();
                Def = binaryReader.Read7BitEncodedInt32();
                FireAtt = binaryReader.Read7BitEncodedInt32();
                IceAtt = binaryReader.Read7BitEncodedInt32();
                ThunderAtt = binaryReader.Read7BitEncodedInt32();
                PoisonAtt = binaryReader.Read7BitEncodedInt32();
                DarkAtt = binaryReader.Read7BitEncodedInt32();
                FireDef = binaryReader.Read7BitEncodedInt32();
                IceDef = binaryReader.Read7BitEncodedInt32();
                ThunderDef = binaryReader.Read7BitEncodedInt32();
                PoisonDef = binaryReader.Read7BitEncodedInt32();
                DarkDef = binaryReader.Read7BitEncodedInt32();
                MissRate = binaryReader.Read7BitEncodedInt32();
                CritRate = binaryReader.Read7BitEncodedInt32();
                MoveSpeed = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

