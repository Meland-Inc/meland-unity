using MelandGame3;
using UnityEngine;

/// <summary>
/// 实体大部分处理服务器数据的地方
/// </summary>
public abstract class EntitySvrDataProcess : MonoBehaviour
{
    /// <summary>
    /// 服务器数据初始化
    /// </summary>
    /// <param name="svrEntity"></param>
    public abstract void SvrDataInit(EntityWithLocation svrEntity);
}
