/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 玩家信息
 * @Date: 2022-06-22 14:51:10
 * @FilePath: /Assets/Src/Module/MainPlayerRole/view/FormPlayerInfo.cs
 */
using FairyGUI;
public class FormPlayerInfo : FGUIForm
{
    private const string VIEW_TYPE_ROLE = "role";
    private const string VIEW_TYPE_SLOT = "slot";
    private GTextField _tfName;
    private GList _lstSlot;
    private ComRoleInfoLogic _roleInfoLogic;
    private ComSlotInfoLogic _slotInfoLogic;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        _tfName = GetTextField("tfName");
        _lstSlot = GetList("lstSlot");

        _roleInfoLogic = GCom.AddSubUILogic<ComRoleInfoLogic>("comRoleInfo");
        _slotInfoLogic = GCom.AddSubUILogic<ComSlotInfoLogic>("comSlotInfo");
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        base.OnClose(isShutdown, userData);
    }

    private void AddMessage()
    {

    }

    private void RemoveMessage()
    {

    }

    private void AddUIEvent()
    {
        _lstSlot.onClickItem.Add(OnClickSlotItem);
    }

    private void RemoveUIEvent()
    {
        _lstSlot.onClickItem.Remove(OnClickSlotItem);
    }

    private void OnClickSlotItem(EventContext context)
    {

    }
}