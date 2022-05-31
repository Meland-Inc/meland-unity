using UnityEngine;

/// <summary>
/// 环绕看向 会根据自己朝向来调整位置 保证不管什么角度都是看向目标 且距离不变 比如摄像机朝向主角后的旋转
/// </summary>
[RequireComponent(typeof(FollowTarget))]
public class AroundLookAt : MonoBehaviour
{
    private Vector3 _lastRecordEulerAngles = Vector3.one * float.MinValue;//给个初始极端值 为了触发第一次
    private FollowTarget _refFollowLogic;

    private void Awake()
    {
        _refFollowLogic = GetComponent<FollowTarget>();
    }

    private void LateUpdate()
    {
        if (_refFollowLogic.TargetTsm == null)
        {
            return;
        }

        Vector3 angles = transform.eulerAngles;
        if (Mathf.Approximately(_lastRecordEulerAngles.x, angles.x) && Mathf.Approximately(_lastRecordEulerAngles.y, angles.y) && Mathf.Approximately(_lastRecordEulerAngles.z, angles.z))
        {
            return;
        }

        _lastRecordEulerAngles = angles;

        Vector3 newFollowPos = -_refFollowLogic.FollowDistance * transform.forward.normalized;
        _refFollowLogic.Offset = newFollowPos;
    }
}