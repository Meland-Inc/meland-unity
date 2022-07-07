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
public class DREntityBuildObject : DataRowBase
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
  /**获取子类型
专门用于自动建造判定。*/
    /// </summary>
    public int SubType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取建筑背包分类。*/
    /// </summary>
    public int ObjectBagType
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
  /**获取物件逻辑投影。*/
    /// </summary>
    public int[][] Area
    {
        get;
        private set;
    }

    /// <summary>
  /**获取前置物件
0，可以放置在任意类型的前置物件上。*/
    /// </summary>
    public int[] PreArticleType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取物件是否可自动建造。*/
    /// </summary>
    public int BuildAuto
    {
        get;
        private set;
    }

    /// <summary>
  /**获取物件上是否可建造。*/
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
  /**获取血量。*/
    /// </summary>
    public int HpLimit
    {
        get;
        private set;
    }

    /// <summary>
  /**获取死亡掉落配方ID。*/
    /// </summary>
    public int FallingRecipeId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取技能作用类型
傳? 0.未知类型
傳? 1.玩家
傳? 2.木头
傳? 3.草
傳? 4.石头
傳? 5.建筑
傳? 6.机器人
傳? 7.怪物

。*/
    /// </summary>
    public int ToolType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取受击特效。*/
    /// </summary>
    public string HitEffect
    {
        get;
        private set;
    }

    /// <summary>
  /**获取受击音效。*/
    /// </summary>
    public string HitMusic
    {
        get;
        private set;
    }

    /// <summary>
  /**获取物件防御。*/
    /// </summary>
    public int ObjectDef
    {
        get;
        private set;
    }

    /// <summary>
  /**获取掉落经验。*/
    /// </summary>
    public int DropExp
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
  /**获取玩家经过是否半透。*/
    /// </summary>
    public bool IsCover
    {
        get;
        private set;
    }

    /// <summary>
  /**获取身体大小(半径像素)。*/
    /// </summary>
    public int BodyCapacity
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
  /**获取代码界面中物品排序ID。*/
    /// </summary>
    public int Sort
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

    /// <summary>
  /**获取代码库ID。*/
    /// </summary>
    public int CodeBlockId
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

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Name = columnStrings[index++];
        Type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        SubType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ObjectBagType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Icon = columnStrings[index++];
        Desc = columnStrings[index++];
        Texture = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        SupplyTexture = columnStrings[index++];
        Area = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        PreArticleType = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        BuildAuto = DataTableParseUtil.ParseInt(columnStrings[index++]);
        BuildAble = DataTableParseUtil.ParseInt(columnStrings[index++]);
        BuildHigh = DataTableParseUtil.ParseInt(columnStrings[index++]);
        WalkLow = DataTableParseUtil.ParseInt(columnStrings[index++]);
        WalkHigh = DataTableParseUtil.ParseInt(columnStrings[index++]);
        HighEdge = DataTableParseUtil.ParseInt(columnStrings[index++]);
        WalkDir = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        HpLimit = DataTableParseUtil.ParseInt(columnStrings[index++]);
        FallingRecipeId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ToolType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        HitEffect = columnStrings[index++];
        HitMusic = columnStrings[index++];
        ObjectDef = DataTableParseUtil.ParseInt(columnStrings[index++]);
        DropExp = DataTableParseUtil.ParseInt(columnStrings[index++]);
        index++;
        TerrainType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        SlowMotion = DataTableParseUtil.ParseInt(columnStrings[index++]);
        SceneEffectAnchor = DataTableParseUtil.ParseInt(columnStrings[index++]);
        LightRadius = DataTableParseUtil.ParseInt(columnStrings[index++]);
        IsCover = DataTableParseUtil.ParseBool(columnStrings[index++]);
        BodyCapacity = DataTableParseUtil.ParseInt(columnStrings[index++]);
        NoShowCode = DataTableParseUtil.ParseBool(columnStrings[index++]);
        Sort = DataTableParseUtil.ParseInt(columnStrings[index++]);
        AttWidget = DataTableParseUtil.ParseInt(columnStrings[index++]);
        IdleEffect = DataTableParseUtil.ParseInt(columnStrings[index++]);
        DeathEffect = DataTableParseUtil.ParseInt(columnStrings[index++]);
        CodeBlockId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        IsTerrain = DataTableParseUtil.ParseBool(columnStrings[index++]);

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
                SubType = binaryReader.Read7BitEncodedInt32();
                ObjectBagType = binaryReader.Read7BitEncodedInt32();
                Icon = binaryReader.ReadString();
                Desc = binaryReader.ReadString();
                Texture = binaryReader.ReadArray<String>();
                SupplyTexture = binaryReader.ReadString();
                Area = binaryReader.ReadArrayList<Int32>();
                PreArticleType = binaryReader.ReadArray<Int32>();
                BuildAuto = binaryReader.Read7BitEncodedInt32();
                BuildAble = binaryReader.Read7BitEncodedInt32();
                BuildHigh = binaryReader.Read7BitEncodedInt32();
                WalkLow = binaryReader.Read7BitEncodedInt32();
                WalkHigh = binaryReader.Read7BitEncodedInt32();
                HighEdge = binaryReader.Read7BitEncodedInt32();
                WalkDir = binaryReader.ReadArrayList<Int32>();
                HpLimit = binaryReader.Read7BitEncodedInt32();
                FallingRecipeId = binaryReader.Read7BitEncodedInt32();
                ToolType = binaryReader.Read7BitEncodedInt32();
                HitEffect = binaryReader.ReadString();
                HitMusic = binaryReader.ReadString();
                ObjectDef = binaryReader.Read7BitEncodedInt32();
                DropExp = binaryReader.Read7BitEncodedInt32();
                TerrainType = binaryReader.Read7BitEncodedInt32();
                SlowMotion = binaryReader.Read7BitEncodedInt32();
                SceneEffectAnchor = binaryReader.Read7BitEncodedInt32();
                LightRadius = binaryReader.Read7BitEncodedInt32();
                IsCover = binaryReader.ReadBoolean();
                BodyCapacity = binaryReader.Read7BitEncodedInt32();
                NoShowCode = binaryReader.ReadBoolean();
                Sort = binaryReader.Read7BitEncodedInt32();
                AttWidget = binaryReader.Read7BitEncodedInt32();
                IdleEffect = binaryReader.Read7BitEncodedInt32();
                DeathEffect = binaryReader.Read7BitEncodedInt32();
                CodeBlockId = binaryReader.Read7BitEncodedInt32();
                IsTerrain = binaryReader.ReadBoolean();
            }
        }

        return true;
    }
}

