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
public class DRAttributeWidgetBase : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取子组件1。*/
    /// </summary>
    public int Child1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件参数1。*/
    /// </summary>
    public string[][] ChildParam1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件功能1。*/
    /// </summary>
    public int ChildFunc1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件2。*/
    /// </summary>
    public int Child2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件参数2。*/
    /// </summary>
    public string[][] ChildParam2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件功能2。*/
    /// </summary>
    public int ChildFunc2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件3。*/
    /// </summary>
    public int Child3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件参数3。*/
    /// </summary>
    public string[][] ChildParam3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件功能3。*/
    /// </summary>
    public int ChildFunc3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件4。*/
    /// </summary>
    public int Child4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件参数4。*/
    /// </summary>
    public string[][] ChildParam4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件功能4。*/
    /// </summary>
    public int ChildFunc4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件5。*/
    /// </summary>
    public int Child5
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件参数5。*/
    /// </summary>
    public string[][] ChildParam5
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件功能5。*/
    /// </summary>
    public int ChildFunc5
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件6。*/
    /// </summary>
    public int Child6
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件参数6。*/
    /// </summary>
    public string[][] ChildParam6
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件功能6。*/
    /// </summary>
    public int ChildFunc6
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件7。*/
    /// </summary>
    public int Child7
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件参数7。*/
    /// </summary>
    public string[][] ChildParam7
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件功能7。*/
    /// </summary>
    public int ChildFunc7
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件8。*/
    /// </summary>
    public int Child8
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件参数8。*/
    /// </summary>
    public string[][] ChildParam8
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件功能8。*/
    /// </summary>
    public int ChildFunc8
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件9。*/
    /// </summary>
    public int Child9
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件参数9。*/
    /// </summary>
    public string[][] ChildParam9
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件功能9。*/
    /// </summary>
    public int ChildFunc9
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件10。*/
    /// </summary>
    public int Child10
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件参数10。*/
    /// </summary>
    public string[][] ChildParam10
    {
        get;
        private set;
    }

    /// <summary>
  /**获取子组件功能10。*/
    /// </summary>
    public int ChildFunc10
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        index++;
        Child1 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ChildParam1 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        ChildFunc1 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Child2 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ChildParam2 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        ChildFunc2 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Child3 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ChildParam3 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        ChildFunc3 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Child4 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ChildParam4 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        ChildFunc4 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Child5 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ChildParam5 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        ChildFunc5 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Child6 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ChildParam6 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        ChildFunc6 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Child7 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ChildParam7 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        ChildFunc7 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Child8 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ChildParam8 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        ChildFunc8 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Child9 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ChildParam9 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        ChildFunc9 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Child10 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        ChildParam10 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        ChildFunc10 = DataTableParseUtil.ParseInt(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Child1 = binaryReader.Read7BitEncodedInt32();
                ChildParam1 = binaryReader.ReadArrayList<String>();
                ChildFunc1 = binaryReader.Read7BitEncodedInt32();
                Child2 = binaryReader.Read7BitEncodedInt32();
                ChildParam2 = binaryReader.ReadArrayList<String>();
                ChildFunc2 = binaryReader.Read7BitEncodedInt32();
                Child3 = binaryReader.Read7BitEncodedInt32();
                ChildParam3 = binaryReader.ReadArrayList<String>();
                ChildFunc3 = binaryReader.Read7BitEncodedInt32();
                Child4 = binaryReader.Read7BitEncodedInt32();
                ChildParam4 = binaryReader.ReadArrayList<String>();
                ChildFunc4 = binaryReader.Read7BitEncodedInt32();
                Child5 = binaryReader.Read7BitEncodedInt32();
                ChildParam5 = binaryReader.ReadArrayList<String>();
                ChildFunc5 = binaryReader.Read7BitEncodedInt32();
                Child6 = binaryReader.Read7BitEncodedInt32();
                ChildParam6 = binaryReader.ReadArrayList<String>();
                ChildFunc6 = binaryReader.Read7BitEncodedInt32();
                Child7 = binaryReader.Read7BitEncodedInt32();
                ChildParam7 = binaryReader.ReadArrayList<String>();
                ChildFunc7 = binaryReader.Read7BitEncodedInt32();
                Child8 = binaryReader.Read7BitEncodedInt32();
                ChildParam8 = binaryReader.ReadArrayList<String>();
                ChildFunc8 = binaryReader.Read7BitEncodedInt32();
                Child9 = binaryReader.Read7BitEncodedInt32();
                ChildParam9 = binaryReader.ReadArrayList<String>();
                ChildFunc9 = binaryReader.Read7BitEncodedInt32();
                Child10 = binaryReader.Read7BitEncodedInt32();
                ChildParam10 = binaryReader.ReadArrayList<String>();
                ChildFunc10 = binaryReader.Read7BitEncodedInt32();
            }
        }

        return true;
    }
}

