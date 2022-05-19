using UnityEngine;

/// <summary>
/// 场景相关各全局功能模块 本模块及其逻辑模块都会随场景创建销毁的生命周期
/// </summary>
public class SceneModule : MonoBehaviour
{
    /// <summary>
    /// 场景实体管理 管理这和服务器交互的所有逻辑实体
    /// </summary>
    public static SceneEntityMgr EntityMgr;

    private void Awake()
    {
        EntityMgr = AddModule<SceneEntityMgr>();
    }

    //添加场景内全局功能模块
    private T AddModule<T>() where T : MonoBehaviour
    {
        string name = typeof(T).Name;
        GameObject go = new(name);
        go.transform.parent = transform;
        return go.AddComponent<T>();
    }
}