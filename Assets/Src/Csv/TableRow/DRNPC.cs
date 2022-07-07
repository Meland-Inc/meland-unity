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
public class DRNPC : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取NPCid。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取NPC名字1。*/
    /// </summary>
    public string NpcName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取NPC所属地图

2.刷出npc。*/
    /// </summary>
    public int NpcMap
    {
        get;
        private set;
    }

    /// <summary>
  /**获取NPC位置1。*/
    /// </summary>
    public int[] Location
    {
        get;
        private set;
    }

    /// <summary>
  /**获取NPC场景备注。*/
    /// </summary>
    public string NPCsceneRemark
    {
        get;
        private set;
    }

    /// <summary>
  /**获取NPC闲聊对话ID。*/
    /// </summary>
    public int ChatDialogID
    {
        get;
        private set;
    }

    /// <summary>
  /**获取NPC半身像资源。*/
    /// </summary>
    public string HalfAvatar
    {
        get;
        private set;
    }

    /// <summary>
  /**获取npcAvatar。*/
    /// </summary>
    public string NpcAvatar
    {
        get;
        private set;
    }

    /// <summary>
  /**获取NPC类型。*/
    /// </summary>
    public string Npctype
    {
        get;
        private set;
    }

    /// <summary>
  /**获取大地图是否展示NPC。*/
    /// </summary>
    public bool IfNpcShow
    {
        get;
        private set;
    }

    /// <summary>
  /**获取NPC默认对话。*/
    /// </summary>
    public string[] DefaultDialog
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        NpcName = columnStrings[index++];
        NpcMap = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Location = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        NPCsceneRemark = columnStrings[index++];
        ChatDialogID = DataTableParseUtil.ParseInt(columnStrings[index++]);
        HalfAvatar = columnStrings[index++];
        NpcAvatar = columnStrings[index++];
        Npctype = columnStrings[index++];
        IfNpcShow = DataTableParseUtil.ParseBool(columnStrings[index++]);
        DefaultDialog = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                NpcName = binaryReader.ReadString();
                NpcMap = binaryReader.Read7BitEncodedInt32();
                Location = binaryReader.ReadArray<Int32>();
                NPCsceneRemark = binaryReader.ReadString();
                ChatDialogID = binaryReader.Read7BitEncodedInt32();
                HalfAvatar = binaryReader.ReadString();
                NpcAvatar = binaryReader.ReadString();
                Npctype = binaryReader.ReadString();
                IfNpcShow = binaryReader.ReadBoolean();
                DefaultDialog = binaryReader.ReadArray<String>();
            }
        }

        return true;
    }
}

