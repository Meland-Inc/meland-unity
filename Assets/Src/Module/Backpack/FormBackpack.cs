/*
 * @Author: mangit
 * @LastEditTime: 2022-06-20 20:08:21
 * @LastEditors: mangit
 * @Description: 背包界面
 * @Date: 2022-06-15 11:32:37
 * @FilePath: /Assets/Src/Module/Backpack/FormBackpack.cs
 */
using System.Collections.Generic;
using FairyGUI;
using NFT;
using static BackpackDefine;

public class FormBackpack : FGUIForm
{
    private List<BpNftItem> _bpDataListCache;
    private GTextInput _tfSearch;
    private GList _lstQualityTag;
    private GList _lstTag;
    private GList _lstItem;
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        InitChildren();
        InitLstItem();
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        AddDataAction();
        AddUIEvent();
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        RemoveDataAction();
        RemoveUIEvent();
        base.OnClose(isShutdown, userData);
    }

    private void AddDataAction()
    {
        SceneModule.BackpackMgr.OnDataInit += OnDataInit;
        SceneModule.BackpackMgr.OnDataAdded += OnDataUpdate;
        SceneModule.BackpackMgr.OnDataRemoved += OnDataUpdate;
        SceneModule.BackpackMgr.OnDataUpdated += OnDataUpdate;
    }

    private void RemoveDataAction()
    {
        SceneModule.BackpackMgr.OnDataInit -= OnDataInit;
        SceneModule.BackpackMgr.OnDataAdded -= OnDataUpdate;
        SceneModule.BackpackMgr.OnDataRemoved -= OnDataUpdate;
        SceneModule.BackpackMgr.OnDataUpdated -= OnDataUpdate;
    }

    private void AddUIEvent()
    {
        _lstItem.onClickItem.Add(OnItemClick);
        _lstTag.onClickItem.Add(OnTagClick);
        _lstQualityTag.onClickItem.Add(OnQualityTagClick);
        _tfSearch.onChanged.Add(OnSearchChanged);
    }

    private void RemoveUIEvent()
    {
        _lstItem.onClickItem.Remove(OnItemClick);
        _lstTag.onClickItem.Remove(OnTagClick);
        _lstQualityTag.onClickItem.Remove(OnQualityTagClick);
        _tfSearch.onChanged.Remove(OnSearchChanged);
    }

    private void InitChildren()
    {
        _tfSearch = GetTextInput("tfSearch");
        _lstQualityTag = GetList("lstQualityTag");
        _lstTag = GetList("lstTag");
        _lstTag.selectedIndex = 0;//默认选择all标签页
    }

    private void InitLstItem()
    {
        _lstItem = GetList("lstBpItem");
        _lstItem.SetVirtual();
        _lstItem.itemRenderer = OnRenderItem;
        _lstItem.itemProvider = OnProvideItem;
    }

    private void OnDataInit()
    {
        RefreshListItem();
    }

    private void OnDataUpdate()
    {
        RefreshListItem();
    }

    private void OnRenderItem(int index, GObject item)
    {
        if (index >= _bpDataListCache.Count)
        {
            return;
        }


        if (item.asCom is not BpNftItemRenderer renderer)
        {
            return;
        }

        renderer.SetData(_bpDataListCache[index]);
    }

    /// <summary>
    /// 根据数据类型提供背包itemUI资源
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private string OnProvideItem(int index)
    {
        if (index < _bpDataListCache.Count)
        {
            return UIPackage.GetItemURL(eFUIPackage.Backpack.ToString(), FGUIDefine.NFT_ITEM_RES);
        }

        return UIPackage.GetItemURL(eFUIPackage.Backpack.ToString(), FGUIDefine.EMPTY_ITEM_RES);
    }

    private void OnItemClick(EventContext context)
    {
        //todo show tooltip
    }

    private void OnTagClick(EventContext context)
    {
        RefreshListItem();
    }

    private void OnQualityTagClick(EventContext context)
    {
        RefreshListItem();
    }

    private void OnSearchChanged(EventContext context)
    {
        //todo：这里需要做节流优化
        RefreshListItem();
    }

    /// <summary>
    /// 刷新背包列表
    /// </summary>
    private void RefreshListItem()
    {
        List<QueryBpDataBase> queryList = GetQueryList();
        _bpDataListCache = DataManager.Backpack.QueryBpDataList(queryList);
        BackpackUtil.SortNftItemList(_bpDataListCache);
        int lenOffset = DataManager.Backpack.ItemList.Count - _bpDataListCache.Count;//筛选掉的数量
        _lstItem.numItems = DataManager.Backpack.BpSize - lenOffset;
    }

    private List<QueryBpDataBase> GetQueryList()
    {
        List<QueryBpDataBase> queryList = new();
        if (_tfSearch.text.Length > 0)
        {
            queryList.Add(new QueryBpDataName(_tfSearch.text));
        }

        GObject curTag = _lstTag.GetChildAt(_lstTag.selectedIndex);
        if (curTag != null)
        {
            queryList.Add(new QueryBpDataUITag(curTag.name.ToEnum<eItemUIType>()));
        }

        List<int> qualitySelection = _lstQualityTag.GetSelection();
        if (qualitySelection.Count > 0)
        {
            List<eNFTQuality> qualityList = new();
            foreach (int index in qualitySelection)
            {
                GObject obj = _lstQualityTag.GetChildAt(index);
                qualityList.Add(obj.name.ToEnum<eNFTQuality>());
            }
            queryList.Add(new QueryBpDataQuality(qualityList));
        }
        return queryList;
    }
}