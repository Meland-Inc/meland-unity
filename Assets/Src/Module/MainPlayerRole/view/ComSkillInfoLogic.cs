/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 
 * @Date: 2022-06-29 15:32:36
 * @FilePath: /Assets/Src/Module/MainPlayerRole/view/ComSkillInfoLogic.cs
 */
using System;
using System.Collections.Generic;
using FairyGUI;
using Runtime;
using static SceneModule;

public class ComSkillInfLogic : FGUILogicCpt
{
    private GList _lstSkillItem;
    private GButton _btnSkillIcon;
    private GProgressBar _comRoleExp;
    private GProgressBar _comProficiency;
    private GButton _btnExpHelp;
    private GProgressBar _comMeld;
    private GButton _btnUpgrade;
    private GButton _btnLevelMax;
    private UserSkillInfo _skillInfo;
    private DRCraftSkill _nextLvSkillCfg;

    private CraftDetailLogic _craftDetailLogic;

    protected override void OnAdd()
    {
        base.OnAdd();
        _lstSkillItem = (GList)GCom.GetChild("lstSkillItem");
        _btnSkillIcon = (GButton)GCom.GetChild("btnSkillIcon");
        _comProficiency = (GProgressBar)GCom.GetChild("comProficiency");
        _comRoleExp = (GProgressBar)GCom.GetChild("comRoleExp");
        _btnExpHelp = (GButton)GCom.GetChild("btnExpHelp");
        _comMeld = (GProgressBar)GCom.GetChild("comMeld");
        _btnUpgrade = (GButton)GCom.GetChild("btnUpgrade");
        _btnLevelMax = (GButton)GCom.GetChild("btnLevelMax");

        _craftDetailLogic = GCom.AddUILogic<CraftDetailLogic>();
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
        _lstSkillItem.onClickItem.Add(OnSkillItemClick);
        _btnUpgrade.onClick.Add(OnUpgradeClick);
        _btnExpHelp.onClick.Add(OnExpHelpClick);
    }

    private void RemoveUIEvent()
    {
        _lstSkillItem.onClickItem.Remove(OnSkillItemClick);
        _btnUpgrade.onClick.Remove(OnUpgradeClick);
        _btnExpHelp.onClick.Remove(OnExpHelpClick);
    }

    private void AddMessage()
    {
        Craft.OnSkillInfoUpdated += OnSkillInfoUpdated;
        Craft.OnGameMeldCountUpdated += OnMeldCountUpdated;
        Recharge.OnRechargeMeldStatusChanged += OnRechargeMeldStatusChanged;
    }

    private void RemoveMessage()
    {
        Craft.OnSkillInfoUpdated -= OnSkillInfoUpdated;
        Craft.OnGameMeldCountUpdated -= OnMeldCountUpdated;
        Recharge.OnRechargeMeldStatusChanged -= OnRechargeMeldStatusChanged;
    }

    private void OnSkillItemClick(EventContext context)
    {
        SelectSkillItem(_lstSkillItem.selectedIndex);
    }

    private void OnUpgradeClick(EventContext context)
    {
        Craft.UpgradeSkill(_skillInfo.Id, _nextLvSkillCfg.UseMELD);
    }

    private void OnExpHelpClick()
    {
        _ = UICenter.OpenUIAlert<AlertCommon>(new AlertData("SKILL", $"Do you spend{_skillInfo.Exp} and {Craft.MeldCount} to upgrade your skills?"));
    }

    private void OnSkillItemRenderer(int index, GObject item)
    {
        UserSkillInfo skillInfo = Craft.Skills[index];
        DRCraftSkill drSkill = CraftSkillTable.Inst.GetRow(Convert.ToInt32(skillInfo.Id), skillInfo.Lv);
        GButton btn = (GButton)item.asCom;
        btn.GetChild("tfLv").asTextField.SetVar("lv", skillInfo.Lv.ToString()).FlushVars();
        btn.data = drSkill;
    }

    public void UpdateView()
    {
        UpdateLstSkill();
        SelectSkillItem(_lstSkillItem.selectedIndex);
    }

    private void SelectSkillItem(int index)
    {
        _skillInfo = Craft.Skills[index];
        _nextLvSkillCfg = CraftSkillTable.Inst.GetNextLvRow(Convert.ToInt32(_skillInfo.Id), _skillInfo.Lv);
        UpdateSkillIcon();
        UpdateProficiency();
        UpdateRoleExp();
        UpdateSkillMeldCost();
        UpdateUpgradeBtn();

        List<int> idList = CraftSkillTable.Inst.GetSkillRecipes(Convert.ToInt32(_skillInfo.Id));
        _craftDetailLogic.UpdateView(idList);
    }

    private void UpdateLstSkill()
    {
        for (int i = 0; i < _lstSkillItem.numChildren; i++)
        {
            OnSkillItemRenderer(i, _lstSkillItem.GetChildAt(i));
        }
        SelectSkillItem(_lstSkillItem.selectedIndex);
    }

    private void UpdateSkillIcon()
    {
        GObject skillItem = _lstSkillItem.GetChildAt(_lstSkillItem.selectedIndex);
        _btnSkillIcon.icon = skillItem.icon;
        _btnSkillIcon.GetChild("tfLv1").asTextField.SetVar("lv", _skillInfo.Lv.ToString()).FlushVars();
    }

    private void UpdateProficiency()
    {
        _comProficiency.max = _nextLvSkillCfg.SkillExp;
        _comProficiency.value = _skillInfo.Exp;
    }

    private void UpdateRoleExp()
    {
        _comRoleExp.max = _nextLvSkillCfg.UseExp;
        _comRoleExp.value = Craft.RoleExp;
    }

    private void UpdateSkillMeldCost()
    {
        _comMeld.max = _nextLvSkillCfg.UseMELD;
        _comMeld.value = Craft.MeldCount;
    }

    private void UpdateUpgradeBtn()
    {
        bool canUpgrade = _skillInfo.Exp >= _nextLvSkillCfg.SkillExp
                            && Craft.MeldCount >= _nextLvSkillCfg.UseMELD
                            && Craft.RoleExp >= _nextLvSkillCfg.UseExp
                            && Craft.RoleLv >= _nextLvSkillCfg.RoleLevel;
        SetBtnEnable(_btnUpgrade, canUpgrade);
        UIUtil.SetBtnLoadingStatus(_btnUpgrade, Recharge.IsMeldRecharging);

        _btnLevelMax.visible = _skillInfo.Lv >= DataManager.MainPlayer.RoleLv;
        _btnUpgrade.visible = !_btnLevelMax.visible;
    }

    private void OnSkillInfoUpdated()
    {
        UpdateLstSkill();
    }

    private void OnMeldCountUpdated(int count)
    {
        if (_skillInfo == null || _nextLvSkillCfg == null)
        {
            return;
        }

        UpdateSkillMeldCost();
    }

    private void OnRechargeMeldStatusChanged(bool recharging)
    {
        UIUtil.SetBtnLoadingStatus(_btnUpgrade, recharging);
    }

    private void SetBtnEnable(GButton btn, bool enable)
    {
        btn.touchable = enable;
        btn.grayed = !enable;
    }
}