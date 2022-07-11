/*
 * @Author: xiang huan
 * @Date: 2022-06-16 14:24:44
 * @Description: 用户资产
 * @FilePath: /meland-unity/Assets/Src/Module/Territory/Data/TerritoryUserAssetData.cs
 * 
 */

using UnityEngine;
public class TerritoryUserAssetData
{
    public int EnergyNum { get; private set; }     //能量数 
    public int LandNum { get; private set; }  //地块数
    public int LandMaxNum { get; private set; } //max地块数
    public int GoldNum { get; private set; } //金币数
    public int TicketLandNum { get; private set; }
    public int VipLandNum { get; private set; }
    public int ActivityNum { get; private set; }
    public int OccupiedLandLimit { get; private set; }
    public string StakeVipName { get; private set; }
    public int GoldnumMaybePerHour { get; private set; }
    public int DitaminChallengePercent { get; private set; }
    public int GoldnumMaybePer24Hours { get; private set; }
    public int DitaminLand24Hours { get; private set; }
    public string WalletAddress { get; private set; } //钱包地址

    public TerritoryUserAssetData()
    {
        EnergyNum = 0;
        LandNum = 0;
        LandMaxNum = 0;
        GoldNum = 0;
        TicketLandNum = 0;
        VipLandNum = 0;
        ActivityNum = 0;
        OccupiedLandLimit = 0;
        StakeVipName = "";
        GoldnumMaybePerHour = 0;
        DitaminChallengePercent = 0;
        GoldnumMaybePer24Hours = 0;
        DitaminLand24Hours = 0;
        WalletAddress = "";
    }
    public void SetData(Runtime.TUserAssetResponse assetData)
    {
        EnergyNum = assetData.EnergyNum;
        LandNum = assetData.LandNum;
        LandMaxNum = assetData.LandMaxNum;
        GoldNum = assetData.GoldNum;
        TicketLandNum = assetData.TicketLandNum;
        VipLandNum = assetData.VipLandNum;
        ActivityNum = assetData.ActivityNum;
        OccupiedLandLimit = assetData.OccupiedLandLimit;
        StakeVipName = assetData.StakeVipName ?? "";
        GoldnumMaybePerHour = assetData.GoldnumMaybePerHour;
        DitaminChallengePercent = assetData.DitaminChallengePercent;
        GoldnumMaybePer24Hours = assetData.GoldnumMaybePer24Hours;
        DitaminLand24Hours = assetData.DitaminLand24Hours;
        WalletAddress = assetData.WalletAddress ?? "";
    }
}