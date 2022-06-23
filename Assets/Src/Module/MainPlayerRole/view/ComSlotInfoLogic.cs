using System.Reflection.Emit;
using System.Globalization;
/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 装备插槽信息
 * @Date: 2022-06-22 15:46:59
 * @FilePath: /Assets/Src/Module/MainPlayerRole/view/ComSlotInfoLogic.cs
 */
using FairyGUI;
public class ComSlotInfoLogic : FGUILogicCpt
{
    private GList _lstAttr;
    private GLabel _labSlotIcon;
    private GButton _btnUpgrade;
    private GTextField tfDitaminCost;
    private GProgressBar _comExp;
    protected override void OnAdd()
    {
        base.OnAdd();
        _lstAttr = GCom.GetChild("lstAttr") as GList;
        _labSlotIcon = GCom.GetChild("labSlotIcon") as GLabel;
        _btnUpgrade = GCom.GetChild("btnUpgrade") as GButton;
        tfDitaminCost = GCom.GetChild("tfDitaminCost") as GTextField;
        _comExp = GCom.GetChild("comExp") as GProgressBar;
    }
}