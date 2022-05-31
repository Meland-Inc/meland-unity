using UnityEngine;
using DG.Tweening;

/// <summary>
/// 主相机上的移动输入
/// </summary>
[RequireComponent(typeof(FollowTarget))]
public class MainCameraMoveInput : MonoBehaviour
{
    public Vector3 HorizontalRotateOffset = new(0, 30f, 0);//水平旋转偏移 欧拉角
    public Ease HorizontalRotateEase = Ease.OutQuad;//水平旋转缓动
    public float HorizontalRotateTweenTime = 0.3f;//水平旋转缓动时间


    public float VerticalRotateMaxAngles = 60f;
    public float VerticalRotateMaxDistance = 25f;
    public float VerticalRotateMinAngles = 30f;
    public float VerticalRotateMinDistance = 12f;
    public Vector3 VerticalRotateOffset = new(5f, 0, 0);//水平旋转偏移 欧拉角
    public Ease VerticalRotateEase = Ease.OutQuad;//水平旋转缓动
    public float VerticalRotateTweenTime = 0.3f;//水平旋转缓动时间

    private FollowTarget _followLogic;
    private int _isRotateTweening = 0;//是否正在旋转缓动中 -1代表在水平旋转 1代表在垂直旋转

    private void Start()
    {
        _followLogic = GetComponent<FollowTarget>();

        Message.MainPlayerRoleInitFinish += OnMainPlayerRoleInitFinish;
    }

    private void OnDestroy()
    {
        Message.MainPlayerRoleInitFinish -= OnMainPlayerRoleInitFinish;
    }

    private void OnMainPlayerRoleInitFinish()
    {
        SceneEntity mainRole = DataManager.MainPlayer.Role;
        transform.position = mainRole.Transform.position + SceneDefine.MainCameraInitFollowMainRoleOffset;
        GetComponent<FollowTarget>().SetTargetTsm(mainRole.Transform);
    }

    private void Update()
    {
        if (!_followLogic || !_followLogic.TargetTsm)
        {
            return;
        }

        bool changed = InputVerticalRotate();

        if (!changed)
        {
            _ = InputHorizontalRotate();
        }
    }

    private bool InputHorizontalRotate()
    {
        if (_isRotateTweening is not 0 and > 0)
        {
            return false;
        }

        int dir = 0;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            dir = 1;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            dir = -1;
        }

        if (dir == 0)
        {
            return false;
        }

        _isRotateTweening = -1;
        _ = transform.DORotate(transform.eulerAngles + (dir * HorizontalRotateOffset), HorizontalRotateTweenTime, RotateMode.Fast).SetEase(HorizontalRotateEase).OnComplete(() =>
        {
            _isRotateTweening = 0;
        });

        return true;
    }

    private bool InputVerticalRotate()
    {
        if (_isRotateTweening is not 0 and < 0)
        {
            return false;
        }

        float scroll = Input.mouseScrollDelta.y;

        if (Mathf.Approximately(scroll, 0f))
        {
            return false;
        }
        scroll = scroll > 0 ? 1 : -1;

        float eulerX = Mathf.Clamp(transform.eulerAngles.x + (scroll * VerticalRotateOffset.x), VerticalRotateMinAngles, VerticalRotateMaxAngles);
        _isRotateTweening = 1;
        _ = transform.DORotate(new Vector3(eulerX, transform.eulerAngles.y, transform.eulerAngles.z), VerticalRotateTweenTime, RotateMode.Fast).SetEase(VerticalRotateEase).OnUpdate(() =>
        {
            float curEulerX = transform.eulerAngles.x;
            float curDistance = Mathf.Lerp(VerticalRotateMinDistance, VerticalRotateMaxDistance, (curEulerX - VerticalRotateMinAngles) / (VerticalRotateMaxAngles - VerticalRotateMinAngles));
            _followLogic.FollowDistance = curDistance;
        }).OnComplete(() =>
        {
            _isRotateTweening = 0;
        });
        return true;
    }
}