using System;
public static class MathExtension
{
    /// <summary>
    /// 近似相等另外一个float unity官方的Mathf.Approximately 不大可靠 有时对比精度超级高
    /// </summary>
    /// <param name="cur"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static bool ApproximatelyEquals(this float cur, float target)
    {
        return MathF.Abs(cur - target) < 0.0001;
    }
}