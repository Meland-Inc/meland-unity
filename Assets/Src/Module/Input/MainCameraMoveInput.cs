using System;
using UnityEngine;

/// <summary>
/// 主相机上的移动输入
/// </summary>
[RequireComponent(typeof(FollowTarget))]
public class MainCameraMoveInput : MonoBehaviour
{
    public float HorizontalRotateSpeed = 60f;//水平面旋转速度 欧拉角/s
    public float VerticalRotateFactor = 10;//垂直旋转因子
    public float VerticalRotateSpeed = 60f;//垂直旋转速度 欧拉角/s
    public float CameraEulerXMax = 80;//相机最大欧拉角X
    public float CameraEulerXMin = 15;//相机最小欧拉角X
    public Vector3 RotateAnchorOffset = Vector3.zero;

    private FollowTarget _followLogic;
    private Vector3 _initEulerAngles;
    private Vector3 _initRelativePosition;
    private float _initTargetDistance = -1;
    private float _targetEulerX;
    private void Start()
    {
        _followLogic = GetComponent<FollowTarget>();
        _targetEulerX = transform.eulerAngles.x;

        if (_followLogic.TargetTsm)
        {
            _initEulerAngles = transform.eulerAngles;
            _initRelativePosition = transform.position - _followLogic.TargetTsm.position;
            _initTargetDistance = Vector3.Distance(transform.position, _followLogic.TargetTsm.position);
        }
    }

    private void Update()
    {
        if (!_followLogic || !_followLogic.TargetTsm)
        {
            return;
        }

        bool changed = false;
        if (InputHorizontalRotate())
        {
            changed = true;
        }
        if (InputVerticalRotate())
        {
            changed = true;
        }
        if (InputReset())
        {
            changed = true;
        }

        if (changed)
        {
            _followLogic.Offset = transform.position - _followLogic.TargetTsm.position;//修正跟随偏移值
        }
    }

    private bool InputHorizontalRotate()
    {
        Vector3 eulerOffset = Vector3.zero;
        if (Input.GetKey(KeyCode.Q))
        {
            eulerOffset += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            eulerOffset += new Vector3(0, -1, 0);
        }

        if (eulerOffset == Vector3.zero)
        {
            return false;
        }

        transform.RotateAround(_followLogic.TargetTsm.position + RotateAnchorOffset, Vector3.up, HorizontalRotateSpeed * eulerOffset.y * Time.deltaTime);
        return true;
    }

    private bool InputVerticalRotate()
    {
        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0)
        {
            scroll = scroll > 0 ? 1 : -1;
            _targetEulerX = Math.Clamp(_targetEulerX + (scroll * VerticalRotateFactor), CameraEulerXMin, CameraEulerXMax);
        }

        if (MathUtil.FloatEquals(transform.eulerAngles.x, _targetEulerX))
        {
            return false;
        }

        float deltaEulerX = _targetEulerX - transform.eulerAngles.x;
        if (deltaEulerX > 0)
        {
            deltaEulerX = Math.Min(deltaEulerX, VerticalRotateSpeed * Time.deltaTime);
        }
        else
        {
            deltaEulerX = Math.Max(deltaEulerX, -VerticalRotateSpeed * Time.deltaTime);
        }

        transform.RotateAround(_followLogic.TargetTsm.position + RotateAnchorOffset, _followLogic.TargetTsm.right, deltaEulerX);

        if (_initTargetDistance > 0)//有成功初始化过
        {
            Vector3 dir = transform.position - _followLogic.TargetTsm.position;
            dir.Normalize();
            dir *= _initTargetDistance / _initEulerAngles.x * transform.eulerAngles.x;
            transform.position = _followLogic.TargetTsm.position + dir;
        }

        return true;
    }

    private bool InputReset()
    {
        if (_initEulerAngles == null)
        {
            return false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.eulerAngles = _initEulerAngles;
            transform.position = _followLogic.TargetTsm.position + _initRelativePosition;
            _targetEulerX = transform.eulerAngles.x;
            return true;
        }

        return false;
    }
}