/*
 * @Author: xiang huan
 * @Date: 2022-07-20 13:45:40
 * @Description: 实体头部信息UI
 * @FilePath: /meland-unity/Assets/Src/Module/Common/HUD/HUDEntityHeadInfo.cs
 * 
 */
using FairyGUI;
using UnityEngine;

public class HUDEntityHeadInfo : HUDBase
{
    private GList _infoList;
    private GComponent _comHeadInfoAnswer;
    private GComponent _answerStateEffectRoot;
    private GComponent _comHeadInfoFight;
    private GComponent _comHeadInfoHp;
    private Controller _ctrlHeadInfoHpType;
    private GLoader _imgHpProcess;
    private GComponent _comHeadInfoNickName;
    private GTextField _tfNick;
    private Controller _ctrlRoleName;
    public static readonly string HEAD_INFO_HP_TYPE_FRIEND = "friend";
    public static readonly string HEAD_INFO_HP_TYPE_ENEMY = "enemy";
    public static readonly string HEAD_INFO_HP_TYPE_ENEMY_GRAY = "enemyGray";
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        _infoList = GetList("list");

        _comHeadInfoAnswer = _infoList.GetChild("comHeadInfoAnswer").asCom;
        _answerStateEffectRoot = _comHeadInfoAnswer.GetChild("root").asCom;

        _comHeadInfoFight = _infoList.GetChild("comHeadInfoFight").asCom;

        _comHeadInfoHp = _infoList.GetChild("comHeadInfoHp").asCom;
        _ctrlHeadInfoHpType = _comHeadInfoHp.GetController("ctrlType");
        _imgHpProcess = _comHeadInfoHp.GetChild("imgHpProcess").asLoader;

        _comHeadInfoNickName = _infoList.GetChild("comHeadInfoNickName").asCom;
        _tfNick = _comHeadInfoNickName.GetChild("tfNick").asTextField;
        _ctrlRoleName = _comHeadInfoNickName.GetController("ctrlRoleName");
    }


    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        HideAllInfo();
        SetHpVisible(true);
        SetNickNameVisible(true);
    }
    protected override void OnClose(bool isShutdown, object userData)
    {

        base.OnClose(isShutdown, userData);
    }
    public void HideAllInfo()
    {
        GObject[] objectList = _infoList.GetChildren();
        for (int i = 0; i < objectList.Length; i++)
        {
            objectList[i].visible = false;
        }
    }

    public void SetNickNameVisible(bool visible)
    {
        _comHeadInfoNickName.visible = visible;
    }
    public void SetNickName(string name)
    {
        _tfNick.text = name;
    }

    public void SetNickNameColor(Color color)
    {
        _tfNick.color = color;
    }

    /**改变角色归属 -> 角色名称颜色 */
    public void ChangeRole(bool isMine)
    {
        _ctrlRoleName.selectedPage = isMine ? "mine" : "other";
    }

    public void SetHpVisible(bool visible)
    {
        _comHeadInfoHp.visible = visible;
    }
    public void SetHp(float process)
    {
        _imgHpProcess.width = process * _imgHpProcess.initWidth;
    }
    public void SetHpType(string page)
    {
        _ctrlHeadInfoHpType.selectedPage = page;
    }
}
