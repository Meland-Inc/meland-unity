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
public class DRRandomMaps : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取ID。*/
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
  /**获取视角。*/
    /// </summary>
    public int Type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取主地块。*/
    /// </summary>
    public int Terrain_1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取副地块。*/
    /// </summary>
    public int Terrain_2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取补充地块1。*/
    /// </summary>
    public int Terrain_3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取补充地块2。*/
    /// </summary>
    public int Terrain_4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取补充地块3。*/
    /// </summary>
    public int Terrain_5
    {
        get;
        private set;
    }

    /// <summary>
  /**获取虚空格数。*/
    /// </summary>
    public int Broad_width
    {
        get;
        private set;
    }

    /// <summary>
  /**获取地块1的物件。*/
    /// </summary>
    public int[][] Ids_1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取地块2的物件。*/
    /// </summary>
    public int[][] Ids_2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取地块3的物件。*/
    /// </summary>
    public int[][] Ids_3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取地块4的物件。*/
    /// </summary>
    public int[][] Ids_4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取地块5的物件。*/
    /// </summary>
    public int[][] Ids_5
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
        Type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Terrain_1 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Terrain_2 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Terrain_3 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Terrain_4 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Terrain_5 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Broad_width = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Ids_1 = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        Ids_2 = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        Ids_3 = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        Ids_4 = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        Ids_5 = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);

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
                Type = binaryReader.Read7BitEncodedInt32();
                Terrain_1 = binaryReader.Read7BitEncodedInt32();
                Terrain_2 = binaryReader.Read7BitEncodedInt32();
                Terrain_3 = binaryReader.Read7BitEncodedInt32();
                Terrain_4 = binaryReader.Read7BitEncodedInt32();
                Terrain_5 = binaryReader.Read7BitEncodedInt32();
                Broad_width = binaryReader.Read7BitEncodedInt32();
                Ids_1 = binaryReader.ReadArrayList<Int32>();
                Ids_2 = binaryReader.ReadArrayList<Int32>();
                Ids_3 = binaryReader.ReadArrayList<Int32>();
                Ids_4 = binaryReader.ReadArrayList<Int32>();
                Ids_5 = binaryReader.ReadArrayList<Int32>();
            }
        }

        return true;
    }
}

