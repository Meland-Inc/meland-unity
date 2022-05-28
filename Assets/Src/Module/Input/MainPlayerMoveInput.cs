using UnityEngine;

/// <summary>
/// 主角移动脚本 接受输入控制 以主相机为输入参照
/// </summary>
public class MainPlayerMoveInput : MonoBehaviour
{
    /// <summary>
    /// 移动速度 u/s
    /// </summary>
    public float MoveSpeed = 5;

    private void Update()
    {
        if (!Camera.main)
        {
            return;
        }

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
        moveDir *= MoveSpeed * Time.deltaTime;
        transform.position = transform.position + moveDir;
        transform.forward = moveDir;
    }
}