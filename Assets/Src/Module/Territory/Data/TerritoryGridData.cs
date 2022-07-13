/*
 * @Author: xiang huan
 * @Date: 2022-06-16 14:24:25
 * @Description: 领地网格数据
 * @FilePath: /meland-unity/Assets/Src/Module/Territory/Data/TerritoryGridData.cs
 * 
 */

using GameFramework;
using UnityEngine;
public class TerritoryGridData : IReference
{
    public MelandGame3.BigWorldTile SvrData { get; private set; }
    public Vector2 Location { get; private set; }  //XZ坐标
    public int MaxHp { get; private set; }
    public int CurHp { get; private set; }
    public string Owner { get; private set; }
    public MelandGame3.BigWorldLandState State { get; private set; }
    public MelandGame3.BigWorldFightState FightState { get; private set; }
    public MelandGame3.BigWorldFightInfo FightInfo { get; private set; }

    private const int MAX_HP_ID = 8000003;
    public TerritoryGridData()
    {
        Location = new();
    }

    public static TerritoryGridData Create(MelandGame3.BigWorldTile svrData)
    {
        TerritoryGridData data = ReferencePool.Acquire<TerritoryGridData>();
        data.SetData(svrData);
        return data;
    }
    public void SetData(MelandGame3.BigWorldTile svrData)
    {
        SvrData = svrData;
        CurHp = svrData.Profile.CurHp;
        MaxHp = GFEntry.DataTable.GetDataTable<DRGameValue>().GetDataRow(MAX_HP_ID).Value;
        Owner = svrData.Profile.OwnerId;
        State = svrData.Profile.State;
        (float x, float z) = NetUtil.RCToXZ(svrData.R, svrData.C);
        Location.Set(x, z);
        FightState = svrData.FightState;
        FightInfo = svrData.FightInfo;
    }
    public void Clear()
    {
        SvrData = null;
        CurHp = 0;
        MaxHp = 0;
        Owner = null;
        State = 0;
        Location.Set(0, 0);
        FightState = 0;
        FightInfo = null;
    }
    public bool IsBattleState()
    {
        return FightState == MelandGame3.BigWorldFightState.BigWorldFightStateFighting;
    }

}

