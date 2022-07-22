/*
 * @Author: xiang huan
 * @Date: 2022-07-20 15:33:50
 * @Description: hud基础使用组件,可以继承或者参考这个去实现
 * @FilePath: /meland-unity/Assets/Src/Framework/HUD/HUDBaseCpt.cs
 * 
 */
using UnityEngine;

public class HUDBaseCpt<THUDBase> : MonoBehaviour where THUDBase : HUDBase
{
    private string _assetPath;
    protected THUDBase _hud;
    public THUDBase HUD => _hud;
    protected CameraSameDirection _cameraSameDirection;

    /// <summary>
    /// 创建HUD
    /// </summary>
    protected async void CreateHUD(string uiAssetName, object userData = null)
    {
        if (!string.IsNullOrEmpty(_assetPath))
        {
            return;
        }
        try
        {
            _assetPath = UICenter.GetFormAsset(uiAssetName);
            GameObject uiAsset = await BasicModule.Asset.LoadAsset<GameObject>(_assetPath, GetHashCode());
            _hud = BasicModule.HUDCenter.OpenUI<THUDBase>(_assetPath, uiAsset, gameObject, userData);
            _cameraSameDirection = _hud.gameObject.AddComponent<CameraSameDirection>();
            _cameraSameDirection.SetTargetTsm(Camera.main.transform);
            CreateHUDSuccess();
        }
        catch (AssetLoadException e)
        {
            DestroyHUD();
            CreateHUDFailure();
            MLog.Error(eLogTag.asset, $"InitHeadInfo asset error,path={_assetPath} error={e}");
        }
    }
    /// <summary>
    /// 销毁HUD
    /// </summary>
    protected void DestroyHUD()
    {
        if (!string.IsNullOrEmpty(_assetPath))
        {
            BasicModule.Asset.UnloadAsset<GameObject>(_assetPath, GetHashCode());
            _assetPath = null;
        }
        if (_cameraSameDirection != null)
        {
            Destroy(_cameraSameDirection);
            _cameraSameDirection = null;
        }
        if (_hud != null)
        {
            BasicModule.HUDCenter.CloseUI(_hud);
            _hud = null;
        }
    }
    protected virtual void CreateHUDSuccess()
    {
        //
    }
    protected virtual void CreateHUDFailure()
    {
        //
    }
    /// <summary>
    /// 销毁组件
    /// </summary>
    protected virtual void OnDestroy()
    {
        DestroyHUD();
    }
}