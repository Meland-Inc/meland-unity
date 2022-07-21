using System;
using GameFramework.Fsm;

public class IdleStatus : IdleStatusCore
{
    protected override Type MoveStatusType => typeof(MoveStatus);

    protected override void OnEnter(IFsm<EntityStatusCtrl> fsm)
    {
        base.OnEnter(fsm);

        IAnimationCpt animCpt = StatusCtrl.GetComponent<IAnimationCpt>();
        animCpt.PlayAnim(EntityDefine.ANIM_NAME_IDLE, true);
    }
}