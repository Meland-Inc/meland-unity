using System;
using System.Threading;
/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 
 * @Date: 2022-07-01 10:35:37
 * @FilePath: /Assets/Src/Module/Backpack/View/ComTooltipNftInfoLogic.cs
 */
using FairyGUI;
using NFT;

public class ComTooltipNftInfoLogic : FGUILogicCpt
{
    private Controller _ctrlQuality;
    private GLoader _ladIcon;
    private GTextField _tfName;
    private GTextField _tfDesc;
    private GTextField _tfLv;

    private GGroup _grpAttr;
    private GList _lstAttr;
    private GImage _imgLineTop;
    private GImage _imgLineBottom;
    private BpNftItem _nftData;
    protected override void OnAdd()
    {
        base.OnAdd();
        _ctrlQuality = GCom.GetController("ctrlQuality");
        _ladIcon = GCom.GetChild("ladIcon") as GLoader;
        _tfName = GCom.GetChild("tfName") as GTextField;
        _tfDesc = GCom.GetChild("tfDesc") as GTextField;
        _tfLv = GCom.GetChild("tfLv") as GTextField;

        _grpAttr = GCom.GetChild("grpAttr") as GGroup;
        _lstAttr = GCom.GetChild("lstAttr") as GList;
        _imgLineTop = GCom.GetChild("imgLineTop") as GImage;
        _imgLineBottom = GCom.GetChild("imgLineBottom") as GImage;
    }

    public void SetData(BpNftItem nftData)
    {
        _nftData = nftData;
        UpdateView();
    }

    private void UpdateView()
    {
        UpdateBasicInfo();
        UpdateRarity();
        UpdateAttr();
        UpdateLabel();
        FitSize();
    }

    private void UpdateBasicInfo()
    {
        _ladIcon.icon = _nftData.Icon;
        _tfName.text = _nftData.Name;
        _tfDesc.text = _nftData.Desc;
        string lv = _nftData.GetAttribute(eNFTTraitType.Level.ToString());
        if (string.IsNullOrEmpty(lv))
        {
            _tfLv.height = 0;
            _tfLv.visible = false;
        }
        else
        {
            _tfLv.SetVar("lv", lv).FlushVars();
            _tfLv.visible = true;
            _tfLv.height = _tfLv.initHeight;
        }
    }

    private void UpdateRarity()
    {
        _ctrlQuality.SetSelectedPage(_nftData.Quality.ToString());
    }

    private void UpdateLabel()
    {
        GList lstLabel = GCom.GetChild("lstLabel").asList;
        GLabel rarityLabel = lstLabel.GetChild("rarity").asLabel;
        GLabel qualityLabel = lstLabel.GetChild("quality").asLabel;
        GLabel typeLabel = lstLabel.GetChild("type").asLabel;

        string nftType = _nftData.GetAttribute(eNFTTraitType.Type.ToString());
        typeLabel.GetChild("title").text = nftType;
        rarityLabel.visible = nftType == eNFTType.Placeable.ToString() || nftType == eNFTType.Wearable.ToString();
        qualityLabel.visible = !rarityLabel.visible;
        rarityLabel.GetController("ctrlRarity").SetSelectedPage(_nftData.Quality.ToString());
        qualityLabel.GetController("ctrlQuality").SetSelectedPage(_nftData.Quality.ToString());
    }

    private void UpdateAttr()
    {
        _lstAttr.RemoveChildrenToPool();
        foreach (string name in Enum.GetNames(typeof(eNFTBattleTrait)))
        {
            string attr = _nftData.GetAttribute(name);
            if (string.IsNullOrEmpty(attr))
            {
                continue;
            }

            GComponent attrItem = _lstAttr.AddItemFromPool().asCom;
            attrItem.GetChild("tfName").text = name;
            int numValue = Convert.ToInt32(attr);
            GTextField tfValue = attrItem.GetChild("tfValue") as GTextField;
            if (numValue > 0)
            {
                tfValue.text = "+" + numValue;
                tfValue.color = UnityEngine.Color.green;
            }
            else
            {
                tfValue.text = numValue.ToString();
                tfValue.color = UnityEngine.Color.red;
            }
        }
    }

    private void FitSize()
    {
        _lstAttr.ResizeToFit();
        _lstAttr.height = Math.Min(_lstAttr.height, _lstAttr.initHeight);
        if (_lstAttr.numItems == 0)
        {
            _imgLineBottom.y = _imgLineTop.y;
            _grpAttr.visible = false;
        }
        else
        {
            _imgLineBottom.y = _lstAttr.y + _lstAttr.height + 25;
            _grpAttr.visible = true;
        }
    }
}