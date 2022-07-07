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
public class DRTemplatePass : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取地图模板ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取地图模板名。*/
    /// </summary>
    public string MapTemplateName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取关联副本ID。*/
    /// </summary>
    public int DungeonId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取关卡积分。*/
    /// </summary>
    public int Score
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        MapTemplateName = columnStrings[index++];
        DungeonId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        index++;
        Score = DataTableParseUtil.ParseInt(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                MapTemplateName = binaryReader.ReadString();
                DungeonId = binaryReader.Read7BitEncodedInt32();
                Score = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

