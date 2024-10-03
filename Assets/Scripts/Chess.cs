using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _isOpen;
    [SerializeField] private bool _close;

    public void OpenChess() {
        _animator.SetBool("Open", true);
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
