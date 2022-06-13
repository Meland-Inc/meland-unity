using System;
using UnityEngine;

/// <summary>
/// 自定义的一些数学工具
/// </summary>
public static class MathUtil
{
    /// <summary>
    /// 两个int转成一个ulong 方便将二维坐标转成一个key 类似对之前egret中的r_c的字符串优化
    /// </summary>
    public static ulong TwoIntToUlong(int a, int b)
    {
        return ((ulong)a << 32) | (uint)b;
    }

    /// <summary>
    /// 二维转的key还原回之前的二维坐标
    /// </summary>
    public static (int a, int b) UlongToTwoInt(ulong value)
    {
        return ((int)(value >> 32), (int)value);
    }

    /// <summary>
    /// 和地面交点
    /// </summary>
    /// <param name="plane">地面高</param>
    /// <returns></returns>
    public static Vector3 GetPlaneInteractivePoint(Ray ray, float plane = 0)
    {
        Vector3 dir = ray.direction;

        if (Mathf.Approximately(dir.y, 0))
        {
            return Vector3.zero;
        }

        float num = (plane - ray.origin.y) / dir.y;
        return ray.origin + (ray.direction * num);
    }
}