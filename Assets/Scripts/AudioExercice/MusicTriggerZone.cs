using System;
using UnityEngine;
using UnityEngine.Audio;

public class MusicTriggerZone : MonoBehaviour
{
    [SerializeField] private bool _changeMusic;
    [SerializeField] private AudioClip _music;
    [SerializeField] private bool _changeAmbiance;
    [SerializeField] private AudioClip _ambiance;
    
    private AudioManager _audioManager;


    private void Awake()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

private void OnTriggerEnter2D(Collider2D other)
{
        if (other.CompareTag("Player"))
        {
            _changeMusic = true;
            _changeAmbiance = true;
            _audioManager.PlayMusic(_music);
            _audioManager.PlayAmbiance(_ambiance);
            
        }
    }
}
