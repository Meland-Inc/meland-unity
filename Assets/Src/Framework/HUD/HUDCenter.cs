/*
 * @Author: xiang huan
 * @Date: 2022-07-21 14:57:09
 * @Description: hud中心
 * @FilePath: /meland-unity/Assets/Src/Framework/HUD/HUDCenter.cs
 * 
 */

using GameFramework;
using GameFramework.ObjectPool;
using UnityEngine;
using UnityGameFramework.Runtime;
public partial class HUDCenter : GameFrameworkComponent
{
    [SerializeField]
    private float _instanceAutoReleaseInterval = 60f;

    [SerializeField]
    private int _instanceCapacity = 16;

    [SerializeField]
    private float _instanceExpireTime = 60f;

    [SerializeField]
    private int _instancePriority = 0;

    private IObjectPool<HUDInstanceObject> _instancePool;
    private HUDHelper _hudHelper;

    private void Start()
    {
        _instancePool = GFEntry.ObjectPool.CreateSingleSpawnObjectPool<HUDInstanceObject>("HUD Instance Pool");
        _instancePool.AutoReleaseInterval = _instanceAutoReleaseInterval;
        _instancePool.Capacity = _instanceCapacity;
        _instancePool.ExpireTime = _instanceExpireTime;
        _instancePool.Priority = _instancePriority;
        _hudHelper = new HUDHelper();
    }

    public T OpenUI<T>(string uiAssetName, object uiAsset, GameObject rootNode, object userData = null) where T : HUDBase
    {
        try
        {
            HUDInstanceObject uiInstanceObject = _instancePool.Spawn(uiAssetName);
            bool isNew = false;
            if (uiInstanceObject == null)
            {
                uiInstanceObject = HUDInstanceObject.Create(uiAssetName, _hudHelper.InstantiateUI(uiAsset), _hudHelper);
                _instancePool.Register(uiInstanceObject, true);
                isNew = true;
            }
            HUDBase hUDBase = _hudHelper.CreateUI(uiInstanceObject.Target, rootNode, userData);
            if (hUDBase == null)
            {
                throw new GameFrameworkException("HUDCenter Can not OpenUI form in UI form helper.");
            }
            if (isNew)
            {
                hUDBase.Init(userData);
            }
            hUDBase.Open(userData);
            return hUDBase as T;
        }
        catch (System.Exception)
        {
            return null;
        }
    }

    public void CloseUI(HUDBase hUDBase, object userData = null)
    {
        hUDBase.Close(false, userData);
        hUDBase.Recycle();
        _instancePool.Unspawn(hUDBase.gameObject);
    }
}