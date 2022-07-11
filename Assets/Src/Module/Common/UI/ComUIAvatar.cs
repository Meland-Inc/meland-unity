using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

public class ComUIAvatar : GComponent
{
    private Avatar2DMixed _refAvatarCpt;
    public override void ConstructFromXML(XML xml)
    {
        base.ConstructFromXML(xml);
        InitAvatar();
    }

    private void InitAvatar()
    {
        MLog.Info(eLogTag.avatar, "start load ui avatar");
        GGraph container = GetChild("container").asGraph;
        try
        {
            GameObject go = new();
            _refAvatarCpt = go.AddComponent<Avatar2DMixed>();
            //为了适配ui,fairygui所有界面对应的game Object的scale都被缩小了108倍,这里外部game object要恢复原来的scale
            go.transform.localScale = new Vector3(108, 108, 108);
            go.GetComponent<Avatar2DMixed>().LoadAvatar(AssetDefine.PATH_AVATAR_SKELETON, new()
            {
                "full-skins/boy",//TODO:需要按方案修改
            }, (target) =>
            {
                _ = target.SkeletonAnimation.AnimationState.SetAnimation(0, "idle", true);
                container.SetNativeObject(new GoWrapper(target.gameObject));
            });
        }
        catch (System.Exception e)
        {
            MLog.Error(eLogTag.avatar, $"load avatar error {e.Message}");
        }
    }

    /// <summary>
    /// 通过部件资源更换avatar
    /// </summary>
    /// <param name="partList"></param>
    public void ChangeAvatar(List<string> partResList)
    {
        if (_refAvatarCpt == null)
        {
            MLog.Error(eLogTag.avatar, "change avatar error, avatar cpt is null");
            return;
        }

        _refAvatarCpt.LoadAvatar(AssetDefine.PATH_AVATAR_SKELETON, partResList, null);
    }

    /// <summary>
    /// 通过部件id更换avatar
    /// </summary>
    /// <param name="partIDList"></param>
    public void ChangeAvatar(List<int> partIDList)
    {
        List<string> partList = new();
        foreach (int partID in partIDList)
        {
            DRAvatar drAvatar = GFEntry.DataTable.GetDataTable<DRAvatar>().GetDataRow(partID);
            if (drAvatar == null)
            {
                continue;
            }
            partList.Add(drAvatar.ResouceBoy);
        }

        ChangeAvatar(partList);
    }
}