using System;
using FairyGUI;
using FairyGUI.Utils;

public class ComLabelCurMax : GComponent
{
    private Controller _ctrEnough;
    private GTextField _tfMaxNum;
    private GTextField _tfCurNum;
    public override void ConstructFromXML(XML xml)
    {
        base.ConstructFromXML(xml);
        _ctrEnough = GetController("ctrEnougn");
        _tfMaxNum = GetChild("tfMaxNum") as GTextField;
        _tfCurNum = GetChild("tfCurNum") as GTextField;
    }

    public void SetData(int cur, int max)
    {
        cur = Math.Min(cur, max);
        _tfCurNum.text = cur.ToString();
        _tfMaxNum.SetVar("max", max.ToString()).FlushVars();
        _ctrEnough.selectedPage = cur >= max ? "true" : "false";
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}