using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum BGMEnum
{
}

public enum SFXEnum
{
    뿅
}

public class SoundManager : MonoSingleton<SoundManager>
{
    [SerializeField] private BgmListData bgmListData;
    [SerializeField] private SfxListData sfxListData;
    
    AudioSource bgmPlayer;
    AudioSource[] sfxPlayers;
    

    public int channels = 16;
    int channelIndex;
    
    [SerializeField] private AudioMixer _mixer;

    private Dictionary<BGMEnum,AudioClip> _bgmDic = new Dictionary<BGMEnum,AudioClip>();
    private Dictionary<SFXEnum,AudioClip> _sfxDic = new Dictionary<SFXEnum,AudioClip>();

    private void Awake()
    {
        Init();
        DontDestroyOnLoad(gameObject);
    }

    private void Init()
    {
        foreach (BgmSO item in bgmListData.bgmList)
        {
            _bgmDic.Add(item.bgmType,item.clip);
        }
        foreach (SfxSO item in sfxListData.sfxList)
        {
            _sfxDic.Add(item.sfxType,item.clip);
        }
        
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.GetComponent<AudioSource>().outputAudioMixerGroup = _mixer.FindMatchingGroups("BGM")[0];
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        //bgmPlayer.clip = bgmLis

        // 효과음 초기화
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];
        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[i].outputAudioMixerGroup = _mixer.FindMatchingGroups("SFX")[0];
            sfxPlayers[i].playOnAwake = false;
        }
        
        _mixer.SetFloat("MASTER", Mathf.Log10(0.5f) * 20);
        _mixer.SetFloat("SFX", Mathf.Log10(0.5f) * 20);
        _mixer.SetFloat("BGM", Mathf.Log10(0.5f) * 20);
        
    }
    
    public void PlaySfx(SFXEnum sfx)
    {
        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            int loopIndex = (i + channelIndex) % sfxPlayers.Length;
            if (sfxPlayers[loopIndex].isPlaying)
            {
                continue;
            }
            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = _sfxDic[sfx];
            sfxPlayers[loopIndex].Play();
            break;
        }
    }

    public void BgmStop()
    {
        bgmPlayer.Stop();
    }
    public void PlayBgm(BGMEnum bgm)
    {
        bgmPlayer.clip = _bgmDic[bgm];
        bgmPlayer.Play();
    }

    public void SetBgmVolume(float value)
    {
        _mixer.SetFloat("BGM", Mathf.Log10(value) * 20);
        
    }
    public void SetSfxVolume(float value)
    {
        _mixer.SetFloat("SFX", Mathf.Log10(value) * 20);
    } 
    public void SetMasterVolume(float value)
    {
        _mixer.SetFloat("MASTER", Mathf.Log10(value) * 20);
    }
}
