using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayerEffects : MonoBehaviour
{

    public PlayerController2D _playerController2D;
    [SerializeField] private AudioMixerGroup _mixerGroup;
    
    [Space(10)]
    public AudioElement _SFXLanding;
    public AudioElement _SFXJimping;
    public AudioElement _SFXAttacking;
    [Space(10), SerializeField] 
    private float _foodStepDelay =0.5f;
    [SerializeField]private AudioElement _SFXFootStep;

    private bool _isGrounded;
    private bool _isWalking;
    private float _footStepTimer;
    void Start() {
        _playerController2D.OnLanding+= PlayerController2DOnOnLanding;
        _playerController2D.OnJumping+= PlayerController2DOnOnJumping;
        _playerController2D.OnAttack+= PlayerController2DOnOnAttack;
        _playerController2D.OnWalking+= PlayerController2DOnOnWalking;
        _playerController2D.OnIsGrounded += PlayerController2DOnOnIsGrounded;
    }

    private void Update()
    {
        if( _isWalking && _isGrounded) ManagerFootStep();
    }

    private void ManagerFootStep() {
        _footStepTimer += Time.deltaTime;
        if (_footStepTimer >= _foodStepDelay) {
            _footStepTimer = 0;
            PlayFootStep();
        }
    }

    private void PlayerController2DOnOnIsGrounded(object sender, bool e) {
        _isGrounded = e;
        if (!e) _footStepTimer = 0;
    }

    private void PlayerController2DOnOnWalking(object sender, bool e) {
        _isWalking = e;
        if (!e) _footStepTimer = 0;
    }

    private void PlayerController2DOnOnAttack(object sender, EventArgs e) {
        AudioClip clip = _SFXAttacking.GetSound();
        if (clip == null) return;
        AudioSource audioSource = transform.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.pitch = _SFXAttacking.GetPitch();
        audioSource.outputAudioMixerGroup = _mixerGroup;
        audioSource.Play();
        Destroy(audioSource, audioSource.clip.length+1);
    }

    private void PlayerController2DOnOnJumping(object sender, EventArgs e) {
        AudioClip clip = _SFXJimping.GetSound();
        if (clip == null) return;
        AudioSource audioSource = transform.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.pitch = _SFXJimping.GetPitch();
        audioSource.outputAudioMixerGroup = _mixerGroup;
        audioSource.Play();
        Destroy(audioSource, clip.length+1);
    }

    private void PlayerController2DOnOnLanding(object sender, EventArgs e) {
        AudioClip clip = _SFXLanding.GetSound();
        if (clip == null) return;
        AudioSource audioSource = transform.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.pitch = _SFXLanding.GetPitch();
        audioSource.outputAudioMixerGroup = _mixerGroup;
        audioSource.Play();
        Destroy(audioSource, clip.length+1);
    }
    private void PlayFootStep() {
        AudioClip clip = _SFXFootStep.GetSound();
        if (clip == null) return;
        AudioSource audioSource = transform.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.pitch = _SFXFootStep.GetPitch();
        audioSource.outputAudioMixerGroup = _mixerGroup;
        audioSource.Play();
        Destroy(audioSource, clip.length+1);
    }
}