/*
* @Author: mangit
 * @LastEditTime: 2022-07-21 20:12:09
 * @LastEditors: wym
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
    public static float StageWidth => (float)Stage.inst.width;
    public static float StageHeight => (float)Stage.inst.height;
    private readonly FguiExtensionCfg[] _extensionCfg = new FguiExtensionCfg[]
    {
        new (eFUIPackage.Backpack, FGUIDefine.NFT_ITEM_RES,typeof( BpNftItemRenderer)),
        new (eFUIPackage.Backpack, FGUIDefine.NFT_EQUIP_ITEM_RES,typeof( BpNftItemRenderer)),
        new (eFUIPackage.Backpack, FGUIDefine.NFT_REWARD_ITEM_RES,typeof( RewardNftItemRenderer)),
        new (eFUIPackage.Backpack, FGUIDefine.EQUIPMENT_SLOT_RES,typeof( EquipmentSlot)),
        new (eFUIPackage.Common, FGUIDefine.UI_AVATAR_RES,typeof( ComUIAvatar)),
        new (eFUIPackage.Common, FGUIDefine.COM_LABEL_CUR_MAX_RES,typeof( ComLabelCurMax)),
        new (eFUIPackage.Task, FGUIDefine.TASK_MENU_ITEM_RES,typeof( TaskMenuItemRender)),
        new (eFUIPackage.Task, FGUIDefine.TASK_TRACKER_ITEM_RES,typeof( TaskTrackerItemRender)),
        new (eFUIPackage.Task, FGUIDefine.TASK_SUB_ITEM_RES,typeof( TaskSubItemRender)),
    };

    private readonly string[] _fontCfg = {
        "HermanoAlto_Round.ttf"
    };
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
                MLog.Error(eLogTag.ui, $"extend fgui package item error: {e.Message}");
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