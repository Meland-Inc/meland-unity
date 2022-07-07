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
public class DRNPCtalk : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取下个对话组首句闲聊。*/
    /// </summary>
    public int NextTalkTeam
    {
        get;
        private set;
    }

    /// <summary>
  /**获取对话内容
支持随机对话内容。*/
    /// </summary>
    public string[] Content
    {
        get;
        private set;
    }

    /// <summary>
  /**获取接取1个任务对话。*/
    /// </summary>
    public string[] Accept1TaskTalk
    {
        get;
        private set;
    }

    /// <summary>
  /**获取接取2个任务对话。*/
    /// </summary>
    public string[] Accept2TaskTalk
    {
        get;
        private set;
    }

    /// <summary>
  /**获取接取3个任务对话。。*/
    /// </summary>
    public string[] Accept3TaskTalk
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否气泡。*/
    /// </summary>
    public int IsBubble
    {
        get;
        private set;
    }

    /// <summary>
  /**获取对话选项数量。*/
    /// </summary>
    public int TalkOptionNum
    {
        get;
        private set;
    }

    /// <summary>
  /**获取对话选项1。*/
    /// </summary>
    public string[] Option1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取对话选项1跳转对话ID。*/
    /// </summary>
    public int ToTalkId1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务标记1。*/
    /// </summary>
    public int TaskMark1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取关联任务1。*/
    /// </summary>
    public int LinkTask1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取对话选项2。*/
    /// </summary>
    public string[] Option2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取对话选项2跳转对话ID。*/
    /// </summary>
    public int ToTalkId2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务标记2。*/
    /// </summary>
    public int TaskMark2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取关联任务2。*/
    /// </summary>
    public int LinkTask2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取对话选项3。*/
    /// </summary>
    public string[] Option3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取对话选项3跳转对话ID。*/
    /// </summary>
    public int ToTalkId3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取任务标记3。*/
    /// </summary>
    public int TaskMark3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取关联任务3。*/
    /// </summary>
    public int LinkTask3
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        NextTalkTeam = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Content = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Accept1TaskTalk = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Accept2TaskTalk = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        Accept3TaskTalk = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        IsBubble = DataTableParseUtil.ParseInt(columnStrings[index++]);
        TalkOptionNum = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Option1 = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        ToTalkId1 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        TaskMark1 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        LinkTask1 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Option2 = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        ToTalkId2 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        TaskMark2 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        LinkTask2 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Option3 = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);
        ToTalkId3 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        TaskMark3 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        LinkTask3 = DataTableParseUtil.ParseInt(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                NextTalkTeam = binaryReader.Read7BitEncodedInt32();
                Content = binaryReader.ReadArray<String>();
                Accept1TaskTalk = binaryReader.ReadArray<String>();
                Accept2TaskTalk = binaryReader.ReadArray<String>();
                Accept3TaskTalk = binaryReader.ReadArray<String>();
                IsBubble = binaryReader.Read7BitEncodedInt32();
                TalkOptionNum = binaryReader.Read7BitEncodedInt32();
                Option1 = binaryReader.ReadArray<String>();
                ToTalkId1 = binaryReader.Read7BitEncodedInt32();
                TaskMark1 = binaryReader.Read7BitEncodedInt32();
                LinkTask1 = binaryReader.Read7BitEncodedInt32();
                Option2 = binaryReader.ReadArray<String>();
                ToTalkId2 = binaryReader.Read7BitEncodedInt32();
                TaskMark2 = binaryReader.Read7BitEncodedInt32();
                LinkTask2 = binaryReader.Read7BitEncodedInt32();
                Option3 = binaryReader.ReadArray<String>();
                ToTalkId3 = binaryReader.Read7BitEncodedInt32();
                TaskMark3 = binaryReader.Read7BitEncodedInt32();
                LinkTask3 = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

