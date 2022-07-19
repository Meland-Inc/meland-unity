using System;
/*
* @Author: mangit
 * @LastEditTime: 2022-06-20 14:52:01
 * @LastEditors: mangit
* @Description: 背包管理模块
* @Date: 2022-06-15 11:22:30
 * @FilePath: /Assets/Src/Module/Backpack/BackpackMgr.cs
*/
using UnityEngine;

public class BackpackMgr : MonoBehaviour
{
    public Action OnDataInit = delegate { };
    public Action OnDataUpdated = delegate { };
    public Action OnWearableDataUpdated = delegate { };
    public Action OnDataAdded = delegate { };
    public Action OnDataRemoved = delegate { };
    private void Awake()
    {
        ReqData();
        Message.RspMapEnterFinish += OnMapEnterFinish;
    }

    private void OnDestroy()
    {
        Message.RspMapEnterFinish -= OnMapEnterFinish;
    }

    private void OnMapEnterFinish(MelandGame3.EnterMapResponse rsp)
    {
        ReqData();
    }

    private void ReqData()
    {
        ItemsGetAction.Req();
    }

    private void OnReconnect()
    {
        ReqData();
    }

    public void OpenBackpack()
    {
        ReqData();
        _ = UICenter.OpenUIForm<FormBackpack>();
    }

    public static void TestOpenBackpack()
    {
        ItemsGetAction.Req();
        _ = UICenter.OpenUIForm<FormBackpack>();
    }

    public void CloseBackpack()
    {
        UICenter.CloseUIForm<FormBackpack>();
    }

    public void UseItem(BpItemData item)
    {
        item.UseFunc();
    }
}