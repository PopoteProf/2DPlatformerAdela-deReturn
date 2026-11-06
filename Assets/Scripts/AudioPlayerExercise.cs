using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayerExercise : MonoBehaviour {
    
    public PlayerController2D _playerController2D;
    [SerializeField] private AudioSource onLand;
    [SerializeField] private AudioSource onJump;
    [SerializeField] private AudioSource onAttack;
    // [SerializeField] private AudioSource onWalk;
    // [SerializeField] private AudioSource onGrounded;
    [SerializeField] private AudioClip walkSound;

    private bool Grounded;
    private bool Walking;
    [SerializeField] private float walkSoundDelay;
    private float walkSoundTimer;
    
    void Start() {
        _playerController2D.OnLanding+= PlayerController2DOnOnLanding;
        _playerController2D.OnJumping+= PlayerController2DOnOnJumping;
        _playerController2D.OnAttack+= PlayerController2DOnOnAttack;
        _playerController2D.OnWalking+= PlayerController2DOnOnWalking;
        _playerController2D.OnIsGrounded += PlayerController2DOnOnIsGrounded;
    }
    
    private void PlayerController2DOnOnIsGrounded(object sender, bool isGRounded) {
        // onGrounded.Play();
        Grounded = isGRounded;
    }

    private void PlayerController2DOnOnWalking(object sender, bool isWalking) {
        // onWalk.Play();
        Walking = isWalking;
    }

    private void PlayerController2DOnOnAttack(object sender, EventArgs e)
    {
        onAttack.Play();
    }

    private void PlayerController2DOnOnJumping(object sender, EventArgs e) {
       onJump.Play();
    }

    private void PlayerController2DOnOnLanding(object sender, EventArgs e) {
        onLand.Play();
    }

    private void Update()
    {
        if (Walking && Grounded)
        {
            ManageFootStep();
        }
    }

    private void ManageFootStep()
    {
        walkSoundTimer += Time.deltaTime;
        if (walkSoundTimer >= walkSoundDelay)
        {
            walkSoundTimer = 0;
            PlayFootStep();
        }
    }
    
    private void PlayFootStep()
    {
        AudioManager.instance.PlaySFX(walkSound);
    }
}