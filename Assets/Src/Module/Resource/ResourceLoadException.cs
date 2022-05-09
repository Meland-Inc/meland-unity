using System;
using GameFramework.Resource;

/// <summary>
/// 资源加载异常
/// </summary>
public class ResourceLoadException : Exception
{
    /// <summary>
    /// 加载状态 基本也是error code的意思
    /// </summary>
    public readonly LoadResourceStatus LoadStatus;
    // public readonly string ErrorMsg;
    public readonly string AssetName;
    /// <summary>
    /// 加载时传进去的用户自定义数据
    /// </summary>
    public readonly object UserData;
    public ResourceLoadException(string assetName, LoadResourceStatus status, string errorMessage, object userData) : base(errorMessage)
    {
        AssetName = assetName;
        LoadStatus = status;
        // Message = errorMessage;
        UserData = userData;
    }
}