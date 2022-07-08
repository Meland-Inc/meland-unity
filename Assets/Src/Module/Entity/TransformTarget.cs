using UnityEngine;

/// <summary>
/// 相对目标做一些变换
/// </summary>
public class TransformTarget : MonoBehaviour
{
    [SerializeField]
    private Transform _targetTsm;
    public Transform TargetTsm => _targetTsm;

    public void SetTargetTsm(Transform target)
    {
        _targetTsm = target;

        OnSetTarget();
    }

    /// <summary>
    /// 设置了目标后行为可能需要一些初始化
    /// </summary>
    protected virtual void OnSetTarget()
    {
    }
}