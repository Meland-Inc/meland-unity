using System;
using GameFramework.Resource;

/// <summary>
/// 资源加载异常
/// </summary>
public class AssetLoadException : Exception
{
    /// <summary>
    /// 加载状态 基本也是error code的意思
    /// </summary>
    public readonly LoadResourceStatus LoadStatus;
    public readonly string AssetName;
    public readonly Type AssetType;
    public AssetLoadException(string assetName, Type assetType, LoadResourceStatus status, string errorMessage) : base(errorMessage)
    {
        AssetName = assetName;
        AssetType = assetType;
        LoadStatus = status;
    }
}