using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Clips")]
    [SerializeField] private AudioClip _defaultMusic;
    [SerializeField] private AudioClip _defaultAmbiance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource _musicAudioSource;
    [SerializeField] private AudioSource _ambianceAudioSource;

    [Header("Audio Mixers")]
    [SerializeField] private AudioMixerGroup _musicMixer;
    [SerializeField] private AudioMixerGroup _ambianceMixer;
    [SerializeField] private AudioMixerGroup _sfxMixer;
    
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(Instance);
        Instance = this;
    }

    private void Start()
    {
        PlayMusic(_defaultMusic);
        PlayAmbiance(_defaultAmbiance);
    }
    
    public void PlayMusic(AudioClip clip)
    {
        _musicAudioSource.clip = clip;
        _musicAudioSource.Play();
    }

    public void PlayAmbiance(AudioClip clip)
    {
        _ambianceAudioSource.clip = clip;
        _ambianceAudioSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = _sfxMixer;
        Destroy(source, clip.length + .1f);
    }
}