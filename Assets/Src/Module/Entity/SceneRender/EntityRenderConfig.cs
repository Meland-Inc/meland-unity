using UnityEngine;

/// <summary>
/// 实体的渲染配置 只是关于纯渲染 往往给美术使用 和服务器无关
/// </summary>
public class EntityRenderConfig : MonoBehaviour
{
    /// <summary>
    /// 纸片物件看向相机 对3D物件无效
    /// </summary>
    public bool lookCamera = true;
    /// <summary>
    /// 是否水平放置 比如纸片地板 3d物件无效 
    /// </summary>
    public bool IsHorizontal = false;
}