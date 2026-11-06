using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance = null;
    public static AudioManager Instance => _instance;
    
    [SerializeField] private AudioClip _defaultMusic;
    [SerializeField] private AudioClip _defaultAmbiance;
    [SerializeField] private AudioSource _musicAudioSource;
    [SerializeField] private AudioSource _ambianceAudioSource;

    public AudioSource MusicAudioSource => _musicAudioSource;
    public AudioSource AmbianceAudioSource => _ambianceAudioSource;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        PlayMusic(_defaultMusic);
        PlayAmbiance(_defaultAmbiance);
    }

    public void PlayMusic(AudioClip clip)
    {
        _musicAudioSource.Stop();
        _musicAudioSource.clip = null;
        _musicAudioSource.clip = clip;
        _musicAudioSource.Play();
    }

    public void PlayAmbiance(AudioClip clip)
    {
        _ambianceAudioSource.Stop();
        _ambianceAudioSource.clip = null;
        _ambianceAudioSource.clip = clip;
        _ambianceAudioSource.Play();
    }
    
}
