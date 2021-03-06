using System;
/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: nft item tooltip
 * @Date: 2022-07-01 10:34:41
 * @FilePath: /Assets/Src/Module/Backpack/View/TooltipNFTItem.cs
 */
using FairyGUI;
public class TooltipNFTItem : FGUITooltip
{
    private GGroup _grpBtn;
    private GList _lstBtn;
    private GButton _btnUse;
    private GButton _btnSell;
    private GButton _btnPutOn;
    private GButton _btnTakeOff;
    private GButton _btnDestroy;
    private GButton _btnQuickPack;
    private ComTooltipNftInfoLogic _comTooltipInfo;
    private BpNftItem _nftData;
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        _comTooltipInfo = GCom.AddSubUILogic<ComTooltipNftInfoLogic>("comTooltipInfo");

        _grpBtn = GCom.GetChild("grpBtn") as GGroup;
        _lstBtn = GCom.GetChild("lstBtn") as GList;
        _btnUse = _lstBtn.GetChild("btnUse") as GButton;
        _btnSell = _lstBtn.GetChild("btnSell") as GButton;
        _btnPutOn = _lstBtn.GetChild("btnPutOn") as GButton;
        _btnTakeOff = _lstBtn.GetChild("btnTakeOff") as GButton;
        _btnDestroy = _lstBtn.GetChild("btnDestroy") as GButton;
        _btnQuickPack = _lstBtn.GetChild("btnQuickPack") as GButton;
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        _nftData = TooltipInfo.Data as BpNftItem;
        _comTooltipInfo.SetData(TooltipInfo.Data as BpNftItem);

        UpdateOperate();
        FitPos();
    }

    private void UpdateOperate()
    {
        foreach (GObject child in _lstBtn._children)
        {
            child.visible = false;
        }

        NFT.eNFTType type = _nftData.GetAttribute(NFT.eNFTTraitType.Type.ToString()).ToEnum<NFT.eNFTType>();
        if (_nftData is BpWearableNftItem wearableNft)
        {
            _btnUse.visible = !wearableNft.Using;
            _btnTakeOff.visible = wearableNft.Using;
        }

        if (_nftData is BpPlaceableNftItem placeableNft)
        {
            _btnUse.visible = !placeableNft.Using;
        }

        if (_nftData is BpFoodNftItem)
        {
            _btnUse.visible = true;
        }

        _lstBtn.ResizeToFit();
        _grpBtn.visible = !UnityEngine.Mathf.Approximately(_lstBtn.height, 0);
    }
}