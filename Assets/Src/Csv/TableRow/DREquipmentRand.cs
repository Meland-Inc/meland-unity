//------------------------------------------------------------
// 此文件由工具自动生成
// 生成时间：2022-05-23 15:59:48.073
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
public class DREquipmentRand : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取随机范围ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取属性提升下限
万分比。*/
    /// </summary>
    public int AttUpMin
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性提升上限
万分比。*/
    /// </summary>
    public int AttUpMax
    {
        get;
        private set;
    }

    /// <summary>
  /**获取对应概率
权重。*/
    /// </summary>
    public int AttChance
    {
        get;
        private set;
    }

    /// <summary>
  /**获取对应装备品质。*/
    /// </summary>
    public int ItemQuality
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        AttUpMin = DataTableExtension.ParseInt(columnStrings[index++]);
        AttUpMax = DataTableExtension.ParseInt(columnStrings[index++]);
        AttChance = DataTableExtension.ParseInt(columnStrings[index++]);
        ItemQuality = DataTableExtension.ParseInt(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                AttUpMin = binaryReader.Read7BitEncodedInt32();
                AttUpMax = binaryReader.Read7BitEncodedInt32();
                AttChance = binaryReader.Read7BitEncodedInt32();
                ItemQuality = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

