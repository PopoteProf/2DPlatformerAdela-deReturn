using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayerExercise : MonoBehaviour {
    
    public PlayerController2D _playerController2D;
    [SerializeField] private AudioSource  _audioWalk;
    [SerializeField] private AudioSource  _audioJump;
    [SerializeField] private AudioSource  _audioAttack;
    [SerializeField] private AudioSource  _audioLanding;
    [SerializeField] private AudioSource  _audioGrounded;
    
    void Start() {
        _playerController2D.OnLanding+= PlayerController2DOnOnLanding;
        _playerController2D.OnJumping+= PlayerController2DOnOnJumping;
        _playerController2D.OnAttack+= PlayerController2DOnOnAttack;
        _playerController2D.OnWalking+= PlayerController2DOnOnWalking;
        _playerController2D.OnIsGrounded += PlayerController2DOnOnIsGrounded;
    }
    
    private void PlayerController2DOnOnIsGrounded(object sender, bool isGRounded) {
        _audioGrounded.Play();
    }

    private void PlayerController2DOnOnWalking(object sender, bool isWalking) {
        _audioWalk.Play();
    }

    private void PlayerController2DOnOnAttack(object sender, EventArgs e) {
        _audioAttack.Play();
        
    }

    private void PlayerController2DOnOnJumping(object sender, EventArgs e) {
        _audioJump.Play();
       
    }

    private void PlayerController2DOnOnLanding(object sender, EventArgs e) {
        _audioLanding.Play();
        
    }
    
}