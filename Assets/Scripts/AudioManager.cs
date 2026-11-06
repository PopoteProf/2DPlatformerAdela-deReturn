using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager changeLeFondDEcranDYvan;
    
    public AudioClip DefaultMusic;
    public AudioClip DefaultAmbiance;
    
    public AudioSource MusicAudioSource;
    public AudioSource AmbianceAudioSource;

    public void Awake()
    {
        if (changeLeFondDEcranDYvan == null)
        {
            changeLeFondDEcranDYvan = this;
        }
    }

    private void PlayMusic(AudioClip clip)
    {
        MusicAudioSource.clip = clip;
        MusicAudioSource.Play();
    }

    private void PlayAmbiance(AudioClip clip)
    {
        AmbianceAudioSource.clip = clip;
        AmbianceAudioSource.Play();
    }

    void Start()
    {
        PlayMusic(DefaultMusic);
        PlayAmbiance(DefaultAmbiance);
    }
}
