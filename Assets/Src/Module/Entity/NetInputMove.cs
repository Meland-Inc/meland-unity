using UnityEngine;
using Bian;

/// <summary>
/// 网络输入移动
/// </summary>
public class NetInputMove : MonoBehaviour
{
    /// <summary>
    /// 强制设置到某个位置
    /// </summary>
    /// <param name="location"></param>
    /// <param name="dir">朝向向量 绕Y轴旋转的朝向</param>
    public void ForcePosition(EntityLocation location, VectorXY dir)
    {
        transform.position = NetUtil.SvrLocToClient(location);
        transform.forward = NetUtil.SvrDirToClient(dir);
    }
}