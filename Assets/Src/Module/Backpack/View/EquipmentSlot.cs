/*
 * @Author: mangit
 * @LastEditTime: 2022-07-01 13:30:16
 * @LastEditors: mangit
 * @Description: 装备插槽
 * @Date: 2022-06-20 22:43:25
 * @FilePath: /Assets/Src/Module/Backpack/View/EquipmentSlot.cs
 */
using Bian;
using FairyGUI;
using FairyGUI.Utils;

public class EquipmentSlot : GButton
{
    private Controller _ctrlStatus;
    private GTextField _tfLv;
    public bool IsEmpty { get; private set; }
    public BpNftItemRenderer NftItemRenderer { get; private set; }
    private ItemSlot _slotData;
    public override void ConstructFromXML(XML xml)
    {
        base.ConstructFromXML(xml);
        _ctrlStatus = GetController("ctrlStatus");
        _tfLv = GetChild("tfLv") as GTextField;
        NftItemRenderer = GetChild("item") as BpNftItemRenderer;
    }

    public void SetNftData(BpWearableNftItem nftItem)
    {
        if (nftItem != null)
        {
            IsEmpty = false;
            NftItemRenderer.SetData(nftItem);
            _ctrlStatus.SetSelectedPage("equip");
        }
        else
        {
            _ctrlStatus.SetSelectedPage("empty");
            IsEmpty = true;
        }
    }

    public void SetSlotData(ItemSlot slotData)
    {
        _slotData = slotData;
        SetLv(slotData.Level);
    }

    public void SetLv(int lv)
    {
        _tfLv.SetVar("lv", lv.ToString()).FlushVars();
    }
}