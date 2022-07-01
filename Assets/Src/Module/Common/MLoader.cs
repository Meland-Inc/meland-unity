using System;
/*
 * @Author: mangit
 * @LastEditTime: 2022-07-01 15:56:37
 * @LastEditors: mangit
 * @Description: fairygui GLoader 的扩展,M代表Meland
 * @Date: 2022-06-09 10:22:49
 * @FilePath: /Assets/Src/Module/Common/MLoader.cs
 */
using FairyGUI;
using UnityEngine;

public class MLoader : GLoader
{
    protected override void LoadExternal()
    {
        MLoadExternal();
    }

    protected override void FreeExternal(NTexture texture)
    {
        BasicModule.Asset.UnloadAsset<Texture2D>(url, GetHashCode());
    }

    private async void MLoadExternal()
    {
        try
        {
            Texture2D tex = await BasicModule.Asset.LoadAsset<Texture2D>(url, GetHashCode());
            onExternalLoadSuccess(new NTexture(tex));
        }
        catch
        {
            onExternalLoadFailed();
        }
    }
}