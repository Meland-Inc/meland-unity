using UnityEngine;
using Bian;

/// <summary>
/// 处理网络数据转换的工具类
/// </summary>
public static class NetUtil
{
    /// <summary>
    /// 服务器坐标到客户端坐标转换系数
    /// </summary>
    public static readonly float SVR_POS_2_CLIENT_POS_SCALE = 1 / 12f;
    /// <summary>
    /// 老数据中地表抬高的高度
    /// </summary>
    public static readonly float TERRAIN_OFFSET_Y = 75f;

    /// <summary>
    /// 服务器 location 转客户端坐标
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    public static Vector3 SvrLocToClient(EntityLocation location)
    {
        return new Vector3(location.Pos.X, location.Z - TERRAIN_OFFSET_Y, -location.Pos.Y) * SVR_POS_2_CLIENT_POS_SCALE;
    }

    /// <summary>
    /// 服务器XY二维转到客户端坐标
    /// </summary>
    /// <param name="xy"></param>
    /// <returns></returns>
    public static Vector3 SvrVectorXYToClient(VectorXY xy)
    {
        return new Vector3(xy.X, 0, -xy.Y) * SVR_POS_2_CLIENT_POS_SCALE;
    }
}