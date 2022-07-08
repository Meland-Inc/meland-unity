/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: nft item tooltip
 * @Date: 2022-07-01 10:34:41
 * @FilePath: /Assets/Src/Module/Backpack/View/TooltipSyntheticMatDetail.cs
 */
using System;
using System.IO;
public class TooltipSyntheticMatDetail : FGUITooltip
{
    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        try
        {
            int itemID = (int)TooltipInfo.Data;
            DRItem drItem = GFEntry.DataTable.GetDataTable<DRItem>().GetDataRow(itemID);
            GetTextField("tfName").text = drItem.Name;
            GetTextField("tfDesc").text = drItem.Desc;
            GetTextField("icon").icon = Path.Combine(AssetDefine.PATH_ITEM_ICON, $"{drItem.Icon}.png");
        }
        catch (Exception e)
        {
            MLog.Error(eLogTag.ui, e.Message);
        }
    }
}