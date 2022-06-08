using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 场景相关各全局功能模块 本模块及其逻辑模块都会随场景创建销毁的生命周期
/// </summary>
[DisallowMultipleComponent]
public class SceneModule : MonoBehaviour
{
    /// <summary>
    /// 根 获取添加模块都在这个上面
    /// </summary>
    /// <value></value>
    public static GameObject Root { get; private set; }
    /// <summary>
    /// 场景实体管理 管理这和服务器交互的所有逻辑实体
    /// </summary>
    public static SceneEntityMgr EntityMgr;
    /// <summary>
    /// 场景渲染管理
    /// </summary>
    public static SceneRender SceneRender;

    private void Awake()
    {
        if (Root != null)
        {
            Log.Error("Scene module has been initialized.");
            Destroy(Root);
            Root = null;
        }

        Root = gameObject;

        EntityMgr = Root.AddComponent<SceneEntityMgr>();
        SceneRender = Root.AddComponent<SceneRender>();
    }

    private void OnDestroy()
    {
        Root = null;
        EntityMgr = null;
        SceneRender = null;
    }
}