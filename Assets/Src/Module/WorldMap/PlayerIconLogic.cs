using System.Collections.Generic;
using Bian;
using FairyGUI;
using Google.Protobuf.Collections;

namespace WorldMap
{
    public class PlayerIconLogic : FGUILogicCpt
    {
        private float _curMapScale = 1.0f;
        private LinkedList<GComponent> _iconPool = new();
        private List<GComponent> _activeIconList = new();
        protected override void OnAdd()
        {
            base.OnAdd();
        }

        protected override void OnRemove()
        {
            base.OnRemove();
            foreach (GComponent icon in _iconPool)
            {
                icon.Dispose();//pool obj need to be disposed
            }
            _iconPool.Clear();
            _activeIconList.Clear();//parent will dispose all child view
            _iconPool = null;
            _activeIconList = null;
        }

        public override void OnOpen()
        {
            base.OnOpen();
            SceneModule.WorldMap.StartReqPlayerLoc();
            SceneModule.WorldMap.OnPlayerLocUpdated += OnPlayerLocUpdated;

            GCom.onRollOver.Add(OnRollOver);
            GCom.onClick.Add(OnClick);
        }

        public override void OnClose()
        {
            base.OnClose();
            SceneModule.WorldMap.StopReqPlayerLoc();
            SceneModule.WorldMap.OnPlayerLocUpdated -= OnPlayerLocUpdated;

            GCom.onRollOver.Remove(OnRollOver);
            GCom.onClick.Remove(OnClick);
        }

        private void OnRollOver()
        {

        }

        private void OnClick()
        {
            GComponent curIcon = GRoot.inst.touchTarget.asCom;
            if (curIcon == null)
            {
                return;
            }
        }

        private void OnPlayerLocUpdated(RepeatedField<PlayerLocInfo> locInfoList)
        {
            foreach (GComponent icon in _activeIconList)
            {
                RecyclePlayerIcon(icon);
            }
            _activeIconList.Clear();

            foreach (PlayerLocInfo locInfo in locInfoList)
            {
                GComponent icon = RenderPlayerIcon(locInfo);
                _activeIconList.Add(icon);
            }
        }

        private GComponent RenderPlayerIcon(PlayerLocInfo info)
        {
            GComponent comIcon = SpawnPlayerIcon();
            comIcon.x = info.Loc.Pos.X * WorldMapDefine.MAP_RATIO * _curMapScale;
            comIcon.y = info.Loc.Pos.Y * WorldMapDefine.MAP_RATIO * _curMapScale;
            comIcon.name = info.Name;
            comIcon.text = info.Name;
            _ = GCom.AddChild(comIcon);
            return comIcon;
        }

        private GComponent SpawnPlayerIcon()
        {
            if (_iconPool.Count > 0)
            {
                GComponent icon = _iconPool.First.Value;
                _iconPool.RemoveFirst();
                return icon;
            }

            return UIPackage.CreateObject(eFUIPackage.WorldMap.ToString(), "comPlayerIcon").asCom;
        }

        private void RecyclePlayerIcon(GComponent icon)
        {
            icon.RemoveFromParent();
            _ = _iconPool.AddLast(icon);
        }

        public void OnMapScaleChanged(float lastScale, float curScale)
        {
            _curMapScale = curScale;
            foreach (GComponent icon in _activeIconList)
            {
                icon.x = icon.x * curScale / lastScale;
                icon.y = icon.y * curScale / lastScale;
            }
        }
    }
}