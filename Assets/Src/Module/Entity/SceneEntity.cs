using UnityEngine;
using UnityGameFramework.Runtime;
using Bian;
using System;

/// <summary>
/// 场景实体 和服务器对应的实体逻辑
/// </summary>
public class SceneEntity
{
    /// <summary>
    /// 逻辑实体根节点 可以挂载逻辑实体相关逻辑 一定不为空
    /// </summary>
    /// <value></value>
    public GameObject Root { get; private set; }
    /// <summary>
    /// 场景实体变换 也是Root节点的变换 一定不为空
    /// </summary>
    public Transform Transform => Root.transform;
    /// <summary>
    /// 场景实体基础数据 快捷访问方式
    /// </summary>
    /// <value></value>
    public SceneEntityBaseData BaseData { get; private set; }

    /// <summary>
    /// 外观 是真正的显示资源及上面的显示逻辑 可能为空
    /// </summary>
    /// <value></value>
    public Entity Surface { get; private set; }
    /// <summary>
    /// 外观渲染器 外观渲染的主脚本和入口 可能为空
    /// </summary>
    public SceneEntityRenderBase SurfaceRender => Surface != null ? Surface.GetSurfaceRender() as SceneEntityRenderBase : null;

    public SceneEntity(string name = null)
    {
        if (string.IsNullOrEmpty(name))
        {
            name = "SceneEntity" + GetHashCode();
        }
        Root = new GameObject(name);
        BaseData = Root.AddComponent<SceneEntityBaseData>();
    }

    public void Init()
    {
        BaseData.Reset();
    }

    public void Dispose()
    {
        if (Surface)
        {
            GFEntry.Entity.HideEntity(Surface.Id);
            SetSurface(null);
        }
    }

    /// <summary>
    /// 设置外观实体
    /// </summary>
    /// <param name="surfaceEntity"></param>
    public void SetSurface(Entity surfaceEntity)
    {
        Surface = surfaceEntity;
        if (Surface != null)
        {
            Surface.transform.SetParent(Transform, false);
        }
    }

    public void SetRootName(string name)
    {
        Root.name = name;
    }

    public void SetRootParent(Transform parent)
    {
        Transform.SetParent(parent, false);
    }

    /// <summary>
    /// 直接设置服务器位置 大部分物件是静态不会动的没必要添加NetInputMove脚本 直接设置下即可 节省性能
    /// </summary>
    /// <param name="location"></param>
    public void DirectSetSvrPosition(EntityLocation location)
    {
        Transform.position = NetUtil.SvrLocToClient(location);
    }

    /// <summary>
    /// 直接设置服务器朝向 大部分物件是静态不会动的没必要添加NetInputMove脚本 直接设置下即可 节省性能
    /// </summary>
    /// <param name="dir"></param>
    public void DirectSetSvrDir(VectorXY dir)
    {
        Transform.forward = NetUtil.SvrDirToClient(dir);
    }
}