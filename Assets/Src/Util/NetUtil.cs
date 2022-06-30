using System;
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
    public static readonly float SVR_POS_2_CLIENT_POS_SCALE = 1 / 60f;
    /// <summary>
    /// 客户端坐标转服务器坐标转换系数
    /// </summary>
    public static readonly float CLIENT_POS_2_SVR_POS_SCALE = 1 / SVR_POS_2_CLIENT_POS_SCALE;
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
    /// 客户端坐标转服务器location
    /// </summary>
    /// <param name="clientPos"></param>
    /// <returns></returns>
    public static EntityLocation ClientPosToSvrLoc(Vector3 clientPos)
    {
        return new EntityLocation()
        {
            MapId = 0,
            Pos = new VectorXY()
            {
                X = (int)(clientPos.x * CLIENT_POS_2_SVR_POS_SCALE),
                Y = (int)(-clientPos.z * CLIENT_POS_2_SVR_POS_SCALE)
            },
            Z = (int)((clientPos.y * CLIENT_POS_2_SVR_POS_SCALE) + TERRAIN_OFFSET_Y),
            Zindex = 1
        };
    }

    /// <summary>
    /// 客户端位置转成服务器位置 返回结构使用的客户端结构 但是是服务器坐标系
    /// </summary>
    /// <param name="clientPos"></param>
    /// <returns></returns>
    public static Vector3 ClientPosToSvrPos(Vector3 clientPos)
    {
        return new Vector3()
        {
            x = (int)(clientPos.x * CLIENT_POS_2_SVR_POS_SCALE),
            y = (int)(-clientPos.z * CLIENT_POS_2_SVR_POS_SCALE),
            z = (int)((clientPos.y * CLIENT_POS_2_SVR_POS_SCALE) + TERRAIN_OFFSET_Y)
        };
    }

    /// <summary>
    /// 服务器方向向量转客户端
    /// </summary>
    /// <param name="xy"></param>
    /// <returns></returns>
    public static Vector3 SvrDirToClient(VectorXY xy)
    {
        return xy == null ? Vector3.back : SvrVectorXYToClient(xy);
    }

    /// <summary>
    /// 服务器XY二维转到客户端坐标
    /// </summary>
    /// <param name="xy"></param>
    /// <returns></returns>
    public static Vector3 SvrVectorXYToClient(VectorXY xy)
    {
        if (xy == null)
        {
            return Vector3.zero;
        }

        return new Vector3(xy.X, 0, -xy.Y) * SVR_POS_2_CLIENT_POS_SCALE;
    }

    /// <summary>
    /// 服务器的屏幕坐标系Y方向转客户端屏幕坐标系Y方向
    /// </summary>
    /// <param name="svrScreenY"></param>
    /// <returns></returns>
    public static float SvrScreenYToClient(float svrScreenY)
    {
        return GlobalDefine.IS_ADAPTIVE_OLD_DATA ? -svrScreenY : svrScreenY;
    }

    //将服务器rc转换成客户端坐标
    public static (float x, float z) RCToXZ(float r, float c)
    {
        if (GlobalDefine.IS_ADAPTIVE_OLD_DATA)
        {
            return (c, SvrScreenYToClient(r));
        }
        else
        {
            MLog.Error(eLogTag.map, "not support rc already");
            return (c, r);
        }
    }

    /// <summary>
    /// 将服务器RCIndex转换成客户端坐标
    /// </summary>
    /// <param name="rcIndex"></param>
    /// <returns></returns>
    public static (float x, float z) RCIndexToXZ(int rcIndex)
    {
        (int r, int c) = RCIndexToRC(rcIndex);
        return RCToXZ(r, c);
    }

    /// <summary>
    /// 将服务器RCIndex转换成RC
    /// </summary>
    /// <param name="rcIndex"></param>
    /// <returns></returns>
    public static (int r, int c) RCIndexToRC(int rcIndex)
    {
        int row = Mathf.FloorToInt(rcIndex / DataManager.Map.MapColTileNum) - DataManager.Map.MapOffsetRowTileNum;
        int col = (rcIndex % DataManager.Map.MapColTileNum) - DataManager.Map.MapOffsetCowTileNum;
        return (row, col);
    }

    //将服务器rc转换成客户端坐标key
    public static ulong RCToXZKey(float r, float c)
    {
        (float x, float z) = RCToXZ(r, c);
        return MathUtil.TwoIntToUlong((int)x, (int)z);
    }

    //将服务器rc转换成客户端坐标key
    public static ulong RCIndexToXZKey(int rcIndex)
    {
        (int r, int c) = RCIndexToRC(rcIndex);
        return RCToXZKey(r, c);
    }
}