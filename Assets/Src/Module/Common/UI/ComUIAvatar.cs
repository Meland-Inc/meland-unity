using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

public class ComUIAvatar : GComponent
{
    private Avatar2DMixed _refAvatarCpt;
    private bool _isAvatarLoaded;
    private GGraph _container;
    private GameObject _avatarGo;
    public override void ConstructFromXML(XML xml)
    {
        base.ConstructFromXML(xml);
        _container = GetChild("container") as GGraph;
        _avatarGo = new GameObject();
        _refAvatarCpt = _avatarGo.AddComponent<Avatar2DMixed>();
        _avatarGo.transform.localScale = new Vector3(GlobalDefine.POS_UNIT_TO_PIX, GlobalDefine.POS_UNIT_TO_PIX, GlobalDefine.POS_UNIT_TO_PIX);
    }

    private void LoadAvatar(string skeletonAsset, List<string> elements)
    {
        MLog.Info(eLogTag.avatar, "start load ui avatar");
        _refAvatarCpt.LoadAvatar(skeletonAsset, elements, (target) =>
            {
                if (!_isAvatarLoaded)
                {
                    _isAvatarLoaded = true;
                    _ = target.SkeletonAnimation.AnimationState.SetAnimation(0, "idle", true);
                    _container.SetNativeObject(new GoWrapper(target.gameObject));
                }
            });
    }

    /// <summary>
    /// 通过部件资源更换avatar
    /// </summary>
    /// <param name="partList"></param>
    public void ChangeAvatar(string skeletonRes, List<string> partResList)
    {
        if (_refAvatarCpt == null)
        {
            MLog.Error(eLogTag.avatar, "change avatar error, avatar cpt is null");
            return;
        }


        _refAvatarCpt.LoadAvatar(skeletonRes, partResList, null);
    }

    /// <summary>
    /// 通过部件id更换avatar
    /// </summary>
    /// <param name="partIDList"></param>
    public void ChangeAvatar(int roleCfgID, List<int> partIDList)
    {
        List<string> partList = Avatar2DUtil.GetPartResList(roleCfgID, partIDList);
        string skeletonRes = Avatar2DUtil.GetRoleSkeletonRes(roleCfgID);

        ChangeAvatar(skeletonRes, partList);
    }

    public override void Dispose()
    {
        Object.Destroy(_avatarGo);
        _avatarGo = null;
        base.Dispose();
    }
}