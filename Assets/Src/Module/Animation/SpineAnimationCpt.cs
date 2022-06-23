/*
 * @Author: xiang huan
 * @Date: 2022-06-14 14:11:43
 * @Description: spine动画组件
 * @FilePath: /meland-unity/Assets/Src/Module/Animation/SpineAnimationCpt.cs
 * 
 */
using System.Collections.Generic;
using System;
using Spine.Unity;
using Spine;

public class SpineAnimationCpt : UnityEngine.MonoBehaviour, IAnimationCpt
{

    private SkeletonAnimation _skeletonAnimation;
    private Skeleton _skeleton;
    private AnimationState _animationState;
    private const int DEFAULT_TRACK_INDEX = 0;
    private Dictionary<int, List<SpineAnimationInfo>> _animInfoMap;
    public Action<string, eAnimationEventType, object> EventDelegate
    {
        get; set;
    }

    public bool IsValid { get; private set; }
    void Awake()
    {
        _animInfoMap = new();
        IsValid = false;
        EventDelegate = delegate { };
    }

    public void Init()
    {
        if (IsValid)
        {
            return;
        }
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        Init(_skeletonAnimation);
    }

    public void Init(SkeletonAnimation skeletonAnim)
    {
        if (IsValid)
        {
            return;
        }
        _skeletonAnimation = skeletonAnim;
        if (_skeletonAnimation != null && _skeletonAnimation.valid)
        {
            IsValid = true;
            _skeleton = _skeletonAnimation.skeleton;
            _animationState = _skeletonAnimation.AnimationState;
            _animationState.Start += OnSpineAnimationStart;
            _animationState.Interrupt += OnSpineAnimationInterrupt;
            _animationState.End += OnSpineAnimationEnd;
            _animationState.Dispose += OnSpineAnimationDispose;
            _animationState.Complete += OnSpineAnimationComplete;
            ExecuteAnim();
        }
    }

    public void PlayAnim(string animationName, bool loop = false, float timeScale = 1f)
    {
        PlayAnim(DEFAULT_TRACK_INDEX, animationName, loop, timeScale);
    }
    public void PlayAnim(int trackIndex, string animationName, bool loop, float timeScale = 1f)
    {
        if (!IsValid)
        {
            SpineAnimationInfo info = SpineAnimationInfo.Create(trackIndex, animationName, loop, timeScale);
            AddAnimationInfo(trackIndex, info, true);
            return;
        }
        TrackEntry curEntry = _animationState.GetCurrent(trackIndex);
        if (curEntry != null && curEntry.Animation.Name == animationName)
        {
            return;
        }

        TrackEntry entry = _animationState.SetAnimation(trackIndex, animationName, loop);
        entry.TimeScale = timeScale;
    }

    public void PlayAnimQueued(string animationName, bool loop = false, float timeScale = 1f, float delay = 0f)
    {
        PlayAnimQueued(DEFAULT_TRACK_INDEX, animationName, loop, delay, timeScale);
    }
    public void PlayAnimQueued(int trackIndex, string animationName, bool loop = false, float timeScale = 1f, float delay = 0f)
    {
        if (!IsValid)
        {
            SpineAnimationInfo info = SpineAnimationInfo.Create(trackIndex, animationName, loop, timeScale, delay);
            AddAnimationInfo(trackIndex, info, false);
            return;
        }
        TrackEntry entry = _animationState.AddAnimation(trackIndex, animationName, loop, delay);
        entry.TimeScale = timeScale;
    }
    private void AddAnimationInfo(int trackIndex, SpineAnimationInfo info, bool isClear)
    {

        if (_animInfoMap.TryGetValue(trackIndex, out List<SpineAnimationInfo> infoList))
        {
            if (isClear)
            {
                infoList.Clear();
            }
            infoList.Add(info);
        }
        else
        {
            infoList = new()
            {
                info
            };
            _animInfoMap.Add(trackIndex, infoList);
        }
    }
    private void ExecuteAnim()
    {
        foreach (KeyValuePair<int, List<SpineAnimationInfo>> item in _animInfoMap)
        {
            for (int i = 0; i < item.Value.Count; i++)
            {
                SpineAnimationInfo info = item.Value[i];
                PlayAnimQueued(item.Key, info.AnimationName, info.Loop, info.Delay, info.TimeScale);
            }
        }
        _animInfoMap.Clear();
    }
    public bool IsPlaying(string name)
    {
        return IsPlaying(DEFAULT_TRACK_INDEX, name);
    }

    public bool IsPlaying(int trackIndex, string name)
    {
        if (!IsValid)
        {
            return false;
        }
        TrackEntry curEntry = _animationState.GetCurrent(trackIndex);
        return curEntry != null && curEntry.Animation.Name == name;
    }
    public void StopAnim(string name)
    {
        StopAnim(DEFAULT_TRACK_INDEX);
    }

    public void StopAnim(int trackIndex)
    {
        if (_animInfoMap.ContainsKey(trackIndex))
        {
            _ = _animInfoMap.Remove(trackIndex);
        }
        if (!IsValid)
        {
            return;
        }
        _animationState.ClearTrack(trackIndex);
    }

    public void OnSpineAnimationStart(TrackEntry trackEntry)
    {
        EventDelegate?.Invoke(trackEntry.Animation.Name, eAnimationEventType.Start, null);
    }
    public void OnSpineAnimationInterrupt(TrackEntry trackEntry)
    {
        EventDelegate?.Invoke(trackEntry.Animation.Name, eAnimationEventType.Complete, null);
    }
    public void OnSpineAnimationEnd(TrackEntry trackEntry)
    {
        EventDelegate?.Invoke(trackEntry.Animation.Name, eAnimationEventType.End, null);
    }
    public void OnSpineAnimationDispose(TrackEntry trackEntry)
    {
        EventDelegate?.Invoke(trackEntry.Animation.Name, eAnimationEventType.Dispose, null);
    }
    public void OnSpineAnimationComplete(TrackEntry trackEntry)
    {
        EventDelegate?.Invoke(trackEntry.Animation.Name, eAnimationEventType.Complete, null);
    }

    public void OnUserDefinedEvent(TrackEntry trackEntry, Event e)
    {
        EventDelegate?.Invoke(trackEntry.Animation.Name, eAnimationEventType.Event, e);
    }

}