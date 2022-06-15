using System.Collections.Generic;
using FairyGUI;
namespace WorldMap
{
    public class HomeIconLogic : FGUILogicCpt
    {
        private List<GComponent> _activeIconList = new();
        private LinkedList<GComponent> _iconPool = new();
        protected override void OnAdd()
        {
            base.OnAdd();
        }

        protected override void OnRemove()
        {
            foreach (GComponent icon in _iconPool)
            {
                icon.Dispose();
            }
            _iconPool.Clear();
            _activeIconList.Clear();
            _iconPool = null;
            _activeIconList = null;
            base.OnRemove();
        }

        public void OnMapScaleChanged(float lastScale, float curScale)
        {
            foreach (GComponent icon in _activeIconList)
            {
                icon.x = icon.x * curScale / lastScale;
                icon.y = icon.y * curScale / lastScale;
            }
        }
    }
}