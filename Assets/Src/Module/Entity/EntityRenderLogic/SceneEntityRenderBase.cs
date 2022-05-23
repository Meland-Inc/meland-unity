using UnityGameFramework.Runtime;

/// <summary>
/// 场景实体渲染逻辑基类
/// </summary>
public class SceneEntityRenderBase : EntityLogic
{
    /// <summary>
    /// 引用的场景实体对象
    /// </summary>
    /// <value></value>
    public SceneEntity RefSceneEntity { get; private set; }
    /// <summary>
    /// 对应的场景实体ID
    /// </summary>
    /// <value></value>
    public string SceneEntityID { get; private set; }

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        EntityRenderTempData data = userData as EntityRenderTempData;
        SceneEntity sceneEntity = SceneModule.EntityMgr.GetSceneEntity(data.SceneEntityID);
        if (sceneEntity == null)
        {
            GFEntry.Entity.HideEntity(Entity.Id);
            throw new System.Exception($"EntityLogic Can not find scene entity '{data.SceneEntityID}'.");
        }

        gameObject.SetActive(true);

        SetSceneEntityInfo(sceneEntity);
        sceneEntity.SetSurface(Entity);
    }

    protected override void OnRecycle()
    {
        RefSceneEntity.SetSurface(null);
        transform.SetParent(null);

        RefSceneEntity = null;
        SceneEntityID = null;

        gameObject.SetActive(false);

        base.OnRecycle();
    }

    /// <summary>
    /// 设置对应的场景实体的信息 建议访问关系
    /// </summary>
    /// <param name="sceneEntity"></param>
    public void SetSceneEntityInfo(SceneEntity sceneEntity)
    {
        RefSceneEntity = sceneEntity;
        SceneEntityID = sceneEntity.BaseData.ID;
    }
}