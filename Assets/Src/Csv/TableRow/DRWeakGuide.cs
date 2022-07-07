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
public class DRWeakGuide : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取引导id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取描述。*/
    /// </summary>
    public string Desc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取引导类型。*/
    /// </summary>
    public int Type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取提示文案。*/
    /// </summary>
    public string GuideTips
    {
        get;
        private set;
    }

    /// <summary>
  /**获取引导持续时间
毫秒。*/
    /// </summary>
    public int Duration
    {
        get;
        private set;
    }

    /// <summary>
  /**获取隐藏方式。*/
    /// </summary>
    public string HideMethod
    {
        get;
        private set;
    }

    /// <summary>
  /**获取引导位置
e.g. :100,100。*/
    /// </summary>
    public int[] Pos
    {
        get;
        private set;
    }

    /// <summary>
  /**获取引导点击的UI
e.g. :WinmainContainer/btnAttack
如果点击的是主界面任务列表的某项任务，最后一个参数作为任务id检索。*/
    /// </summary>
    public string ClickUI
    {
        get;
        private set;
    }

    /// <summary>
  /**获取holderUI
存放提示组件的UI路径。*/
    /// </summary>
    public string HolderUI
    {
        get;
        private set;
    }

    /// <summary>
  /**获取引导点击位置偏移
e.g. :100,100。*/
    /// </summary>
    public int[] ClickOffset
    {
        get;
        private set;
    }

    /// <summary>
  /**获取前置条件。*/
    /// </summary>
    public string[][] PreConds
    {
        get;
        private set;
    }

    /// <summary>
  /**获取触发引导的条件。*/
    /// </summary>
    public string[] TriggerConds
    {
        get;
        private set;
    }

    /// <summary>
  /**获取条件参数。*/
    /// </summary>
    public string[][] Args
    {
        get;
        private set;
    }

    /// <summary>
  /**获取完成条件。*/
    /// </summary>
    public string FinishCond
    {
        get;
        private set;
    }

    /// <summary>
  /**获取引导过期条件
(暂定这些条件其中一个触发都导致失效）。*/
    /// </summary>
    public int[] Overdue
    {
        get;
        private set;
    }

    /// <summary>
  /**获取过期条件参数。*/
    /// </summary>
    public string[][] OverdueArgs
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Desc = columnStrings[index++];
        Type = DataTableParseUtil.ParseInt(columnStrings[index++]);
        GuideTips = columnStrings[index++];
        Duration = DataTableParseUtil.ParseInt(columnStrings[index++]);
        HideMethod = columnStrings[index++];
        Pos = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        ClickUI = columnStrings[index++];
        HolderUI = columnStrings[index++];
        ClickOffset = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        PreConds = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        TriggerConds = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Args = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        FinishCond = columnStrings[index++];
        Overdue = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        OverdueArgs = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Desc = binaryReader.ReadString();
                Type = binaryReader.Read7BitEncodedInt32();
                GuideTips = binaryReader.ReadString();
                Duration = binaryReader.Read7BitEncodedInt32();
                HideMethod = binaryReader.ReadString();
                Pos = binaryReader.ReadArray<Int32>();
                ClickUI = binaryReader.ReadString();
                HolderUI = binaryReader.ReadString();
                ClickOffset = binaryReader.ReadArray<Int32>();
                PreConds = binaryReader.ReadArrayList<String>();
                TriggerConds = binaryReader.ReadArray<String>();
                Args = binaryReader.ReadArrayList<String>();
                FinishCond = binaryReader.ReadString();
                Overdue = binaryReader.ReadArray<Int32>();
                OverdueArgs = binaryReader.ReadArrayList<String>();
            }
        }

        return true;
    }
}

