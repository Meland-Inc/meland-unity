/** 
 * @Author xiangqian
 * @Description 
 * @Date 2022-07-06 11:55:33
 * @FilePath /Assets/Src/Module/Entity/EntityRenderLogic/SceneEntityRenderBase.cs
 */
using UnityGameFramework.Runtime;
using UnityEngine;

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
    public long SceneEntityID { get; private set; }

    private Vector3 _initedPostion;
    private Vector3 _initedScale;
    private Quaternion _initedRotation;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        long sceneEntityID = (long)userData;
        if (sceneEntityID == 0)
        {
            MLog.Error(eLogTag.entity, $"sceneEntityID error={sceneEntityID}");
            return;
        }

        if (SceneModule.EntityMgr.GetEntity(sceneEntityID) is not SceneEntity sceneEntity)
        {
            GFEntry.Entity.HideEntity(Entity.Id);
            throw new System.Exception($"EntityLogic Can not find scene entity '{sceneEntityID}'.");
        }

        _initedPostion = transform.position;
        _initedRotation = transform.rotation;
        _initedScale = transform.localScale;

        gameObject.SetActive(true);

        SetSceneEntityInfo(sceneEntity);
        sceneEntity.SetSurface(Entity);
    }

    protected override void OnRecycle()
    {
        RefSceneEntity.SetSurface(null);
        transform.SetParent(null);

        transform.SetPositionAndRotation(_initedPostion, _initedRotation);
        transform.localScale = _initedScale;

        RefSceneEntity = null;
        SceneEntityID = 0;

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
        SceneEntityID = sceneEntity.BaseData.Id;
    }
}