using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private void Awake()
    {
        Singleton();
    }
    void Singleton()
    {
        if (Instance !=null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _ambianceSource;
    [SerializeField] private AudioClip _defaultMusic;
    [SerializeField] private AudioClip _defaultAmbience
        ;
    [SerializeField] private AudioMixerGroup _sfxGroup;


    public void Start()
    {
        if(_defaultAmbience) PlayAmbience(Instance._defaultAmbience);
        if(_defaultMusic) PlayMusic(Instance._defaultMusic);
    }

    public static void PlayMusic(AudioClip clip)
    {
        if(clip)
        {
            Instance._musicSource.clip = clip;
            Instance._musicSource.Play();
        }
        else
        {
            Instance._musicSource.Stop();
        }
    }
    public static void PlayAmbience(AudioClip clip)
    {
        if(clip)
        {
            Instance._ambianceSource.clip = clip;
            Instance._ambianceSource.Play();
        }
        else
        {
            Instance._ambianceSource.Stop();
        }
    }

    public static void PlaySfx(AudioClip clip)
    {
        if (!clip) return;
        
        AudioSource source = Instance.gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.outputAudioMixerGroup = Instance._sfxGroup;
        source.Play();
        source.loop = false;
        
        Destroy(source, clip.length);
    }
}
