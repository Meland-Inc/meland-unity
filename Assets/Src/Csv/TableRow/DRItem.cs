//------------------------------------------------------------
// 此文件由工具自动生成
// 生成时间：2022-05-23 15:59:48.097
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
public class DRItem : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取物品ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取物品名称。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取建筑背包分类
（素材库的分类）。*/
    /// </summary>
    public int ObjectBagType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取物品描述。*/
    /// </summary>
    public string Desc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取物品类型。*/
    /// </summary>
    public int Type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取初始物件数量。*/
    /// </summary>
    public int InitObjectQuantity
    {
        get;
        private set;
    }

    /// <summary>
  /**获取背包堆叠上限。*/
    /// </summary>
    public int BackpackItemLimit
    {
        get;
        private set;
    }

    /// <summary>
  /**获取物品图标。*/
    /// </summary>
    public string Icon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取物品品质。*/
    /// </summary>
    public int[] Quality
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否可以交易。*/
    /// </summary>
    public bool CanTrade
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否可以出售。*/
    /// </summary>
    public bool CanSell
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否可以丢弃。*/
    /// </summary>
    public bool CanDrop
    {
        get;
        private set;
    }

    /// <summary>
  /**获取（废弃）是否是燃料。*/
    /// </summary>
    public bool IsFuel
    {
        get;
        private set;
    }

    /// <summary>
  /**获取背包显示分类。*/
    /// </summary>
    public int BagShowType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取使用后掉落。*/
    /// </summary>
    public int UseDrop
    {
        get;
        private set;
    }

    /// <summary>
  /**获取使用等级。*/
    /// </summary>
    public int UseLv
    {
        get;
        private set;
    }

    /// <summary>
  /**获取不显示在代码块下拉中。*/
    /// </summary>
    public bool NoShowCode
    {
        get;
        private set;
    }

    /// <summary>
  /**获取使用者类型。*/
    /// </summary>
    public int UserType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性控件。*/
    /// </summary>
    public int AttWidget
    {
        get;
        private set;
    }

    /// <summary>
  /**获取代码库。*/
    /// </summary>
    public int CodeBlockId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取素材分组。*/
    /// </summary>
    public int SubjectGroup
    {
        get;
        private set;
    }

    /// <summary>
  /**获取绑定类型。*/
    /// </summary>
    public int Binding
    {
        get;
        private set;
    }

    /// <summary>
  /**获取素材库展示类型。*/
    /// </summary>
    public int[] ObjectBagShowType
    {
        get;
        private set;
    }

    /// <summary>
  /**获取正视角物品图标。*/
    /// </summary>
    public string RectIcon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否NFT。*/
    /// </summary>
    public int CanMint
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
        index++;
        ObjectBagType = DataTableExtension.ParseInt(columnStrings[index++]);
        Desc = columnStrings[index++];
        Type = DataTableExtension.ParseInt(columnStrings[index++]);
        InitObjectQuantity = DataTableExtension.ParseInt(columnStrings[index++]);
        BackpackItemLimit = DataTableExtension.ParseInt(columnStrings[index++]);
        Icon = columnStrings[index++];
        Quality = DataTableExtension.ParseArray<int>(columnStrings[index++]);
        CanTrade = DataTableExtension.ParseBool(columnStrings[index++]);
        CanSell = DataTableExtension.ParseBool(columnStrings[index++]);
        CanDrop = DataTableExtension.ParseBool(columnStrings[index++]);
        IsFuel = DataTableExtension.ParseBool(columnStrings[index++]);
        BagShowType = DataTableExtension.ParseInt(columnStrings[index++]);
        UseDrop = DataTableExtension.ParseInt(columnStrings[index++]);
        UseLv = DataTableExtension.ParseInt(columnStrings[index++]);
        NoShowCode = DataTableExtension.ParseBool(columnStrings[index++]);
        UserType = DataTableExtension.ParseInt(columnStrings[index++]);
        AttWidget = DataTableExtension.ParseInt(columnStrings[index++]);
        CodeBlockId = DataTableExtension.ParseInt(columnStrings[index++]);
        SubjectGroup = DataTableExtension.ParseInt(columnStrings[index++]);
        Binding = DataTableExtension.ParseInt(columnStrings[index++]);
        ObjectBagShowType = DataTableExtension.ParseArray<int>(columnStrings[index++]);
        RectIcon = columnStrings[index++];
        CanMint = DataTableExtension.ParseInt(columnStrings[index++]);

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
                ObjectBagType = binaryReader.Read7BitEncodedInt32();
                Desc = binaryReader.ReadString();
                Type = binaryReader.Read7BitEncodedInt32();
                InitObjectQuantity = binaryReader.Read7BitEncodedInt32();
                BackpackItemLimit = binaryReader.Read7BitEncodedInt32();
                Icon = binaryReader.ReadString();
                Quality = binaryReader.ReadArray<Int32>();
                CanTrade = binaryReader.ReadBoolean();
                CanSell = binaryReader.ReadBoolean();
                CanDrop = binaryReader.ReadBoolean();
                IsFuel = binaryReader.ReadBoolean();
                BagShowType = binaryReader.Read7BitEncodedInt32();
                UseDrop = binaryReader.Read7BitEncodedInt32();
                UseLv = binaryReader.Read7BitEncodedInt32();
                NoShowCode = binaryReader.ReadBoolean();
                UserType = binaryReader.Read7BitEncodedInt32();
                AttWidget = binaryReader.Read7BitEncodedInt32();
                CodeBlockId = binaryReader.Read7BitEncodedInt32();
                SubjectGroup = binaryReader.Read7BitEncodedInt32();
                Binding = binaryReader.Read7BitEncodedInt32();
                ObjectBagShowType = binaryReader.ReadArray<Int32>();
                RectIcon = binaryReader.ReadString();
                CanMint = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

