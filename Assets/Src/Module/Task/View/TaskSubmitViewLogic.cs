using FairyGUI;
using System.Collections.Generic;
public class TaskSubmitViewLogic : FGUILogicCpt
{
    private TaskChainData _taskChainData;
    // 背包数据
    private readonly List<RewardNftData> _bpItemData = new();
    // 当选中的数据
    private readonly List<RewardNftData> _selectedBpItemData = new();
    // 展示选中数量
    private GTextField _tfSelectCount;
    // 需要提交的item
    private GList _lstSubmitItems;
    // 背包item
    private GList _lstBpItems;
    // 提交按钮
    private GButton _btnSubmit;
    protected override void OnAdd()
    {
        base.OnAdd();
        _tfSelectCount = GCom.GetChild("tfSelectCount") as GTextField;
        _btnSubmit = GCom.GetChild("btnSubmit") as GButton;

        // 需要提交的列表
        _lstSubmitItems = GCom.GetChild("lstSubmitItems") as GList;
        _lstSubmitItems.numItems = 0;
        _lstSubmitItems.SetVirtual();
        _lstSubmitItems.itemRenderer = OnRenderSubmitItem;

        // 背包列表
        _lstBpItems = GCom.GetChild("lstBpItems") as GList;
        _lstBpItems.numItems = 0;
        _lstBpItems.SetVirtual();
        _lstBpItems.itemRenderer = OnRenderBpItem;
    }

    public override void OnOpen()
    {
        base.OnOpen();
        AddUIEvent();
        AddDataAction();
    }

    public override void OnClose()
    {
        RemoveUIEvent();
        RemoveDataAction();
        base.OnClose();
    }

    private void AddUIEvent()
    {
        _lstBpItems.onClickItem.Add(OnBpItemClick);
        // _lstSubmitItems.onClickItem.Add(OnSubmitItemClick);
        _btnSubmit.onClick.Add(OnBtnSubmitClick);
    }

    private void RemoveUIEvent()
    {
        _lstBpItems.onClickItem.Remove(OnBpItemClick);
        // _lstSubmitItems.onClickItem.Remove(OnSubmitItemClick);
        _btnSubmit.onClick.Remove(OnBtnSubmitClick);
    }

    private void AddDataAction()
    {
        SceneModule.BackpackMgr.OnDataAdded += RefreshBpItem;
        SceneModule.BackpackMgr.OnDataRemoved += RefreshBpItem;
        SceneModule.BackpackMgr.OnDataUpdated += RefreshBpItem;
    }

    private void RemoveDataAction()
    {
        SceneModule.BackpackMgr.OnDataAdded -= RefreshBpItem;
        SceneModule.BackpackMgr.OnDataRemoved -= RefreshBpItem;
        SceneModule.BackpackMgr.OnDataUpdated -= RefreshBpItem;
    }

    public void SetData(TaskChainData taskChainData)
    {
        _taskChainData = taskChainData;
        OnUpdateUI();
    }

    private void OnUpdateUI()
    {
        RefreshBpItem();
        RefreshSubmitItem();
    }

    private void RefreshBpItem()
    {
        List<BpNftItem> bpItemList = DataManager.Backpack.ItemList;

        // 处理堆叠，把相同的nft集合到一起
        _bpItemData.Clear();
        _selectedBpItemData.Clear();
        bpItemList.ForEach(bpItem =>
        {
            RewardNftData sameItem = _bpItemData.Find(item => item.Cid == bpItem.Cid);
            if (sameItem == null)
            {
                _bpItemData.Add(new RewardNftData()
                {
                    NftId = bpItem.Id,
                    Cid = bpItem.Cid,
                    Icon = bpItem.Icon,
                    Count = bpItem.Count,
                    Quality = bpItem.Quality,
                    BpItemData = bpItem
                });
            }
            else
            {
                sameItem.Count += bpItem.Count;
            }
        });

        _lstBpItems.numItems = _bpItemData.Count;
    }

    private void RefreshSubmitItem()
    {
        _lstSubmitItems.numItems = _taskChainData.TaskSubmitItems.Count;
    }

    private void OnBpItemClick(EventContext context)
    {
        RewardNftItemRenderer render = (RewardNftItemRenderer)context.data;
        UpdateSelectedItemData(render);
        _ = UICenter.OpenUITooltip<TooltipNFTItem>(new TooltipInfo(render, render.ItemData.BpItemData));
    }

    private void UpdateSelectedItemData(RewardNftItemRenderer item)
    {
        if (item.selected)
        {
            _selectedBpItemData.Add(item.ItemData);
        }
        else
        {
            _ = _selectedBpItemData.Remove(item.ItemData);
        }
        OnUpdateSelectCount();
        OnUpdateBtnSubmit();
    }

    // private void OnSubmitItemClick(EventContext context)
    // {
    // }

    private void OnBtnSubmitClick(EventContext context)
    {
        TaskUpgradeTaskProgressAction.ReqItem(_taskChainData.TaskChainKind, _selectedBpItemData);
        UICenter.CloseUIForm<FormTaskSubmit>();
    }
    // 刷新选中的数量
    private void OnUpdateSelectCount()
    {
        int selectCount = 0;
        if (_selectedBpItemData.Count > 0)
        {
            _selectedBpItemData.ForEach((item) =>
            {
                selectCount += item.Count;
            });
        }
        _tfSelectCount.SetVar("count", selectCount.ToString()).FlushVars();
    }
    // 检查是否满足提交条件
    private bool checkMeetSubmitCondition()
    {
        List<RewardNftData> submitItems = _taskChainData.TaskSubmitItems;

        for (int i = 0; i < submitItems.Count; i++)
        {
            RewardNftData submitItem = submitItems[i];
            RewardNftData selectedItem = _selectedBpItemData.Find(bpItem => bpItem.NftId == submitItem.NftId);
            // 没有选到，或者选到的数量不足
            if (selectedItem == null || selectedItem.Count < submitItem.Count)
            {
                return false;
            }
        }

        return true;
    }
    // 更新提交按钮状态
    private void OnUpdateBtnSubmit()
    {
        if (checkMeetSubmitCondition())
        {
            _btnSubmit.GetController("color").selectedPage = "yellow";
            _btnSubmit.enabled = true;
            return;
        }
        _btnSubmit.GetController("color").selectedPage = "gray";
        _btnSubmit.enabled = false;
    }

    private void OnRenderBpItem(int index, GObject item)
    {
        RewardNftItemRenderer renderer = (RewardNftItemRenderer)item;
        renderer.SetData(_bpItemData[index]);
    }

    private void OnRenderSubmitItem(int index, GObject item)
    {
        RewardNftItemRenderer render = (RewardNftItemRenderer)item;
        render.SetData(_taskChainData.TaskSubmitItems[index]);
    }
}