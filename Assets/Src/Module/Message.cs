using System;
using MelandGame3;

public static class Message
{
    #region  地图场景

    /// <summary>
    /// 游戏主场景改变了 切场景过程中会先改变到none状态 也会发这个消息
    /// </summary>
    public static Action<eSceneName> GameMainSceneChanged = delegate { };
    /// <summary>
    /// 回复了地图进入成功
    /// </summary>
    public static Action<EnterMapResponse> RspMapEnterFinish = delegate { };

    #endregion

    #region  runtime

    public static Action<bool> WebReady = delegate { };
    public static Action<string> RuntimeMessageEmitted = delegate { };

    public static Action<Runtime.TUserAssetResponse> RuntimeUserAssetUpdate = delegate { };

    #endregion

    #region 实体

    /// <summary>
    /// 主角初始化好了
    /// </summary>
    public static Action MainPlayerRoleInitFinish = delegate { };
    /// <summary>
    /// 场景实体加载完成
    /// </summary>
    public static Action SceneEntityLoadFinish = delegate { };

    #endregion

    #region 领地
    public static Action<TerritoryGridData> UpdateTerritoryGridData = delegate { };
    public static Action<List<ulong>, List<ulong>> UpdateTerritoryGridDataList = delegate { };
    public static Action<string> UpdateTerritoryPlayerAreaData = delegate { };
    public static Action<eTerritoryBorderRenderMode> UpdateTerritoryBorderRenderMode = delegate { };
    #endregion

    #region 角色
    /// <summary>
    /// 角色属性更新
    /// </summary>
    public static Action<EntityProfileField> RoleProfileUpdated = delegate { };
    #endregion
}