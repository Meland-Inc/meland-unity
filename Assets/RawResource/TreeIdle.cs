using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class TreeIdle : MonoBehaviour
{

    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle;
    public string currentState;    

    // Start is called before the first frame update
    void Start()
    {
        SetAnimationState("idle");
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetAnimationState(string state){
        if(state.Equals("idle")){
            SetAnimation(idle,true,1f);
        }
        currentState = state;
    }

    public void SetAnimation(AnimationReferenceAsset animation,bool loop,float timeScale){
        if(animation!=null){

            if(animation.name.ToLower().Contains(currentState.ToLower()) && !animation.name.Equals("hited") && !animation.name.Equals("attack")){
                return;
            }
            Spine.TrackEntry animationEntry = skeletonAnimation.state.SetAnimation(0,animation,loop);
            animationEntry.TimeScale = timeScale;
            animationEntry.Complete += AnimationEntryComplete;
            currentState = animation.name;
        }
    }

    private void AnimationEntryComplete(Spine.TrackEntry trackEntry){
        if(currentState.Equals("run")||currentState.Equals("run1")){
            SetAnimationState("idle");
        }
    }
}
