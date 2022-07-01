using System.Collections.Generic;
using System;
/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 装备插槽信息
 * @Date: 2022-06-22 15:46:59
 * @FilePath: /Assets/Src/Module/MainPlayerRole/view/ComSlotInfoLogic.cs
 */
using FairyGUI;
using Bian;
public class ComSlotInfoLogic : FGUILogicCpt
{
    private const int ATTR_ITEM_COUNT = 11;
    private GList _lstAttr;
    private GTextField _tfLv;
    private GButton _btnUpgrade;
    private GButton _btnExpHelp;
    private GButton _btnMeldHelp;
    private GProgressBar _comMeld;
    private GProgressBar _comExp;
    private ItemSlot _slotData;
    /// <summary>
    /// 插槽升级属性变更
    /// </summary>
    private List<SlotUpgradeInfo> _slotUpgradeInfoList;
    protected override void OnAdd()
    {
        base.OnAdd();
        _lstAttr = GCom.GetChild("lstAttr") as GList;
        _tfLv = GCom.GetChild("tfLv") as GTextField;
        _btnExpHelp = GCom.GetChild("btnExpHelp") as GButton;
        _btnMeldHelp = GCom.GetChild("btnMeldHelp") as GButton;
        _btnUpgrade = GCom.GetChild("btnUpgrade") as GButton;
        _comMeld = GCom.GetChild("comMeld") as GProgressBar;
        _comExp = GCom.GetChild("comExp") as GProgressBar;

        _lstAttr.itemRenderer = OnItemRenderer;
        _lstAttr.itemProvider = OnItemProvider;

        AddUIEvent();
    }

    private void AddUIEvent()
    {
        _btnUpgrade.onClick.Add(OnBtnUpgradeClick);
        _btnExpHelp.onClick.Add(OnBtnExpHelpClick);
        _btnMeldHelp.onClick.Add(OnBtnMeldHelpClick);
    }

    public void UpdateView(AvatarPosition slotPos)
    {
        _slotData = DataManager.MainPlayer.ItemSlotDice[slotPos];
        UpdateSlotLv();
        UpdateExp();
        UpdateAttr();
        UpdateMeld();
        UpdateBtn();
    }

    private void UpdateSlotLv()
    {
        _tfLv.SetVar("lv", _slotData.Level.ToString())
          .FlushVars();
    }

    private void UpdateExp()
    {
        DRSlotLv drSlot = SlotLvTable.Inst.GetDataRow((int)_slotData.Position, _slotData.Level);
        _comExp.value = Convert.ToDouble(DataManager.MainPlayer.RoleData.Profile.Exp);
        _comExp.max = drSlot.Exp;
    }

    private void UpdateMeld()
    {
        //TODO:
    }

    private void UpdateAttr()
    {
        _lstAttr.RemoveChildrenToPool();
        _slotUpgradeInfoList = SlotUpgradeInfo.GetUpgradeInfoList(_slotData.Position, _slotData.Level);
        _lstAttr.numItems = ATTR_ITEM_COUNT;
    }

    private void AddAttrItem(string tName, int curValue, int tNextValue, bool showFrame)
    {
        if (_lstAttr != null)
        {
            GComponent item = _lstAttr.AddItemFromPool().asCom;
            item.GetController("ctrlType").SetSelectedPage(tName.ToLower());//TODO:to be optimized
            item.GetController("ctrlFrame").SetSelectedPage(showFrame ? "show" : "hide");
            item.GetChild("tfValue").asTextField
                .SetVar("cur", curValue.ToString())
                .SetVar("next", tNextValue.ToString())
                .FlushVars();
        }
    }

    private void UpdateBtn()
    {
        Controller ctrlEnable = _btnUpgrade.GetController("ctrlEnable");
        if (SceneModule.RoleLevel.CheckCanUpgradeSlot(_slotData.Position))
        {
            ctrlEnable.SetSelectedPage("true");
        }
        else
        {
            DRSlotLv drSlot = SlotLvTable.Inst.GetDataRow((int)_slotData.Position, _slotData.Level);
            int needExp = drSlot.Exp;
            int ditaminNeed = drSlot.Ditamin;
            ctrlEnable.SetSelectedPage("false");
            _btnUpgrade.GetChild("title").asTextField
                .SetVar("exp", needExp.ToString())
                .SetVar("lv", Math.Max(1, _slotData.Level - RoleLevelModule.MAX_LV_GAP_BETWEEN_SLOT_AND_ROLE).ToString())
                .SetVar("ditamin", ditaminNeed.ToString())
                .FlushVars();
        }
    }

    private void OnBtnUpgradeClick()
    {
        _ = SceneModule.RoleLevel.UpgradeSlot(_slotData.Position);
    }

    private void OnBtnExpHelpClick()
    {
        //  TODO:
    }

    private void OnBtnMeldHelpClick()
    {
        //TODO:
    }

    private void OnItemRenderer(int index, GObject item)
    {
        GButton btnItem = item.asButton;
        btnItem.GetChild("imgBg").visible = index % 2 == 0;
        if (index < _slotUpgradeInfoList.Count)
        {
            SlotUpgradeInfo info = _slotUpgradeInfoList[index];
            btnItem.GetController("ctrlType").SetSelectedPage(info.AttrName);
            btnItem.GetChild("tfValue").asTextField
                .SetVar("cur", info.CurValue.ToString())
                .SetVar("next", info.NextValue.ToString())
                .FlushVars();
        }

        //empty item 
    }

    private string OnItemProvider(int index)
    {
        if (_slotUpgradeInfoList != null && index < _slotUpgradeInfoList.Count)
        {
            return UIPackage.GetItemURL(eFUIPackage.Player.ToString(), "btnSlotAttrItem");
        }

        return _lstAttr.defaultItem;
    }
}