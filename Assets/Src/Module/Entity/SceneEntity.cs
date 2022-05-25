using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 场景实体 和服务器对应的实体逻辑
/// </summary>
public class SceneEntity
{
    /// <summary>
    /// 逻辑实体根节点 可以挂载逻辑实体相关逻辑 出现在场景时会被创建
    /// </summary>
    /// <value></value>
    public GameObject Root { get; private set; }
    /// <summary>
    /// 场景实体基础数据 快捷访问方式
    /// </summary>
    /// <value></value>
    public SceneEntityBaseData BaseData { get; private set; }
    /// <summary>
    /// 外观 是真正的显示资源及上面的显示逻辑
    /// </summary>
    /// <value></value>
    public Entity Surface { get; private set; }
    /// <summary>
    /// 外观渲染器 外观渲染的主脚本和入口
    /// </summary>
    public EntityLogic SurfaceRender => Surface != null ? Surface.GetSurfaceRender() : null;

    public SceneEntity(string name = null)
    {
        if (string.IsNullOrEmpty(name))
        {
            name = "SceneEntity" + GetHashCode();
        }
        Root = new GameObject(name);
    }

    public void SetRootName(string name)
    {
        Root.name = name;
    }

    public void SetRootParent(Transform parent)
    {
        Root.transform.SetParent(parent, false);
    }
}