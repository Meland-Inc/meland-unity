//------------------------------------------------------------
// 此文件由工具自动生成
// 生成时间：2022-07-04 17:14:18.940
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
public class DRTaskList : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取任务链ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取任务链解锁等级。*/
    /// </summary>
    public int Level
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务链体系。*/
    /// </summary>
    public int System
    {
        get;
        private set;
    }

    /// <summary>
  /**获取发放任务及概率（万分制）。*/
    /// </summary>
    public int[][] IncludeTask
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务链道具奖励。*/
    /// </summary>
    public int ItemReward
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务链Ditamin奖励。*/
    /// </summary>
    public int DitaminReward
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务链Exp奖励。*/
    /// </summary>
    public int ExpReward
    {
        get;
        private set;
    }

    /// <summary>
  /**获取刷新是否重置进度。*/
    /// </summary>
    public int ProgressReset
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Level = DataTableParseUtil.ParseInt(columnStrings[index++]);
        System = DataTableParseUtil.ParseInt(columnStrings[index++]);
        IncludeTask = DataTableParseUtil.ParseArrayList<int>(columnStrings[index++]);
        ItemReward = DataTableParseUtil.ParseInt(columnStrings[index++]);
        DitaminReward = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ExpReward = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ProgressReset = DataTableParseUtil.ParseInt(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Level = binaryReader.Read7BitEncodedInt32();
                System = binaryReader.Read7BitEncodedInt32();
                IncludeTask = binaryReader.ReadArrayList<Int32>();
                ItemReward = binaryReader.Read7BitEncodedInt32();
                DitaminReward = binaryReader.Read7BitEncodedInt32();
                ExpReward = binaryReader.Read7BitEncodedInt32();
                ProgressReset = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

