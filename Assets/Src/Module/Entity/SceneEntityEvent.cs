using System;
/// <summary>
/// 客户端实体事件组件
/// </summary>
public class SceneEntityEvent : EntityEvent
{
    /// <summary>
    /// 战斗数据初始化好了
    /// </summary>
    public Action<EntityBattleData> BattleDataInited;
    /// <summary>
    /// 当前血量变化了
    /// </summary>
    public Action<int> HpUpated;
    /// <summary>
    /// 当期最大血量变化了
    /// </summary>
    public Action<int> HpMaxUpdated;
}