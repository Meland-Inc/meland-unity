/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 角色升级成功提示
 * @Date: 2022-07-06 19:07:32
 * @FilePath: /Assets/Src/Module/MainPlayerRole/view/FormRoleAttrUpgradeSuccess.cs
 */
using FairyGUI;
public class FormRoleAttrUpgradeSuccess : FGUIForm
{
    private Controller _ctrlArrange;
    private GList _lstAttr;
    private GTextField _tfLvDiff;
    private Transition _transShow;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        _ctrlArrange = GetController("ctrlArrange");
        _lstAttr = GetList("lstAttr");
        _tfLvDiff = GetChild("tfLvDiff").asTextField;
        _transShow = GCom.GetTransition("show");
    }
    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        _lstAttr.RemoveChildrenToPool();
        if (userData is RoleUpgradeAttrDiffInfo upgradeInfo)
        {
            _tfLvDiff
                .SetVar("lvCur", upgradeInfo.Lv.ToString())
                .SetVar("lvNext", (upgradeInfo.Lv + 1).ToString())
                .FlushVars();
            foreach (RoleAttrDiffInfo diff in upgradeInfo.AttrDiffList)
            {
                AddAttrDiffItem(diff.AttrName, diff.CurValue, diff.NextValue);
            }

            _ctrlArrange.SetSelectedPage(_lstAttr.numItems <= 5 ? "single" : "double");
            _lstAttr.ResizeToFit();
            _transShow.Play();
        }

        GCom.onClick.Add(Close);
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        GCom.onClick.Remove(Close);
        base.OnClose(isShutdown, userData);
    }

    private void AddAttrDiffItem(string attrName, int curValue, int nextValue)
    {
        GComponent item = _lstAttr.AddItemFromPool().asCom;
        item.GetController("ctrlType").SetSelectedPage(attrName);
        item.GetChild("tfCur").text = curValue.ToString();
        item.GetChild("tfNext").text = nextValue.ToString();
    }
}