using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayerEffects : MonoBehaviour
{

    public PlayerController2D _playerController2D;
    
    void Start() {
        _playerController2D.OnLanding+= PlayerController2DOnOnLanding;
        _playerController2D.OnJumping+= PlayerController2DOnOnJumping;
        _playerController2D.OnAttack+= PlayerController2DOnOnAttack;
        _playerController2D.OnWalking+= PlayerController2DOnOnWalking;
        _playerController2D.OnIsGrounded += PlayerController2DOnOnIsGrounded;
    }

   

    private void PlayerController2DOnOnIsGrounded(object sender, bool e) {
        
    }

    private void PlayerController2DOnOnWalking(object sender, bool e) {
        
    }

    private void PlayerController2DOnOnAttack(object sender, EventArgs e) {
       
    }

    private void PlayerController2DOnOnJumping(object sender, EventArgs e) {
        
    }

    private void PlayerController2DOnOnLanding(object sender, EventArgs e) {
       
    }
   
}