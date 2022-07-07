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
public class DRResourcePoint : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取刷新间隔时间(毫秒)。*/
    /// </summary>
    public int Update_interval
    {
        get;
        private set;
    }

    /// <summary>
  /**获取范围(半径)。*/
    /// </summary>
    public int Radius
    {
        get;
        private set;
    }

    /// <summary>
  /**获取资源类型
1. monster。*/
    /// </summary>
    public int Resource_type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取资源 ID。*/
    /// </summary>
    public int[][] Resource_id
    {
        get;
        private set;
    }

    /// <summary>
  /**获取巡逻半径。*/
    /// </summary>
    public int PatrolRadius
    {
        get;
        private set;
    }

    /// <summary>
  /**获取巡逻速度。*/
    /// </summary>
    public int PatrolSpd
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否在编辑器里显示。*/
    /// </summary>
    public int IsShow
    {
        get;
        private set;
    }

    /// <summary>
  /**获取刷新点图标。*/
    /// </summary>
    public string Icon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取刷新点名称。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Update_interval = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Radius = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Resource_type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Resource_id = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        PatrolRadius = DataTableParseUtil.ParseInt(columnStrings[index++]);
        PatrolSpd = DataTableParseUtil.ParseInt(columnStrings[index++]);
        IsShow = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Icon = columnStrings[index++];
        Name = columnStrings[index++];
        index++;

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Update_interval = binaryReader.Read7BitEncodedInt32();
                Radius = binaryReader.Read7BitEncodedInt32();
                Resource_type = binaryReader.Read7BitEncodedInt32();
                Resource_id = binaryReader.ReadArrayList<Int32>();
                PatrolRadius = binaryReader.Read7BitEncodedInt32();
                PatrolSpd = binaryReader.Read7BitEncodedInt32();
                IsShow = binaryReader.Read7BitEncodedInt32();
                Icon = binaryReader.ReadString();
                Name = binaryReader.ReadString();
            }
        }

        return true;
    }
}

