using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

public class AudioPlayerExercise : MonoBehaviour {
    
    public PlayerController2D _playerController2D;
    
    [SerializeField] private AudioSource _onLanding;
    [SerializeField] private AudioSource _onJumping;
    [SerializeField] private AudioSource _onAttack;
    [SerializeField] private AudioSource _onWalking;
    [SerializeField] private AudioSource _onIsGrounded;
    
    void Start() {
        _playerController2D.OnLanding+= PlayerController2DOnOnLanding;
        _playerController2D.OnJumping+= PlayerController2DOnOnJumping;
        _playerController2D.OnAttack+= PlayerController2DOnOnAttack;
        _playerController2D.OnWalking+= PlayerController2DOnOnWalking;
        _playerController2D.OnIsGrounded += PlayerController2DOnOnIsGrounded;
    }
    
    private void PlayerController2DOnOnIsGrounded(object sender, bool isGRounded) {
        if(_onIsGrounded) _onIsGrounded?.Play();
    }

    private void PlayerController2DOnOnWalking(object sender, bool isWalking) {
        if(_onWalking) _onWalking.Play();
    }

    private void PlayerController2DOnOnAttack(object sender, EventArgs e) {
        if(_onAttack) _onAttack.Play();
    }

    private void PlayerController2DOnOnJumping(object sender, EventArgs e) {
        if(_onJumping) _onJumping.Play();
    }

    private void PlayerController2DOnOnLanding(object sender, EventArgs e) {
        if(_onLanding) _onLanding.Play();
    }
    
}