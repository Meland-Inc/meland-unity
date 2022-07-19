using UnityEngine;

/// <summary>
/// 主角移动脚本 接受输入控制 以主相机为输入参照
/// </summary>
public class MainPlayerMoveInput : MonoBehaviour, IReqMoveInfo
{
    public Rigidbody RefRigid;
    public Vector3 PushDownForce = Vector3.down * 20f;//下压力 防止弹起
    /// <summary>
    /// 移动速度 u/s
    /// </summary>
    public float MoveSpeed = 5;
    private bool _isMoving;

    public float FinallyMoveSpeed => _isMoving ? MoveSpeed : 0;
    public Vector3 FinallyMoveDir => transform.forward;
    public MelandGame3.MovementType RoleSyncMovementType => _isMoving ? MelandGame3.MovementType.MovementTypeRun : MelandGame3.MovementType.MovementTypeIdle;

    [SerializeField] private Vector3 _roleCenterPoint = new(0, 0.5f, 0);
    public Vector3 RoleCenterPoint => _roleCenterPoint;

    private void FixedUpdate()
    {
        if (!Camera.main)
        {
            ChangeMoveStatus(false);
            return;
        }

        RefRigid.AddForce(PushDownForce, ForceMode.Force);//持续下压 否则在持续碰撞下会逐渐上移 暂时没有使用重力

        Transform cameraTsm = Camera.main.transform;

        Vector3 moveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            moveDir += -cameraTsm.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir += cameraTsm.right;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            Vector3 cameraHorizontalForward = new(cameraTsm.forward.x, 0, cameraTsm.forward.z);//相机在水平面上的前方
            cameraHorizontalForward.Normalize();
            if (Input.GetKey(KeyCode.W))
            {
                moveDir += cameraHorizontalForward;
            }
            else
            {
                moveDir += -cameraHorizontalForward;
            }
        }

        if (moveDir == Vector3.zero)
        {
            ChangeMoveStatus(false);
            return;
        }

        moveDir.Normalize();
        moveDir *= MoveSpeed * Time.fixedDeltaTime;
        RefRigid.MovePosition(transform.position + moveDir);
        transform.forward = moveDir;
        ChangeMoveStatus(true);
    }

    private void ChangeMoveStatus(bool moving)
    {
        if (_isMoving == moving)
        {
            return;
        }

        _isMoving = moving;

        //TODO:临时的切动画
        SceneEntity mainPlayer = SceneModule.EntityMgr.GetSceneEntity(DataManager.MainPlayer.RoleID);
        if (mainPlayer.Surface)
        {
            string animName = _isMoving ? EntityDefine.ANIM_NAME_RUN : EntityDefine.ANIM_NAME_IDLE;
            mainPlayer.Surface.GetComponent<IAnimationCpt>().PlayAnim(animName, true);
        }
    }
}