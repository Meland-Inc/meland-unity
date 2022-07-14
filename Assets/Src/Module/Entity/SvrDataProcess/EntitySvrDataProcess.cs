using Bian;
using UnityEngine;

/// <summary>
/// 实体大部分处理服务器数据的地方
/// </summary>
public abstract class EntitySvrDataProcess : MonoBehaviour
{
    /// <summary>
    /// 服务器数据初始化
    /// </summary>
    /// <param name="SceneEntity">客户端的逻辑实体</param>
    /// <param name="svrEntity">服务器实体数据</param>
    public abstract void SvrDataInit(SceneEntity sceneEntity, EntityWithLocation svrEntity);
}
