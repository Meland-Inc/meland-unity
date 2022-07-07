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
public class DRRoleAsset : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取描述。*/
    /// </summary>
    public string Desc
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
  /**获取闲置叫声。*/
    /// </summary>
    public string IdleSound
    {
        get;
        private set;
    }

    /// <summary>
  /**获取普通攻击声音。*/
    /// </summary>
    public string AttackSound
    {
        get;
        private set;
    }

    /// <summary>
  /**获取受伤暴击声音。*/
    /// </summary>
    public string HurtedCritSound
    {
        get;
        private set;
    }

    /// <summary>
  /**获取受伤声音。*/
    /// </summary>
    public string HurtedSound
    {
        get;
        private set;
    }

    /// <summary>
  /**获取死亡声音。*/
    /// </summary>
    public string DeathSound
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Desc = columnStrings[index++];
        ArmatureRes = columnStrings[index++];
        IdleSound = columnStrings[index++];
        AttackSound = columnStrings[index++];
        HurtedCritSound = columnStrings[index++];
        HurtedSound = columnStrings[index++];
        DeathSound = columnStrings[index++];

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Desc = binaryReader.ReadString();
                ArmatureRes = binaryReader.ReadString();
                IdleSound = binaryReader.ReadString();
                AttackSound = binaryReader.ReadString();
                HurtedCritSound = binaryReader.ReadString();
                HurtedSound = binaryReader.ReadString();
                DeathSound = binaryReader.ReadString();
            }
        }

        return true;
    }
}

