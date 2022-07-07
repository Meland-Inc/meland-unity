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
public class DREntity : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取物件ID1。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取物件名称1。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取素材分组。*/
    /// </summary>
    public int SubjectGroup
    {
        get;
        private set;
    }

    /// <summary>
  /**获取类型
专门用于前置物件判定
还有代码块类型筛选判断。*/
    /// </summary>
    public int Type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取建筑背包分类
（素材库的分类）。*/
    /// </summary>
    public int ObjectBagType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取素材标签。*/
    /// </summary>
    public string[] EntityTag
    {
        get;
        private set;
    }

    /// <summary>
  /**获取Entity的Icon。*/
    /// </summary>
    public string Icon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取Entity的描述。*/
    /// </summary>
    public string Desc
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
  /**获取动画名字。*/
    /// </summary>
    public string AnimeName
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
  /**获取建造高度。*/
    /// </summary>
    public int BuildHigh
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性控件。*/
    /// </summary>
    public int AttWidget
    {
        get;
        private set;
    }

    /// <summary>
  /**获取代码库。*/
    /// </summary>
    public int CodeBlockId
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
  /**获取通行方向。*/
    /// </summary>
    public int[][] WalkDir
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否是地块。*/
    /// </summary>
    public bool IsTerrain
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
  /**获取场景效果根锚点。*/
    /// </summary>
    public int SceneEffectAnchor
    {
        get;
        private set;
    }

    /// <summary>
  /**获取光效。*/
    /// </summary>
    public string[] LightEffect
    {
        get;
        private set;
    }

    /// <summary>
  /**获取光效锚点偏移。*/
    /// </summary>
    public int[] LightOffset 
    {
        get;
        private set;
    }

    /// <summary>
  /**获取掉落。*/
    /// </summary>
    public int DropId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取素材库展示类型。*/
    /// </summary>
    public int[] ObjectBagShowType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取正视角素材库ICON。*/
    /// </summary>
    public string RectIcon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取正视角地图纹理。*/
    /// </summary>
    public string[] RectTexture
    {
        get;
        private set;
    }

    /// <summary>
  /**获取正视角地图建造高度。*/
    /// </summary>
    public int RectBuildHigh
    {
        get;
        private set;
    }

    /// <summary>
  /**获取正视角地图行走矮边高。*/
    /// </summary>
    public int RectWalkLow
    {
        get;
        private set;
    }

    /// <summary>
  /**获取正视角地图行走高边高。*/
    /// </summary>
    public int RectWalkHigh
    {
        get;
        private set;
    }

    /// <summary>
  /**获取正视角地图效果根锚点。*/
    /// </summary>
    public int RectSceneEffectAnchor
    {
        get;
        private set;
    }

    /// <summary>
  /**获取正视角地图光效锚点偏移。*/
    /// </summary>
    public int[] RectLightOffset
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
        SubjectGroup = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ObjectBagType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        EntityTag = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Icon = columnStrings[index++];
        Desc = columnStrings[index++];
        Texture = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        SupplyTexture = columnStrings[index++];
        AnimeName = columnStrings[index++];
        Area = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        BuildHigh = DataTableParseUtil.ParseInt(columnStrings[index++]);
        AttWidget = DataTableParseUtil.ParseInt(columnStrings[index++]);
        CodeBlockId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        WalkLow = DataTableParseUtil.ParseInt(columnStrings[index++]);
        WalkHigh = DataTableParseUtil.ParseInt(columnStrings[index++]);
        HighEdge = DataTableParseUtil.ParseInt(columnStrings[index++]);
        WalkDir = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        IsTerrain = DataTableParseUtil.ParseBool(columnStrings[index++]);
        IdleEffect = DataTableParseUtil.ParseInt(columnStrings[index++]);
        SceneEffectAnchor = DataTableParseUtil.ParseInt(columnStrings[index++]);
        index++;
        LightEffect = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        LightOffset  = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        DropId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ObjectBagShowType = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        RectIcon = columnStrings[index++];
        RectTexture = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        RectBuildHigh = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RectWalkLow = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RectWalkHigh = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RectSceneEffectAnchor = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RectLightOffset = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);

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
                SubjectGroup = binaryReader.Read7BitEncodedInt32();
                Type = binaryReader.Read7BitEncodedInt32();
                ObjectBagType = binaryReader.Read7BitEncodedInt32();
                EntityTag = binaryReader.ReadArray<String>();
                Icon = binaryReader.ReadString();
                Desc = binaryReader.ReadString();
                Texture = binaryReader.ReadArray<String>();
                SupplyTexture = binaryReader.ReadString();
                AnimeName = binaryReader.ReadString();
                Area = binaryReader.ReadArrayList<Int32>();
                BuildHigh = binaryReader.Read7BitEncodedInt32();
                AttWidget = binaryReader.Read7BitEncodedInt32();
                CodeBlockId = binaryReader.Read7BitEncodedInt32();
                WalkLow = binaryReader.Read7BitEncodedInt32();
                WalkHigh = binaryReader.Read7BitEncodedInt32();
                HighEdge = binaryReader.Read7BitEncodedInt32();
                WalkDir = binaryReader.ReadArrayList<Int32>();
                IsTerrain = binaryReader.ReadBoolean();
                IdleEffect = binaryReader.Read7BitEncodedInt32();
                SceneEffectAnchor = binaryReader.Read7BitEncodedInt32();
                LightEffect = binaryReader.ReadArray<String>();
                LightOffset  = binaryReader.ReadArray<Int32>();
                DropId = binaryReader.Read7BitEncodedInt32();
                ObjectBagShowType = binaryReader.ReadArray<Int32>();
                RectIcon = binaryReader.ReadString();
                RectTexture = binaryReader.ReadArray<String>();
                RectBuildHigh = binaryReader.Read7BitEncodedInt32();
                RectWalkLow = binaryReader.Read7BitEncodedInt32();
                RectWalkHigh = binaryReader.Read7BitEncodedInt32();
                RectSceneEffectAnchor = binaryReader.Read7BitEncodedInt32();
                RectLightOffset = binaryReader.ReadArray<Int32>();
            }
        }

        return true;
    }
}

