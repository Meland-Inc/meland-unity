using UnityEngine;

/// <summary>
/// 场景中为纸片渲染添加特性 这里是管理所有纸片渲染的总入口 需要做到程序动态添加和场景美术添加兼容
/// </summary>
public class PaperRender : MonoBehaviour
{
    /// <summary>
    /// 朝向相机
    /// </summary>
    public bool LookCamera = true;
    /// <summary>
    /// 场景预览下自动找相机 往往美术为了预览会提前设置好 如果需要程序控制时 可以在start之前禁用掉即可 之后更加没关系 直接赋值操作
    /// </summary>
    public bool PreviewAutoFindCamera = true;
    /// <summary>
    /// 是否是水平地板纸片
    /// </summary>
    public bool IsHorizontalPaper = false;
    /// <summary>
    /// 是否是spine2d动画
    /// </summary>
    public bool IsSpine2D = false;

    private CameraSameDirection _cameraSameDirection;

    private void Awake()
    {
        if (!IsHorizontalPaper && LookCamera)
        {
            _cameraSameDirection = gameObject.AddComponent<CameraSameDirection>();
        }
    }

    private void OnDestroy()
    {
        if (_cameraSameDirection != null)
        {
            Destroy(_cameraSameDirection);
            _cameraSameDirection = null;
        }
    }

    private void Start()
    {
        if (PreviewAutoFindCamera && _cameraSameDirection != null)
        {
            if (Camera.main != null)
            {
                _cameraSameDirection.SetTargetTsm(Camera.main.transform);
            }
        }
    }

    /// <summary>
    /// 手动设置看向的目标相机
    /// </summary>
    /// <param name="camera"></param>
    public void SetLookedTargetCamera(Camera camera)
    {
        if (_cameraSameDirection == null || camera == null)
        {
            return;
        }

        _cameraSameDirection.SetTargetTsm(camera.transform);
    }
}