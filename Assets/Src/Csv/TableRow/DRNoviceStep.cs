﻿//------------------------------------------------------------
// 此文件由工具自动生成
// 生成时间：2022-05-23 15:59:48.133
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
public class DRNoviceStep : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取当前引导id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取引导描述。*/
    /// </summary>
    public string Description
    {
        get;
        private set;
    }

    /// <summary>
  /**获取引导类型
1.点击引导
2.拖动引导
3.对话引导
4.特殊的代码块引导
5.点击机器人
6.砍树
7.确认建造
8.图片提示
9.采集代码块引导
10.开场白。*/
    /// </summary>
    public int Type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否强制引导。*/
    /// </summary>
    public bool IsForce
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否可以跳过。*/
    /// </summary>
    public bool CanSkip
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否显示半透蒙版。*/
    /// </summary>
    public bool IsShowMask
    {
        get;
        private set;
    }

    /// <summary>
  /**获取本次引导中能否移动。*/
    /// </summary>
    public bool CanMove
    {
        get;
        private set;
    }

    /// <summary>
  /**获取到下一步引导的延时（毫秒）。*/
    /// </summary>
    public int Delay
    {
        get;
        private set;
    }

    /// <summary>
  /**获取显示点击下一步延时。*/
    /// </summary>
    public int NextTipsDelay
    {
        get;
        private set;
    }

    /// <summary>
  /**获取点击特定location的场景物体。*/
    /// </summary>
    public int[] ClickLocation
    {
        get;
        private set;
    }

    /// <summary>
  /**获取点击的场景物体类型
0.未知
1.地图物件
2.玩家
4.Npc
8.怪物
16.刷新点
32.掉落物
64.material
128.机器人
256.玩家死亡掉落物。*/
    /// </summary>
    public int ClickTargetType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取点击场景位置提示文案。*/
    /// </summary>
    public string ClickSceneTips
    {
        get;
        private set;
    }

    /// <summary>
  /**获取点击提示方向
0：左上
1：右上
2：左下
3：右下。*/
    /// </summary>
    public int Direction
    {
        get;
        private set;
    }

    /// <summary>
  /**获取提示文字。*/
    /// </summary>
    public string ClickUITips
    {
        get;
        private set;
    }

    /// <summary>
  /**获取点击的按钮路径。*/
    /// </summary>
    public string UiPath
    {
        get;
        private set;
    }

    /// <summary>
  /**获取对话框位置。*/
    /// </summary>
    public int[] DialogPos
    {
        get;
        private set;
    }

    /// <summary>
  /**获取自己名字。*/
    /// </summary>
    public string SelfName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取别人名字。*/
    /// </summary>
    public string OtherName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取自己的icon。*/
    /// </summary>
    public string SelfIcon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取别人的icon。*/
    /// </summary>
    public string OtherIcon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取对话引导属性结束
对话内容。*/
    /// </summary>
    public string[] Speech
    {
        get;
        private set;
    }

    /// <summary>
  /**获取服务器发送的数据类型
0:不用添加
1：添加背包数据
2：创建实体到场景。*/
    /// </summary>
    public int DataType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取引导步骤所需派发的item Id。*/
    /// </summary>
    public int[] ItemIds
    {
        get;
        private set;
    }

    /// <summary>
  /**获取item数量。*/
    /// </summary>
    public int[] ItemsNum
    {
        get;
        private set;
    }

    /// <summary>
  /**获取实体配置id。*/
    /// </summary>
    public int EntityId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取实体类型
0.未知
1.地图物件
2.玩家
4.Npc
8.怪物
16.刷新点
32.掉落物
64.material
128.机器人
256.玩家死亡掉落物。*/
    /// </summary>
    public int EntityType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取实体location。*/
    /// </summary>
    public int[] EntityLocation
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Description = columnStrings[index++];
        Type = DataTableExtension.ParseInt(columnStrings[index++]);
        IsForce = DataTableExtension.ParseBool(columnStrings[index++]);
        CanSkip = DataTableExtension.ParseBool(columnStrings[index++]);
        IsShowMask = DataTableExtension.ParseBool(columnStrings[index++]);
        CanMove = DataTableExtension.ParseBool(columnStrings[index++]);
        Delay = DataTableExtension.ParseInt(columnStrings[index++]);
        NextTipsDelay = DataTableExtension.ParseInt(columnStrings[index++]);
        ClickLocation = DataTableExtension.ParseArray<int>(columnStrings[index++]);
        ClickTargetType = DataTableExtension.ParseInt(columnStrings[index++]);
        ClickSceneTips = columnStrings[index++];
        Direction = DataTableExtension.ParseInt(columnStrings[index++]);
        ClickUITips = columnStrings[index++];
        UiPath = columnStrings[index++];
        DialogPos = DataTableExtension.ParseArray<int>(columnStrings[index++]);
        SelfName = columnStrings[index++];
        OtherName = columnStrings[index++];
        SelfIcon = columnStrings[index++];
        OtherIcon = columnStrings[index++];
        Speech = DataTableExtension.ParseArray<string>(columnStrings[index++]);
        DataType = DataTableExtension.ParseInt(columnStrings[index++]);
        ItemIds = DataTableExtension.ParseArray<int>(columnStrings[index++]);
        ItemsNum = DataTableExtension.ParseArray<int>(columnStrings[index++]);
        EntityId = DataTableExtension.ParseInt(columnStrings[index++]);
        EntityType = DataTableExtension.ParseInt(columnStrings[index++]);
        EntityLocation = DataTableExtension.ParseArray<int>(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Description = binaryReader.ReadString();
                Type = binaryReader.Read7BitEncodedInt32();
                IsForce = binaryReader.ReadBoolean();
                CanSkip = binaryReader.ReadBoolean();
                IsShowMask = binaryReader.ReadBoolean();
                CanMove = binaryReader.ReadBoolean();
                Delay = binaryReader.Read7BitEncodedInt32();
                NextTipsDelay = binaryReader.Read7BitEncodedInt32();
                ClickLocation = binaryReader.ReadArray<Int32>();
                ClickTargetType = binaryReader.Read7BitEncodedInt32();
                ClickSceneTips = binaryReader.ReadString();
                Direction = binaryReader.Read7BitEncodedInt32();
                ClickUITips = binaryReader.ReadString();
                UiPath = binaryReader.ReadString();
                DialogPos = binaryReader.ReadArray<Int32>();
                SelfName = binaryReader.ReadString();
                OtherName = binaryReader.ReadString();
                SelfIcon = binaryReader.ReadString();
                OtherIcon = binaryReader.ReadString();
                Speech = binaryReader.ReadArray<String>();
                DataType = binaryReader.Read7BitEncodedInt32();
                ItemIds = binaryReader.ReadArray<Int32>();
                ItemsNum = binaryReader.ReadArray<Int32>();
                EntityId = binaryReader.Read7BitEncodedInt32();
                EntityType = binaryReader.Read7BitEncodedInt32();
                EntityLocation = binaryReader.ReadArray<Int32>();
            }
        }

        return true;
    }
}

