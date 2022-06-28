using UnityEngine;

/// <summary>
/// 主角移动脚本 接受输入控制 以主相机为输入参照
/// </summary>
public class MainPlayerMoveInput : MonoBehaviour
{
    public Rigidbody RefRigid;
    public Vector3 PushDownForce = Vector3.down * 20f;//下压力 防止弹起
    /// <summary>
    /// 移动速度 u/s
    /// </summary>
    public float MoveSpeed = 5;

    private void FixedUpdate()
    {
        if (!Camera.main)
        {
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
            return;
        }

        moveDir.Normalize();
        moveDir *= MoveSpeed * Time.fixedDeltaTime;
        RefRigid.MovePosition(transform.position + moveDir);
        transform.forward = moveDir;
    }
}