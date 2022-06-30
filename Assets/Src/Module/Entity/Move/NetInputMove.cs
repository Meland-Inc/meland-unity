using UnityEngine;
using MelandGame3;
using DG.Tweening;

/// <summary>
/// 网络输入移动
/// </summary>
public class NetInputMove : MonoBehaviour
{
    private const float MAX_ALLOW_POSITION_OFFSET = 0.5f;//最大运行位置偏差距离 否则会强拉

    private MovementType _curMoveType = MovementType.MovementTypeUnknown;

#if UNITY_EDITOR
    private UnityEngine.Vector3 _svrCurPos;
    private UnityEngine.Vector3 _svrDestPos;
#endif

    /// <summary>
    /// 强制设置到某个位置
    /// </summary>
    /// <param name="location"></param>
    /// <param name="dir">朝向向量 绕Y轴旋转的朝向</param>
    public void ForcePosition(EntityLocation location, MelandGame3.Vector3 dir)
    {
        transform.position = NetUtil.SvrToClientLoc(location);
        transform.forward = NetUtil.SvrToClientDir(dir);
    }

    public void ReceiveMoveStep(EntityMoveStep cur, EntityMoveStep dest, MovementType moveType, MelandGame3.Vector3 dir)
    {
        transform.forward = NetUtil.SvrToClientDir(dir);
        ChangeMoveType(moveType);

        //超过当前坐标判定误差阈值 直接强拉
        UnityEngine.Vector3 svrCur = NetUtil.SvrToClientVector3(cur.Location.Loc);
        if (UnityEngine.Vector3.Distance(svrCur, transform.position) >= MAX_ALLOW_POSITION_OFFSET)
        {
            transform.position = svrCur;
        }

        UnityEngine.Vector3 svrDest = dest == null ? default : NetUtil.SvrToClientVector3(dest.Location.Loc);
        if (svrDest == default)
        {
            _ = transform.DOKill();
        }
        else
        {
            float duration = (dest.Stamp - cur.Stamp) * TimeDefine.MS_2_S;
            _ = transform.DOMove(svrDest, duration);
        }


#if UNITY_EDITOR
        _svrCurPos = svrCur;
        _svrDestPos = svrDest;
#endif

    }

    private void ChangeMoveType(MovementType moveType)
    {
        if (_curMoveType == moveType)
        {
            return;
        }

        _curMoveType = moveType;
        //TODO:临时的切动画
    }

#if UNITY_EDITOR
    /// <summary>
    /// 开启开关后 画出所有网络同步对象的上一次包状态
    /// </summary>
    private void OnDrawGizmos()
    {
        if (!TestUtil.ShowMoveDebug)
        {
            return;
        }

        Color oldColor = Gizmos.color;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(_svrCurPos, 0.1f);
        if (_svrDestPos != default)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_svrCurPos, _svrDestPos);
            Gizmos.DrawSphere(_svrDestPos, 0.1f);
        }

        Gizmos.color = oldColor;
    }
#endif

}