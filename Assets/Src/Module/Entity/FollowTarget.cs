using UnityEngine;

/// <summary>
/// 跟随目标
/// </summary>
public class FollowTarget : TransformTarget
{
    [SerializeField]
    private Vector3 _offset = Vector3.up;

    /// <summary>
    /// 是否在目标的本地空间 例如一个宠物一直跟随主角 如果设置本地 主角旋转宠物位置也会变 如果不是本地 主角旋转宠物位移不变
    /// </summary>
    public bool IsLocalSpace = false;

    /// <summary>
    /// 跟随偏移量 配合是否本地坐标空间达到效果
    /// </summary>
    /// <value></value>
    public Vector3 Offset { get => _offset; set => _offset = value; }

    private void LateUpdate()
    {
        if (!TargetTsm)
        {
            return;
        }

        if (IsLocalSpace)
        {
            transform.position = TargetTsm.TransformPoint(Offset);
        }
        else
        {
            transform.position = TargetTsm.position + Offset;
        }
    }

    /// <summary>
    /// 设置目标后 往往需要自动设置一下偏移量 此时偏移量会参考是否设置本地空间
    /// </summary>
    protected override void OnSetTarget()
    {
        if (!TargetTsm)
        {
            return;
        }

        if (IsLocalSpace)
        {
            _offset = TargetTsm.InverseTransformPoint(transform.position);
        }
        else
        {
            _offset = transform.position - TargetTsm.position;
        }
    }
}