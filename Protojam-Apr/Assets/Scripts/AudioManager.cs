using UnityEngine;

/// <summary>
/// 게임의 배경음악(BGM) 및 사운드 이펙트(SFX)를 관리하는 MonoSingleton입니다.
/// <para></para>
/// AudioManager를 사용할 때 하위 오브젝트 두개에 각각 AudioSource 컴포넌트를 추가해 bgmSource와 sfxSource에 할당해야 합니다.
/// <para></para>
/// 또한 AudioClipsScriptableObject를 생성하여 bgmClips와 sfxClips에 각각 BGM과 SFX 사운드 클립을 추가해야 합니다.
/// <para></para>
/// AudioClips의 위치 : Assets/Resources/ScriptableObjects/AudioClips.asset
/// </summary>
public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField] private BGMClipsScriptableObject bgmClips;
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private BGMType currentBGMClip = BGMType.None;
    public float BGMVolume
    {
        get => bgmSource.volume;
        set => bgmSource.volume = value;
    }

    [SerializeField] private SFXClipsScriptableObject sfxClips;
    [SerializeField] private AudioSource sfxSource;
    public float SFXVolume
    {
        get => sfxSource.volume;
        set => sfxSource.volume = value;
    }

    public void PlayBGM(BGMType type)
    {
        if (type == BGMType.None) return;

        bgmSource.clip = bgmClips.list[type];
        bgmSource.Play();

        currentBGMClip = type;
    }

    public void StopBGM()
    {
        bgmSource.Stop();

        currentBGMClip = BGMType.None;
    }

    public void PlaySFX(SFXType type, bool oneShot = true)
    {
        if (type == SFXType.None) return;

        var clip = sfxClips.list[type];
        if (oneShot)
        {
            sfxSource.PlayOneShot(clip);
        }
        else if (!sfxSource.isPlaying)
        {
            sfxSource.clip = clip;
            sfxSource.Play();
        }
    }
}