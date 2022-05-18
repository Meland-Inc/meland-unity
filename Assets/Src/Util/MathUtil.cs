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
}