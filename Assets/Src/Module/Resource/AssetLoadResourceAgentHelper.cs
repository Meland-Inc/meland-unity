/*
 * @Author: xiang huan
 * @Date: 2022-06-10 10:08:11
 * @LastEditTime: 2022-06-13 17:30:54
 * @LastEditors: xiang huan
 * @Description: 资产加载辅助器
 * @FilePath: /meland-unity/Assets/Src/Module/Resource/AssetLoadResourceAgentHelper.cs
 * 
 */


using GameFramework;
using GameFramework.Resource;
using UnityGameFramework.Runtime;


public class AssetLoadResourceAgentHelper : DefaultLoadResourceAgentHelper
{
    private LoadWebAssetAgent _loadWebAssetAgent = null;

    protected void Awake()
    {
        _loadWebAssetAgent = new LoadWebAssetAgent();
        _loadWebAssetAgent.LoadWebAssetUpdate += LoadWebAssetUpdate;
        _loadWebAssetAgent.LoadWebAssetComplete += LoadWebAssetComplete;
        _loadWebAssetAgent.LoadWebAssetError += LoadWebAssetError;
    }
    /// <summary>
    /// 重置加载资源代理辅助器。
    /// </summary>
    public override void Reset()
    {
        if (_loadWebAssetAgent != null)
        {
            _loadWebAssetAgent.Reset();
        }
        base.Reset();
    }


    /// <summary>
    /// 释放资源。
    /// </summary>
    /// <param name="disposing">释放资源标记。</param>
    protected override void Dispose(bool disposing)
    {

        if (m_Disposed)
        {
            return;
        }

        if (disposing)
        {
            if (_loadWebAssetAgent != null)
            {
                _loadWebAssetAgent.Dispose();
                _loadWebAssetAgent = null;
            }
        }
        base.Dispose(disposing);
    }

    protected override void Update()
    {
        if (_loadWebAssetAgent != null)
        {
            _loadWebAssetAgent.Update();
        }
        base.Update();
    }

    public override void LoadWebAsset(string fullPath)
    {
        if (m_LoadResourceAgentHelperLoadCompleteEventHandler == null || m_LoadResourceAgentHelperUpdateEventHandler == null || m_LoadResourceAgentHelperErrorEventHandler == null)
        {
            Log.Fatal("Load resource agent helper handler is invalid.");
            return;
        }
        _loadWebAssetAgent.LoadAsset(fullPath);
    }

    private void LoadWebAssetUpdate(string url, float progress)
    {
        LoadResourceAgentHelperUpdateEventArgs updateEventArgs = LoadResourceAgentHelperUpdateEventArgs.Create(LoadResourceProgress.LoadAsset, progress);
        m_LoadResourceAgentHelperUpdateEventHandler(this, updateEventArgs);
        ReferencePool.Release(updateEventArgs);
    }

    private void LoadWebAssetComplete(string url, object asset)
    {
        LoadResourceAgentHelperLoadCompleteEventArgs loadCompleteEventArgs = LoadResourceAgentHelperLoadCompleteEventArgs.Create(asset);
        m_LoadResourceAgentHelperLoadCompleteEventHandler(this, loadCompleteEventArgs);
        ReferencePool.Release(loadCompleteEventArgs);
    }

    private void LoadWebAssetError(string url, string errorStr)
    {
        LoadResourceAgentHelperErrorEventArgs errorEventArgs = LoadResourceAgentHelperErrorEventArgs.Create(LoadResourceStatus.NotExist, errorStr);
        m_LoadResourceAgentHelperErrorEventHandler(this, errorEventArgs);
        ReferencePool.Release(errorEventArgs);
    }
}

