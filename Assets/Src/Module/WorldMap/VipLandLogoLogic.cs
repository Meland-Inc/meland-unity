using Bian;
using System.Collections.Generic;
using FairyGUI;
using Google.Protobuf.Collections;

namespace WorldMap
{
    public class VipLandLogoLogic : FGUILogicCpt
    {
        private const int GRID_SIZE = 18;
        private const int GRID_GAP = 1;
        private LinkedList<ComVipLandLogo> _logoPool = new();
        private List<ComVipLandLogo> _activeLogoList = new();
        private GObject _imgGrid;
        private GComponent _comRawVipLandCtnr;
        private GComponent _comVipLandCtnr;
        private ComVipLandLogo _lastLogo;
        protected override void OnAdd()
        {
            base.OnAdd();
            _imgGrid = GCom.GetChild("imgGrid");
            _comRawVipLandCtnr = GCom.GetChild("comRawVipLandCtnr").asCom;
            _comVipLandCtnr = GCom.GetChild("comVipLandGroupCtnr").asCom;
            GCom.onSizeChanged.Add(OnSizeChanged);
            GCom.onClick.Add(OnClickLogo);

            LoadTestData();
        }

        protected override void OnRemove()
        {
            foreach (ComVipLandLogo logo in _logoPool)
            {
                logo.Dispose();
            }
            _logoPool.Clear();
            _logoPool = null;
            _activeLogoList.Clear();
            _activeLogoList = null;
            base.OnRemove();
        }

        public override void OnOpen()
        {
            base.OnOpen();
            SceneModule.WorldMap.OnVipLandLogoUpdated += OnVipLandLogoUpdated;
        }

        public override void OnClose()
        {
            SceneModule.WorldMap.OnVipLandLogoUpdated -= OnVipLandLogoUpdated;
            base.OnClose();
        }

        private void LoadTestData()
        {
            SceneModule.WorldMap.ReqLogoData();
        }

        private void OnVipLandLogoUpdated(RepeatedField<BigWorldLogoInfo> infoList)
        {
            foreach (ComVipLandLogo logo in _activeLogoList)
            {
                RecycleComLogo(logo);
            }
            _activeLogoList.Clear();

            foreach (BigWorldLogoInfo logo in infoList)
            {
                AddLogo(logo);
            }
        }

        private void OnClickLogo(EventContext context)
        {
            if (GRoot.inst.touchTarget is not ComVipLandLogo logo)
            {
                return;
            }

            if (_lastLogo != null)
            {
                _lastLogo.selected = false;
            }

            _lastLogo = logo;
        }

        private void OnSizeChanged()
        {
            // _imgGrid.width = GCom.width / _imgGrid.scaleX;
            // _imgGrid.height = GCom.height / _imgGrid.scaleY;   
        }

        public void OnMapScaleChanged(float lastScale, float scale)
        {
            HandleMapScaleChanged(_comRawVipLandCtnr, lastScale, scale);
            HandleMapScaleChanged(_comVipLandCtnr, lastScale, scale);
            _imgGrid.SetScale(scale, scale);
        }

        private void HandleMapScaleChanged(GComponent com, float lastScale, float scale)
        {
            foreach (GObject obj in com._children)
            {
                obj.x = obj.x * scale / lastScale;
                obj.y = obj.y * scale / lastScale;
                obj.width = obj.width * scale / lastScale;
                obj.height = obj.height * scale / lastScale;
            }
        }

        private void AddLogo(BigWorldLogoInfo logoInfo)
        {
            foreach (BigWorldVipLandGroup groupInfo in logoInfo.VipLandGroups)
            {
                ComVipLandLogo logo = RenderGroupLogo(groupInfo);
                logo.SetLogoInfo(logoInfo);
                _activeLogoList.Add(logo);
            }

            foreach (int rcIndex in logoInfo.VipLands)
            {
                ComVipLandLogo logo = RenderRawLogo(rcIndex);
                logo.SetLogoInfo(logoInfo);
                _activeLogoList.Add(logo);
            }
        }

        private ComVipLandLogo RenderRawLogo(int rcIndex)
        {
            ComVipLandLogo logo = SpawnComLogo();
            (int, int) rc = WorldMapTool.RCIndex2RC(rcIndex);
            logo.x = (rc.Item2 * GRID_SIZE) + GRID_GAP;
            logo.y = (rc.Item1 * GRID_SIZE) + GRID_GAP;
            _ = _comRawVipLandCtnr.AddChild(logo);
            return logo;
        }

        private ComVipLandLogo RenderGroupLogo(BigWorldVipLandGroup groupInfo)
        {
            ComVipLandLogo logo = SpawnComLogo();
            logo.SetIsGroup(true);

            int rcIndex = groupInfo.VipLands[0];//vip Land group中，第一个vip land的index是其所在的row col index
            (int, int) rc = WorldMapTool.RCIndex2RC(rcIndex);
            int colLen = groupInfo.Width;
            int rowLen = groupInfo.VipLands.Count / colLen;
            logo.x = (rc.Item2 * GRID_SIZE) + GRID_GAP;
            logo.y = (rc.Item1 * GRID_SIZE) + GRID_GAP;
            logo.width = (colLen * GRID_SIZE) - (GRID_GAP * 2);
            logo.height = (rowLen * GRID_SIZE) - (GRID_GAP * 2);
            // logo.icon = groupInfo.Image;
            _ = _comVipLandCtnr.AddChild(logo);

            return logo;
        }

        private ComVipLandLogo SpawnComLogo()
        {
            return _logoPool.Count > 0 ? _logoPool.First.Value : UIPackage.CreateObject(eFUIPackage.WorldMap.ToString(), "ComVipLandLogo") as ComVipLandLogo;
        }

        private void RecycleComLogo(ComVipLandLogo logo)
        {
            logo.RemoveFromParent();
            _ = _logoPool.AddLast(logo);
        }
    }
}