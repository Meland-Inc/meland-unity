using System;
/*
 * @Author: xiang huan
 * @Date: 2022-05-09 19:35:27
 * @LastEditTime 2022-06-23 15:57:59
 * @LastEditors Please set LastEditors
 * @Description: 游戏资源加载
 * @FilePath /Assets/Src/Module/Procedure/ProcedurePreload.cs
 * 
 */

using GameFramework.Event;
using GameFramework.Procedure;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Resource;
using System.IO;
using FairyGUI;

public class ProcedurePreload : ProcedureBase
{
    private readonly Dictionary<string, bool> _loadedFlag = new();
    private int _loadedUICount = 0;
    private int _uiPackageCount = 0;
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        MLog.Info(eLogTag.procedure, "enter preload procedure");
        base.OnEnter(procedureOwner);

        GFEntry.Event.Subscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
        GFEntry.Event.Subscribe(LoadDataTableFailureEventArgs.EventId, OnLoadDataTableFailure);
        _loadedFlag.Clear();
        _loadedUICount = 0;
        _uiPackageCount = 0;
        ResourcesInit();
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        GFEntry.Event.Unsubscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
        GFEntry.Event.Unsubscribe(LoadDataTableFailureEventArgs.EventId, OnLoadDataTableFailure);
        base.OnLeave(procedureOwner, isShutdown);
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        foreach (KeyValuePair<string, bool> loadedFlag in _loadedFlag)
        {
            if (!loadedFlag.Value)
            {
                return;
            }
        }

        if (_loadedUICount != _uiPackageCount)
        {
            return;
        }

        ChangeState<LoginProcedure>(procedureOwner);
    }

    /// <summary>
    /// 资源初始化 加载使用之前需要初始化
    /// </summary>
    private void ResourcesInit()
    {
        if (GFEntry.Base.EditorResourceMode)
        {
            PreloadResources();
        }
        else if (GFEntry.Resource.ResourceMode == ResourceMode.Package)
        {
            GFEntry.Resource.InitResources(PreloadResources);
        }
        else
        {
            MLog.Fatal(eLogTag.resource, "ResourceMode not support");
        }
    }

    private void PreloadResources()
    {
        // Preload data tables
        foreach (string dataTableName in DataTableConfig.DataTableNames)
        {
            LoadDataTable(dataTableName);
        }

        PreloadUIRes();
    }

    private void LoadDataTable(string dataTableName)
    {
#if UNITY_EDITOR
        string dataTableAssetName = AssetUtil.GetDataTableAssetPath(dataTableName, false);
#else
        string dataTableAssetName = AssetUtil.GetDataTableAssetPath(dataTableName, true);
#endif
        _loadedFlag.Add(dataTableAssetName, false);
        GFEntry.DataTable.LoadDataTable(dataTableName, dataTableAssetName, this);
    }

    private void OnLoadDataTableSuccess(object sender, GameEventArgs e)
    {
        LoadDataTableSuccessEventArgs ne = (LoadDataTableSuccessEventArgs)e;
        if (ne.UserData != this)
        {
            return;
        }

        _loadedFlag[ne.DataTableAssetName] = true;
        Log.Info("Load data table '{0}' OK.", ne.DataTableAssetName);
    }

    private void OnLoadDataTableFailure(object sender, GameEventArgs e)
    {
        LoadDataTableFailureEventArgs ne = (LoadDataTableFailureEventArgs)e;
        if (ne.UserData != this)
        {
            return;
        }
        _loadedFlag[ne.DataTableAssetName] = true;
        Log.Error("Can not load data table '{0}' from '{1}' with error message '{2}'.", ne.DataTableAssetName, ne.DataTableAssetName, ne.ErrorMessage);
    }

    private async void PreloadUIRes()
    {
        string[] names = Enum.GetNames(typeof(eFUIPackage));
        _uiPackageCount = names.Length;
        foreach (string name in names)
        {
            string assetPrefix = Path.Combine(AssetDefine.PATH_UI, $"{name}");
            try
            {
                TextAsset asset = await Asset.LoadAsset<TextAsset>($"{assetPrefix}_fui.bytes");
                _ = UIPackage.AddPackage(asset.bytes, assetPrefix, LoadRes);
                _loadedUICount++;
            }
            catch (Exception e)
            {
                MLog.Error(eLogTag.ui, $"load ui {name} failed, {e.Message}");
                continue;
            }
        }
    }

    private async void LoadRes(string name, string extension, Type type, PackageItem item)
    {
        try
        {
            object asset = await Asset.LoadAsset<object>(name + extension);
            item.owner.SetItemAsset(item, asset, DestroyMethod.Unload);
            MLog.Info(eLogTag.ui, $"load ui res {name} success");
        }
        catch (Exception e)
        {
            MLog.Error(eLogTag.ui, $"load ui {name} failed, {e.Message}");
            return;
        }
    }
}