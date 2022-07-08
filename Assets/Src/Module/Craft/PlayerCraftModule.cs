/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 角色合成
 * @Date: 2022-06-29 11:26:09
 * @FilePath: /Assets/Src/Module/Craft/PlayerCraftModule.cs
 */
using UnityEngine;
using System;
using Runtime;

public class PlayerCraftModule : MonoBehaviour
{
    public Action OnSkillInfoUpdated = delegate { };
    public Action OnUnlockedRecipesUpdated = delegate { };
    public Action<int> OnGameMeldCountUpdated = delegate { };
    public Action OnSyntheticSuccess = delegate { };
    public UserSkillInfo[] Skills { get; private set; }
    public int RoleExp { get; private set; }
    public int RoleLv { get; private set; }
    public int[] UnlockedRecipes { get; private set; }
    public int MeldCount { get; private set; }

    public void OpenFormPlayerInfo()
    {
        _ = UICenter.OpenUIForm<FormPlayerInfo>();
        GetUserSkillInfoAction.Req();
        GetUserGameInternalTokenAction.Req();
        GetUnlockedRecipesAction.Req();
    }

    public void UpgradeSkill(string skillID, int meldCost)
    {
        HandleUpgrade(skillID, meldCost);
    }

    public async void HandleUpgrade(string skillID, int meldCost)
    {
        MLog.Info(eLogTag.craft, $"recharge meld {meldCost} before upgrade skill {skillID}");
        await SceneModule.Recharge.RechargeMeld(meldCost);
        MLog.Info(eLogTag.craft, $"recharge meld {meldCost} success,req upgrade skill {skillID}");
        UpgradeSkillAction.Req(skillID).SetCB(OnSkillUpgrade);
    }

    public void UseRecipes(int recipesID, int num, int meldCost)
    {
        HandleUseRecipes(recipesID, num, meldCost);
        // _useRecipesTask = new();
        // return _useRecipesTask.Task;
    }

    private async void HandleUseRecipes(int recipesID, int num, int meldCost)
    {
        try
        {
            MLog.Info(eLogTag.craft, $"recharge meld {meldCost} before use recipes {recipesID}");
            await SceneModule.Recharge.RechargeMeld(meldCost);
            MLog.Info(eLogTag.craft, $"recharge meld {meldCost} success,req use recipes {recipesID}");
            UseRecipesAction.Req(recipesID, num).SetCB(OnUseRecipes);
        }
        catch (Exception e)
        {
            MLog.Error(eLogTag.craft, $"recharge meld {meldCost} failed,req use recipes {recipesID}");
        }
    }

    // public UniTask<int> RechargeMeld(int meld)
    // {
    //     _rechargeMeldTask = new();
    //     MeldRecharging = true;
    //     OnRechargeMeld.Invoke();
    //     RechargeTokenAction.Req(meld).SetCB(OnChargeMeldResponse);
    //     return _rechargeMeldTask.Task;
    // }

    public void GetUserGameMeld()
    {
        GetUserGameInternalTokenAction.Req();
    }

    public void SetSkillInfo(GetUserSkillInfoResponse rsp)
    {
        Skills = rsp.Skills;
        RoleLv = rsp.RoleLv;
        RoleExp = rsp.RoleExp;
        OnSkillInfoUpdated.Invoke();
    }

    private void OnSkillUpgrade(UpgradeSkillResponse rsp)
    {
        GetUserSkillInfoAction.Req();
        GetUnlockedRecipesAction.Req();
    }

    private void OnUseRecipes(UseRecipesResponse rsp)
    {
        GetUserGameInternalTokenAction.Req();
        _ = UICenter.OpenUIToast<ToastCommon>("Synthetic successfully");
    }

    public void SetUnlockedRecipes(int[] unlockedRecipes)
    {
        UnlockedRecipes = unlockedRecipes;
        OnUnlockedRecipesUpdated.Invoke();
    }

    public int GetMaxSyntheticNum(DRRecipes recipes)
    {
        int maxNum = int.MaxValue;
        foreach (int[] itemInfo in recipes.MatItemId)
        {
            if (itemInfo.Length == 2)
            {
                int itemId = itemInfo[0];
                int itemNeedNum = itemInfo[1];
                int hasItemNum = DataManager.Backpack.GetItemCount(itemId);
                int canSyntheticNum = hasItemNum / itemNeedNum;
                maxNum = Math.Min(maxNum, canSyntheticNum);
            }
        }

        int meldLimit = MeldCount / recipes.UseMELD;

        maxNum = Math.Min(99, Math.Min(maxNum, meldLimit));
        return maxNum;
    }

    public void SetMeldCount(int meldCount)
    {
        MeldCount = meldCount;
        OnGameMeldCountUpdated.Invoke(meldCount);
    }

    public bool CheckRecipeUnlocked(int id)
    {
        if (UnlockedRecipes == null || UnlockedRecipes.Length == 0)
        {
            return false;
        }

        foreach (int item in UnlockedRecipes)
        {
            if (item == id)
            {
                return true;
            }
        }

        return false;
    }
}