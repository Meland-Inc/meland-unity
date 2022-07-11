using System.Collections.Generic;
//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text;
using System;

namespace Meland.Editor.DataTableTools
{
    public sealed class DataTableGeneratorUtil
    {
        public static string SVNCsvPath { get; private set; }
        public static string SVNConfigPath { get; private set; }

        public static void SetPath(string configPath)
        {
            if (configPath is null)
            {
                return;
            }
            SVNConfigPath = configPath;
            SVNCsvPath = configPath + "/csv";
        }

        public static void UpdateCsv()
        {
            string csvPath = Utility.Path.GetRegularPath(DataTableGenerator.DATA_TABLE_CSV_PATH);
            if (!Directory.Exists(csvPath))
            {
                _ = Directory.CreateDirectory(csvPath);
            }
            DirectoryInfo direction = new(SVNCsvPath);
            FileInfo[] files = direction.GetFiles("*.csv", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {
                string dest = Path.Combine(csvPath, files[i].Name);
                File.Copy(files[i].FullName, dest, true);
            }
        }
        public static void GenerateDataTables()
        {
            string csvPath = Utility.Path.GetRegularPath(DataTableGenerator.DATA_TABLE_CSV_PATH);
            DirectoryInfo direction = new(csvPath);
            FileInfo[] files = direction.GetFiles("*.csv", SearchOption.AllDirectories);
            List<string> tableNames = new();
            for (int i = 0; i < files.Length; i++)
            {
                string fileName = files[i].Name;
                string extension = files[i].Extension;
                string fullName = files[i].FullName;
                string dataTableName = fileName[..^extension.Length];
                tableNames.Add(dataTableName);
                DataTableProcessor dataTableProcessor = DataTableGenerator.CreateDataTableProcessor(fullName);
                if (!DataTableGenerator.CheckRawData(dataTableProcessor, dataTableName))
                {
                    Debug.LogError(Utility.Text.Format("Check raw data failure. DataTableName='{0}'", dataTableName));
                    break;
                }

                DataTableGenerator.GenerateDataFile(dataTableProcessor, dataTableName);
            }
        }

        public static void GenerateDataTableCodes()
        {
            string csvPath = Utility.Path.GetRegularPath(DataTableGenerator.DATA_TABLE_CSV_PATH);
            DirectoryInfo direction = new(csvPath);
            FileInfo[] files = direction.GetFiles("*.csv", SearchOption.AllDirectories);
            List<string> tableNames = new();
            for (int i = 0; i < files.Length; i++)
            {
                string fileName = files[i].Name;
                string extension = files[i].Extension;
                string fullName = files[i].FullName;
                string dataTableName = fileName[..^extension.Length];
                tableNames.Add(dataTableName);
                DataTableProcessor dataTableProcessor = DataTableGenerator.CreateDataTableProcessor(fullName);
                if (!DataTableGenerator.CheckRawData(dataTableProcessor, dataTableName))
                {
                    Debug.LogError(Utility.Text.Format("Check raw data failure. DataTableName='{0}'", dataTableName));
                    break;
                }
                DataTableGenerator.GenerateCodeFile(dataTableProcessor, dataTableName);
            }
            DataTableGenerator.GenerateConfigFile(tableNames.ToArray());
        }
    }
}
