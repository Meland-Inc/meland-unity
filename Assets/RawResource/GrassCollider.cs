using UnityEngine;
using Spine.Unity;

public class GrassCollider : MonoBehaviour
{

    public SkeletonAnimation SkeletonAnimation;
    public AnimationReferenceAsset Idle;
    public AnimationReferenceAsset Run;
    public string currentState;    

    // Start is called before the first frame update
    void Start()
    {
        SetAnimationState("idle");
    }

    public void OnTriggerEnter(){
        SetAnimationState("run");
    }

    public void SetAnimationState(string state){
        if(state.Equals("idle")){
            SetAnimation(Idle, true, 1f);
        }else if(state.Equals("run")){
            SetAnimation(Run, true, 1f);
        }
    }

    public void SetAnimation(AnimationReferenceAsset animation,bool loop,float timeScale){
        if (animation != null)
        {
            Spine.TrackEntry animationEntry = SkeletonAnimation.state.SetAnimation(0, animation, loop);
            animationEntry.TimeScale = timeScale;
            animationEntry.Complete += AnimationEntryComplete;
            currentState = animation.name;
        }
    }

    private void AnimationEntryComplete(Spine.TrackEntry trackEntry){
        if(currentState.Equals("run")){
            SetAnimationState("idle");
        }
    }
}