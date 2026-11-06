using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayerExercise : MonoBehaviour {
    
    [Header("PlayerController")]
    public PlayerController2D _playerController2D;

    [Header("SoundEffects"), Space(5)] 
    [SerializeField] private AudioSource _playerAttack;
    [SerializeField] private AudioSource _playerJump;
    [SerializeField] private AudioSource _playerLand;
    
    void Start() {
        _playerController2D.OnLanding+= PlayerController2DOnOnLanding;
        _playerController2D.OnJumping+= PlayerController2DOnOnJumping;
        _playerController2D.OnAttack+= PlayerController2DOnOnAttack;
        _playerController2D.OnWalking+= PlayerController2DOnOnWalking;
        _playerController2D.OnIsGrounded += PlayerController2DOnOnIsGrounded;
    }
    
    private void PlayerController2DOnOnIsGrounded(object sender, bool isGRounded) {
        
    }

    private void PlayerController2DOnOnWalking(object sender, bool isWalking) {
    }

    private void PlayerController2DOnOnAttack(object sender, EventArgs e) {
        _playerAttack.Play();
    }

    private void PlayerController2DOnOnJumping(object sender, EventArgs e) {
        _playerJump.Play();
    }

    private void PlayerController2DOnOnLanding(object sender, EventArgs e) {
        Debug.Log("MethodPlays");
        _playerLand.Play();
    }
}