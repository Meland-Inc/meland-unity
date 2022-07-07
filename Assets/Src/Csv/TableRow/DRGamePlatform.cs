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
public class DRGamePlatform : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取显示类型。*/
    /// </summary>
    public int ShowType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取分页。*/
    /// </summary>
    public string RootDirectory
    {
        get;
        private set;
    }

    /// <summary>
  /**获取游戏名字。*/
    /// </summary>
    public string Game
    {
        get;
        private set;
    }

    /// <summary>
  /**获取宣传图片名。*/
    /// </summary>
    public string Picture1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取游戏说明。*/
    /// </summary>
    public string Text1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取作者姓名。*/
    /// </summary>
    public string GameName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取人物ID。*/
    /// </summary>
    public int RoleId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取游戏编号。*/
    /// </summary>
    public int GameId
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        ShowType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RootDirectory = columnStrings[index++];
        Game = columnStrings[index++];
        Picture1 = columnStrings[index++];
        Text1 = columnStrings[index++];
        GameName = columnStrings[index++];
        RoleId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        GameId = DataTableParseUtil.ParseInt(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                ShowType = binaryReader.Read7BitEncodedInt32();
                RootDirectory = binaryReader.ReadString();
                Game = binaryReader.ReadString();
                Picture1 = binaryReader.ReadString();
                Text1 = binaryReader.ReadString();
                GameName = binaryReader.ReadString();
                RoleId = binaryReader.Read7BitEncodedInt32();
                GameId = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

