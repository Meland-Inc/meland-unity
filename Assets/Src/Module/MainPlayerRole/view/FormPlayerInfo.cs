/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 玩家信息
 * @Date: 2022-06-22 14:51:10
 * @FilePath: /Assets/Src/Module/MainPlayerRole/view/FormPlayerInfo.cs
 */
using MelandGame3;
using FairyGUI;
public class FormPlayerInfo : FGUIForm
{
    private const string VIEW_TYPE_ROLE = "role";
    private const string VIEW_TYPE_SLOT = "slot";
    private const string VIEW_TYPE_SKILL = "skill";
    private GList _lstSlot;
    private ComRoleInfoLogic _roleInfoLogic;
    private ComSlotInfoLogic _slotInfoLogic;
    private ComSkillInfLogic _skillInfoLogic;
    private Controller _ctrlViewType;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        _lstSlot = GetList("lstSlot");
        _ctrlViewType = GetController("ctrlViewType");
        AddSubLogic();
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        AddMessage();
        AddUIEvent();
        UpdateView();
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        RemoveMessage();
        RemoveUIEvent();
        base.OnClose(isShutdown, userData);
    }

    private void AddMessage()
    {
        SceneModule.BackpackMgr.OnWearableDataUpdated += OnAvatarUpdated;
        SceneModule.RoleLevel.OnRoleUpgraded += OnRoleUpgraded;
        SceneModule.RoleLevel.OnSlotUpgraded += OnSlotUpgraded;
        Message.RoleProfileUpdated += OnRoleProfileUpdated;
    }

    private void RemoveMessage()
    {
        SceneModule.BackpackMgr.OnWearableDataUpdated -= OnAvatarUpdated;
        SceneModule.RoleLevel.OnRoleUpgraded -= OnRoleUpgraded;
        SceneModule.RoleLevel.OnSlotUpgraded -= OnSlotUpgraded;
        Message.RoleProfileUpdated -= OnRoleProfileUpdated;
    }

    private void AddUIEvent()
    {
        _lstSlot.onClickItem.Add(OnClickSlotItem);
        _ctrlViewType.onChanged.Add(OnCtrlViewTypeChanged);
    }

    private void RemoveUIEvent()
    {
        _lstSlot.onClickItem.Remove(OnClickSlotItem);
        _ctrlViewType.onChanged.Remove(OnCtrlViewTypeChanged);
    }

    private void AddSubLogic()
    {
        _roleInfoLogic = GCom.AddSubUILogic<ComRoleInfoLogic>("comRoleInfo");
        _slotInfoLogic = GCom.AddSubUILogic<ComSlotInfoLogic>("comSlotInfo");
        _skillInfoLogic = GCom.AddSubUILogic<ComSkillInfLogic>("comSkillInfo");
    }

    private void OnClickSlotItem(EventContext context)
    {
        UpdateSubView();
    }

    private void OnCtrlViewTypeChanged()
    {
        UpdateSubView();
    }

    private void OnAvatarUpdated()
    {
        UpdateSlotView();
    }

    private void OnRoleUpgraded()
    {
        UpdateView();
    }

    private void OnSlotUpgraded(AvatarPosition pos)
    {
        UpdateSlotView();
        UpdateSubView();
    }

    private void OnRoleProfileUpdated(EntityProfileField field)
    {
        UpdateView();
    }

    private void UpdateView()
    {
        UpdateSlotView();
        UpdateSubView();
    }

    private void UpdateSlotView()
    {
        for (int index = 0; index < _lstSlot.numChildren; index++)
        {
            AvatarPosition slotPos = LstIndex2AvatarPos(index);
            EquipmentSlot slotItem = _lstSlot.GetChildAt(index) as EquipmentSlot;
            _ = DataManager.Backpack.WearableItemDic.TryGetValue(slotPos, out BpWearableNftItem data);
            _ = DataManager.MainPlayer.ItemSlotDic.TryGetValue(slotPos, out ItemSlot slotData);
            slotItem.SetNftData(data);
            slotItem.SetSlotData(slotData);
        }
    }

    private void UpdateSubView()
    {
        if (_ctrlViewType.selectedPage == VIEW_TYPE_ROLE)
        {
            _roleInfoLogic.UpdateView();
        }
        else if (_ctrlViewType.selectedPage == VIEW_TYPE_SLOT)
        {
            _slotInfoLogic.UpdateView(LstIndex2AvatarPos(_lstSlot.selectedIndex));
        }
        else
        {
            _skillInfoLogic.UpdateView();
        }
    }

    private AvatarPosition LstIndex2AvatarPos(int index)
    {
        if (index == 0)
        {
            return AvatarPosition.AvatarPositionWeapon;
        }

        return (AvatarPosition)index;
    }
}