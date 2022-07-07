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
public class DRAvatar : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取资源女1。*/
    /// </summary>
    public string ResouceGirl
    {
        get;
        private set;
    }

    /// <summary>
  /**获取显示女资源icon。*/
    /// </summary>
    public string ResouceGirlIcon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取资源男。*/
    /// </summary>
    public string ResouceBoy
    {
        get;
        private set;
    }

    /// <summary>
  /**获取显示男资源icon。*/
    /// </summary>
    public string ResouceBoyIcon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取资源机器人。*/
    /// </summary>
    public string ResouceRobot
    {
        get;
        private set;
    }

    /// <summary>
  /**获取avatar资源类别
1.头发 
2.上衣 
3.手套 
4.裤子 
5.脸型 
6.眼睛 
7.嘴巴 
8.眉毛 
9.机器人手臂
10.机器人身体
11.机器人头盔
12.机器人腿部
13.机器人背包
14.鞋子。*/
    /// </summary>
    public int AvatarType
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        ResouceGirl = columnStrings[index++];
        ResouceGirlIcon = columnStrings[index++];
        ResouceBoy = columnStrings[index++];
        ResouceBoyIcon = columnStrings[index++];
        ResouceRobot = columnStrings[index++];
        AvatarType = DataTableParseUtil.ParseInt(columnStrings[index++]);
        index++;

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                ResouceGirl = binaryReader.ReadString();
                ResouceGirlIcon = binaryReader.ReadString();
                ResouceBoy = binaryReader.ReadString();
                ResouceBoyIcon = binaryReader.ReadString();
                ResouceRobot = binaryReader.ReadString();
                AvatarType = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

