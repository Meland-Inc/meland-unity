/*
 * @Author: xiang huan
 * @Date: 2022-06-16 13:54:28
 * @Description: 领地中心
 * @FilePath: /meland-unity/Assets/Src/Module/Territory/TerritoryCenter.cs
 * 
 */
using UnityGameFramework.Runtime;

public class TerritoryCenter : GameFrameworkComponent
{
    private void Awake()
    {
        Message.RuntimeUserAssetUpdate += UpdateAssetData;
    }

    public void UpdateAssetData(Runtime.TUserAssetResponse data)
    {
        DataManager.Territory.UpdateAssetData(data);
    }
}
