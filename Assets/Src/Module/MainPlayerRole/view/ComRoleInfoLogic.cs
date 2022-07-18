/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description:角色信息组件
 * @Date: 2022-06-22 15:46:49
 * @FilePath: /Assets/Src/Module/MainPlayerRole/view/ComRoleInfoLogic.cs
 */
using System;
using FairyGUI;
public class ComRoleInfoLogic : FGUILogicCpt
{
    private GTextField _tfName;
    private GTextField _tfLv;
    private GTextField _tfWallet;
    private GTextField _tfUpgradeTips;
    private GButton _btnCopy;
    private GButton _btnUpgrade;
    private GButton _btnLevelMax;
    private GProgressBar _comExp;
    private GList _lstAttr;

    protected override void OnAdd()
    {
        base.OnAdd();
        _tfName = GCom.GetChild("tfName") as GTextField;
        _tfLv = GCom.GetChild("tfLv") as GTextField;
        _tfWallet = GCom.GetChild("tfWallet") as GTextField;
        _tfUpgradeTips = GCom.GetChild("tfUpgradeTips") as GTextField;
        _btnCopy = GCom.GetChild("btnCopy") as GButton;
        _btnUpgrade = GCom.GetChild("btnUpgrade") as GButton;
        _btnLevelMax = GCom.GetChild("btnLevelMax") as GButton;
        _comExp = GCom.GetChild("comExp") as GProgressBar;
        _lstAttr = GCom.GetChild("lstAttr") as GList;
    }

    public override void OnOpen()
    {
        base.OnOpen();
        AddMessage();
        AddUIEvent();
        // UpdateView();
    }

    public override void OnClose()
    {
        base.OnClose();
        RemoveMessage();
        RemoveUIEvent();
    }

    private void AddMessage()
    {
        SceneModule.RoleLevel.OnRoleUpgraded += OnRoleUpgraded;
    }

    private void RemoveMessage()
    {
        SceneModule.RoleLevel.OnRoleUpgraded -= OnRoleUpgraded;
    }

    private void AddUIEvent()
    {
        _btnCopy.onClick.Add(OnBtnCopyClick);
        _btnUpgrade.onClick.Add(OnBtnUpgradeClick);
    }

    private void RemoveUIEvent()
    {
        _btnCopy.onClick.Remove(OnBtnCopyClick);
        _btnUpgrade.onClick.Remove(OnBtnUpgradeClick);
    }

    private void OnBtnCopyClick()
    {
        UnityEngine.GUIUtility.systemCopyBuffer = _tfWallet.text;
    }

    private void OnBtnUpgradeClick()
    {
        _ = SceneModule.RoleLevel.UpgradeRole();
    }

    public void UpdateView()
    {
        _tfName.text = DataManager.MainPlayer.RoleData.Name;
        _tfLv.SetVar("lv", DataManager.MainPlayer.RoleData.Profile.Lv.ToString()).FlushVars();
        _tfWallet.text = "wallet address";
        UpdateAvatar();
        UpdateAttr();
        UpdateExp();
        UpdateBtn();
        UpdateTips();
    }

    private void UpdateAttr()
    {
        Bian.EntityProfile profile = DataManager.MainPlayer.RoleData.Profile;
        SetAttr("hp", profile.HpCurrent.ToString(), profile.HpLimit.ToString());
        SetAttr("hpRecovery", profile.HpRecovery.ToString());
        SetAttr("atk", profile.Att.ToString());
        SetAttr("atkSpeed", profile.AttSpeed.ToString("f2") + "%");
        SetAttr("def", profile.Def.ToString());
        SetAttr("critRate", ((float)profile.CritRate / 10).ToString("f2") + "%");
        SetAttr("critDamage", 100 + (profile.CritDmg / 10) + "%");
        SetAttr("hitPoints", profile.HitRate.ToString());
        SetAttr("dodgePoints", profile.MissRate.ToString());
        SetAttr("moveSpeed", profile.MoveSpeed.ToString());
    }

    private void SetAttr(string name, string value, string total = "")
    {
        GTextField tf = _lstAttr.GetChild(name).asCom.GetChild("textNum").asTextField;
        if (string.IsNullOrEmpty(total))
        {
            tf.text = value;
        }
        else
        {
            tf.asTextField
                .SetVar("cur", value)
                .SetVar("total", total)
                .FlushVars();
        }
    }

    private void UpdateAvatar()
    {
        //todo:
    }

    private void UpdateExp()
    {
        Bian.EntityProfile profile = DataManager.MainPlayer.RoleData.Profile;
        int lv = profile.Lv == 0 ? 1 : profile.Lv;
        int needExp = RoleLvTable.Inst.GetRow(lv).Exp;
        _comExp.value = string.IsNullOrEmpty(profile.Exp) ? 0.0d : Convert.ToDouble(profile.Exp);
        _comExp.max = Convert.ToDouble(needExp); ;
    }

    private void UpdateBtn()
    {
        _btnUpgrade.touchable = SceneModule.RoleLevel.CheckCanUpgradeRole();
        _btnUpgrade.grayed = !_btnUpgrade.touchable;
        _btnLevelMax.visible = RoleLevelModule.MAX_ROLE_LV == DataManager.MainPlayer.RoleData.Profile.Lv;
        _btnUpgrade.visible = !_btnLevelMax.visible;
    }

    private void UpdateTips()
    {
        int roleLv = DataManager.MainPlayer.Role.GetComponent<RoleProfileData>().RoleLv;
        int needExp = RoleLvTable.Inst.GetRow(roleLv).Exp;
        _tfUpgradeTips
            .SetVar("exp", needExp.ToString())
            .SetVar("lv", Math.Max(1, roleLv - RoleLevelModule.MAX_LV_GAP_BETWEEN_SLOT_AND_ROLE).ToString())
            .FlushVars();
    }

    private void OnRoleUpgraded()
    {
        UpdateView();
    }
}