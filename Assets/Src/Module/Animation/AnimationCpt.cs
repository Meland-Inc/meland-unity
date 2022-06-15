/*
 * @Author: xiang huan
 * @Date: 2022-06-14 19:07:39
 * @LastEditTime: 2022-06-15 15:45:36
 * @LastEditors: xiang huan
 * @Description: 动画组件基类
 * @FilePath: /meland-unity/Assets/Src/Module/Animation/AnimationCpt.cs
 * 
 */
using System;
using UnityEngine;

public abstract class AnimationCpt : MonoBehaviour
{
    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="animationName">动画名</param>
    /// <param name="loop">是否循环</param>
    /// <param name="timeScale">播放速度</param>
    public abstract void PlayAnim(string animationName, bool loop = false, float timeScale = 1f);

    /// <summary>
    /// 是否播放
    /// </summary>
    /// <param name="animationName">动画名</param>
    public abstract bool IsPlaying(string animationName);
    /// <summary>
    /// 动画排队播放
    /// </summary>
    /// <param name="animationName">动画名</param>
    /// <param name="loop">是否循环</param>
    /// <param name="timeScale">播放速度</param>
    /// <param name="delay">延长时间</param>
    public abstract void PlayAnimQueued(string animationName, bool loop = false, float timeScale = 1f, float delay = 0f);
    /// <summary>
    /// 停止播放
    /// </summary>
    /// <param name="animationName">动画名</param>
    public abstract void StopAnim(string animationName);
    /// <summary>
    /// 动画事件监听
    /// </summary>
    public Action<string, eAnimationEventType, object> EventDelegate = delegate { };
}

public enum eAnimationEventType
{
    /// <summary>
    /// 动画开始
    /// </summary>
    Start,
    /// <summary>
    /// 动画停止
    /// </summary>
    End,
    /// <summary>
    /// 动画播放完成，如果是循环事件会重复出现多次
    /// </summary>
    Complete,
    /// <summary>
    /// 动画销毁
    /// </summary>
    Dispose,
    /// <summary>
    /// 用户自定义事件
    /// </summary>
    Event,
}


