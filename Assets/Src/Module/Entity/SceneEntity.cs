using UnityEngine;
using UnityGameFramework.Runtime;
using MelandGame3;

/// <summary>
/// 场景实体 和服务器对应的实体逻辑
/// </summary>
public class SceneEntity : EntityBase
{
    /// <summary>
    /// 外观 是真正的显示资源及上面的显示逻辑 可能为空
    /// </summary>
    /// <value></value>
    public Entity Surface { get; private set; }
    /// <summary>
    /// 外观渲染器 外观渲染的主脚本和入口 可能为空
    /// </summary>
    public SceneEntityRenderBase SurfaceRender => Surface != null ? Surface.GetSurfaceRender() as SceneEntityRenderBase : null;

    public SceneEntity() : base()
    {
        EntityEvent = Root.AddComponent<SceneEntityEvent>();
    }

    public override void Dispose()
    {
        if (Surface)
        {
            GFEntry.Entity.HideEntity(Surface.Id);
            SetSurface(null);
        }
        base.Dispose();
    }

    protected override void InitToScene()
    {
        eSceneGroup sceneGroup = SceneModule.EntityMgr.GetEntitySceneGroup(BaseData.Type);
        SceneModule.SceneRender.AddToGroup(Transform, sceneGroup);
    }

    protected override void UnInitFromScene()
    {
        SceneModule.SceneRender.RemoveFromGroup(Transform);
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

    /// <summary>
    /// 直接设置服务器位置 大部分物件是静态不会动的没必要添加NetInputMove脚本 直接设置下即可 节省性能
    /// </summary>
    /// <param name="location"></param>
    public void DirectSetSvrPosition(EntityLocation location)
    {
        Transform.position = NetUtil.SvrToClientLoc(location);
    }

    /// <summary>
    /// 直接设置服务器朝向 大部分物件是静态不会动的没必要添加NetInputMove脚本 直接设置下即可 节省性能
    /// </summary>
    /// <param name="dir"></param>
    public void DirectSetSvrDir(MelandGame3.Vector3 dir)
    {
        Transform.forward = NetUtil.SvrToClientDir(dir);
    }
}