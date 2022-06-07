using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 全局基础模块 使用其中组件不要在其他基础组件的start中或者之前时序中使用 因为其中组件在start中初始化
/// </summary>
[DisallowMultipleComponent]
public class BasicModule : MonoBehaviour
{
    /// <summary>
    /// 网络消息中心 业务层都使用这个模块派发消息
    /// </summary>
    public static NetMessageCenter NetMsgCenter;
    public static UICenter UICenter;
    public static LoginCenter LoginCenter;
    /// <summary>
    /// 资源加载器
    /// </summary>
    public static AssetLoader Asset;

    public static RuntimeGameCenter RuntimeGameCenter;

    private void Start()
    {
        NetMsgCenter = GameEntry.GetComponent<NetMessageCenter>();
        UICenter = GameEntry.GetComponent<UICenter>();
        LoginCenter = GameEntry.GetComponent<LoginCenter>();
        RuntimeGameCenter = GameEntry.GetComponent<RuntimeGameCenter>();
        Asset = GameEntry.GetComponent<AssetLoader>();
    }
}