using UnityEngine;

/// <summary>
/// 和目标朝向一致 如果camera无法看到时节省性能的话请使用 CameraSameDirection
/// </summary>
public class TargetSameDirection : TransformTarget
{
    /// <summary>
    /// 启动旋转镜像
    /// 不启动时图像正方向永远不变
    /// 启动时图像正方向随着上层真实朝向自动调整，比如角色移动需要正确方向翻转
    /// </summary>
    public bool EnableRotationMirror = false;

    private void LateUpdate()
    {
        if (!TargetTsm)
        {
            return;
        }

        transform.forward = TargetTsm.forward;

        if (EnableRotationMirror)
        {
            if (!transform.localEulerAngles.y.ApproximatelyEquals(0) && !transform.localEulerAngles.y.ApproximatelyEquals(180))
            {
                float scaleX = transform.localEulerAngles.y is > 180 and < 360 ? 1 : -1;
                transform.localScale = new Vector3(scaleX, 1, 1);
            }
        }
    }
}