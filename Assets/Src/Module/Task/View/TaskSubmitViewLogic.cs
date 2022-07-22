using FairyGUI;
using System;
using System.Collections.Generic;
public class TaskSubmitViewLogic : FGUILogicCpt
{
    private TaskChainData _taskChainData;
    // 背包数据
    private readonly List<RewardNftData> _bpItemData = new();
    // 当选中的数据
    private readonly List<RewardNftData> _selectedBpItemData = new();
    // 用于提交的数据
    private readonly List<RewardNftData> _reqItemDatas = new();
    // 展示选中数量
    private GTextField _tfSelectCount;
    // 需要提交的item
    private GList _lstSubmitItems;
    // 背包item
    private GList _lstBpItems;
    // 提交按钮
    private GButton _btnSubmit;
    private GButton _btnClose;
    protected override void OnAdd()
    {
        base.OnAdd();
        _tfSelectCount = GCom.GetChild("tfSelectCount") as GTextField;
        _btnSubmit = GCom.GetChild("btnSubmit") as GButton;
        _btnClose = GCom.GetChild("btnClose") as GButton;

        // 需要提交的列表
        _lstSubmitItems = GCom.GetChild("lstSubmitItems") as GList;
        _lstSubmitItems.numItems = 0;
        _lstSubmitItems.itemRenderer = OnRenderSubmitItem;

        // 背包列表
        _lstBpItems = GCom.GetChild("lstBpItems") as GList;
        _lstBpItems.numItems = 0;
        _lstBpItems.itemRenderer = OnRenderBpItem;
    }

    public override void OnOpen()
    {
        base.OnOpen();
        AddUIEvent();
        AddDataAction();
    }

    private void ResetUIData()
    {
        SingleFocusBpItem(null);
        ClearSelectedItemData();
        _bpItemData.Clear();
        if (_btnSubmit != null)
        {
            _btnSubmit.GetController("ctrColor").selectedPage = "gray";
        }
    }

    public override void OnClose()
    {
        RemoveUIEvent();
        RemoveDataAction();
        UICenter.CloseUIForm<TooltipNFTItem>();
        ResetUIData();
        base.OnClose();
    }

    private void AddUIEvent()
    {
        _btnSubmit.onClick.Add(OnBtnSubmitClick);
        _btnClose.onClick.Add(CloseSubmitView);
    }

    private void CloseSubmitView()
    {
        UICenter.CloseUIForm<FormTaskSubmit>();
    }

    private void RemoveUIEvent()
    {
        _btnSubmit.onClick.Remove(OnBtnSubmitClick);
        _btnClose.onClick.Remove(CloseSubmitView);
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
        OnUpdateSelectCount();
    }

    private void RefreshBpItem()
    {
        List<BpNftItem> bpNftItems = DataManager.Backpack.ItemList;
        List<RewardNftData> submitItems = _taskChainData.TaskSubmitItems;

        // 处理堆叠，把相同的nft集合到一起
        _bpItemData.Clear();
        _selectedBpItemData.Clear();
        UpdateSelectBpItemdUI();
        bpNftItems.ForEach(bpItem =>
        {
            // 仅筛选出当前与需要提交道具同cid的 背包道具
            RewardNftData sameSubmitCidItem = submitItems.Find(item => item.Cid == bpItem.Cid);
            if (sameSubmitCidItem == null)
            {
                return;
            }

            // 同nftId的道具,记录到 _bpItemData，且堆叠起来 
            RewardNftData sameItem = _bpItemData.Find(item => item.NftId == bpItem.Id);
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

        // 按品质排序
        _bpItemData.Sort((RewardNftData a, RewardNftData b) =>
        {
            return a.Quality - b.Quality;
        });

        _lstBpItems.numItems = _bpItemData.Count;
    }

    private void RefreshSubmitItem()
    {
        _lstSubmitItems.numItems = _taskChainData.TaskSubmitItems.Count;
    }

    private void OnBpItemClick(RewardNftItemRenderer render)
    {
        AddSelectedItemData(render);
        UICenter.CloseUIForm<TooltipNFTItem>();
        TooltipNFTItemParam toolTipVo = new() { ItemData = render.ItemData.BpItemData };
        _ = UICenter.OpenUITooltip<TooltipNFTItem>(new TooltipInfo(GCom, toolTipVo, eTooltipDir.Left, -30, 0, false));
    }

    private void OnBpItemCloseClick(RewardNftItemRenderer render)
    {
        RemoveSelectedItemData(render);
    }

    private void ClearSelectedItemData()
    {

        _selectedBpItemData.Clear();
        UpdateSelectBpItemdUI();
        UpdateReqItemDatas();
    }

    // 添加一个选中数据
    private void AddSelectedItemData(RewardNftItemRenderer item)
    {
        if (!_selectedBpItemData.Contains(item.ItemData))
        {
            _selectedBpItemData.Add(item.ItemData);
            UpdateSelectBpItemdUI();
            UpdateReqItemDatas();
        }

        SingleFocusBpItem(item);
        OnUpdateSelectCount();
        OnUpdateBtnSubmit();
    }

    // 移除一个选中数据
    private void RemoveSelectedItemData(RewardNftItemRenderer item)
    {
        if (_selectedBpItemData.Contains(item.ItemData))
        {
            _ = _selectedBpItemData.Remove(item.ItemData);
            UpdateSelectBpItemdUI();
            UpdateReqItemDatas();
        }

        OnUpdateSelectCount();
        OnUpdateBtnSubmit();
    }


    // 更新item被选中
    private void UpdateSelectBpItemdUI()
    {
        for (int i = 0; i < _lstBpItems.numChildren; i++)
        {
            RewardNftItemRenderer render = (RewardNftItemRenderer)_lstBpItems.GetChildAt(i);
            bool isSelected = _selectedBpItemData.Contains(render.ItemData);
            render.SetSelected(isSelected);
            render.SetBtnCancel(isSelected);
        }
    }
    // 单选聚焦某个Item
    private void SingleFocusBpItem(RewardNftItemRenderer focusItem)
    {

        for (int i = 0; i < _lstBpItems.numChildren; i++)
        {
            RewardNftItemRenderer render = (RewardNftItemRenderer)_lstBpItems.GetChildAt(i);
            render.SetFocus(render == focusItem);
        }
    }

    // 刷新选中的数量
    private void OnUpdateSelectCount()
    {
        int selectCount = 0;
        _selectedBpItemData.ForEach(item => selectCount += item.Count);
        _tfSelectCount.SetVar("count", selectCount.ToString()).FlushVars();
    }

    // 检查是否满足提交条件
    private bool checkIfMeetSubmit()
    {
        List<RewardNftData> submitItems = _taskChainData.TaskSubmitItems;
        for (int i = 0; i < submitItems.Count; i++)
        {
            RewardNftData submitItem = submitItems[i];
            List<RewardNftData> selectedItems = _selectedBpItemData.FindAll(bpItem => bpItem.Cid == submitItem.Cid);
            if (selectedItems.Count <= 0)
            {
                return false;
            }
            // 统计该cid道具 已选中的总数
            int selectedSumCount = 0;
            selectedItems.ForEach(selectedItem =>
            {
                selectedSumCount += selectedItem.Count;
            });

            // 如果是非同质化道具，选中数量得刚刚好
            if (BackpackUtil.IsNonFungible(selectedItems[0].BpItemData))
            {
                if (selectedSumCount != submitItem.Count)
                {
                    return false;
                }
            }
            else
            {
                // 同质化道具数量 可以多出所需
                if (selectedSumCount < submitItem.Count)
                {
                    return false;
                }
            }
        }

        return true;
    }
    // 更新提交按钮状态
    private void OnUpdateBtnSubmit()
    {
        if (checkIfMeetSubmit())
        {
            _btnSubmit.GetController("ctrColor").selectedPage = "yellow";
            _btnSubmit.touchable = true;
            return;
        }
        _btnSubmit.GetController("ctrColor").selectedPage = "gray";
        _btnSubmit.touchable = false;
    }

    private void OnRenderBpItem(int index, GObject item)
    {
        RewardNftItemRenderer renderer = (RewardNftItemRenderer)item;
        renderer.SetData(_bpItemData[index]);
        renderer.SetCloseCb(OnBpItemCloseClick);
        renderer.SetItemCb(OnBpItemClick);
    }

    private void OnRenderSubmitItem(int index, GObject item)
    {
        RewardNftItemRenderer render = (RewardNftItemRenderer)item;
        render.SetData(_taskChainData.TaskSubmitItems[index], 0);
    }


    private void OnBtnSubmitClick(EventContext context)
    {
        UpdateReqItemDatas();
        TaskUpgradeTaskProgressAction.ReqItem(_taskChainData.TaskChainKind, _reqItemDatas);
        UICenter.CloseUIForm<FormTaskSubmit>();
    }

    private void UpdateReqItemDatas()
    {
        _reqItemDatas.Clear();

        // 需要提交的数据
        List<RewardNftData> submitItems = _taskChainData.TaskSubmitItems;

        // 从选中的数据中，选取需要提交的数据（只能提交所需的数据，数量得刚刚好，不能超出）
        for (int i = 0; i < submitItems.Count; i++)
        {
            RewardNftData submitItem = submitItems[i];
            List<RewardNftData> selectedItems = _selectedBpItemData.FindAll(bpItem => bpItem.Cid == submitItem.Cid);
            int needSubmitCount = submitItem.Count;
            for (int j = 0; j < selectedItems.Count; j++)
            {
                int curCount = selectedItems[j].Count >= needSubmitCount ? needSubmitCount : selectedItems[j].Count;
                _reqItemDatas.Add(new RewardNftData()
                {
                    NftId = selectedItems[j].NftId,
                    Cid = selectedItems[j].Cid,
                    Count = curCount,
                });

                needSubmitCount -= curCount;
                if (needSubmitCount <= 0)
                {
                    break;
                }
            }
        }

        UpdateReqItemsUI();
    }

    private void UpdateReqItemsUI()
    {
        for (int i = 0; i < _lstSubmitItems.numChildren; i++)
        {
            RewardNftItemRenderer render = (RewardNftItemRenderer)_lstSubmitItems.GetChildAt(i);
            RewardNftData reqItem = _reqItemDatas.Find(reqItem => reqItem.Cid == render.ItemData.Cid);
            int count = 0;
            if (reqItem != null)
            {
                count = reqItem.Count;
            }
            render.SetData(render.ItemData, count);
        }
    }
}