/*
 * @Author: xiang huan
 * @Date: 2022-06-16 13:54:28
 * @Description: 大世界
 * @FilePath: /meland-unity/Assets/Src/Module/BigWorld/BigWorldCenter.cs
 * 
 */
using UnityGameFramework.Runtime;

public class BigWorldCenter : GameFrameworkComponent
{
    private void Awake()
    {
        Message.RuntimeUserAssetUpdate += UpdateAssetData;
    }

    public void UpdateAssetData(Runtime.TUserAssetResponse data)
    {
        DataManager.BigWorld.UpdateAssetData(data);
    }
}
