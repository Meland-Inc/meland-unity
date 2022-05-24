using System;
/// <summary>
/// 自定义的一些数学工具
/// </summary>
public static class MathUtil
{
    /// <summary>
    /// 判断两个float相等
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool FloatEquals(float a, float b)
    {
        return Math.Abs(a - b) < 0.0001f;
    }

    /// <summary>
    /// 两个int转成一个ulong 方便将二维坐标转成一个key 类似对之前egret中的r_c的字符串优化
    /// </summary>
    public static ulong TwoIntToUlong(int x, int y)
    {
        return ((ulong)x << 32) | (uint)y;
    }

    /// <summary>
    /// 二维转的key还原回之前的二维坐标
    /// </summary>
    public static (int x, int y) UlongToTwoInt(ulong value)
    {
        return ((int)(value >> 32), (int)value);
    }
}