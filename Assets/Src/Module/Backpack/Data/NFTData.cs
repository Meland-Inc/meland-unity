/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: NFT数据
 * @Date: 2022-06-16 15:21:19
 * @FilePath: /Assets/Src/Module/Backpack/Data/NFTData.cs
 */
using System;
namespace NFT
{

    [Serializable]
    public struct NFTData
    {
        public bool isMelandAI;
        public string itemId;
        public string network;
        public string id;
        public string tokenId;
        public string address;
        public int amount;
        public string tokenURL;
        public NFTMetadata metadata;
    }

    [Serializable]
    public struct NFTMetadata
    {
        public string name;
        public string description;
        public string image;
        public string image_url;
        public string image_data;
        public string animation_url;
        public NFTAttribute[] attributes;
    }

    [Serializable]
    public struct NFTAttribute
    {
        public string display_type;
        public string trait_type;
        public string value;
    }

    public enum eNFTQuality
    {
        Basic,
        Enhanced,
        Advanced,
        Super,
        Ultimate,
    }

    public enum eNFTRarity
    {
        common,
        rare,
        epic,
        mythic,
        unique,
    }

    public enum eNFTTraitType
    {  // 描述NFT的类型
        Type,

        // 描述NFT的稀有度.
        Rarity,

        // 描述NFT的品质.
        Quality,

        // 描述NFT的系列.
        Series,

        // 描述可穿戴物品的穿戴部位
        WearingPosition,

        // 描述NFT可放置的地块
        // 以","分割.
        // 比如同时支持VIP, Occupied 表示为 "VIP,Occupied"
        PlaceableLands,

        // 描述NFT的核心技能
        CoreSkillId,

        // 描述NFT的技能等级
        SkillLevel,


        // NFT 对应的属性加成
        MaxHP,

        HPRecovery,

        Attack,

        AttackSpeed,

        Defence,

        CritPoints,

        CritDamage,

        HitPoints,

        DodgePoints,

        MoveSpeed,

        // 回血
        RestoreHP,

        // 学习图鉴
        LearnRecipe,

        //创造者
        Creator,

        //等级
        Level,
    }

    public enum eNFTBattleTrait
    {
        // NFT 对应的属性加成
        MaxHP,

        HPRecovery,

        Attack,

        AttackSpeed,

        Defence,

        CritPoints,

        CritDamage,

        HitPoints,

        DodgePoints,

        MoveSpeed,
        RestoreHP,
    }

    public enum eNFTType
    {
        Unknown,
        HeadArmor, // 头部装备
        ChestArmor, // 胸部装备
        LegsArmor, // 腿部装备
        FeetArmor, // 脚部装备
        HandsArmor, // 手部装备
        Sword, // 剑
        Bow, // 弓
        Dagger, // 匕首
        Spear, // 枪
        Consumable, // 消耗品
        Material, // 材料
        Placeable, // 可放置
        Wearable, // 可穿戴
        MysteryBox, // 神秘宝箱
        TestEquipment, // 测试装备
        TestProp, // 测试道具
    }
}