using UnityEngine;
using UnityGameFramework.Runtime;
using Bian;

/// <summary>
/// 场景实体 和服务器对应的实体逻辑
/// </summary>
public class SceneEntity
{
    /// <summary>
    /// 逻辑实体根节点 可以挂载逻辑实体相关逻辑 一定不为空
    /// </summary>
    /// <value></value>
    private GameObject _root;
    /// <summary>
    /// 场景实体变换 也是Root节点的变换 一定不为空
    /// </summary>
    public Transform Transform => _root.transform;
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

    public SceneEntity(bool isMainRole, string name = null)
    {
        if (string.IsNullOrEmpty(name))
        {
            name = "SceneEntity" + GetHashCode();
        }
        if (isMainRole)//为了能和美术场景预览使用同一个预制件脚本配置 空物体主角的放在resouce下当做配置同步加载上来
        {
            GameObject prefab = Resources.Load<GameObject>(EntityDefine.MAIN_PLAYER_ROLE_SPECIAL_PREFAB_PATH);
            _root = Object.Instantiate(prefab);
            Resources.UnloadAsset(prefab);
        }
        else
        {
            _root = new GameObject(name);
        }
        BaseData = _root.AddComponent<SceneEntityBaseData>();
    }

    public void Init()
    {
    }

    public void Dispose()
    {
        BaseData.Reset();

        if (Surface)
        {
            GFEntry.Entity.HideEntity(Surface.Id);
            SetSurface(null);
        }

        Object.Destroy(_root);
        _root = null;
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
        _root.name = name;
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
    public T GetComponent<T>() where T : Component
    {
        return _root.GetComponent<T>();
    }

    public T AddComponent<T>() where T : Component
    {
        return _root.AddComponent<T>();
    }

    public bool TryGetComponent<T>(out T component) where T : Component
    {
        return _root.TryGetComponent(out component);
    }
}