/*
 * @Author: mangit
 * @LastEditTime: 2022-06-20 11:10:23
 * @LastEditors: mangit
 * @Description: nft item renderer
 * @Date: 2022-06-16 21:17:14
 * @FilePath: /Assets/Src/Module/Backpack/View/BpNftItemRenderer.cs
 */
using FairyGUI;
using FairyGUI.Utils;
using NFT;

public class BpNftItemRenderer : GButton
{
    public BpItemData ItemData { get; private set; }
    protected Controller CtrlQuality;
    public override void ConstructFromXML(XML xml)
    {
        base.ConstructFromXML(xml);
        CtrlQuality = GetController("ctrlQuality");
    }

    public void SetData(BpNftItem data)
    {
        ItemData = data;
        icon = data.Icon;
        SetNum(data.Count);
        SetQuality(data.Quality);
        SetUsed(data.Using);
    }

    protected void SetNum(int num)
    {
        if (GetChild("tfNum") is GTextField tfNum)
        {
            tfNum.text = num.ToString();
            tfNum.visible = num > 1;
        }
    }

    protected void SetQuality(eNFTQuality quality)
    {
        CtrlQuality.selectedPage = quality.ToString();
    }

    protected void SetUsed(bool isUsed)
    {
        if (GetChild("imgUsed") is GImage imgUsed)
        {
            imgUsed.visible = isUsed;
        }
    }
}