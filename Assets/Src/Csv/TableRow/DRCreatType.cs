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
public class DRCreatType : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取id。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取通用属性1
功能类型。*/
    /// </summary>
    public int Func1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性1
控件类型。*/
    /// </summary>
    public int Type1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性1
参数。*/
    /// </summary>
    public string[][] Parm1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性2
功能类型。*/
    /// </summary>
    public int Func2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性2
控件类型。*/
    /// </summary>
    public int Type2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性2
参数。*/
    /// </summary>
    public string[][] Parm2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性3
功能类型。*/
    /// </summary>
    public int Func3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性3
控件类型。*/
    /// </summary>
    public int Type3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性3
参数。*/
    /// </summary>
    public string[][] Parm3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性4
功能类型。*/
    /// </summary>
    public int Func4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性4
控件类型。*/
    /// </summary>
    public int Type4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性4
参数。*/
    /// </summary>
    public string[][] Parm4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性5
功能类型。*/
    /// </summary>
    public int Func5
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性5
控件类型。*/
    /// </summary>
    public int Type5
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性5
参数。*/
    /// </summary>
    public string[][] Parm5
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性6
功能类型。*/
    /// </summary>
    public int Func6
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性6
控件类型。*/
    /// </summary>
    public int Type6
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性6
参数。*/
    /// </summary>
    public string[][] Parm6
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性7
功能类型。*/
    /// </summary>
    public int Func7
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性7
控件类型。*/
    /// </summary>
    public int Type7
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性7
参数。*/
    /// </summary>
    public string[][] Parm7
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性8
功能类型。*/
    /// </summary>
    public int Func8
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性8
控件类型。*/
    /// </summary>
    public int Type8
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性8
参数。*/
    /// </summary>
    public string[][] Parm8
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性9
功能类型。*/
    /// </summary>
    public int Func9
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性9
控件类型。*/
    /// </summary>
    public int Type9
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性9
参数。*/
    /// </summary>
    public string[][] Parm9
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性10
功能类型。*/
    /// </summary>
    public int Func10
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性10
控件类型。*/
    /// </summary>
    public int Type10
    {
        get;
        private set;
    }

    /// <summary>
  /**获取通用属性10
参数。*/
    /// </summary>
    public string[][] Parm10
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
        Func1 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Type1 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Parm1 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Func2 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Type2 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Parm2 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Func3 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Type3 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Parm3 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Func4 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Type4 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Parm4 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Func5 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Type5 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Parm5 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Func6 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Type6 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Parm6 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Func7 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Type7 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Parm7 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Func8 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Type8 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Parm8 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Func9 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Type9 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Parm9 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Func10 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Type10 = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Parm10 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Func1 = binaryReader.Read7BitEncodedInt32();
                Type1 = binaryReader.Read7BitEncodedInt32();
                Parm1 = binaryReader.ReadArrayList<String>();
                Func2 = binaryReader.Read7BitEncodedInt32();
                Type2 = binaryReader.Read7BitEncodedInt32();
                Parm2 = binaryReader.ReadArrayList<String>();
                Func3 = binaryReader.Read7BitEncodedInt32();
                Type3 = binaryReader.Read7BitEncodedInt32();
                Parm3 = binaryReader.ReadArrayList<String>();
                Func4 = binaryReader.Read7BitEncodedInt32();
                Type4 = binaryReader.Read7BitEncodedInt32();
                Parm4 = binaryReader.ReadArrayList<String>();
                Func5 = binaryReader.Read7BitEncodedInt32();
                Type5 = binaryReader.Read7BitEncodedInt32();
                Parm5 = binaryReader.ReadArrayList<String>();
                Func6 = binaryReader.Read7BitEncodedInt32();
                Type6 = binaryReader.Read7BitEncodedInt32();
                Parm6 = binaryReader.ReadArrayList<String>();
                Func7 = binaryReader.Read7BitEncodedInt32();
                Type7 = binaryReader.Read7BitEncodedInt32();
                Parm7 = binaryReader.ReadArrayList<String>();
                Func8 = binaryReader.Read7BitEncodedInt32();
                Type8 = binaryReader.Read7BitEncodedInt32();
                Parm8 = binaryReader.ReadArrayList<String>();
                Func9 = binaryReader.Read7BitEncodedInt32();
                Type9 = binaryReader.Read7BitEncodedInt32();
                Parm9 = binaryReader.ReadArrayList<String>();
                Func10 = binaryReader.Read7BitEncodedInt32();
                Type10 = binaryReader.Read7BitEncodedInt32();
                Parm10 = binaryReader.ReadArrayList<String>();
            }
        }

        return true;
    }
}

