using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 场景渲染管理
/// </summary>
[DisallowMultipleComponent]
public class SceneRender : SceneModuleBase
{
    /// <summary>
    /// 场景根节点
    /// </summary>
    public Transform Root { get; private set; }

    //根节点的分组 和显示遮挡层级无关 只是逻辑上的分组和控制
    private readonly Dictionary<eSceneGroup, Transform> _groupMap = new();

    private void Awake()
    {
        Root = new GameObject("Scene").transform;
        foreach (eSceneGroup group in Enum.GetValues(typeof(eSceneGroup)))
        {
            _groupMap.Add(group, Root.gameObject.CreateChildNode(group.ToString()).transform);
        }
    }

    /// <summary>
    /// 获取场景渲染根组 不要拿到后给它添加子节点 需要添加的话走统一的添加子节点方法AddToGroup
    /// </summary>
    /// <param name="group"></param>
    /// <returns></returns>
    public Transform GetGroup(eSceneGroup group)
    {
        if (!_groupMap.TryGetValue(group, out Transform groupNode))
        {
            MLog.Error(eLogTag.scene, "Scene render get group can not find group.");
            return null;
        }

        return groupNode;
    }

    /// <summary>
    /// 添加某个变换到根组
    /// </summary>
    /// <param name="target"></param>
    /// <param name="group"></param>
    public void AddToGroup(Transform target, eSceneGroup group)
    {
        if (!_groupMap.TryGetValue(group, out Transform groupRoot))
        {
            MLog.Error(eLogTag.scene, "Scene render can not find group.");
            return;
        }

        target.SetParent(groupRoot);
    }

    /// <summary>
    /// 从根组移除变换统一接口 方便管理 不会验证合法性 自定义的其他子组不要走这里 这里只是和上面AddToGroup对应的
    /// </summary>
    /// <param name="target"></param>
    public void RemoveFromGroup(Transform target)
    {
        target.SetParent(null);
    }

    /// <summary>
    /// 场景渲染任意节点下添加组节点 统一方法 添加具体实体什么的不用走这里
    /// </summary>
    /// <param name="name"></param>
    /// <param name="parentNode"></param>
    /// <returns></returns>
    public Transform AddCustomGroupNode(string name, Transform parentNode)
    {
        return parentNode.gameObject.CreateChildNode(name).transform;
    }

    /// <summary>
    /// 移除自定义的组节点 不会验证合法性 只是和AddCustomGroupNode对应而已
    /// </summary>
    /// <param name="target"></param>
    public void RemoveCustomGroupNode(Transform target)
    {
        target.SetParent(null);
    }
}

/// <summary>
/// 场景渲染的根分组
/// </summary>
public enum eSceneGroup : uint
{
    other = 0,
    playerRole = 1 << 0,
    /// <summary>
    /// 场景物件
    /// </summary>
    element = 1 << 1,
    /// <summary>
    /// 中立角色
    /// </summary>
    neutralRole = 1 << 2,
    /// <summary>
    /// 战斗角色
    /// </summary>
    fightRole = 1 << 3,
    /// <summary>
    /// 地表
    /// </summary>
    terrain = 1 << 4,
}