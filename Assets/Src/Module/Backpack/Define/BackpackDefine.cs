public static class BackpackDefine
{
    /// <summary>
    /// 背包UI标签
    /// </summary>
    public enum eItemUIType
    {
        All,
        Equipment,//装备类型
        Consumable,//消耗品类型
        Material,//材料类型
        Wearable,//饰品类型
        Placeable,//可放置类型
        ThirdParty,//第三方类型
        Unknown,//未知类型
    }

    public enum eNftItemSortPriority
    {
        Equipment,
        Consumable,
        Material,
        Wearable,
        Placeable,
        ThirdParty,
        Unknown = 9999,
    }
}
