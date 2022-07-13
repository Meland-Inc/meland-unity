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
    private GTextField _tfUpgradeTips;
    private GButton _btnUpgrade;
    private GButton _btnLevelMax;
    private GButton _btnExpHelp;
    private GButton _btnMeldHelp;
    private GProgressBar _comMeld;
    private GProgressBar _comExp;
    private ItemSlot _slotData;
    private DRSlotLv _slotLvCfg;
    /// <summary>
    /// 插槽升级属性变更
    /// </summary>
    private List<RoleAttrDiffInfo> _slotUpgradeInfoList;
    protected override void OnAdd()
    {
        base.OnAdd();
        _lstAttr = GCom.GetChild("lstAttr") as GList;
        _tfLv = GCom.GetChild("tfLv") as GTextField;
        _tfUpgradeTips = GCom.GetChild("tfUpgradeTips") as GTextField;
        _btnExpHelp = GCom.GetChild("btnExpHelp") as GButton;
        _btnMeldHelp = GCom.GetChild("btnMeldHelp") as GButton;
        _btnUpgrade = GCom.GetChild("btnUpgrade") as GButton;
        _btnLevelMax = GCom.GetChild("btnLevelMax") as GButton;
        _comMeld = GCom.GetChild("comMeld") as GProgressBar;
        _comExp = GCom.GetChild("comExp") as GProgressBar;

        _lstAttr.itemRenderer = OnItemRenderer;
        _lstAttr.itemProvider = OnItemProvider;
    }

    public override void OnOpen()
    {
        base.OnOpen();
        AddUIEvent();
        AddMessage();
    }

    public override void OnClose()
    {
        base.OnClose();
        RemoveUIEvent();
        RemoveMessage();
    }

    private void AddUIEvent()
    {
        _btnUpgrade.onClick.Add(OnBtnUpgradeClick);
        _btnExpHelp.onClick.Add(OnBtnExpHelpClick);
        _btnMeldHelp.onClick.Add(OnBtnMeldHelpClick);
    }

    private void RemoveUIEvent()
    {
        _btnUpgrade.onClick.Remove(OnBtnUpgradeClick);
        _btnExpHelp.onClick.Remove(OnBtnExpHelpClick);
        _btnMeldHelp.onClick.Remove(OnBtnMeldHelpClick);
    }

    private void AddMessage()
    {
        SceneModule.Recharge.OnRechargeMeldStatusChanged += OnRechargeMeldStatusChanged;
    }

    private void RemoveMessage()
    {
        SceneModule.Recharge.OnRechargeMeldStatusChanged -= OnRechargeMeldStatusChanged;
    }

    public void UpdateView(AvatarPosition slotPos)
    {
        _slotData = DataManager.MainPlayer.ItemSlotDic[slotPos];
        _slotLvCfg = SlotLvTable.Inst.GetDataRow((int)_slotData.Position, _slotData.Level);
        UpdateSlotLv();
        UpdateExp();
        UpdateAttr();
        UpdateMeld();
        UpdateBtn();
        UpdateTips();
    }

    private void UpdateSlotLv()
    {
        _tfLv.SetVar("lv", _slotData.Level.ToString())
          .FlushVars();
    }

    private void UpdateExp()
    {
        _comExp.value = Convert.ToDouble(DataManager.MainPlayer.RoleExp);
        _comExp.max = _slotLvCfg.Exp;
    }

    private void UpdateMeld()
    {
        _comMeld.value = SceneModule.Craft.MeldCount;
        _comMeld.max = _slotLvCfg.UseMELD;
    }

    private void UpdateAttr()
    {
        _lstAttr.RemoveChildrenToPool();
        if (_slotData.Level < RoleLevelModule.MAX_ROLE_LV)
        {
            RoleUpgradeAttrDiffInfo upgradeInfo = RoleUpgradeAttrDiffInfo.GetSlotUpgradeInfo((int)_slotData.Position, _slotData.Level);
            _slotUpgradeInfoList = upgradeInfo?.AttrDiffList;
        }
        _lstAttr.numItems = ATTR_ITEM_COUNT;
    }

    private void UpdateBtn()
    {
        _btnUpgrade.touchable = SceneModule.RoleLevel.CheckCanUpgradeSlot(_slotData.Position);
        _btnUpgrade.grayed = !_btnUpgrade.touchable;
        SetBtnLoadingStatus(_btnUpgrade, SceneModule.Recharge.IsMeldRecharging);

        _btnLevelMax.visible = _slotData.Level >= RoleLevelModule.MAX_ROLE_LV;
        _btnUpgrade.visible = !_btnLevelMax.visible;
    }

    private void SetBtnLoadingStatus(GButton btn, bool loading)
    {
        btn.GetController("ctrlLoading").SetSelectedPage(loading ? "loading" : "normal");
        btn.touchable = !loading && !btn.grayed;
    }

    private void UpdateTips()
    {
        int needExp = _slotLvCfg.Exp;
        int meldCost = _slotLvCfg.UseMELD;
        _tfUpgradeTips.asTextField
                .SetVar("exp", needExp.ToString())
                .SetVar("lv", Math.Max(1, _slotData.Level - RoleLevelModule.MAX_LV_GAP_BETWEEN_SLOT_AND_ROLE).ToString())
                .SetVar("meld", meldCost.ToString())
                .FlushVars();
    }

    private void OnBtnUpgradeClick()
    {
        SceneModule.RoleLevel.UpgradeSlot(_slotData.Position, _slotLvCfg.UseMELD);
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
        if (_slotUpgradeInfoList != null && index < _slotUpgradeInfoList.Count)
        {
            RoleAttrDiffInfo info = _slotUpgradeInfoList[index];
            btnItem.GetController("ctrlType").SetSelectedPage(info.AttrName);
            btnItem.GetChild("tfCur").text = info.CurValue.ToString();
            btnItem.GetChild("tfNext").text = info.NextValue.ToString();
        }

        //empty item 
    }

    private string OnItemProvider(int index)
    {
        if (_slotUpgradeInfoList != null && index < _slotUpgradeInfoList.Count)
        {
            return UIPackage.GetItemURL(eFUIPackage.Player.ToString(), "comAttrDiffItem");
        }

        return _lstAttr.defaultItem;
    }

    private void OnRechargeMeldStatusChanged(bool recharging)
    {
        SetBtnLoadingStatus(_btnUpgrade, recharging);
    }
}