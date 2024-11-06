using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTriggerZonne : MonoBehaviour
{

    [SerializeField] private bool _changeMusic = true;
    [SerializeField] private AudioClip _music;
    [SerializeField] private bool _changeAmbiance = true;
    [SerializeField] private AudioClip _ambiance;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(_changeMusic) AudioManager.Instance.PlayMusic(_music);
            if(_changeAmbiance) AudioManager.Instance.PlayAmbiance(_ambiance);
        }
    }
}