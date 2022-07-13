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

    /// <summary>
    /// 背包管理
    /// </summary>
    public static BackpackMgr BackpackMgr;

    private void Awake()
    {
        if (Root != null)
        {
            Log.Error("Scene module has been initialized.");
            Destroy(Root);
            Root = null;
        }

        Root = gameObject;
    }

    private void OnDestroy()
    {
        Root = null;
        EntityMgr = null;
        SceneRender = null;
        BackpackMgr = null;
    }

    /// <summary>
    /// 添加运行时初始化模块 只有正式代码走过来的才会调用  美术预览场景时是不会触发的
    /// </summary>
    public void AddRuntimeInitModule()
    {
        EntityMgr = Root.AddComponent<SceneEntityMgr>();
        SceneRender = Root.AddComponent<SceneRender>();
        BackpackMgr = Root.AddComponent<BackpackMgr>();
    }
}