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
public class DRStruct : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取名称。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取描述。*/
    /// </summary>
    public string Desc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性值1。*/
    /// </summary>
    public string Property1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性备注1。*/
    /// </summary>
    public string Comment1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性值2。*/
    /// </summary>
    public string Property2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性备注2。*/
    /// </summary>
    public string Comment2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性值3。*/
    /// </summary>
    public string Property3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性备注3。*/
    /// </summary>
    public string Comment3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性值4。*/
    /// </summary>
    public string Property4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性备注4。*/
    /// </summary>
    public string Comment4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性值5。*/
    /// </summary>
    public string Property5
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性备注5。*/
    /// </summary>
    public string Comment5
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性值6。*/
    /// </summary>
    public string Property6
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性备注6。*/
    /// </summary>
    public string Comment6
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性值7。*/
    /// </summary>
    public string Property7
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性备注7。*/
    /// </summary>
    public string Comment7
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性值8。*/
    /// </summary>
    public string Property8
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性备注8。*/
    /// </summary>
    public string Comment8
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性值9。*/
    /// </summary>
    public string Property9
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性备注9。*/
    /// </summary>
    public string Comment9
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性值10。*/
    /// </summary>
    public string Property10
    {
        get;
        private set;
    }

    /// <summary>
  /**获取属性备注10。*/
    /// </summary>
    public string Comment10
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
        Desc = columnStrings[index++];
        Property1 = columnStrings[index++];
        Comment1 = columnStrings[index++];
        Property2 = columnStrings[index++];
        Comment2 = columnStrings[index++];
        Property3 = columnStrings[index++];
        Comment3 = columnStrings[index++];
        Property4 = columnStrings[index++];
        Comment4 = columnStrings[index++];
        Property5 = columnStrings[index++];
        Comment5 = columnStrings[index++];
        Property6 = columnStrings[index++];
        Comment6 = columnStrings[index++];
        Property7 = columnStrings[index++];
        Comment7 = columnStrings[index++];
        Property8 = columnStrings[index++];
        Comment8 = columnStrings[index++];
        Property9 = columnStrings[index++];
        Comment9 = columnStrings[index++];
        Property10 = columnStrings[index++];
        Comment10 = columnStrings[index++];

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
                Desc = binaryReader.ReadString();
                Property1 = binaryReader.ReadString();
                Comment1 = binaryReader.ReadString();
                Property2 = binaryReader.ReadString();
                Comment2 = binaryReader.ReadString();
                Property3 = binaryReader.ReadString();
                Comment3 = binaryReader.ReadString();
                Property4 = binaryReader.ReadString();
                Comment4 = binaryReader.ReadString();
                Property5 = binaryReader.ReadString();
                Comment5 = binaryReader.ReadString();
                Property6 = binaryReader.ReadString();
                Comment6 = binaryReader.ReadString();
                Property7 = binaryReader.ReadString();
                Comment7 = binaryReader.ReadString();
                Property8 = binaryReader.ReadString();
                Comment8 = binaryReader.ReadString();
                Property9 = binaryReader.ReadString();
                Comment9 = binaryReader.ReadString();
                Property10 = binaryReader.ReadString();
                Comment10 = binaryReader.ReadString();
            }
        }

        return true;
    }
}

