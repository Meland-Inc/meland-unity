/*
 * @Author: mangit
 * @LastEditTime: 2022-06-14 21:07:27
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
        GFEntry.Resource.UnloadAsset(url);
    }

    private async void MLoadExternal()
    {
        try
        {
            Texture2D tex = await GFEntry.Resource.AwaitLoadAsset<Texture2D>(url);
            onExternalLoadSuccess(new NTexture(tex));
        }
        catch
        {
            onExternalLoadFailed();
        }
    }
}