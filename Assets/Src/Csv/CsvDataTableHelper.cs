/*
 * @Author: xiang huan
 * @Date: 2022-05-20 10:05:57
 * @LastEditTime: 2022-05-25 10:33:49
 * @LastEditors: xiang huan
 * @Description: 
 * @FilePath: /meland-unity/Assets/Src/Csv/CsvDataTableHelper.cs
 * 
 */
using System.Collections.Generic;
using System;
using System.IO;
using GameFramework;
using GameFramework.DataTable;
using UnityGameFramework.Runtime;
using UnityEngine;
using System.Text;

public class CsvDataTableHelper : DefaultDataTableHelper
{
    private static readonly string BytesAssetExtension = ".bytes";
    public static int DATA_TABLE_START_ROW = 3;
    /// <summary>
    /// 读取数据表。
    /// </summary>
    /// <param name="dataTable">数据表。</param>
    /// <param name="dataTableAssetName">数据表资源名称。</param>
    /// <param name="dataTableAsset">数据表资源。</param>
    /// <param name="userData">用户自定义数据。</param>
    /// <returns>是否读取数据表成功。</returns>
    public override bool ReadData(DataTableBase dataTable, string dataTableAssetName, object dataTableAsset, object userData)
    {
        TextAsset dataTableTextAsset = dataTableAsset as TextAsset;
        if (dataTableTextAsset != null)
        {
            if (dataTableAssetName.EndsWith(BytesAssetExtension, StringComparison.Ordinal))
            {
                return dataTable.ParseData(dataTableTextAsset.bytes, userData);
            }
            else
            {
                string utf8Str = Encoding.GetEncoding("GB2312").GetString(dataTableTextAsset.bytes);
                return dataTable.ParseData(utf8Str, userData);
            }
        }

        Log.Warning("Data table asset '{0}' is invalid.", dataTableAssetName);
        return false;
    }
    /// <summary>
    /// 解析数据表。
    /// </summary>
    /// <param name="dataTable">数据表。</param>
    /// <param name="dataTableString">要解析的数据表字符串。</param>
    /// <param name="userData">用户自定义数据。</param>
    /// <returns>是否解析数据表成功。</returns>
    public override bool ParseData(DataTableBase dataTable, string dataTableString, object userData)
    {
        try
        {
            string[] rows = CSVSerializer.ParseCSVRow(dataTableString);
            for (int i = DATA_TABLE_START_ROW; i < rows.Length; i++)
            {
                if (!dataTable.AddDataRow(rows[i], userData))
                {
                    Log.Warning("Can not parse data row string '{0}'.", rows[i]);
                    return false;
                }
            }

            return true;
        }
        catch (Exception exception)
        {
            Log.Warning("Can not parse data table string with exception '{0}'.", exception);
            return false;
        }
    }
}