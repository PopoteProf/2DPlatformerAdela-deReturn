using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Default Audio Clips")]
    [SerializeField] private AudioClip _defaultMusic;
    [SerializeField] private AudioClip _defaultAmbiance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource _musicAudioSource;
    [SerializeField] private AudioSource _ambianceAudioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (_defaultMusic != null)
        {
            PlayMusic(_defaultMusic);
        }

        if (_defaultAmbiance != null)
        {
            PlayAmbiance(_defaultAmbiance);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;

        _musicAudioSource.clip = clip;
        _musicAudioSource.Play();
    }

    public void PlayAmbiance(AudioClip clip)
    {
        if (clip == null) return;

        _ambianceAudioSource.clip = clip;
        _ambianceAudioSource.Play();
    }
}