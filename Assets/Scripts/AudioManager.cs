using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager :  MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioClip DefaultMusic;
    [SerializeField] private AudioClip DefaultAmbiance;
    public AudioSource MusicAudioSource;
    public AudioSource AmbianceAudioSource;
    public AudioMixerGroup ambiance;
    public AudioMixerGroup music;
    public AudioMixerGroup sfx;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        PlayMusic(DefaultMusic);
        PlayAmbiance(DefaultAmbiance);
        MusicAudioSource.outputAudioMixerGroup = music;
        AmbianceAudioSource.outputAudioMixerGroup = ambiance;
    }
    
    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
        MusicAudioSource.clip = clip;
        MusicAudioSource.Play();
    }

    public void PlayAmbiance(AudioClip clip)
    {
        if (clip == null) return;
        AmbianceAudioSource.clip = clip;
        AmbianceAudioSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        AudioSource caca = transform.AddComponent<AudioSource>();
        caca.outputAudioMixerGroup = sfx;
        caca.clip = clip;
        float clipLength = clip.length;
        Destroy(caca, clipLength);
    } 
    public void StopMusic()
    {
        MusicAudioSource.Stop();
    }

    public void StopAmbiance()
    {
        AmbianceAudioSource.Stop();
    }
    
}