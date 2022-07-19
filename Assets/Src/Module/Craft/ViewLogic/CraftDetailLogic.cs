using System;
using System.Collections.Generic;
using System.IO;
using FairyGUI;
using static SceneModule;
/// <summary>
/// 合成详情界面逻辑类，两个地方使用，这里抽出来共用
/// </summary>
public class CraftDetailLogic : FGUILogicCpt
{
    private Controller _ctrlMeldEnough;
    private Controller _ctrlNeedMat;
    private GList _lstProducts;
    private GList _lstMat;
    private GTextField _tfQuantity;
    private GSlider _sldQuantity;
    private GTextField _tfMaxQuantity;
    private GTextField _tfMeldCost;
    private GButton _btnAdd;
    private GButton _btnSub;
    private GButton _btnConfirm;
    private DRRecipes _recipesCfg;

    private List<int> _recipesIdList;
    private int[][] _matIdList;

    protected override void OnAdd()
    {
        base.OnAdd();
        _ctrlMeldEnough = GCom.GetController("ctrlMeldEnough");
        _ctrlNeedMat = GCom.GetController("ctrlNeedMat");
        _lstProducts = (GList)GCom.GetChild("lstProducts");
        _lstMat = (GList)GCom.GetChild("lstMat");
        _tfQuantity = (GTextField)GCom.GetChild("tfQuantity");
        _sldQuantity = (GSlider)GCom.GetChild("sldQuantity");
        _tfMaxQuantity = (GTextField)GCom.GetChild("tfMaxQuantity");
        _tfMeldCost = (GTextField)GCom.GetChild("tfMeldCost");
        _btnAdd = (GButton)GCom.GetChild("btnAdd");
        _btnSub = (GButton)GCom.GetChild("btnSub");
        _btnConfirm = (GButton)GCom.GetChild("btnConfirm");

        _lstProducts.itemRenderer = OnProductItemRenderer;
        _lstMat.itemRenderer = OnMatItemRenderer;
    }

    public override void OnOpen()
    {
        base.OnOpen();
        AddUIEvent();
        AddMessage();
    }

    public override void OnClose()
    {
        RemoveUIEvent();
        RemoveMessage();
        base.OnClose();
    }

    private void AddUIEvent()
    {
        _lstProducts.onClickItem.Add(OnProductItemClick);
        _lstMat.onClickItem.Add(OnMatItemClick);
        _btnConfirm.onClick.Add(OnConfirmClick);
        _btnAdd.onClick.Add(OnAddClick);
        _btnSub.onClick.Add(OnSubClick);
        _sldQuantity.onChanged.Add(OnQuantityChanged);
    }

    private void RemoveUIEvent()
    {
        _lstProducts.onClickItem.Remove(OnProductItemClick);
        _lstMat.onClickItem.Remove(OnMatItemClick);
        _btnConfirm.onClick.Remove(OnConfirmClick);
        _btnAdd.onClick.Remove(OnAddClick);
        _btnSub.onClick.Remove(OnSubClick);
        _sldQuantity.onChanged.Remove(OnQuantityChanged);
    }

    private void AddMessage()
    {
        SceneModule.BackpackMgr.OnDataUpdated += OnBackpackChanged;
        SceneModule.BackpackMgr.OnDataAdded += OnBackpackChanged;
        SceneModule.BackpackMgr.OnDataRemoved += OnBackpackChanged;
        Craft.OnGameMeldCountUpdated += OnMeldCountUpdated;
        Craft.OnUnlockedRecipesUpdated += OnUnlockedRecipesUpdated;
        Recharge.OnRechargeMeldStatusChanged += OnRechargeMeldStatusChanged;
    }

    private void RemoveMessage()
    {
        SceneModule.BackpackMgr.OnDataUpdated -= OnBackpackChanged;
        SceneModule.BackpackMgr.OnDataAdded -= OnBackpackChanged;
        SceneModule.BackpackMgr.OnDataRemoved -= OnBackpackChanged;
        Craft.OnGameMeldCountUpdated -= OnMeldCountUpdated;
        Craft.OnUnlockedRecipesUpdated -= OnUnlockedRecipesUpdated;
        Recharge.OnRechargeMeldStatusChanged -= OnRechargeMeldStatusChanged;
    }

    public void UpdateView(List<int> recipeIDList)
    {
        _recipesIdList = recipeIDList;
        UpdateProductsList();
    }

    private void OnProductItemRenderer(int index, GObject item)
    {
        int recipeId = _recipesIdList[index];
        DRRecipes drRecipes = GFEntry.DataTable.GetDataTable<DRRecipes>().GetDataRow(recipeId);
        DRItem drItem = GFEntry.DataTable.GetDataTable<DRItem>().GetDataRow(drRecipes.ProductId[0][0]);
        if (drItem != null)
        {
            item.icon = Path.Combine(AssetDefine.PATH_ITEM_ICON, $"{drItem.Icon}.png");
        }
        item.grayed = !Craft.CheckRecipeUnlocked(drRecipes.Id);
    }

    private void OnMatItemRenderer(int index, GObject item)
    {
        int itemID = _matIdList[index][0];
        int itemNeed = _matIdList[index][1] * (int)_sldQuantity.value;
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

    private void OnProductItemClick(EventContext context)
    {
        SelectRecipes(_lstProducts.selectedIndex);
    }

    private void OnMatItemClick(EventContext context)
    {
        GObject obj = context.data as GObject;
        _ = UICenter.OpenUITooltip<TooltipSyntheticMatDetail>(new TooltipInfo(obj, obj.data, eTooltipDir.Left));
    }

    private void OnConfirmClick(EventContext context)
    {
        int value = (int)_sldQuantity.value;
        Craft.UseRecipes(_recipesCfg.Id, value, _recipesCfg.UseMELD * value);
    }

    private void OnAddClick(EventContext context)
    {
        if (_sldQuantity.value < _sldQuantity.max)
        {
            _sldQuantity.value++;
        }
        OnQuantityChanged();
    }

    private void OnSubClick(EventContext context)
    {
        if (_sldQuantity.value > _sldQuantity.min)
        {
            _sldQuantity.value--;
        }
        OnQuantityChanged();
    }

    private void OnQuantityChanged()
    {
        UpdateQuantity();
        UpdateRecipesMeldCost();
    }

    private void UpdateProductsList()
    {
        _lstProducts.numItems = _recipesIdList.Count;
        _lstProducts.selectedIndex = 0;
        SelectRecipes(0);
    }

    private void SelectRecipes(int index)
    {
        _recipesCfg = GFEntry.DataTable.GetDataTable<DRRecipes>().GetDataRow(_recipesIdList[index]);
        InitQuantity();
        UpdateQuantity();
        UpdateMaterial();
        UpdateRecipesMeldCost();
        UpdateConfirmBtn();
    }

    private void InitQuantity(int initValue = 1)
    {
        int canSyntheticNum = Craft.GetMaxSyntheticNum(_recipesCfg);
        _sldQuantity.min = 1;
        _sldQuantity.max = canSyntheticNum > 0 ? canSyntheticNum : 1;
        _sldQuantity.value = Math.Max(1, Math.Clamp(initValue, _sldQuantity.min, _sldQuantity.max));

        GCom.GetChild("grpNumSld").visible = _sldQuantity.max > 1;
        _tfMaxQuantity.text = _sldQuantity.max.ToString();
        _tfQuantity.SetVar("num", ((int)_sldQuantity.value).ToString()).FlushVars();
    }

    private void UpdateQuantity()
    {
        UIUtil.SetBtnEnable(_btnAdd, _sldQuantity.value < _sldQuantity.max);
        UIUtil.SetBtnEnable(_btnSub, _sldQuantity.value > _sldQuantity.min);
        _tfQuantity.SetVar("num", ((int)_sldQuantity.value).ToString()).FlushVars();
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
        int curMeld = Craft.MeldCount;
        int needMeld = _recipesCfg.UseMELD * (int)_sldQuantity.value;
        _tfMeldCost
            .SetVar("cur", curMeld.ToString())
            .SetVar("need", needMeld.ToString())
            .FlushVars();
    }

    private void UpdateConfirmBtn()
    {
        int canSyntheticNum = Craft.GetMaxSyntheticNum(_recipesCfg);
        UIUtil.SetBtnEnable(_btnConfirm, canSyntheticNum > 0 && Craft.CheckRecipeUnlocked(_recipesCfg.Id));
        UIUtil.SetBtnLoadingStatus(_btnConfirm, Recharge.IsMeldRecharging);
    }

    private void OnBackpackChanged()
    {
        InitQuantity((int)_sldQuantity.value);
        UpdateMaterial();
        UpdateConfirmBtn();
    }

    private void OnMeldCountUpdated(int count)
    {
        UpdateRecipesMeldCost();
        UpdateConfirmBtn();
    }

    private void OnRechargeMeldStatusChanged(bool isRecharging)
    {
        UIUtil.SetBtnLoadingStatus(_btnConfirm, isRecharging);
    }

    private void OnUnlockedRecipesUpdated()
    {
        UpdateProductsList();
    }
}