/*
* @Author: mangit
 * @LastEditTime: 2022-07-01 19:42:33
 * @LastEditors: mangit
* @Description: fairygui 处理中心
* @Date: 2022-06-16 20:48:53
 * @FilePath: /Assets/Src/Framework/UI/UICenter.Fgui.cs
*/
using System;
using System.IO;
using FairyGUI;
using UnityEngine;

public partial class UICenter
{
    private readonly FguiExtensionCfg[] _extensionCfg = new FguiExtensionCfg[]
    {
        new (eFUIPackage.Backpack, FGUIDefine.NFT_ITEM_RES,typeof( BpNftItemRenderer)),
        new (eFUIPackage.Backpack, FGUIDefine.NFT_EQUIP_ITEM_RES,typeof( BpNftItemRenderer)),
        new (eFUIPackage.Backpack, FGUIDefine.EQUIPMENT_SLOT_RES,typeof( EquipmentSlot)),
    };

    private readonly string[] _fontCfg = {
        "SourceHanSansCN-Heavy.ttf",
        "FangFang.ttf",
    };
    public static void InitPackage()
    {
        _ = UIPackage.AddPackage(UI_ASSET_PREFIX + eFUIPackage.Common.ToString());
        _ = UIPackage.AddPackage(UI_ASSET_PREFIX + eFUIPackage.Backpack.ToString());
    }

    public void InitFguiExtension()
    {
        UIObjectFactory.SetLoaderExtension(typeof(MLoader));//扩展加载器加载资源方式
        foreach (FguiExtensionCfg item in _extensionCfg)
        {
            try
            {
                string url = UIPackage.GetItemURL(item.Package.ToString(), item.ResName);
                UIObjectFactory.SetPackageItemExtension(url, item.Type);
            }
            catch (Exception e)
            {
                MLog.Info(eLogTag.ui, $"extend fgui package item error: {e.Message}");
            }
        }
    }

    public async void InitFont()
    {
        foreach (string fontName in _fontCfg)
        {
            Font font = await BasicModule.Asset.LoadAsset<Font>(Path.Combine(AssetDefine.PATH_FONT, fontName), fontName.GetHashCode());
            FontManager.RegisterFont(new DynamicFont(fontName, font), font.name);
        }
        UIConfig.defaultFont = _fontCfg[0];//第一个作为默认字体
    }
}