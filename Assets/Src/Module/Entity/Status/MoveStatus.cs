using System;
using GameFramework.Fsm;

public class MoveStatus : MoveStatusCore
{
    protected override Type IdleStatusType => typeof(IdleStatus);

    protected override void OnEnter(IFsm<EntityStatusCtrl> fsm)
    {
        base.OnEnter(fsm);

        IAnimationCpt animCpt = StatusCtrl.GetComponent<IAnimationCpt>();
        animCpt.PlayAnim(EntityDefine.ANIM_NAME_RUN, true);
    }
}