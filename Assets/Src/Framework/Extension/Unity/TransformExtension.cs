using UnityEngine;

public static class TransformExtension
{
    /// <summary>
    /// 创建一个相对位置0的子节点
    /// </summary>
    /// <param name="name">子节点名字 给空时使用系统的名字</param>
    /// <returns></returns>
    public static Transform CreateChildNode(this Transform cur, string name)
    {
        Transform child = (string.IsNullOrEmpty(name) ? new GameObject() : new GameObject(name)).transform;
        child.SetParent(cur, false);
        return child;
    }
}