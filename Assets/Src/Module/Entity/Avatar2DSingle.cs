using System;
using Spine.Unity;

/// <summary>
/// 单一加载资源出来的2d avatar 没有换装功能
/// </summary>
public class Avatar2DSingle : Avatar2D
{
    private string _curAssetPath;//当前加载的主骨架资源路径

    private void OnDestroy()
    {
        UnloadAvatar();
    }

    /// <summary>
    /// 加载单一avatar
    /// </summary>
    /// <param name="assetPath">SkeletonDataAsset的资源全路径</param>
    /// <param name="finishCB">完成回调</param>
    /// <returns></returns>
    public async void LoadAvatar(string assetPath, Action<Avatar2DSingle> finishCB)
    {
        if (string.IsNullOrEmpty(assetPath))
        {
            MLog.Error(eLogTag.avatar, $"load single 2d avatar parm is error assetPath={assetPath}");
            finishCB(this);
            return;
        }

        if (!string.IsNullOrEmpty(_curAssetPath))
        {
            if (_curAssetPath == assetPath)
            {
                finishCB(this);
                return;
            }

            UnloadAvatar();
        }

        _curAssetPath = assetPath;
        try
        {
            SkeletonDataAsset asset = await BasicModule.Asset.LoadAsset<SkeletonDataAsset>(_curAssetPath, GetHashCode(), (int)eLoadPriority.Low);
            SkeletonAnimation animation = SkeletonAnimation.NewSkeletonAnimationGameObject(asset);
            AvatarRoot = animation.gameObject;
            AvatarRoot.transform.SetParent(transform, false);
            AvatarRoot.name = "avatar2DLoaded";

            FindComponent();

            try
            {
                finishCB(this);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        catch (AssetLoadException e)
        {
            MLog.Error(eLogTag.asset, $"load single 2d avatar asset error,path={assetPath} error={e}");
        }
    }

    private void UnloadAvatar()
    {
        if (string.IsNullOrEmpty(_curAssetPath))
        {
            return;
        }

        Destroy(AvatarRoot);
        BasicModule.Asset.UnloadAsset<SkeletonDataAsset>(_curAssetPath, GetHashCode());
        _curAssetPath = null;
    }
}