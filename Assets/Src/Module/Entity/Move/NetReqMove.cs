using UnityEngine;

/// <summary>
/// 请求网络移动 会自动监听移动状态进行同步请求
/// </summary>
public class NetReqMove : MonoBehaviour
{
    public float MaxSyncIntervalTime = 0.5f;
    private IReqMoveInfo _refReqMoveInfo;

    private float _lastReqTime = 0;

    private float _lastSpeed;
    private Vector3 _lastDir;
    private MelandGame3.MovementType _lastMovementType;

    private void Start()
    {
        if (!TryGetComponent<IReqMoveInfo>(out _refReqMoveInfo))
        {
            enabled = false;
            return;
        }
    }

    private void LateUpdate()
    {
        bool changed = false;
        changed = changed || !_lastSpeed.ApproximatelyEquals(_refReqMoveInfo.FinallyMoveSpeed);
        changed = changed || !_lastDir.ApproximatelyEquals(_refReqMoveInfo.FinallyMoveDir);
        changed = changed || _lastMovementType != _refReqMoveInfo.RoleSyncMovementType;

        if (changed)
        {
            ReqSyncMove();
        }
        else
        {
            //有移动速度时 即使走直线没任何变化也需要间隔请求
            if (!_lastSpeed.ApproximatelyEquals(0))
            {
                if (Time.realtimeSinceStartup - _lastReqTime > MaxSyncIntervalTime)
                {
                    ReqSyncMove();
                }
            }
        }
    }

    private void ReqSyncMove()
    {
        _lastReqTime = Time.realtimeSinceStartup;
        _lastSpeed = _refReqMoveInfo.FinallyMoveSpeed;
        _lastDir = _refReqMoveInfo.FinallyMoveDir;
        _lastMovementType = _refReqMoveInfo.RoleSyncMovementType;

        UpdateSelfLocationAction.Req(transform.position, _lastDir, _lastMovementType, _lastSpeed, DetectTargetTime());
    }

    /// <summary>
    /// 检测目标移动时间
    /// </summary>
    /// <returns></returns>
    private float DetectTargetTime()
    {
        //速度为0 没有目标位置
        if (_lastSpeed.ApproximatelyEquals(0))
        {
            return 0;
        }

        float maxTargetTime = MaxSyncIntervalTime * 1.5f;
        float maxDistance = maxTargetTime * _lastSpeed;
        //前方有障碍
        if (Physics.Raycast(transform.position + _refReqMoveInfo.RoleCenterPoint, _lastDir, out RaycastHit hitPoint, maxDistance))
        {
            float hitDistance = Vector3.Distance(transform.position, hitPoint.point);
            return hitDistance / maxDistance * maxTargetTime;
        }
        else
        {
            return maxTargetTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        float targetTime = DetectTargetTime();
        if (targetTime.ApproximatelyEquals(0))
        {
            return;
        }

        Vector3 targetPos = transform.position + targetTime * _lastSpeed * _lastDir.normalized;
        Color oldColor = Gizmos.color;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, targetPos);
        Gizmos.DrawSphere(targetPos, 0.3f);
        Gizmos.color = oldColor;
    }
}