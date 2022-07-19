using UnityEngine;

/// <summary>
/// 能够请求移动所需要的信息
/// </summary>
interface IReqMoveInfo
{
    /// <summary>
    /// 最终的移动速度 并不是角色本身的  可能有环境速度在里面
    /// </summary>
    /// <value></value>
    float FinallyMoveSpeed { get; }
    /// <summary>
    /// 最终的移动方向 并不是角色本身的  可能有环境速度在里面
    /// </summary>
    /// <value></value>
    Vector3 FinallyMoveDir { get; }
    /// <summary>
    /// 角色同步的移动状态类型
    /// </summary>
    /// <value></value>
    MelandGame3.MovementType RoleSyncMovementType { get; }
    /// <summary>
    /// 角色中心点 用来预判障碍使用
    /// </summary>
    /// <value></value>
    Vector3 RoleCenterPoint { get; }
}