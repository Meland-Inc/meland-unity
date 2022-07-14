using UnityEngine;
using Spine.Unity;

public class TreeIdle : MonoBehaviour
{

    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle;
    public string CurrentState;

    // Start is called before the first frame update
    private void Start()
    {
        SetAnimationState("idle");
    }

    public void SetAnimationState(string state)
    {
        if (state.Equals("idle"))
        {
            SetAnimation(idle, true, 1f);
        }
    }

    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        if (animation != null)
        {
            Spine.TrackEntry animationEntry = skeletonAnimation.state.SetAnimation(0, animation, loop);
            animationEntry.TimeScale = timeScale;
            CurrentState = animation.name;
        }
    }
}