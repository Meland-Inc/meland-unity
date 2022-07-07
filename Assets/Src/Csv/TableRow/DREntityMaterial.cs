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
public class DREntityMaterial : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取物件ID。*/
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
  /**获取Material的Icon。*/
    /// </summary>
    public string Icon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取Materia的描述。*/
    /// </summary>
    public string Desc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取类型
5.建筑物品
7.地表/地块
8.资源（地图上刷出来的资源）
10.地板
11.墙面 
     1.普通墙面（自动建造会围绕着地板）
     2.栅栏（自动建造不围绕着地板）
     3.门（门后方不可建造其他物品）
12.窗户。*/
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
  /**获取前置物件
0，可以放置在任意类型的前置物件上。*/
    /// </summary>
    public int[] PreArticleType
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
  /**获取通行方向（阻挡）。*/
    /// </summary>
    public int[][] WalkDir
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
傳? 2.木头
傳? 3.草
傳? 4.石头
傳? 5.建筑
     8.宝箱。*/
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
  /**获取是否遮挡。*/
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
  /**获取阵营。*/
    /// </summary>
    public int Camp
    {
        get;
        private set;
    }

    /// <summary>
  /**获取种出来资源的寿命
（种植专用，非种植无需配置）单位秒。*/
    /// </summary>
    public int Life
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
        index++;
        Icon = columnStrings[index++];
        Desc = columnStrings[index++];
        Type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        SubType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        PreArticleType = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        Area = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        WalkDir = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        Texture = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        SupplyTexture = columnStrings[index++];
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
        Camp = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Life = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Sort = DataTableParseUtil.ParseInt(columnStrings[index++]);
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
                PreArticleType = binaryReader.ReadArray<Int32>();
                Area = binaryReader.ReadArrayList<Int32>();
                WalkDir = binaryReader.ReadArrayList<Int32>();
                Texture = binaryReader.ReadArray<String>();
                SupplyTexture = binaryReader.ReadString();
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
                Camp = binaryReader.Read7BitEncodedInt32();
                Life = binaryReader.Read7BitEncodedInt32();
                Sort = binaryReader.Read7BitEncodedInt32();
                IdleEffect = binaryReader.Read7BitEncodedInt32();
                DeathEffect = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

