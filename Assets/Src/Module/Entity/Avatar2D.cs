using System;
using UnityEngine;
using Spine.Unity;

/// <summary>
/// 2D动画形象
/// </summary>
public class Avatar2D : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private SkeletonAnimation _skeleton;
    public SkeletonAnimation SkeletonAnimation { get => _skeleton; }

    [SerializeField]
    private bool _isValid;
    /// <summary>
    /// 是否有效 代表已经有avatar形象
    /// </summary>
    /// <value></value>
    public bool IsValid => _isValid;
    private string _loadAssetPath;//非空代表走的资源加载的avatar

    [SerializeField]
    private GameObject _root;
    /// <summary>
    /// 真正显示avatar对象的根容器 可能是自己 也可能是生成出来的spine对象
    /// </summary>
    /// <value></value>
    public GameObject Root => _root;

    private void OnDestroy()
    {
        if (!string.IsNullOrEmpty(_loadAssetPath))
        {
            BasicModule.Asset.UnloadAsset<SkeletonDataAsset>(_loadAssetPath, GetHashCode());
            _loadAssetPath = null;
        }
    }

    public void Init()
    {
        _loadAssetPath = null;
        _root = gameObject;
        FindComponent();

        _isValid = _skeleton != null;
    }

    public void Init(string assetPath, Action<Avatar2D> finishCB)
    {
        LoadAvatar(assetPath, finishCB);
    }

    /// <summary>
    /// 需要加载avatar
    /// </summary>
    /// <param name="assetPath">SkeletonDataAsset的资源全路径</param>
    /// <param name="finishCB">完成回调</param>
    /// <returns></returns>
    private async void LoadAvatar(string assetPath, Action<Avatar2D> finishCB)
    {
        if (string.IsNullOrEmpty(assetPath))
        {
            MLog.Error(eLogTag.entity, "LoadAvatar assetPath is empty");
            return;
        }

        try
        {
            _loadAssetPath = assetPath;
            SkeletonDataAsset asset = await BasicModule.Asset.LoadAsset<SkeletonDataAsset>(assetPath, GetHashCode(), (int)eLoadPriority.Low);
            SkeletonAnimation animation = SkeletonAnimation.NewSkeletonAnimationGameObject(asset);
            _root = animation.gameObject;
            _root.transform.SetParent(transform, false);
            _root.name = "avatar2DLoaded";

            FindComponent();
            _isValid = _skeleton != null;

            finishCB(this);
        }
        catch (AssetLoadException e)
        {
            MLog.Error(eLogTag.asset, $"load 2d avatar asset error,path={assetPath} error={e}");
        }
    }

    /// <summary>
    /// 找到显示对象上的基础组件
    /// </summary>
    private void FindComponent()
    {
        _meshRenderer = _root.GetComponent<MeshRenderer>();
        _skeleton = _root.GetComponent<SkeletonAnimation>();
    }
}