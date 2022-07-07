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
public class DRObjectState : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取备注。*/
    /// </summary>
    public string Null
    {
        get;
        private set;
    }

    /// <summary>
  /**获取状态对应图片。*/
    /// </summary>
    public string Texture
    {
        get;
        private set;
    }

    /// <summary>
  /**获取状态对应动画资源名1。*/
    /// </summary>
    public string AniResName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取状态对应的动画名。*/
    /// </summary>
    public string AniName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取过度动画资源名。*/
    /// </summary>
    public string TransitionAniResName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取播放的动画名。*/
    /// </summary>
    public string TransitionAniName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取特殊纹理。*/
    /// </summary>
    public string SpecialTextureRes
    {
        get;
        private set;
    }

    /// <summary>
  /**获取物件ID。*/
    /// </summary>
    public int ObjectId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取。*/
    /// </summary>
    public string AnimName
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
  /**获取下一状态触发条件
1鼠标或手指交互触发
2主角在物件附近触发
3主角离开物件附近触发
4接收到建筑状态。*/
    /// </summary>
    public int[] TriggerConditions
    {
        get;
        private set;
    }

    /// <summary>
  /**获取触发参数。*/
    /// </summary>
    public int TriggerArg
    {
        get;
        private set;
    }

    /// <summary>
  /**获取代码块用的动画名字。*/
    /// </summary>
    public string ShowName
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
  /**获取默认状态。*/
    /// </summary>
    public int IsDefault
    {
        get;
        private set;
    }

    /// <summary>
  /**获取下一状态ID。*/
    /// </summary>
    public int NextStateIds
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否通知后台。*/
    /// </summary>
    public int IsNoticeServer
    {
        get;
        private set;
    }

    /// <summary>
  /**获取正视角地图纹理。*/
    /// </summary>
    public string RectTexture
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Null = columnStrings[index++];
        Texture = columnStrings[index++];
        AniResName = columnStrings[index++];
        AniName = columnStrings[index++];
        TransitionAniResName = columnStrings[index++];
        TransitionAniName = columnStrings[index++];
        SpecialTextureRes = columnStrings[index++];
        ObjectId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        AnimName = columnStrings[index++];
        WalkDir = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        TriggerConditions = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        TriggerArg = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ShowName = columnStrings[index++];
        LightRadius = DataTableParseUtil.ParseInt(columnStrings[index++]);
        IsDefault = DataTableParseUtil.ParseInt(columnStrings[index++]);
        NextStateIds = DataTableParseUtil.ParseInt(columnStrings[index++]);
        IsNoticeServer = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RectTexture = columnStrings[index++];

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Null = binaryReader.ReadString();
                Texture = binaryReader.ReadString();
                AniResName = binaryReader.ReadString();
                AniName = binaryReader.ReadString();
                TransitionAniResName = binaryReader.ReadString();
                TransitionAniName = binaryReader.ReadString();
                SpecialTextureRes = binaryReader.ReadString();
                ObjectId = binaryReader.Read7BitEncodedInt32();
                AnimName = binaryReader.ReadString();
                WalkDir = binaryReader.ReadArrayList<Int32>();
                TriggerConditions = binaryReader.ReadArray<Int32>();
                TriggerArg = binaryReader.Read7BitEncodedInt32();
                ShowName = binaryReader.ReadString();
                LightRadius = binaryReader.Read7BitEncodedInt32();
                IsDefault = binaryReader.Read7BitEncodedInt32();
                NextStateIds = binaryReader.Read7BitEncodedInt32();
                IsNoticeServer = binaryReader.Read7BitEncodedInt32();
                RectTexture = binaryReader.ReadString();
            }
        }

        return true;
    }
}

