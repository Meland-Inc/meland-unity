/*
 * @Author: xiang huan
 * @Date: 2022-06-16 14:24:25
 * @Description: 大世界网格数据
 * @FilePath: /meland-unity/Assets/Src/Module/BigWorld/Data/BigWorldGridData.cs
 * 
 */

using GameFramework;
using UnityEngine;
public class BigWorldGridData : IReference
{
    public Bian.BigWorldTile SvrData { get; private set; }
    public Vector2 Location { get; private set; }  //XZ坐标
    public int MaxHp { get; private set; }
    public int CurHp { get; private set; }
    public string Owner { get; private set; }
    public Bian.BigWorldLandState State { get; private set; }
    public Bian.BigWorldFightState FightState { get; private set; }
    public Bian.BigWorldFightInfo FightInfo { get; private set; }
    public BigWorldGridData()
    {
        Location = new();
    }

    public static BigWorldGridData Create(Bian.BigWorldTile svrData)
    {
        BigWorldGridData data = ReferencePool.Acquire<BigWorldGridData>();
        data.SetData(svrData);
        return data;
    }
    public void SetData(Bian.BigWorldTile svrData)
    {
        SvrData = svrData;
        CurHp = svrData.Profile.CurHp;
        MaxHp = GFEntry.DataTable.GetDataTable<DRGameValue>().GetDataRow(8000003).Value;
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
        return FightState == Bian.BigWorldFightState.BigWorldFightStateFighting;
    }

}

