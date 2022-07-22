using System.Collections.Generic;
using System.IO;
using FairyGUI;
/// <summary>
/// 合成界面
/// </summary>
public class FormCraft : FGUIForm
{
    private CraftDetailLogic _craftLogic;
    private Controller _ctrlLvFilter;
    private Controller _ctrlEmpty;
    private GTextInput _inpSearch;
    private GTextField _tfProductName;
    private GList _lstType;
    private GList _lstRecipes;
    private GList _lstLevelFilter;
    private GButton _btnLvFilter;
    private List<DRRecipes> _recipeList = new();
    private Dictionary<int, int> _recipeLevelDic = new();

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        _ctrlLvFilter = GetController("ctrlLvFilter");
        _ctrlEmpty = GetController("ctrlEmpty");
        _inpSearch = GetTextInput("inpSearch");
        _tfProductName = GetTextField("tfProductName");
        _lstType = GetList("lstType");
        _btnLvFilter = GetButton("btnLvFilter");
        _lstRecipes = GetList("lstRecipes");
        _lstLevelFilter = GetCom("comLvFilter").GetChild("lstLvFilter").asList;

        _lstRecipes.itemRenderer = OnRecipesItemRenderer;
        _lstLevelFilter.itemRenderer = OnLevelFilterItemRenderer;
        _craftLogic = GCom.AddUILogic<CraftDetailLogic>();
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        AddMessage();
        AddUIEvent();
        UpdateLevelFilter();
        UpdateRecipesList();
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        RemoveMessage();
        base.OnClose(isShutdown, userData);
    }

    private void AddUIEvent()
    {
        _inpSearch.onChanged.Add(OnSearchChanged);
        _lstType.onClickItem.Add(OnTypeItemClick);
        _lstRecipes.onClickItem.Add(OnRecipesItemClick);
        _lstLevelFilter.onClickItem.Add(OnLevelFilterItemClick);
        GCom.onClick.Add(OnComClick);
    }

    private void AddMessage()
    {
        SceneModule.Craft.OnUnlockedRecipesUpdated += OnUnlockedRecipesUpdated;
    }

    private void RemoveMessage()
    {
        SceneModule.Craft.OnUnlockedRecipesUpdated -= OnUnlockedRecipesUpdated;
    }

    private void OnComClick(EventContext context)
    {
        // _ctrlLvFilter.SetSelectedPage("hide");
    }

    private void OnSearchChanged()
    {
        UpdateRecipesList();
    }

    private void OnRecipesItemRenderer(int index, GObject item)
    {
        DRRecipes drRecipe = _recipeList[index];
        item.icon = Path.Combine(AssetDefine.PATH_ITEM_ICON, $"{drRecipe.Icon}.png");
        item.data = _recipeList[index];

        bool able = SceneModule.Craft.CheckRecipeUnlocked(drRecipe.Id);
        item.asCom.GetController("ctrlAble").SetSelectedPage(able ? "able" : "disable");
    }

    private void OnLevelFilterItemRenderer(int index, GObject item)
    {
        GButton btnItem = item.asButton;
        if (index == 0)
        {
            btnItem.GetChild("title").asTextField
           .SetVar("begin", "0")
           .SetVar("end", (PlayerCraftModule.CRAFT_MAX_LEVEL * 10).ToString())
           .FlushVars();
        }
        else
        {
            btnItem.GetChild("title").asTextField
            .SetVar("begin", ((index - 1) * 10).ToString())
            .SetVar("end", (index * 10).ToString())
            .FlushVars();
        }
    }

    private void OnTypeItemClick()
    {
        UpdateRecipesList();
        if (_lstRecipes.numItems > 0 && _lstRecipes.selectedIndex != -1)
        {
            SelectRecipes(_lstRecipes.selectedIndex);
        }
    }

    private void OnRecipesItemClick(EventContext context)
    {
        SelectRecipes(_lstRecipes.selectedIndex);
    }

    private void OnLevelFilterItemClick(EventContext context)
    {
        _ctrlLvFilter.SetSelectedPage("hide");
        GTextField title = _btnLvFilter.GetChild("title").asTextField;
        GTextField clickTitle = ((GButton)context.data).GetChild("title").asTextField;
        title.templateVars = clickTitle.templateVars;
        UpdateRecipesList();
    }

    private void UpdateRecipesList()
    {
        _recipeList.Clear();
        List<DRRecipes> recipeList = RecipesTable.Inst.GetRecipeIDListWithDisplayType(PlayerCraftModule.eRecipeDisplayType.Craft);
        if (recipeList == null)
        {
            return;
        }

        foreach (DRRecipes recipe in recipeList)
        {
            if (FilterRecipe(recipe))
            {
                _recipeList.Add(recipe);
            }
        }

        _ctrlEmpty.SetSelectedPage(_recipeList.Count == 0 ? "yes" : "no");
        _lstRecipes.numItems = _recipeList.Count;
        if (_lstRecipes.numItems != 0)
        {
            if (_lstRecipes.selectedIndex == -1)
            {
                _lstRecipes.selectedIndex = 0;
            }
            SelectRecipes(_lstRecipes.selectedIndex);
        }
    }

    private void UpdateLevelFilter()
    {
        _lstLevelFilter.numItems = PlayerCraftModule.CRAFT_MAX_LEVEL + 1;
        if (_lstLevelFilter.numItems != 0 && _lstLevelFilter.selectedIndex == -1)
        {
            _lstLevelFilter.selectedIndex = 0;
        }
    }

    private void SelectRecipes(int index)
    {
        GCom.GetChild("grpProduct").visible = true;
        DRRecipes recipe = _recipeList[index];
        DRItem drItem = GFEntry.DataTable.GetDataTable<DRItem>().GetDataRow(recipe.ProductId[0][0]);
        _tfProductName.text = drItem?.Name;
        _craftLogic.UpdateView(recipe.Id);
    }

    private void OnUnlockedRecipesUpdated()
    {
        UpdateRecipesList();
    }

    private bool FilterRecipe(DRRecipes drRecipe)
    {
        if (drRecipe == null)
        {
            return false;
        }

        if (_inpSearch.text.Length != 0)
        {
            if (drRecipe.Name.IndexOf(_inpSearch.text) == -1)
            {
                return false;
            }
        }

        if (drRecipe.UnlockType == 3)
        {
            return false;
        }

        if (_lstType.selectedIndex != -1)
        {
            PlayerCraftModule.eCraftType curType = _lstType.GetChildAt(_lstType.selectedIndex).name.ToEnum<PlayerCraftModule.eCraftType>();
            if (drRecipe.CraftSkill != (int)curType)
            {
                return false;
            }
        }

        if (_lstLevelFilter.selectedIndex > 0)
        {
            if (drRecipe.ClassifyLevel / 10 != (_lstLevelFilter.selectedIndex - 1) * 10)
            {
                return false;
            }
        }

        return true;
    }
}