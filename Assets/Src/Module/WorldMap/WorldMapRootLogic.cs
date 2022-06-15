using System.Net.Mime;
/*
 * @Author: mangit
 * @LastEditTime: 2022-06-14 10:20:39
 * @LastEditors: mangit
 * @Description: 世界地图 root  
 * @Date: 2022-06-10 14:29:50
 * @FilePath: /Assets/Src/Module/WorldMap/WorldMapRootLogic.cs
 */
using FairyGUI;
using UnityEngine;
namespace WorldMap
{
    public class WorldMapRootLogic : FGUILogicCpt
    {
        private Vector2 _scaleCenter = Vector2.zero;
        private float _lastScale = 1;
        private VipLandLogoLogic _vipLandLogoLogic;
        private WorldMapDisplayLogic _mapDisplayLogic;
        private PlayerIconLogic _playerIconLogic;
        private HomeIconLogic _homeIconLogic;
        protected override void OnAdd()
        {
            base.OnAdd();
            GCom.scrollPane.mouseWheelEnabled = false;
            _mapDisplayLogic = GCom.AddSubUILogic<WorldMapDisplayLogic>("comMap");
            _vipLandLogoLogic = GCom.AddSubUILogic<VipLandLogoLogic>("comVipLandLogo");
            _playerIconLogic = GCom.AddSubUILogic<PlayerIconLogic>("comPlayerIcon");
            _homeIconLogic = GCom.AddSubUILogic<HomeIconLogic>("comHomeIcon");
            _lastScale = _mapDisplayLogic.MapScale;

            GCom.displayObject.onMouseWheel.Add(OnMapMouseWheel);
            GCom.scrollPane.onScroll.Add(OnScroll);
        }
        private void OnScroll()
        {
            _mapDisplayLogic.UpdateMapBlocks(GCom.scrollPane.posX, GCom.scrollPane.posY);
        }

        private void OnMapMouseWheel(EventContext context)
        {
            _scaleCenter = _mapDisplayLogic.GCom.GlobalToLocal(context.inputEvent.position);
            float scaleDelta = context.inputEvent.mouseWheelDelta > 0 ? WorldMapDefine.SCALE_SPEED : -WorldMapDefine.SCALE_SPEED;
            float targetScale = Mathf.Clamp(_lastScale + scaleDelta, WorldMapDefine.MIN_MAP_SCALE, WorldMapDefine.MAX_MAP_SCALE);
            scaleDelta = targetScale - _lastScale;
            _mapDisplayLogic.GCom.SetScale(targetScale, targetScale);
            GCom.scrollPane.SetContentSize(_mapDisplayLogic.RealWidth, _mapDisplayLogic.RealHeight);

            GCom.scrollPane.posX = GCom.scrollPane.scrollingPosX + (_scaleCenter.x * scaleDelta);
            GCom.scrollPane.posY = GCom.scrollPane.scrollingPosY + (_scaleCenter.y * scaleDelta);
            _mapDisplayLogic.UpdateMapBlocks(0, 0);
            OnMapSizeChanged();
        }

        private void OnMapSizeChanged()
        {
            _vipLandLogoLogic.OnMapScaleChanged(_lastScale, _mapDisplayLogic.MapScale);
            _playerIconLogic.OnMapScaleChanged(_lastScale, _mapDisplayLogic.MapScale);
            _homeIconLogic.OnMapScaleChanged(_lastScale, _mapDisplayLogic.MapScale);
            _lastScale = _mapDisplayLogic.MapScale;
        }
    }
}