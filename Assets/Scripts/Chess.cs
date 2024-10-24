using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chess : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _isOpen;
    [SerializeField] private ParticleSystem _psCoindUp;
    [SerializeField] private AudioSource _audioSource;

    public void OpenChess() {
        _animator.SetBool("Open", true);
        if (_psCoindUp != null) _psCoindUp.Play();
        if( _audioSource!=null) _audioSource.Play();
        
        enabled = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (_isOpen) return;
        if (other.gameObject.GetComponent<PlayerController2D>() != null) {
            other.gameObject.GetComponent<PlayerController2D>().Chess = this;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (_isOpen) return;
        if (other.gameObject.GetComponent<PlayerController2D>() != null) {
            other.gameObject.GetComponent<PlayerController2D>().Chess = this;
        }
    }
}
