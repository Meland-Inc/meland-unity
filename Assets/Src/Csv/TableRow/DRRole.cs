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
public class DRRole : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取角色名字。*/
    /// </summary>
    public string RoleName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取角色性别
1.男
2.女。*/
    /// </summary>
    public int RoleSex
    {
        get;
        private set;
    }

    /// <summary>
  /**获取RoleAssetID。*/
    /// </summary>
    public int RoleAssetID
    {
        get;
        private set;
    }

    /// <summary>
  /**获取创建角色可选avatar(1002011)。*/
    /// </summary>
    public int[] RoleDefaultAvatar
    {
        get;
        private set;
    }

    /// <summary>
  /**获取无装备时技能ID(1002002)。*/
    /// </summary>
    public int RoleDefaultSkill
    {
        get;
        private set;
    }

    /// <summary>
  /**获取采集技能。*/
    /// </summary>
    public int CollectSkill
    {
        get;
        private set;
    }

    /// <summary>
  /**获取开宝箱技能。*/
    /// </summary>
    public int OpenChestSkill
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
  /**获取点亮半径。*/
    /// </summary>
    public int LightRadius
    {
        get;
        private set;
    }

    /// <summary>
  /**获取草地跑声音。*/
    /// </summary>
    public string GrasslandRunSound
    {
        get;
        private set;
    }

    /// <summary>
  /**获取拾取音效。*/
    /// </summary>
    public string PickUpSound
    {
        get;
        private set;
    }

    /// <summary>
  /**获取头像名称。*/
    /// </summary>
    public string[] RoleIcon
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        RoleName = columnStrings[index++];
        RoleSex = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RoleAssetID = DataTableParseUtil.ParseInt(columnStrings[index++]);
        RoleDefaultAvatar = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        RoleDefaultSkill = DataTableParseUtil.ParseInt(columnStrings[index++]);
        CollectSkill = DataTableParseUtil.ParseInt(columnStrings[index++]);
        OpenChestSkill = DataTableParseUtil.ParseInt(columnStrings[index++]);
        BodyCapacity = DataTableParseUtil.ParseInt(columnStrings[index++]);
        LightRadius = DataTableParseUtil.ParseInt(columnStrings[index++]);
        GrasslandRunSound = columnStrings[index++];
        PickUpSound = columnStrings[index++];
        RoleIcon = DataTableParseUtil.ParseArray<string>(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                RoleName = binaryReader.ReadString();
                RoleSex = binaryReader.Read7BitEncodedInt32();
                RoleAssetID = binaryReader.Read7BitEncodedInt32();
                RoleDefaultAvatar = binaryReader.ReadArray<Int32>();
                RoleDefaultSkill = binaryReader.Read7BitEncodedInt32();
                CollectSkill = binaryReader.Read7BitEncodedInt32();
                OpenChestSkill = binaryReader.Read7BitEncodedInt32();
                BodyCapacity = binaryReader.Read7BitEncodedInt32();
                LightRadius = binaryReader.Read7BitEncodedInt32();
                GrasslandRunSound = binaryReader.ReadString();
                PickUpSound = binaryReader.ReadString();
                RoleIcon = binaryReader.ReadArray<String>();
            }
        }

        return true;
    }
}

