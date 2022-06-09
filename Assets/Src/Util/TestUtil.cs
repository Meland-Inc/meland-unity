
using UnityEngine;

/// <summary>
/// 测试工具
/// </summary>
public static class TestUtil
{
    /// <summary>
    /// 画一个场景矩形 场景矩形中都是场景坐标
    /// </summary>
    /// <param name="sceneRect"></param>
    public static void GizmosDrawSceneRect(Rect sceneRect, Color color)
    {
        Color old = Gizmos.color;
        Gizmos.color = color;
        Gizmos.DrawLine(new Vector3(sceneRect.xMin, 0, sceneRect.yMin), new Vector3(sceneRect.xMax, 0, sceneRect.yMin));
        Gizmos.DrawLine(new Vector3(sceneRect.xMax, 0, sceneRect.yMin), new Vector3(sceneRect.xMax, 0, sceneRect.yMax));
        Gizmos.DrawLine(new Vector3(sceneRect.xMax, 0, sceneRect.yMax), new Vector3(sceneRect.xMin, 0, sceneRect.yMax));
        Gizmos.DrawLine(new Vector3(sceneRect.xMin, 0, sceneRect.yMax), new Vector3(sceneRect.xMin, 0, sceneRect.yMin));
        Gizmos.color = old;
    }
}