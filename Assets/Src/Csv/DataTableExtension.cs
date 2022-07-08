/*
 * @Author: xiang huan
 * @Date: 2022-05-20 10:05:57
 * @Description: 
 * @FilePath: /meland-unity/Assets/Src/Csv/DataTableExtension.cs
 * 
 */

using GameFramework;
using GameFramework.DataTable;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;


public static class DataTableExtension
{
    private const string DATA_ROW_CLASS_PREFIX_NAME = "DR";
    public static void LoadDataTable(this DataTableComponent dataTableComponent, string dataTableName, string dataTableAssetName, object userData)
    {
        if (string.IsNullOrEmpty(dataTableName))
        {
            Log.Warning("Data table name is invalid.");
            return;
        }

        string[] splitNames = dataTableName.Split('_');
        if (splitNames.Length > 2)
        {
            Log.Warning("Data table name is invalid.");
            return;
        }

        string dataRowClassName = DATA_ROW_CLASS_PREFIX_NAME + splitNames[0];
        Type dataRowType = Utility.Assembly.GetType(dataRowClassName);
        if (dataRowType == null)
        {
            Log.Warning("Can not get data row type with class name '{0}'.", dataRowClassName);
            return;
        }

        string name = splitNames.Length > 1 ? splitNames[1] : null;
        DataTableBase dataTable = dataTableComponent.CreateDataTable(dataRowType, name);
        dataTable.ReadData(dataTableAssetName, (int)eLoadPriority.High, userData);
    }
}

