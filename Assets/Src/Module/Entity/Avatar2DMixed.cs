using System.Collections.Generic;
using System;
using Spine;

/// <summary>
/// 含有换装功能的2d avatar
/// </summary>
public class Avatar2DMixed : Avatar2DSingle
{
    private HashSet<string> _curElements;//当期的所有部件名

    /// <summary>
    /// 加载换装avatar
    /// </summary>
    /// <param name="assetPath">SkeletonDataAsset的资源全路径</param>
    /// <param name="finishCB">完成回调</param>
    /// <returns></returns>
    public void LoadAvatar(string assetPath, List<string> elements, Action<Avatar2DMixed> finishCB)
    {
        if (string.IsNullOrEmpty(assetPath) || elements == null || elements.Count == 0)
        {
            MLog.Error(eLogTag.avatar, $"load mix 2d avatar parm is error assetPath={assetPath}");
            finishCB(this);
            return;
        }

        if (_curElements != null && _curElements.Count == elements.Count)
        {
            bool allSame = true;
            foreach (string item in elements)
            {
                if (!_curElements.Contains(item))
                {
                    allSame = false;
                    break;
                }
            }

            //没变化直接返回
            if (allSame)
            {
                finishCB(this);
                return;
            }
        }

        LoadAvatar(assetPath, (target) =>
        {
            MixAvatar(elements);
            finishCB(this);
        });
    }

    /// <summary>
    /// 换装
    /// </summary>
    /// <param name="elements"></param>
    private void MixAvatar(List<string> elements)
    {
        if (_curElements == null)
        {
            _curElements = new();
        }
        else
        {
            _curElements.Clear();
        }

        Skin combinedSkin = new("CombineSkin");
        Skin mainSkin = SkeletonAnimation.skeleton.Data.FindSkin(EntityDefine.AVATAR_BASE_SKIN);
        combinedSkin.AddSkin(mainSkin);

        foreach (string element in elements)
        {
            if (_curElements.Contains(element))
            {
                continue;
            }

            Skin skin = SkeletonAnimation.skeleton.Data.FindSkin(element);
            if (skin == null)
            {
                MLog.Error(eLogTag.avatar, $"load mix 2d avatar skin not find={element}");
                continue;
            }

            combinedSkin.AddSkin(skin);
            _ = _curElements.Add(element);
        }


        SkeletonAnimation.skeleton.SetSkin(combinedSkin);
        SkeletonAnimation.skeleton.SetSlotsToSetupPose();
    }
}