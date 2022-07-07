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
public class DRPlaceableNFTskill : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取PlaceableNFTskill_ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取技能名称。*/
    /// </summary>
    public string Skill_name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取技能icon。*/
    /// </summary>
    public string Skill_icon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取影响半径。*/
    /// </summary>
    public int[] Radius
    {
        get;
        private set;
    }

    /// <summary>
  /**获取影响数值。*/
    /// </summary>
    public string[] Value
    {
        get;
        private set;
    }

    /// <summary>
  /**获取描述。*/
    /// </summary>
    public string Desc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取作用对象。*/
    /// </summary>
    public string Skill_target
    {
        get;
        private set;
    }

    /// <summary>
  /**获取技能效果。*/
    /// </summary>
    public string Skill_effect
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Skill_name = columnStrings[index++];
        Skill_icon = columnStrings[index++];
        Radius = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        Value = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Desc = columnStrings[index++];
        Skill_target = columnStrings[index++];
        Skill_effect = columnStrings[index++];

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Skill_name = binaryReader.ReadString();
                Skill_icon = binaryReader.ReadString();
                Radius = binaryReader.ReadArray<Int32>();
                Value = binaryReader.ReadArray<String>();
                Desc = binaryReader.ReadString();
                Skill_target = binaryReader.ReadString();
                Skill_effect = binaryReader.ReadString();
            }
        }

        return true;
    }
}

