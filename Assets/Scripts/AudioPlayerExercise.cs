using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayerExercise : MonoBehaviour {
    
    public PlayerController2D _playerController2D;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _jumpClip;
    [SerializeField] private AudioClip _landingClip;
    [SerializeField] private AudioSource _attack;
    [SerializeField] private AudioClip _footstepClip;
    [SerializeField] private float _footstepDelay = 0.4f;
    private float _footstepTimer;
    
    void Start() {
        _playerController2D.OnLanding+= PlayerController2DOnOnLanding;
        _playerController2D.OnJumping+= PlayerController2DOnOnJumping;
        _playerController2D.OnAttack+= PlayerController2DOnOnAttack;
        _playerController2D.OnWalking+= PlayerController2DOnOnWalking;
        _playerController2D.OnIsGrounded += PlayerController2DOnOnIsGrounded;
    }
    
    private void Update()
    {
        if (_footstepTimer > 0)
        {
            _footstepTimer -= Time.deltaTime;
        }
    }
    private void PlayerController2DOnOnIsGrounded(object sender, bool isGRounded) {}

    private void PlayerController2DOnOnWalking(object sender, bool isWalking) 
    {
        if (isWalking && _footstepTimer <= 0) 
        {
            _audioSource.clip = _footstepClip; 
            _audioSource.Play();
            _footstepTimer = _footstepDelay;
        }
    }

    private void PlayerController2DOnOnAttack(object sender, EventArgs e)
    {
        _attack.Play();
    }

    private void PlayerController2DOnOnJumping(object sender, EventArgs e) 
    {
        _audioSource.clip = _jumpClip;
        _audioSource.Play();
    }

    private void PlayerController2DOnOnLanding(object sender, EventArgs e) 
    {
        _audioSource.clip = _landingClip;
        _audioSource.Play();
    }
}