using UnityEngine;
using FairyGUI;
namespace WorldMap
{
    public class MapPosTipsLogic : FGUILogicCpt
    {
        private GImage _imgClickPos;
        private Vector2 _touchBeginPos = Vector2.zero;

        protected override void OnAdd()
        {
            base.OnAdd();
            _imgClickPos = GCom.GetChild("imgClickPos").asImage;

            GCom.onTouchBegin.Add(OnTouchBegin);
            GCom.onClick.Add(OnClick);
            GCom.onTouchMove.Add(OnTouchMove);
        }

        protected override void OnRemove()
        {
            base.OnRemove();
            GCom.onTouchBegin.Remove(OnTouchBegin);
            GCom.onClick.Remove(OnClick);
            GCom.onTouchMove.Remove(OnTouchMove);
        }

        private void OnTouchBegin(EventContext context)
        {
            _touchBeginPos.x = context.inputEvent.x;
            _touchBeginPos.y = context.inputEvent.y;
            if (context.inputEvent.button != 1)
            {
                GCom.visible = false;
            }
            context.CaptureTouch();
        }

        private void OnClick(EventContext context)
        {
            if (context.inputEvent.button != 0)
            {
                return;
            }
            if (Vector2.Distance(_touchBeginPos, context.inputEvent.position) > 3)
            {
                return;
            }

            Vector2 localPos = GCom.GlobalToLocal(context.inputEvent.position);
            GCom.visible = true;
            _imgClickPos.x = localPos.x;
            _imgClickPos.y = localPos.y;
        }

        private void OnTouchMove()
        {
            GCom.visible = false;//；；；
        }
    }
}