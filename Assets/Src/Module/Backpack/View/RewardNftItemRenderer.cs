
using System;
using FairyGUI;
using FairyGUI.Utils;
using NFT;

public class RewardNftItemRenderer : GComponent
{
    public RewardNftData ItemData { get; private set; }
    private Controller _ctrlQuality;
    private Controller _ctrFocus;
    private Controller _ctrBtnCancel;
    private Controller _ctrSelected;
    private Controller _ctrShowCurMax;
    private GTextField _tfNum;
    private GButton _btnCancel;
    private GButton _btnItem;
    private GComponent _iconCom;
    private Action<RewardNftItemRenderer> _closeBtnCb = delegate { };
    private Action<RewardNftItemRenderer> _itemCb = delegate { };
    private ComLabelCurMax _comLabelCurMax;
    public override void ConstructFromXML(XML xml)
    {
        base.ConstructFromXML(xml);
        _tfNum = GetChild("tfNum") as GTextField;
        _ctrlQuality = GetController("ctrlQuality");
        _ctrFocus = GetController("ctrFocus");
        _ctrBtnCancel = GetController("ctrBtnCancel");
        _ctrSelected = GetController("ctrSelected");
        _ctrShowCurMax = GetController("ctrShowCurMax");
        _btnCancel = GetChild("btnCancel") as GButton;
        _btnItem = GetChild("btnItem") as GButton;
        _iconCom = GetChild("icon") as GComponent;
        _comLabelCurMax = GetChild("comLabelCurMax") as ComLabelCurMax;
        AddUIEvent();
    }

    public override void Dispose()
    {
        RemoveUIEvent();
        MelandUtil.ClearDelegage(_closeBtnCb);
        MelandUtil.ClearDelegage(_itemCb);
        _closeBtnCb = null;
        _itemCb = null;
        SetFocus(false);
        SetSelected(false);
        SetBtnCancel(false);
        base.Dispose();
    }

    // 普通设置
    public void SetData(RewardNftData data)
    {
        ItemData = data;
        SetMaxNum(data.Count);
        UpdateUI();
    }

    public void SetData(RewardNftData data, int cur)
    {
        ItemData = data;
        SetCur2MaxNum(cur, data.Count);
        UpdateUI();
    }

    private void UpdateUI()
    {
        _iconCom.icon = ItemData.Icon;
        SetQuality(ItemData.Quality);
    }

    public void SetCloseCb(Action<RewardNftItemRenderer> closeCb = null)
    {
        MelandUtil.ClearDelegage(_closeBtnCb);
        _closeBtnCb += closeCb;
    }

    public void SetItemCb(Action<RewardNftItemRenderer> itemCb = null)
    {
        MelandUtil.ClearDelegage(_itemCb);
        _itemCb += itemCb;
    }

    // 聚焦框
    public void SetFocus(bool isFocus)
    {
        _ctrFocus.selectedPage = isFocus ? "true" : "false";
    }
    // 右上角 xx 按钮
    public void SetBtnCancel(bool isShow)
    {
        _ctrBtnCancel.selectedPage = isShow ? "true" : "false";
    }
    // 选中效果
    public void SetSelected(bool isSelected)
    {
        _ctrSelected.selectedPage = isSelected ? "true" : "false";
    }

    protected void SetMaxNum(int num)
    {
        _ctrShowCurMax.selectedPage = "false";
        _tfNum.text = num.ToString();
    }

    protected void SetCur2MaxNum(int cur, int max)
    {
        _ctrShowCurMax.selectedPage = "true";
        _comLabelCurMax.SetData(cur, max);
    }

    protected void SetQuality(eNFTQuality quality)
    {
        _ctrlQuality.selectedPage = quality.ToString();
    }

    private void AddUIEvent()
    {
        _btnCancel.onClick.Add(OnBtnCancelClick);
        _btnItem.onClick.Add(OnItemClick);
    }

    private void RemoveUIEvent()
    {
        _btnCancel.onClick.Remove(OnBtnCancelClick);
        _btnItem.onClick.Remove(OnItemClick);
    }

    private void OnBtnCancelClick(EventContext context)
    {
        _closeBtnCb.Invoke(this);
    }
    private void OnItemClick(EventContext context)
    {
        _itemCb.Invoke(this);
    }
}