using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
    private AudioSource MusicAudioSource;
    private AudioSource AmbianceAudioSource;
    
    private AudioClip DefaultMusic;
    private AudioClip DefaultAmbiance;

    public void PlayMusic(AudioClip clip)
    {
        DefaultMusic = clip;
        MusicAudioSource.clip = clip;
        MusicAudioSource.Play();
    }

    public void PlayAmbiance(AudioClip clip)
    {
        DefaultAmbiance = clip;
        AmbianceAudioSource.clip = clip;
        AmbianceAudioSource.Play();
    }
}
