
using FairyGUI;
using FairyGUI.Utils;
using NFT;

public class RewardNftItemRenderer : GButton
{
    public RewardNftData ItemData { get; private set; }
    protected Controller CtrlQuality;
    public override void ConstructFromXML(XML xml)
    {
        base.ConstructFromXML(xml);
        CtrlQuality = GetController("ctrlQuality");
    }

    public void SetData(RewardNftData data)
    {
        ItemData = data;
        icon = data.Icon;
        SetNum(data.Count);
        SetQuality(data.Quality);
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

}