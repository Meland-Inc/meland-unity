/*
 * @Author: xiang huan
 * @Date: 2022-05-09 19:35:27
 * @LastEditTime: 2022-06-13 09:58:36
 * @LastEditors: xiang huan
 * @Description: 声音扩展
 * @FilePath: /meland-unity/Assets/Src/Framework/Extension/UnityGameFramework/SoundExtension.cs
 * 
 */


using GameFramework.Sound;
using UnityGameFramework.Runtime;

public static class SoundExtension
{
    private const float FADE_VOLUME_DURATION = 1f;
    private static int? s_musicSerialId = null;

    /// <summary>
    /// 播放音乐<para />
    /// </summary>
    /// <param name="soundAssetName">音效资源<para /></param>
    /// <param name="userData">自定义数据<para /></param>
    /// <returns>标识id</returns>
    public static int? PlayMusic(this SoundComponent soundComponent, string soundAssetName, object userData = null)
    {
        soundComponent.StopMusic();
        PlaySoundParams playSoundParams = PlaySoundParams.Create();
        playSoundParams.Priority = 64;
        playSoundParams.Loop = true;
        playSoundParams.VolumeInSoundGroup = 1f;
        playSoundParams.FadeInSeconds = FADE_VOLUME_DURATION;
        playSoundParams.SpatialBlend = 0f;
        s_musicSerialId = soundComponent.PlaySound(soundAssetName, SoundGroupType.Music, eLoadPriority.Normal, playSoundParams, null, userData);
        return s_musicSerialId;
    }
    /// <summary>
    /// 停止音乐<para />
    /// </summary>
    /// <returns>void</returns>
    public static void StopMusic(this SoundComponent soundComponent)
    {
        if (!s_musicSerialId.HasValue)
        {
            return;
        }

        _ = soundComponent.StopSound(s_musicSerialId.Value, FADE_VOLUME_DURATION);
        s_musicSerialId = null;
    }
    /// <summary>
    /// 播放音效<para />
    /// </summary>
    /// <param name="soundAssetName">音效资源<para /></param>
    /// <param name="loop">是否循环<para /></param>
    /// <param name="fadeIn">声音淡入时间，以秒为单位。<para /></param>
    /// <param name="volume">音量大小<para /></param>
    /// <param name="priority">声音优先级<para /></param>
    /// <param name="spatialBlend">声音空间混合量<para /></param>
    /// <param name="bindingEntity">绑定实体<para /></param>
    /// <param name="userData">自定义数据<para /></param>
    /// <returns>标识id</returns>
    public static int? PlaySound(this SoundComponent soundComponent, string soundAssetName, bool loop = false, float fadeIn = 0f, float volume = 1f, int priority = 0, float spatialBlend = 0f, Entity bindingEntity = null, object userData = null)
    {

        PlaySoundParams playSoundParams = PlaySoundParams.Create();
        playSoundParams.Priority = priority;
        playSoundParams.Loop = loop;
        playSoundParams.FadeInSeconds = fadeIn;
        playSoundParams.VolumeInSoundGroup = volume;
        playSoundParams.SpatialBlend = spatialBlend;
        return soundComponent.PlaySound(soundAssetName, SoundGroupType.Sound, eLoadPriority.Normal, playSoundParams, bindingEntity, userData);
    }

    /// <summary>
    /// 播放音效<para />
    /// </summary>
    /// <param name="soundAssetName">音效资源<para /></param>
    /// <param name="playSoundParams">音效参数<para /></param>
    /// <param name="bindingEntity">绑定实体<para /></param>
    /// <param name="userData">自定义数据<para /></param>
    /// <returns>标识id</returns>
    public static int? PlaySound(this SoundComponent soundComponent, string soundAssetName, PlaySoundParams playSoundParams, Entity bindingEntity = null, object userData = null)
    {
        return soundComponent.PlaySound(soundAssetName, SoundGroupType.Sound, eLoadPriority.Normal, playSoundParams, bindingEntity, userData);
    }

    /// <summary>
    /// 是否静音<para />
    /// </summary>
    /// <param name="soundGroupName">音效组名字<para /></param>
    /// <returns>是否静音</returns>
    public static bool IsMuted(this SoundComponent soundComponent, string soundGroupName)
    {
        if (string.IsNullOrEmpty(soundGroupName))
        {
            Log.Warning("Sound group is invalid.");
            return true;
        }

        ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
        if (soundGroup == null)
        {
            Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
            return true;
        }

        return soundGroup.Mute;
    }

    /// <summary>
    /// 设置静音<para />
    /// </summary>
    /// <param name="soundGroupName">音效组名字<para /></param>
    /// <param name="mute">是否静音<para /></param>
    /// <returns>void</returns>
    public static void Mute(this SoundComponent soundComponent, string soundGroupName, bool mute)
    {
        if (string.IsNullOrEmpty(soundGroupName))
        {
            Log.Warning("Sound group is invalid.");
            return;
        }

        ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
        if (soundGroup == null)
        {
            Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
            return;
        }

        soundGroup.Mute = mute;
    }

    /// <summary>
    /// 获取音量<para />
    /// </summary>
    /// <param name="soundGroupName">音效组名字<para /></param>
    /// <returns>音量</returns>
    public static float GetVolume(this SoundComponent soundComponent, string soundGroupName)
    {
        if (string.IsNullOrEmpty(soundGroupName))
        {
            Log.Warning("Sound group is invalid.");
            return 0f;
        }

        ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
        if (soundGroup == null)
        {
            Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
            return 0f;
        }
        return soundGroup.Volume;
    }

    /// <summary>
    /// 设置音量<para />
    /// </summary>
    /// <param name="soundGroupName">音效组名字<para /></param>
    /// <param name="volume">音量<para /></param>
    /// <returns>void</returns>
    public static void SetVolume(this SoundComponent soundComponent, string soundGroupName, float volume)
    {
        if (string.IsNullOrEmpty(soundGroupName))
        {
            Log.Warning("Sound group is invalid.");
            return;
        }

        ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
        if (soundGroup == null)
        {
            Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
            return;
        }

        soundGroup.Volume = volume;
    }
}

