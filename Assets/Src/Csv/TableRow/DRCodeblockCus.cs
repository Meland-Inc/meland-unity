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
public class DRCodeblockCus : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取顺序索引。*/
    /// </summary>
    public int[] OrderArr
    {
        get;
        private set;
    }

    /// <summary>
  /**获取映射代码块。*/
    /// </summary>
    public int SourceId
    {
        get;
        private set;
    }

    /// <summary>
  /**获取代码块描述。*/
    /// </summary>
    public string CodeblockDesc
    {
        get;
        private set;
    }

    /// <summary>
  /**获取函数调用名称1。*/
    /// </summary>
    public string FuncCallName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取调用名称。*/
    /// </summary>
    public string ActionName
    {
        get;
        private set;
    }

    /// <summary>
  /**获取单位。*/
    /// </summary>
    public string Unit
    {
        get;
        private set;
    }

    /// <summary>
  /**获取单位消耗。*/
    /// </summary>
    public int Price
    {
        get;
        private set;
    }

    /// <summary>
  /**获取类别。*/
    /// </summary>
    public string Category
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否是默认代码块。*/
    /// </summary>
    public bool Default
    {
        get;
        private set;
    }

    /// <summary>
  /**获取类型 。*/
    /// </summary>
    public string Type
    {
        get;
        private set;
    }

    /// <summary>
  /**获取代码块权限。*/
    /// </summary>
    public int Permission
    {
        get;
        private set;
    }

    /// <summary>
  /**获取关联数据结构。*/
    /// </summary>
    public int Struct
    {
        get;
        private set;
    }

    /// <summary>
  /**获取提示图标。*/
    /// </summary>
    public string PromptIcon
    {
        get;
        private set;
    }

    /// <summary>
  /**获取模板。*/
    /// </summary>
    public string Template1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取可隐藏结构。*/
    /// </summary>
    public string[][] HiddenStr
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数1。*/
    /// </summary>
    public string[][] Args1
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数2。*/
    /// </summary>
    public string[][] Args2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数3。*/
    /// </summary>
    public string[][] Args3
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数4。*/
    /// </summary>
    public string[][] Args4
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数5。*/
    /// </summary>
    public string[][] Args5
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数6。*/
    /// </summary>
    public string[][] Args6
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数7。*/
    /// </summary>
    public string[][] Args7
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数8。*/
    /// </summary>
    public string[][] Args8
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数9。*/
    /// </summary>
    public string[][] Args9
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数10。*/
    /// </summary>
    public string[][] Args10
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数11。*/
    /// </summary>
    public string[][] Args11
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数12。*/
    /// </summary>
    public string[][] Args12
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数13。*/
    /// </summary>
    public string[][] Args13
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数14。*/
    /// </summary>
    public string[][] Args14
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数15。*/
    /// </summary>
    public string[][] Args15
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数16。*/
    /// </summary>
    public string[][] Args16
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数17。*/
    /// </summary>
    public string[][] Args17
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数18。*/
    /// </summary>
    public string[][] Args18
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数19。*/
    /// </summary>
    public string[][] Args19
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数20。*/
    /// </summary>
    public string[][] Args20
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数21。*/
    /// </summary>
    public string[][] Args21
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数22。*/
    /// </summary>
    public string[][] Args22
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数23。*/
    /// </summary>
    public string[][] Args23
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数24。*/
    /// </summary>
    public string[][] Args24
    {
        get;
        private set;
    }

    /// <summary>
  /**获取参数25。*/
    /// </summary>
    public string[][] Args25
    {
        get;
        private set;
    }

    /// <summary>
  /**获取模板2。*/
    /// </summary>
    public string Template2
    {
        get;
        private set;
    }

    /// <summary>
  /**获取代码块排序。*/
    /// </summary>
    public int Sort
    {
        get;
        private set;
    }

    /// <summary>
  /**获取是否能在公共区域使用。*/
    /// </summary>
    public bool PublicUseful
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        OrderArr = DataTableParseUtil.ParseArray<int>(columnStrings[index++]);
        SourceId = DataTableParseUtil.ParseInt(columnStrings[index++]);
        CodeblockDesc = columnStrings[index++];
        index++;
        FuncCallName = columnStrings[index++];
        ActionName = columnStrings[index++];
        Unit = columnStrings[index++];
        Price = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Category = columnStrings[index++];
        Default = DataTableParseUtil.ParseBool(columnStrings[index++]);
        Type = columnStrings[index++];
        Permission = DataTableParseUtil.ParseInt(columnStrings[index++]);
        Struct = DataTableParseUtil.ParseInt(columnStrings[index++]);
        PromptIcon = columnStrings[index++];
        Template1 = columnStrings[index++];
        HiddenStr = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args1 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args2 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args3 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args4 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args5 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args6 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args7 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args8 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args9 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args10 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args11 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args12 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args13 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args14 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args15 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args16 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args17 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args18 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args19 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args20 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args21 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args22 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args23 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args24 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Args25 = DataTableParseUtil.ParseArrayList<string>(columnStrings[index++]);
        Template2 = columnStrings[index++];
        Sort = DataTableParseUtil.ParseInt(columnStrings[index++]);
        PublicUseful = DataTableParseUtil.ParseBool(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                OrderArr = binaryReader.ReadArray<Int32>();
                SourceId = binaryReader.Read7BitEncodedInt32();
                CodeblockDesc = binaryReader.ReadString();
                FuncCallName = binaryReader.ReadString();
                ActionName = binaryReader.ReadString();
                Unit = binaryReader.ReadString();
                Price = binaryReader.Read7BitEncodedInt32();
                Category = binaryReader.ReadString();
                Default = binaryReader.ReadBoolean();
                Type = binaryReader.ReadString();
                Permission = binaryReader.Read7BitEncodedInt32();
                Struct = binaryReader.Read7BitEncodedInt32();
                PromptIcon = binaryReader.ReadString();
                Template1 = binaryReader.ReadString();
                HiddenStr = binaryReader.ReadArrayList<String>();
                Args1 = binaryReader.ReadArrayList<String>();
                Args2 = binaryReader.ReadArrayList<String>();
                Args3 = binaryReader.ReadArrayList<String>();
                Args4 = binaryReader.ReadArrayList<String>();
                Args5 = binaryReader.ReadArrayList<String>();
                Args6 = binaryReader.ReadArrayList<String>();
                Args7 = binaryReader.ReadArrayList<String>();
                Args8 = binaryReader.ReadArrayList<String>();
                Args9 = binaryReader.ReadArrayList<String>();
                Args10 = binaryReader.ReadArrayList<String>();
                Args11 = binaryReader.ReadArrayList<String>();
                Args12 = binaryReader.ReadArrayList<String>();
                Args13 = binaryReader.ReadArrayList<String>();
                Args14 = binaryReader.ReadArrayList<String>();
                Args15 = binaryReader.ReadArrayList<String>();
                Args16 = binaryReader.ReadArrayList<String>();
                Args17 = binaryReader.ReadArrayList<String>();
                Args18 = binaryReader.ReadArrayList<String>();
                Args19 = binaryReader.ReadArrayList<String>();
                Args20 = binaryReader.ReadArrayList<String>();
                Args21 = binaryReader.ReadArrayList<String>();
                Args22 = binaryReader.ReadArrayList<String>();
                Args23 = binaryReader.ReadArrayList<String>();
                Args24 = binaryReader.ReadArrayList<String>();
                Args25 = binaryReader.ReadArrayList<String>();
                Template2 = binaryReader.ReadString();
                Sort = binaryReader.Read7BitEncodedInt32();
                PublicUseful = binaryReader.ReadBoolean();
            }
        }

        return true;
    }
}

