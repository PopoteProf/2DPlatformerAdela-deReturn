using System;
using System.Collections;
using System.Collections.Generic;
using Cainos.LucidEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController2D : MonoBehaviour, IDamagable
{

    [SerializeField] private float _moveSpeedPower= 10;
    [SerializeField] private float _jumpPower=10;
    [SerializeField] private Rigidbody2D _rigidbody;
    
    [Space(5)] 
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _groundDetectionLength = 0.75f;
    [Space(5)] [SerializeField] private bool _diplayDebugGizmos;
    [SerializeField] private float _damagedBumpForce = 1;
    [SerializeField] private float _damagedTime = 1;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriterendere;

    [Space(5), Header("Attack Parameters"), SerializeField]
    private float _attackTime=0.8f;
    [SerializeField]private float _attackDamageDelay = 0.4f;
    [SerializeField]    private SpriteRenderer _attackZoneLeft, _attackZoneRight;

    public Chess Chess;


    private float _timer;
    private bool _isDamaged;
    private bool _isAttacking;
    private bool _hadAttack;
    private Vector3 _velocity;
    private bool _flip;
    [ShowInInspector]private bool _isGrounded;
    
    void Update() {
        if (_isDamaged) {
            ManageIsDamaged();
            return;
        }
        CheckIfGrounded();
        if( Input.GetKeyDown(KeyCode.Space)&&!_isAttacking)StartAttack(); 
        if (_isAttacking) {
            ManagerAttack();
            return;
        }

        if (Chess != null && Input.GetKeyDown(KeyCode.E)) {
            Chess.OpenChess();
            Chess = null;
        }
        ManagerMove();
        
    }

    private void CheckIfGrounded() {
        _isGrounded = Physics2D.Raycast(transform.position, Vector3.down , _groundDetectionLength, _groundMask);
        if (_animator)_animator.SetBool("IsGrounded", _isGrounded);
    }

    private void CheckFlip() {
        if (_velocity.x < -0.1f) _flip = true;
        if (_velocity.x > 0.1f) _flip = false;
    }

    private void ManagerMove() {
        _velocity = _rigidbody.velocity;
        //_velocity.x = Mathf.Clamp(_velocity.x+ Input.GetAxisRaw("Horizontal") * _moveSpeedPower, -_moveSpeedLimite, _moveSpeedLimite);
        _velocity.x = Input.GetAxisRaw("Horizontal") * _moveSpeedPower;
        if (Input.GetKeyDown(KeyCode.UpArrow)&&_isGrounded) _velocity.y += _jumpPower;
        _rigidbody.velocity = _velocity;
        
        CheckFlip();
        
        if (_animator)_animator.SetBool("IsWalking",_velocity.x>0.3f||_velocity.x<-0.3f );
        if (_spriterendere)_spriterendere.flipX = _flip;
    }

    private void ManageIsDamaged() {
        _timer += Time.deltaTime;
        if (_timer >= _damagedTime)
        {
            _isDamaged = false;
            _timer = 0;
        }
        if (_animator)_animator.SetBool("IsDamaged", _isDamaged);
        CheckIfGrounded();
    }

    public void ManagerAttack() {
        _timer += Time.deltaTime;
        if (_timer >= _attackDamageDelay && !_hadAttack) {
            if (_diplayDebugGizmos) {
                if (_flip) _attackZoneLeft.enabled = true;
                else _attackZoneRight.enabled = true;
            }

            DoAttackDamage();
            _hadAttack = true;
        }

        if (_timer >= _attackTime) {
            _attackZoneLeft.enabled = false;
            _attackZoneRight.enabled = false;

            _timer = 0;
            _isAttacking=false;
            _hadAttack = false;
            if (_animator)_animator.SetBool("Attack", false);
        }
    }
    private void DoAttackDamage() {
        Collider2D[] cols = new Collider2D[0];
        if (_flip) cols =Physics2D.OverlapBoxAll(_attackZoneLeft.transform.position, new Vector2(1,2), 0);
        else cols =Physics2D.OverlapBoxAll(_attackZoneRight.transform.position, new Vector2(1,2), 0);
        foreach (var col in cols) {
            if (col.transform.GetComponent<IDamagable>()!=null) {
                if (col.gameObject == gameObject) return;
                col.transform.GetComponent<IDamagable>().TakeDamage(1, transform.position);
            }
        }
    }

    public void StartAttack() {
        _timer = 0;
        _isAttacking = true;
        if (_animator)_animator.SetBool("Attack", true);
    }
    
    public void TakeDamage(int damage, Vector2 origin) {
        Vector2 push = new Vector2(transform.position.x - origin.x, 1).normalized;
        _rigidbody.AddForce(push * _damagedBumpForce, ForceMode2D.Impulse);
        //_rigidbody.velocity = push * _damagedBumpForce;
        _isDamaged = true;

        
    }

    private void OnDrawGizmos()
    {
        if(!_diplayDebugGizmos) return;
        if( _isGrounded)Gizmos.color = Color.yellow;
        else Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position+Vector3.down * _groundDetectionLength);
    }
    
    
}
