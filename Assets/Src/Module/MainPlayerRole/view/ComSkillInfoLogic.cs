/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 
 * @Date: 2022-06-29 15:32:36
 * @FilePath: /Assets/Src/Module/MainPlayerRole/view/ComSkillInfoLogic.cs
 */
using System.IO;
using System;
using FairyGUI;
using System.Collections.Generic;
using Runtime;
using static SceneModule;

public class ComSkillInfLogic : FGUILogicCpt
{
    private Controller _ctrlNeedMat;
    private GList _lstSkillItem;
    private GButton _btnSkillIcon;
    private GProgressBar _comRoleExp;
    private GProgressBar _comProficiency;
    private GButton _btnExpHelp;
    private GProgressBar _comMeld;
    private GButton _btnUpgrade;
    private GButton _btnLevelMax;
    private GButton _btnSynthetic;
    private GList _lstRecipes;
    private GList _lstMat;
    private GRichTextField _tfMeldCost;
    private GButton _btnAdd;
    private GButton _btnSub;
    private GTextField _tfMax;
    private GTextField _tfQuantity;
    private GSlider _sldSynthetic;

    private List<int> _recipesIdList;
    private int[][] _matIdList;
    private UserSkillInfo _skillInfo;
    private DRCraftSkill _nextLvSkillCfg;
    private DRRecipes _recipesCfg;

    protected override void OnAdd()
    {
        base.OnAdd();
        _ctrlNeedMat = GCom.GetController("ctrlNeedMat");
        _lstSkillItem = (GList)GCom.GetChild("lstSkillItem");
        _btnSkillIcon = (GButton)GCom.GetChild("btnSkillIcon");
        _comProficiency = (GProgressBar)GCom.GetChild("comProficiency");
        _comRoleExp = (GProgressBar)GCom.GetChild("comRoleExp");
        _btnExpHelp = (GButton)GCom.GetChild("btnExpHelp");
        _comMeld = (GProgressBar)GCom.GetChild("comMeld");
        _btnUpgrade = (GButton)GCom.GetChild("btnUpgrade");
        _btnLevelMax = (GButton)GCom.GetChild("btnLevelMax");
        _btnSynthetic = (GButton)GCom.GetChild("btnSynthetic");
        _lstRecipes = (GList)GCom.GetChild("lstRecipes");
        _lstMat = (GList)GCom.GetChild("lstMat");
        _tfMeldCost = (GRichTextField)GCom.GetChild("tfMeldCost");
        _btnAdd = (GButton)GCom.GetChild("btnAdd");
        _btnSub = (GButton)GCom.GetChild("btnSub");
        _tfMax = (GTextField)GCom.GetChild("tfMax");
        _tfQuantity = (GTextField)GCom.GetChild("tfQuantity");
        _sldSynthetic = (GSlider)GCom.GetChild("sldSynthetic");

        _lstRecipes.itemRenderer = OnRecipesItemRenderer;
        _lstMat.itemRenderer = OnMatItemRenderer;
        _lstSkillItem.selectedIndex = 0;
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
        _lstRecipes.onClickItem.Add(OnRecipeItemClick);
        _lstMat.onClickItem.Add(OnMatItemClick);
        _btnUpgrade.onClick.Add(OnUpgradeClick);
        _btnSynthetic.onClick.Add(OnSyntheticClick);
        _btnAdd.onClick.Add(OnAddClick);
        _btnSub.onClick.Add(OnSubClick);
        _btnExpHelp.onClick.Add(OnExpHelpClick);
        _sldSynthetic.onChanged.Add(OnSyntheticChanged);
    }

    private void RemoveUIEvent()
    {
        _lstSkillItem.onClickItem.Remove(OnSkillItemClick);
        _lstRecipes.onClickItem.Remove(OnRecipeItemClick);
        _lstMat.onClickItem.Remove(OnMatItemClick);
        _btnUpgrade.onClick.Remove(OnUpgradeClick);
        _btnSynthetic.onClick.Remove(OnSyntheticClick);
        _btnAdd.onClick.Remove(OnAddClick);
        _btnSub.onClick.Remove(OnSubClick);
        _btnExpHelp.onClick.Remove(OnExpHelpClick);
        _sldSynthetic.onChanged.Remove(OnSyntheticChanged);
    }

    private void AddMessage()
    {
        SceneModule.BackpackMgr.OnDataUpdated += OnBackpackChanged;
        SceneModule.BackpackMgr.OnDataAdded += OnBackpackChanged;
        SceneModule.BackpackMgr.OnDataRemoved += OnBackpackChanged;
        Craft.OnSkillInfoUpdated += OnSkillInfoUpdated;
        Craft.OnGameMeldCountUpdated += OnMeldCountUpdated;
        Craft.OnUnlockedRecipesUpdated += OnUnlockedRecipesUpdated;
        Recharge.OnRechargeMeldStatusChanged += OnRechargeMeldStatusChanged;
    }

    private void RemoveMessage()
    {
        SceneModule.BackpackMgr.OnDataUpdated -= OnBackpackChanged;
        SceneModule.BackpackMgr.OnDataAdded -= OnBackpackChanged;
        SceneModule.BackpackMgr.OnDataRemoved -= OnBackpackChanged;
        Craft.OnSkillInfoUpdated -= OnSkillInfoUpdated;
        Craft.OnGameMeldCountUpdated -= OnMeldCountUpdated;
        Craft.OnUnlockedRecipesUpdated -= OnUnlockedRecipesUpdated;
        Recharge.OnRechargeMeldStatusChanged -= OnRechargeMeldStatusChanged;
    }

    private void OnSkillItemClick(EventContext context)
    {
        SelectSkillItem(_lstSkillItem.selectedIndex);
    }

    private void OnRecipeItemClick(EventContext context)
    {
        SelectRecipes(_lstRecipes.selectedIndex);
    }

    private void OnMatItemClick(EventContext context)
    {
        GObject obj = context.data as GObject;
        _ = UICenter.OpenUITooltip<TooltipItem>(new TooltipInfo(obj, obj.data, eTooltipDir.Left));
    }

    private void OnUpgradeClick(EventContext context)
    {
        Craft.UpgradeSkill(_skillInfo.Id, _nextLvSkillCfg.UseMELD);
    }

    private void OnSyntheticClick(EventContext context)
    {
        _btnSynthetic.touchable = false;
        int value = (int)_sldSynthetic.value;
        Craft.UseRecipes(_recipesCfg.Id, value, _recipesCfg.UseMELD * value);
    }

    private void OnAddClick(EventContext context)
    {
        if (_sldSynthetic.value < _sldSynthetic.max)
        {
            _sldSynthetic.value++;
        }
        OnSyntheticChanged();
    }

    private void OnSubClick(EventContext context)
    {
        if (_sldSynthetic.value > _sldSynthetic.min)
        {
            _sldSynthetic.value--;
        }
        OnSyntheticChanged();
    }

    private void OnExpHelpClick()
    {
        _ = UICenter.OpenUIAlert<AlertCommon>(new AlertData("SKILL", $"Do you spend{_skillInfo.Exp} and {Craft.MeldCount} to upgrade your skills?"));
    }

    private void OnSyntheticChanged()
    {
        UpdateSyntheticNum();
        UpdateRecipesMeldCost();
    }

    private void OnSkillItemRenderer(int index, GObject item)
    {
        UserSkillInfo skillInfo = Craft.Skills[index];
        DRCraftSkill drSkill = CraftSkillTable.Inst.GetRow(Convert.ToInt32(skillInfo.Id), skillInfo.Lv);
        GButton btn = (GButton)item.asCom;
        btn.GetChild("tfLv").asTextField.SetVar("lv", skillInfo.Lv.ToString()).FlushVars();
        btn.data = drSkill;
    }

    private void OnRecipesItemRenderer(int index, GObject item)
    {
        DRRecipes drRecipes = GFEntry.DataTable.GetDataTable<DRRecipes>().GetDataRow(_recipesIdList[index]);
        GButton btn = (GButton)item.asCom;
        btn.icon = Path.Combine(AssetDefine.PATH_ITEM_ICON, $"{drRecipes.Icon}.png");
        btn.data = drRecipes;
        btn.grayed = !Craft.CheckRecipeUnlocked(drRecipes.Id);
    }

    private void OnMatItemRenderer(int index, GObject item)
    {
        int itemID = _matIdList[index][0];
        int itemNeed = _matIdList[index][1] * (int)_sldSynthetic.value;
        int itemHas = DataManager.Backpack.GetItemCount(itemID);
        DRItem drItem = GFEntry.DataTable.GetDataTable<DRItem>().GetDataRow(itemID);
        GButton btn = (GButton)item.asCom;
        if (drItem != null)
        {
            btn.data = drItem.Id;
            btn.icon = Path.Combine(AssetDefine.PATH_ITEM_ICON, $"{drItem.Icon}.png");
            btn.GetController("ctrlTextColor").SetSelectedPage(itemHas >= itemNeed ? "green" : "red");
            btn.GetChild("title").asTextField
                .SetVar("cur", itemHas.ToString())
                .SetVar("need", itemNeed.ToString())
                .FlushVars();
        }
    }

    public void UpdateView()
    {
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
        UpdateRecipesList();
    }

    private void SelectRecipes(int index)
    {
        _recipesCfg = GFEntry.DataTable.GetDataTable<DRRecipes>().GetDataRow(_recipesIdList[index]);
        InitSyntheticNum();
        UpdateSyntheticNum();
        UpdateMaterial();
        UpdateRecipesMeldCost();
        UpdateSyntheticBtn();
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
        SetBtnLoadingStatus(_btnUpgrade, Recharge.IsMeldRecharging);

        _btnLevelMax.visible = _skillInfo.Lv >= DataManager.MainPlayer.RoleLv;
        _btnUpgrade.visible = !_btnLevelMax.visible;
    }

    private void UpdateRecipesList()
    {
        _recipesIdList = CraftSkillTable.Inst.GetSkillRecipes(Convert.ToInt32(_skillInfo.Id));
        _lstRecipes.numItems = _recipesIdList.Count;
        _lstRecipes.selectedIndex = 0;
        SelectRecipes(0);
    }

    private void InitSyntheticNum(int initValue = 1)
    {
        int canSyntheticNum = Craft.GetMaxSyntheticNum(_recipesCfg);
        _sldSynthetic.min = 1;
        _sldSynthetic.max = canSyntheticNum > 0 ? canSyntheticNum : 1;
        _sldSynthetic.value = Math.Max(1, Math.Clamp(initValue, _sldSynthetic.min, _sldSynthetic.max));

        GCom.GetChild("grpNumSld").visible = _sldSynthetic.max > 1;
        _tfMax.text = _sldSynthetic.max.ToString();
        _tfQuantity.SetVar("num", ((int)_sldSynthetic.value).ToString()).FlushVars();
    }

    private void UpdateSyntheticNum()
    {
        SetBtnEnable(_btnAdd, _sldSynthetic.value < _sldSynthetic.max);
        SetBtnEnable(_btnSub, _sldSynthetic.value > _sldSynthetic.min);
        _tfQuantity.SetVar("num", ((int)_sldSynthetic.value).ToString()).FlushVars();
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        _lstMat.RemoveChildrenToPool();
        if (_recipesCfg.MatItemId.Length > 0 && _recipesCfg.MatItemId[0].Length > 1)
        {
            _ctrlNeedMat.SetSelectedPage("yes");
            _matIdList = _recipesCfg.MatItemId;
            _lstMat.numItems = _recipesCfg.MatItemId.Length;
        }
        else
        {
            _ctrlNeedMat.SetSelectedPage("no");
        }
    }

    private void UpdateRecipesMeldCost()
    {
        GObject item = _lstRecipes.GetChildAt(_lstRecipes.selectedIndex);
        DRRecipes recipes = item.data as DRRecipes;
        int curMeld = Craft.MeldCount;
        int needMeld = recipes.UseMELD * (int)_sldSynthetic.value;
        _tfMeldCost
            .SetVar("cur", curMeld.ToString())
            .SetVar("need", needMeld.ToString())
            .FlushVars();
    }

    private void SetBtnLoadingStatus(GButton btn, bool isLoading)
    {
        btn.GetController("ctrlLoading").SetSelectedPage(isLoading ? "loading" : "normal");
        btn.touchable = !isLoading && !btn.grayed;
    }

    private void OnSkillInfoUpdated()
    {
        UpdateLstSkill();
    }

    private void OnBackpackChanged()
    {
        InitSyntheticNum((int)_sldSynthetic.value);
        UpdateMaterial();
        UpdateSyntheticBtn();
    }

    private void OnMeldCountUpdated(int count)
    {
        if (_skillInfo == null || _nextLvSkillCfg == null)
        {
            return;
        }

        UpdateSkillMeldCost();
        UpdateRecipesMeldCost();
        UpdateSyntheticBtn();
    }

    private void OnUnlockedRecipesUpdated()
    {
        if (_skillInfo == null || _nextLvSkillCfg == null)
        {
            return;
        }
        UpdateRecipesList();
    }

    private void OnRechargeMeldStatusChanged(bool recharging)
    {
        SetBtnLoadingStatus(_btnUpgrade, recharging);
        SetBtnLoadingStatus(_btnSynthetic, recharging);
    }

    private void UpdateSyntheticBtn()
    {
        int canSyntheticNum = Craft.GetMaxSyntheticNum(_recipesCfg);
        SetBtnEnable(_btnSynthetic, canSyntheticNum > 0 && Craft.CheckRecipeUnlocked(_recipesCfg.Id));
        SetBtnLoadingStatus(_btnSynthetic, Recharge.IsMeldRecharging);
    }

    private void SetBtnEnable(GButton btn, bool enable)
    {
        btn.touchable = enable;
        btn.grayed = !enable;
    }
}