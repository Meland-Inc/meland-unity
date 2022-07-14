using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class TreeIdle : MonoBehaviour
{

    public SkeletonAnimation SkeletonAnimation;
    public AnimationReferenceAsset Idle;
    private string CurrentState;    

    // Start is called before the first frame update
    void Start()
    {
        SetAnimationState("idle");
    }

    public void SetAnimationState(string state)
    {
        if(state.Equals("idle"))
        {
            SetAnimation(Idle,true,1f);
        }
        CurrentState = state;
    }

    public void SetAnimation(AnimationReferenceAsset animation,bool loop,float timeScale)
    {
        if(animation!=null)
        {
            Spine.TrackEntry animationEntry = SkeletonAnimation.state.SetAnimation(0,animation,loop);
            //animationEntry.TimeScale = timeScale;
            //animationEntry.Complete += AnimationEntryComplete;
            CurrentState = animation.name;
        }
    }

}
