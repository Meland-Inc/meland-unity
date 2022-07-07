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
public class DREntityVaria : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取物件ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取物件名称。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取Varia的Icon。*/
    /// </summary>
    public string Icon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取Varia的描述。*/
    /// </summary>
    public string Desc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取类型
5.建筑物品
7.地块
8.资源（地图上刷出来的资源）
10.地板
11.墙面 
     1.普通墙面（自动建造会围绕着地板）
     2.栅栏（自动建造不围绕着地板）
     3.门（门后方不可建造其他物品）
12.窗户
17.地表（特指用于装饰地块的物件）。*/
    /// </summary>
    public int Type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子类型。*/
    /// </summary>
    public int SubType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取纹理1。*/
    /// </summary>
    public string[] Texture
    {
        get;
        private set;
    }

    /// <summary>
  /**获取补充纹理。*/
    /// </summary>
    public string SupplyTexture
    {
        get;
        private set;
    }

    /// <summary>
  /**获取行走矮边高。*/
    /// </summary>
    public int WalkLow
    {
        get;
        private set;
    }

    /// <summary>
  /**获取行走高边高。*/
    /// </summary>
    public int WalkHigh
    {
        get;
        private set;
    }

    /// <summary>
  /**获取物件高边 。*/
    /// </summary>
    public int HighEdge
    {
        get;
        private set;
    }

    /// <summary>
  /**获取物件逻辑投影。*/
    /// </summary>
    public int[][] Area
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通行方向。*/
    /// </summary>
    public int[][] WalkDir
    {
        get;
        private set;
    }

    /// <summary>
  /**获取物件形状。*/
    /// </summary>
    public int[] Shape
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否多格物件（特指不切图装饰物）
1为多格物件
0不为多格物件。*/
    /// </summary>
    public bool IsMultiPicture
    {
        get;
        private set;
    }

    /// <summary>
  /**获取物件上是否可建造
0不能建造
1可以建造但不会被覆盖
2插旗时被删除。*/
    /// </summary>
    public int BuildAble
    {
        get;
        private set;
    }

    /// <summary>
  /**获取建造高度。*/
    /// </summary>
    public int BuildHigh
    {
        get;
        private set;
    }

    /// <summary>
  /**获取建造类型
1.储物类(ArchStorage)
2.制造类(ArchProduction)
3.提示类(ArchPrompt)
4.时间类(ArchProduction)
5.状态类(ArchStateSend)。*/
    /// </summary>
    public int ArchType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取制造id
对应自己制造类型表中的id。*/
    /// </summary>
    public int ArchId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取接受状态ids。*/
    /// </summary>
    public int[] StateAcceptIds
    {
        get;
        private set;
    }

    /// <summary>
  /**获取功能扩展。*/
    /// </summary>
    public int Extension
    {
        get;
        private set;
    }

    /// <summary>
  /**获取地形类型。*/
    /// </summary>
    public int TerrainType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否有缓动效果。*/
    /// </summary>
    public int SlowMotion
    {
        get;
        private set;
    }

    /// <summary>
  /**获取场景效果根锚点。*/
    /// </summary>
    public int SceneEffectAnchor
    {
        get;
        private set;
    }

    /// <summary>
  /**获取照亮范围。*/
    /// </summary>
    public int LightRadius
    {
        get;
        private set;
    }

    /// <summary>
  /**获取遮挡是否产生半透。*/
    /// </summary>
    public bool IsCover
    {
        get;
        private set;
    }

    /// <summary>
  /**获取不显示在代码块下拉中。*/
    /// </summary>
    public bool NoShowCode
    {
        get;
        private set;
    }

    /// <summary>
  /**获取idle效果。*/
    /// </summary>
    public int IdleEffect
    {
        get;
        private set;
    }

    /// <summary>
  /**获取死亡效果。*/
    /// </summary>
    public int DeathEffect
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
        Icon = columnStrings[index++];
        Desc = columnStrings[index++];
        Type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        SubType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Texture = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        SupplyTexture = columnStrings[index++];
        WalkLow = DataTableParseUtil.ParseInt(columnStrings[index++]);
        WalkHigh = DataTableParseUtil.ParseInt(columnStrings[index++]);
        HighEdge = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Area = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        WalkDir = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        Shape = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        IsMultiPicture = DataTableParseUtil.ParseBool(columnStrings[index++]);
        BuildAble = DataTableParseUtil.ParseInt(columnStrings[index++]);
        BuildHigh = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ArchType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ArchId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        StateAcceptIds = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        Extension = DataTableParseUtil.ParseInt(columnStrings[index++]);
        TerrainType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        SlowMotion = DataTableParseUtil.ParseInt(columnStrings[index++]);
        SceneEffectAnchor = DataTableParseUtil.ParseInt(columnStrings[index++]);
        LightRadius = DataTableParseUtil.ParseInt(columnStrings[index++]);
        IsCover = DataTableParseUtil.ParseBool(columnStrings[index++]);
        NoShowCode = DataTableParseUtil.ParseBool(columnStrings[index++]);
        IdleEffect = DataTableParseUtil.ParseInt(columnStrings[index++]);
        DeathEffect = DataTableParseUtil.ParseInt(columnStrings[index++]);

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
                Icon = binaryReader.ReadString();
                Desc = binaryReader.ReadString();
                Type = binaryReader.Read7BitEncodedInt32();
                SubType = binaryReader.Read7BitEncodedInt32();
                Texture = binaryReader.ReadArray<String>();
                SupplyTexture = binaryReader.ReadString();
                WalkLow = binaryReader.Read7BitEncodedInt32();
                WalkHigh = binaryReader.Read7BitEncodedInt32();
                HighEdge = binaryReader.Read7BitEncodedInt32();
                Area = binaryReader.ReadArrayList<Int32>();
                WalkDir = binaryReader.ReadArrayList<Int32>();
                Shape = binaryReader.ReadArray<Int32>();
                IsMultiPicture = binaryReader.ReadBoolean();
                BuildAble = binaryReader.Read7BitEncodedInt32();
                BuildHigh = binaryReader.Read7BitEncodedInt32();
                ArchType = binaryReader.Read7BitEncodedInt32();
                ArchId = binaryReader.Read7BitEncodedInt32();
                StateAcceptIds = binaryReader.ReadArray<Int32>();
                Extension = binaryReader.Read7BitEncodedInt32();
                TerrainType = binaryReader.Read7BitEncodedInt32();
                SlowMotion = binaryReader.Read7BitEncodedInt32();
                SceneEffectAnchor = binaryReader.Read7BitEncodedInt32();
                LightRadius = binaryReader.Read7BitEncodedInt32();
                IsCover = binaryReader.ReadBoolean();
                NoShowCode = binaryReader.ReadBoolean();
                IdleEffect = binaryReader.Read7BitEncodedInt32();
                DeathEffect = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

