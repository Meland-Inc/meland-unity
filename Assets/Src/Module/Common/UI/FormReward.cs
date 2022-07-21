
using FairyGUI;
public class FormReward : FGUIForm
{
    protected FormRewardData formData;
    protected override FitScreen FitScreenMode => FitScreen.FitSize;//弹窗类型，默认适应屏幕大小
    private GButton _btnOK;
    private GButton _btnClose;
    private GTextField _tfTitle;
    private GTextField _tfContent;
    private string _oriOkBtnText;
    private GList _lstReward;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        _btnOK = GCom.GetChild("btnOK") as GButton;
        _btnClose = GCom.GetChild("btnClose") as GButton;
        _tfTitle = GCom.GetChild("tfTitle") as GTextField;
        _tfContent = GCom.GetChild("tfContent") as GTextField;
        _oriOkBtnText = _btnOK.text;

        _lstReward = GCom.GetChild("lstReward") as GList;
        _lstReward.numItems = 0;
        _lstReward.SetVirtual();
        _lstReward.itemRenderer = OnRenderRewardItem;
    }

    private void OnRenderRewardItem(int index, GObject item)
    {
        FormRewardData alertData = formData as FormRewardData;
        RewardNftItemRenderer renderer = (RewardNftItemRenderer)item;
        renderer.SetData(alertData.Rewards[index]);
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        if (userData is FormRewardData alertData)
        {
            formData = alertData;
            if (!string.IsNullOrEmpty(alertData.OKBtnText))
            {
                _btnOK.text = alertData.OKBtnText;
            }
            else
            {
                _btnOK.text = _oriOkBtnText;
            }

            _tfTitle.text = string.IsNullOrEmpty(alertData.Title) ? _tfTitle.text : alertData.Title;
            _tfContent.text = string.IsNullOrEmpty(alertData.Content) ? _tfContent.text : alertData.Content;

        }
        AddUIEvent();
        _lstReward.numItems = formData.Rewards.Count;
    }



    protected override void OnClose(bool isShutdown, object userData)
    {
        RemoveUIEvent();
        base.OnClose(isShutdown, userData);
    }


    private void AddUIEvent()
    {
        _btnOK.onClick.Add(onBtnOkClick);
        _btnClose.onClick.Add(Close);
        _lstReward.onClickItem.Add(OnListRewardItemClick);
    }
    private void RemoveUIEvent()
    {
        _btnOK.onClick.Remove(onBtnOkClick);
        _btnClose.onClick.Remove(Close);
        _lstReward.onClickItem.Remove(OnListRewardItemClick);
    }

    private void OnListRewardItemClick(EventContext context)
    {
        RewardNftItemRenderer itemRenderer = (RewardNftItemRenderer)context.data;
        _ = UICenter.OpenUITooltip<TooltipItem>(new TooltipInfo(itemRenderer, itemRenderer.ItemData.Cid, eTooltipDir.Right));
    }
    private void onBtnOkClick()
    {
        formData.OKBtnCb?.Invoke();
        Close();
    }
}