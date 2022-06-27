using UnityEngine;
using Spine.Unity;

/// <summary>
/// 2D动画形象 不会有加载逻辑 gameobject本身就是加载好的2d形象
/// 是所有2D动画形象的基类
/// </summary>
public class Avatar2D : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _meshRenderer;
    public MeshRenderer MeshRenderer => _meshRenderer;

    [SerializeField]
    private SkeletonAnimation _skeletonAnimation;
    public SkeletonAnimation SkeletonAnimation => _skeletonAnimation;

    /// <summary>
    /// 真正显示avatar对象的根容器 可能是自己 也可能是生成出来的spine对象
    /// </summary>
    /// <value></value>
    public GameObject AvatarRoot { get; protected set; }

    /// <summary>
    /// 是否有效 代表已经有avatar形象
    /// </summary>
    /// <value></value>
    public bool IsValid => _skeletonAnimation != null;


    private void Awake()
    {
        InitSelfAvatar();
    }

    /// <summary>
    /// 初始化自身就是avatar的情况 子类不需要时覆写掉空
    /// </summary>
    protected virtual void InitSelfAvatar()
    {
        AvatarRoot = gameObject;
        FindComponent();
    }

    /// <summary>
    /// 找到显示对象上的基础组件
    /// </summary>
    protected void FindComponent()
    {
        _meshRenderer = AvatarRoot.GetComponent<MeshRenderer>();
        _skeletonAnimation = AvatarRoot.GetComponent<SkeletonAnimation>();
    }
}