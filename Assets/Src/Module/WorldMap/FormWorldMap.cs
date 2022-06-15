/*
 * @Author: mangit
 * @LastEditTime: 2022-06-10 16:14:00
 * @LastEditors: mangit
 * @Description: 大世界地图
 * @Date: 2022-06-09 14:18:03
 * @FilePath: /Assets/Src/Module/WorldMap/FormWorldMap.cs
 */
using FairyGUI;
using UnityEngine;
using WorldMap;

public class FormWorldMap : FGUIForm
{
    private GButton _btnZoomIn;
    private GButton _btnZoomOut;
    private GButton _btnShowPlayerName;

    private Controller _ctrlPosType;
    private GTextField _tfPos;
    private GImage _imgClickPos;
    private MapPosTipsLogic _posTipsLogic;
    //todo:
    // private _lowerFpsTaskID = -1;

    private GComponent _comMap;
    private GComponent _comHomeIcons;
    private GComponent _comPlayerIcons;
    // private MouseScaleMoveHandler _mapScaleHandler;
    // private PlayerIconLogic _playerIconLogic;
    // private HomeIconLogic _homeIconLogic;
    // private WorldMapRender _worldMapRender;

    private Controller _ctrlShowGameMap;
    private GGroup _grpMapTypeHeader;
    private GButton _btnShowVipLand;
    private GButton _btnShowGameMap;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        _btnZoomIn = GetButton("btnZoomIn");
        _btnZoomOut = GetButton("btnZoomOut");
        _btnShowPlayerName = GetButton("btnShowPlayerName");

        _ctrlPosType = GetController("ctrlPosType");
        _tfPos = GetTextField("tfPos");
        _imgClickPos = GetImage("imgClickPos");

        _comMap = GetCom("comMap");
        _comHomeIcons = GetCom("comHomeIcons");
        _comPlayerIcons = GetCom("comPlayerIcons");
        _grpMapTypeHeader = GetGroup("grpMapTypeHeader");
        _btnShowGameMap = GetButton("btnShowGameMap");
        _btnShowVipLand = GetButton("btnShowVipLand");
        _ctrlShowGameMap = GetController("ctrlShowGameMap");

        _ = GCom.AddSubUILogic<WorldMapRootLogic>("ComRoot");
        _posTipsLogic = GCom.AddSubUILogic<MapPosTipsLogic>("ComPos");
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        AddUIListener();
        AddMessageListener();
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        RemoveUIListener();
        RemoveMessageListener();
        base.OnClose(isShutdown, userData);
    }

    private void AddUIListener()
    {
        _btnZoomIn.onClick.Add(OnBtnZoomInClick);
        _btnZoomOut.onClick.Add(OnBtnZoomOutClick);
        _btnShowPlayerName.onClick.Add(OnBtnShowPlayerNameClick);
        _btnShowGameMap.onClick.Add(OnBtnShowGameMapClick);
        _ctrlPosType.onChanged.Add(OnCtrlPosTypeChanged);
        _ctrlShowGameMap.onChanged.Add(OnCtrlShowGameMapChanged);
    }

    private void RemoveUIListener()
    {
        _btnZoomIn.onClick.Remove(OnBtnZoomInClick);
        _btnZoomOut.onClick.Remove(OnBtnZoomOutClick);
        _btnShowPlayerName.onClick.Remove(OnBtnShowPlayerNameClick);
        _btnShowGameMap.onClick.Remove(OnBtnShowGameMapClick);
        _ctrlPosType.onChanged.Remove(OnCtrlPosTypeChanged);
        _ctrlShowGameMap.onChanged.Remove(OnCtrlShowGameMapChanged);
    }

    private void AddMessageListener()
    {
        //todo:
    }

    private void RemoveMessageListener()
    {
        //todo
    }

    protected override void OnResize(float w, float h)
    {
        //todo:
    }

    private void OnBtnZoomInClick()
    {
        //
    }

    private void OnBtnZoomOutClick()
    {
        //
    }

    private void OnBtnShowPlayerNameClick()
    {
        //
    }

    private void OnBtnShowGameMapClick()
    {
        //
    }

    private void OnCtrlPosTypeChanged(EventContext context)
    {
        //
    }

    private void OnCtrlShowGameMapChanged(EventContext context)
    {
        //
    }
}