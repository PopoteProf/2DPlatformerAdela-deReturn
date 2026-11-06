using System;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Collider2D))]
public class MusicTriggerZone : MonoBehaviour
{
    [SerializeField] private bool _changeMusic;
    [SerializeField] private AudioClip _music;
    [SerializeField] private bool _changeAmbience;
    [SerializeField] private AudioClip _ambiance;
    
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(_changeMusic) AudioManager.PlayMusic(_music);
            if(_changeAmbience) AudioManager.PlayAmbience(_ambiance);
            
        }
            
    }
}
