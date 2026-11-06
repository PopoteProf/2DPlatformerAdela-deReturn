using System;
using UnityEngine;

public class MusicTriggerZone : MonoBehaviour
{
    public bool changeMusic;
    public AudioClip music;
    public bool changeAmbiance;
    public AudioClip ambiance;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && changeMusic)
        {
            AudioManager.instance.StopMusic();
            AudioManager.instance.PlayMusic(music);
        }

        if (other.CompareTag("Player") && changeAmbiance)
        {
            AudioManager.instance.StopAmbiance();
            AudioManager.instance.PlayAmbiance(ambiance);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && changeMusic)
            AudioManager.instance.StopMusic();
        if (other.CompareTag("Player") && changeAmbiance)
            AudioManager.instance.StopAmbiance();
    }
}