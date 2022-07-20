using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 处理网络数据转换的工具类
/// </summary>
public static class NetUtil
{
    /// <summary>
    /// 服务器 location 转客户端坐标
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    public static Vector3 SvrToClientLoc(MelandGame3.EntityLocation location)
    {
        return new Vector3(location.Loc.X, location.Loc.Y, location.Loc.Z);
    }

    /// <summary>
    /// 客户端坐标转服务器location
    /// </summary>
    /// <param name="clientPos"></param>
    /// <returns></returns>
    public static MelandGame3.EntityLocation ClientToSvrLoc(Vector3 clientPos)
    {
        return new MelandGame3.EntityLocation()
        {
            MapId = 0,
            Loc = ClienToSvrVector3(clientPos)
        };
    }

    /// <summary>
    /// 客户端坐标转成服务器坐标
    /// </summary>
    /// <param name="clientVector3"></param>
    /// <returns></returns>
    public static MelandGame3.Vector3 ClienToSvrVector3(Vector3 clientVector3)
    {
        return new MelandGame3.Vector3()
        {
            X = clientVector3.x,
            Y = clientVector3.y,
            Z = clientVector3.z
        };
    }

    /// <summary>
    /// 服务器坐标转客户端
    /// </summary>
    /// <param name="svrVector3"></param>
    /// <returns></returns>
    public static Vector3 SvrToClientVector3(MelandGame3.Vector3 svrVector3)
    {
        return svrVector3 == null
        ? Vector3.zero
        : new Vector3(svrVector3.X, svrVector3.Y, svrVector3.Z);
    }

    /// <summary>
    /// 服务器方向向量转客户端 返回必不为空或者长度为0
    /// </summary>
    /// <param name="svrDir"></param>
    /// <returns></returns>
    public static Vector3 SvrToClientDir(MelandGame3.Vector3 svrDir)
    {
        if (svrDir == null)
        {
            return Vector3.back;
        }

        if (svrDir.X.ApproximatelyEquals(0) && svrDir.Y.ApproximatelyEquals(0) && svrDir.Z.ApproximatelyEquals(0))
        {
            return Vector3.back;
        }

        return SvrToClientVector3(svrDir);
    }

    /// <summary>
    /// 客户端方向向量转服务器
    /// </summary>
    /// <param name="clientDir"></param>
    /// <returns></returns>
    public static MelandGame3.Vector3 ClientToSvrDir(Vector3 clientDir)
    {
        return clientDir == null
            ? new MelandGame3.Vector3()
            {
                X = 0,
                Y = 0,
                Z = -1
            }
            : ClienToSvrVector3(clientDir);
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

    /// <summary>
    /// 服务器角色外观数据转客户端列表
    /// </summary>
    /// <param name="feature"></param>
    /// <returns></returns>
    public static List<int> SvrToClientRoleFeature(MelandGame3.PlayerFeature feature)
    {
        return new List<int>()
        {
            feature.Hair,
            feature.Face,
            feature.Clothes,
            feature.Pants,
            feature.Glove,
            feature.Shoes,
        };
    }

    public static eEntityType SvrEntityType2Client(MelandGame3.EntityType type)
    {
        return type switch
        {
            MelandGame3.EntityType.EntityTypePlayer => eEntityType.player,
            MelandGame3.EntityType.EntityTypeMonster => eEntityType.monster,
            _ => eEntityType.unknown,
        };
    }
}