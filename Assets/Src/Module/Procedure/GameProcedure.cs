using System;
using Bian;
using GameFramework.Fsm;
using GameFramework.Procedure;

/// <summary>
/// 正式在场景里游戏流程
/// </summary>
public class GameProcedure : ProcedureBase
{
    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        AddEvent();

        ShowUI();

        CreateSceneEntity();

        RegisterPlayOperateSystem();
    }

    protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
    {
        RemoveEvent();

        HideUI();

        DestroySceneEntity();

        UnregisterPlayOperateSystem();

        base.OnLeave(procedureOwner, isShutdown);
    }

    private void AddEvent()
    {
        Message.RspMapEnterFinish += OnRspMapEnterFinish;//断线重连 重新收到enterMap时的处理
    }

    private void RemoveEvent()
    {
        Message.RspMapEnterFinish -= OnRspMapEnterFinish;
    }

    private void OnRspMapEnterFinish(EnterMapResponse rsp)
    {
        //断线重连的情况
        SceneModule.EntityMgr.NetInitMainRole(rsp.Me, rsp.Location);
    }

    private void ShowUI()
    {
        //TODO:
        _ = UICenter.OpenUIForm<FormMain>("open ui form");
    }

    private void HideUI()
    {
        //TODO:
        UICenter.CloseUIForm<FormMain>();
    }

    private async void CreateSceneEntity()
    {
        //TODO:
        // try
        // {
        //     string fileName = "DSJ_ggdx_3_1_01";
        //     Sprite asset = await Resource.LoadSprite(fileName);
        //     GameObject go = new("loadSprite");
        //     go.AddComponent<SpriteRenderer>().sprite = asset;
        //     Log.Debug($"load success ={asset} name={fileName}");
        // }
        // catch (ResourceLoadException e)
        // {
        //     Log.Debug($"load fail status={e.LoadStatus} msg={e.Message}");
        // }
    }

    private void DestroySceneEntity()
    {
        //TODO:
    }

    private void RegisterPlayOperateSystem()
    {
        //TODO:
    }

    private void UnregisterPlayOperateSystem()
    {
        //TODO:
    }
}