/*
 * @Author: xiang huan
 * @Date: 2022-06-14 15:52:04
 * @LastEditTime: 2022-06-15 15:44:24
 * @LastEditors: xiang huan
 * @Description: spine播放动画数据
 * @FilePath: /meland-unity/Assets/Src/Module/Animation/SpineAnimationInfo.cs
 * 
 */


public class SpineAnimationInfo
{
    public int TrackIndex { get; private set; }
    public string AnimationName { get; private set; }
    public bool Loop { get; private set; }
    public float TimeScale { get; private set; }
    public float Delay { get; private set; }

    public static SpineAnimationInfo Create(int trackIndex, string animationName, bool loop = false, float timeScale = 1f, float delay = 0)
    {
        SpineAnimationInfo info = new()
        {
            TrackIndex = trackIndex,
            AnimationName = animationName,
            Loop = loop,
            TimeScale = timeScale,
            Delay = delay
        };
        return info;
    }
}