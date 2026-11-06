using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayerExercise : MonoBehaviour {
    
    public PlayerController2D _playerController2D;

    [SerializeField] private float _footstepInterval;
    [SerializeField] private AudioClip _footstepSFX;
    [SerializeField] private AudioMixerGroup _sfxMixer;
    
    [Header("Audio Sources")]
    [SerializeField] private AudioSource _attackAudio;
    [SerializeField] private AudioSource _jumpingAudio;
    [SerializeField] private AudioSource _landingAudio;
    //[SerializeField] private AudioSource _walkingAudio;

    private bool _isGrounded;
    private bool _isWalking;
    private float _footstepTimer;
    
    void Start() {
        _playerController2D.OnLanding+= PlayerController2DOnOnLanding;
        _playerController2D.OnJumping+= PlayerController2DOnOnJumping;
        _playerController2D.OnAttack+= PlayerController2DOnOnAttack;
        _playerController2D.OnWalking+= PlayerController2DOnOnWalking;
        _playerController2D.OnIsGrounded += PlayerController2DOnOnIsGrounded;
    }

    void Update()
    {
        _isGrounded = _playerController2D.IsGrounded;
        _isWalking = _playerController2D.IsWalking;
        
        if (_isGrounded && _isWalking) ManageFootStep();
    }

    void ManageFootStep()
    {
        _footstepTimer += Time.deltaTime;
        if (_footstepTimer >= _footstepInterval)
        {
            PlayFootStep();
            _footstepTimer = 0;
        }
    }

    void PlayFootStep()
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = _sfxMixer;
        Destroy(source, _footstepSFX.length + .1f);
    }
    
    private void PlayerController2DOnOnIsGrounded(object sender, bool isGRounded) {
        
    }

    private void PlayerController2DOnOnWalking(object sender, bool isWalking) {
        //_walkingAudio.Play();
    }

    private void PlayerController2DOnOnAttack(object sender, EventArgs e)
    {
        _attackAudio.Play();
    }

    private void PlayerController2DOnOnJumping(object sender, EventArgs e)
    {
        _jumpingAudio.Play();
    }

    private void PlayerController2DOnOnLanding(object sender, EventArgs e) {
        _landingAudio.Play();
    }
    
}