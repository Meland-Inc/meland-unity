using UnityEngine;

/// <summary>
/// 全局基础模块
/// </summary>
public class BasicModule : MonoBehaviour
{
    /// <summary>
    /// 网络消息中心 业务层都使用这个模块派发消息
    /// </summary>
    public static NetMessageCenter NetMsgCenter;

    private void Start()
    {
        NetMsgCenter = UnityGameFramework.Runtime.GameEntry.GetComponent<NetMessageCenter>();
    }
}