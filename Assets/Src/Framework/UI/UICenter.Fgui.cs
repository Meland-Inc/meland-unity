using System;
/*
 * @Author: mangit
 * @LastEditTime: 2022-06-21 14:29:49
 * @LastEditors: mangit
 * @Description: fairygui 处理中心
 * @Date: 2022-06-16 20:48:53
 * @FilePath: /Assets/Src/Framework/UI/UICenter.Fgui.cs
 */
using FairyGUI;

public partial class UICenter
{
    private readonly FguiExtensionCfg[] _extensionCfg = new FguiExtensionCfg[]
    {
        new (eFUIPackage.Backpack, FGUIDefine.NFT_ITEM_RES,typeof( BpNftItemRenderer)),
        new (eFUIPackage.Backpack, FGUIDefine.NFT_EQUIP_ITEM_RES,typeof( BpNftItemRenderer)),
        new (eFUIPackage.Backpack, FGUIDefine.EQUIPMENT_SLOT_RES,typeof( EquipmentSlot)),
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
}