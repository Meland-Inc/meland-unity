using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 正式在场景里游戏流程
/// </summary>
public class GameProcedure : ProcedureBase
{
    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        ShowUI();

        CreateSceneEntity();

        RegisterPlayOperateSystem();
    }

    protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
    {
        HideUI();

        DestroySceneEntity();

        UnregisterPlayOperateSystem();

        base.OnLeave(procedureOwner, isShutdown);
    }

    private void ShowUI()
    {
        //TODO:
    }

    private void HideUI()
    {
        //TODO:
    }

    private async void CreateSceneEntity()
    {
        //TODO:
        string filePath = "Assets/RawResource/DSJ_ggdx_3_1_01.png";
        try
        {
            Sprite asset = await GFEntry.Resource.AwaitLoadAsset<Sprite>(filePath);
            GameObject go = new("loadSprite");
            go.AddComponent<SpriteRenderer>().sprite = asset;
            Log.Debug($"load success ={asset} name={filePath}");
        }
        catch (ResourceLoadException e)
        {
            Log.Debug($"load fail status={e.LoadStatus} msg={e.Message}");
        }
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