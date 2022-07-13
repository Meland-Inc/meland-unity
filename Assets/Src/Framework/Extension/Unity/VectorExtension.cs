using UnityEngine;

public static class VectorExtension
{
    /// <summary>
    /// 两个三维向量近似相等
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool ApproximatelyEquals(this Vector3 a, Vector3 b)
    {
        return a.x.ApproximatelyEquals(b.x) && a.y.ApproximatelyEquals(b.y) && a.z.ApproximatelyEquals(b.z);
    }
}