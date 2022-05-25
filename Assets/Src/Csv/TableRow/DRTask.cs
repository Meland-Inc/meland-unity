//------------------------------------------------------------
// 此文件由工具自动生成
// 生成时间：2022-05-25 14:56:28.748
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
public class DRTask : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取任务ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取任务名称
最多五个字。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务描述。*/
    /// </summary>
    public string[] Description
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务简述。*/
    /// </summary>
    public string[] ShortDescription
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务类型
1.基础任务
2.banner任务
3.上课任务。*/
    /// </summary>
    public int Type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取完成需求条件
1.默认完成
2.建造
3.对话
4.获取物品
5.合成
6.打怪
7.采集
8.扣除物品
9.探索区域
10.达成等级
11.达成神庙等级
12.代码块使用
13.养殖(暂不做)
14.种植(暂不做)。*/
    /// </summary>
    public int[] FinishTargetType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取完成需求ID
1.默认完成-不需要配
2.建造-配置EntityID
3.对话-不用配置，不能配空
4.获取物品-配置需要获取的ItemID
5.合成-配置需要合成的ItemID
6.打怪-配置击杀的MonsterID
7.采集-配置需要击杀的EntityMaterialID
8.扣除物品-扣除物品的itemID
9.区域-配置方式不确定
10.达成等级-不配置，完成数量配置等级
11.配置神庙TemplateDungeonsID
12.配置CodeblockID
13.配置MonsterID
14.配置MateriallID
。*/
    /// </summary>
    public int[] FinishTargetId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取完成需求数量。*/
    /// </summary>
    public int[] FinishTargetCont
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务奖励。*/
    /// </summary>
    public int RewardId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务是否自动交付。*/
    /// </summary>
    public bool IsAutoFinish
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务可接等级。*/
    /// </summary>
    public int StartPlayerLevel
    {
        get;
        private set;
    }

    /// <summary>
  /**获取前置任务ID。*/
    /// </summary>
    public int[] PreTaskId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否循环任务。*/
    /// </summary>
    public bool IsCyclicTasks
    {
        get;
        private set;
    }

    /// <summary>
  /**获取指引教案。*/
    /// </summary>
    public string TeachingPlan
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
        Description = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        ShortDescription = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        FinishTargetType = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        FinishTargetId = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        FinishTargetCont = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        RewardId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        IsAutoFinish = DataTableParseUtil.ParseBool(columnStrings[index++]);
        StartPlayerLevel = DataTableParseUtil.ParseInt(columnStrings[index++]);
        PreTaskId = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        IsCyclicTasks = DataTableParseUtil.ParseBool(columnStrings[index++]);
        TeachingPlan = columnStrings[index++];

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
                Description = binaryReader.ReadArray<String>();
                ShortDescription = binaryReader.ReadArray<String>();
                Type = binaryReader.Read7BitEncodedInt32();
                FinishTargetType = binaryReader.ReadArray<Int32>();
                FinishTargetId = binaryReader.ReadArray<Int32>();
                FinishTargetCont = binaryReader.ReadArray<Int32>();
                RewardId = binaryReader.Read7BitEncodedInt32();
                IsAutoFinish = binaryReader.ReadBoolean();
                StartPlayerLevel = binaryReader.Read7BitEncodedInt32();
                PreTaskId = binaryReader.ReadArray<Int32>();
                IsCyclicTasks = binaryReader.ReadBoolean();
                TeachingPlan = binaryReader.ReadString();
            }
        }

        return true;
    }
}

