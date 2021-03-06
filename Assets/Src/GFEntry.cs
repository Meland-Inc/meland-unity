//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// Game Framework 入口  使用game framework组件时直接使用这里变量 不要再去GameEntry.GetComponent 有性能问题
/// 使用其中组件不要在其他基础组件的start中或者之前时序中使用 因为其中组件在start中初始化
/// </summary>
public class GFEntry : MonoBehaviour
{
    /// <summary>
    /// 获取游戏基础组件。
    /// </summary>
    public static BaseComponent Base
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取配置组件。
    /// </summary>
    public static ConfigComponent Config
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取数据结点组件。
    /// </summary>
    public static DataNodeComponent DataNode
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取数据表组件。
    /// </summary>
    public static DataTableComponent DataTable
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取调试组件。
    /// </summary>
    public static DebuggerComponent Debugger
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取下载组件。
    /// </summary>
    public static DownloadComponent Download
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取实体组件。
    /// </summary>
    public static EntityComponent Entity
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取事件组件。
    /// </summary>
    public static EventComponent Event
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取文件系统组件。
    /// </summary>
    public static FileSystemComponent FileSystem
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取有限状态机组件。
    /// </summary>
    public static FsmComponent Fsm
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取本地化组件。
    /// </summary>
    public static LocalizationComponent Localization
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取网络组件。 业务层使用NetMessageCenter不用这个
    /// </summary>
    public static NetworkComponent Network
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取对象池组件。
    /// </summary>
    public static ObjectPoolComponent ObjectPool
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取流程组件。
    /// </summary>
    public static ProcedureComponent Procedure
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取场景组件。
    /// </summary>
    public static SceneComponent Scene
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取配置组件。
    /// </summary>
    public static SettingComponent Setting
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取声音组件。
    /// </summary>
    public static SoundComponent Sound
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取界面组件。
    /// </summary>
    public static UIComponent UI
    {
        get;
        private set;
    }

    /// <summary>
    /// 获取网络组件。
    /// </summary>
    public static WebRequestComponent WebRequest
    {
        get;
        private set;
    }

    private void Start()
    {
        InitBuiltinComponents();
    }

    private void InitBuiltinComponents()
    {
        Base = GameEntry.GetComponent<BaseComponent>();
        Config = GameEntry.GetComponent<ConfigComponent>();
        DataNode = GameEntry.GetComponent<DataNodeComponent>();
        DataTable = GameEntry.GetComponent<DataTableComponent>();
        Debugger = GameEntry.GetComponent<DebuggerComponent>();
        Download = GameEntry.GetComponent<DownloadComponent>();
        Entity = GameEntry.GetComponent<EntityComponent>();
        Event = GameEntry.GetComponent<EventComponent>();
        FileSystem = GameEntry.GetComponent<FileSystemComponent>();
        Fsm = GameEntry.GetComponent<FsmComponent>();
        Localization = GameEntry.GetComponent<LocalizationComponent>();
        Network = GameEntry.GetComponent<NetworkComponent>();
        ObjectPool = GameEntry.GetComponent<ObjectPoolComponent>();
        Scene = GameEntry.GetComponent<SceneComponent>();
        Setting = GameEntry.GetComponent<SettingComponent>();
        Sound = GameEntry.GetComponent<SoundComponent>();
        UI = GameEntry.GetComponent<UIComponent>();
        WebRequest = GameEntry.GetComponent<WebRequestComponent>();

        Procedure = GameEntry.GetComponent<ProcedureComponent>();

        //会自动开始默认初始流程 逻辑转入初始流程 LaunchProcedure
    }
}
