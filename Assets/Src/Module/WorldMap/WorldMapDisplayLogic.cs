using FairyGUI;
using UnityEngine;

namespace WorldMap
{
    public class WorldMapDisplayLogic : FGUILogicCpt
    {
        private GComponent _mapDisplay;
        protected override void OnAdd()
        {
            base.OnAdd();
            WorldMapTool tool = new();
            _mapDisplay = tool.LoadMapFromIpfsUrls(WorldMapDefine.s_WorldMapUrls);
            _ = GCom.AddChildAt(_mapDisplay, 0);
            InitMapScale(3);
            CheckMapBlocksVisible();
        }

        public void UpdateMapBlocks(float posX, float posY)
        {
            CheckMapBlocksVisible();
        }

        /// <summary>
        /// 不在屏幕内的不渲染
        /// </summary>
        private void CheckMapBlocksVisible()
        {
            foreach (GObject obj in _mapDisplay._children)
            {
                Vector2 leftTop = obj.LocalToGlobal(Vector2.zero);
                Vector2 rightBottom = obj.LocalToGlobal(obj.size);
                obj.visible = leftTop.x <= Screen.width && rightBottom.x >= 0 && leftTop.y <= Screen.height && rightBottom.y >= 0;
            }
        }

        private void InitMapScale(float scale)
        {
            _mapDisplay.SetScale(scale, scale);
            GCom.SetSize(_mapDisplay.width * scale, _mapDisplay.height * scale);
            UpdateMapBlocks(0, 0);
        }

        public float MapScale => GCom.scaleX;

        public float RealWidth => GCom.width * MapScale;
        public float RealHeight => GCom.height * MapScale;
    }
}