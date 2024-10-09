using System;
using UnityEngine;

public class PlayerController2D : MonoBehaviour, IDamagable
{

    [SerializeField] private float _moveSpeedPower= 10;
    [SerializeField] private float _jumpPower=10;
    [SerializeField] private Rigidbody2D _rigidbody;

    [Space(5)] 
    [SerializeField] private bool _SpriteIsFlip;
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

    [Header("Particules")]
    [SerializeField] private ParticleSystem _psWalk;
    [SerializeField] private ParticleSystem _PSDashRight;
    [SerializeField] private ParticleSystem _pSDashLeft;
    [SerializeField] private ParticleSystem _pSJump;
    [SerializeField] private ParticleSystem _pSLanding;
    [SerializeField] private ParticleSystem _pSHit;
    [NonSerialized]public Chess Chess;


    private float _timer;
    private bool _isDamaged;
    private bool _isAttacking;
    private bool _hadAttack;
    private bool _isWalking;
    private Vector3 _velocity;
    private bool _flip;
    private bool _isGrounded;
    
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
        bool isGrounded = Physics2D.Raycast(transform.position, Vector3.down , _groundDetectionLength, _groundMask);
        if (_animator)_animator.SetBool("IsGrounded", isGrounded);
        if( _isGrounded==false && isGrounded&&_pSLanding!=null) _pSLanding.Play();
        _isGrounded = isGrounded;
    }

    private void CheckFlip()
    {
        if (_SpriteIsFlip) {
            if (_velocity.x < -0.1f) _flip = false;
            if (_velocity.x > 0.1f) _flip = true;
        }
        else{
            if (_velocity.x < -0.1f) _flip = true;
            if (_velocity.x > 0.1f) _flip = false;
        }
    }

    private void ManagerMove() {
        _velocity = _rigidbody.velocity;
        _velocity.x = Input.GetAxisRaw("Horizontal") * _moveSpeedPower;
        if (Input.GetKeyDown(KeyCode.UpArrow) && _isGrounded) {
            _velocity.y += _jumpPower;
            if(_pSJump!=null)_pSJump.Play();
        }
        _rigidbody.velocity = _velocity;
        
        CheckFlip();
        bool isWalking = _velocity.x > 0.3f || _velocity.x < -0.3f;
        
        //Gère l'animator et le flip du sprite lors de la marche.
        if (_animator)_animator.SetBool("IsWalking",isWalking );
        if (_spriterendere)_spriterendere.flipX = _flip;

        //Gère les particule lors de la marche.
        if (_psWalk != null) {
            ParticleSystem.EmissionModule emission = _psWalk.emission;
            emission.enabled = isWalking&& _isGrounded;
        }

        if (_isWalking == false && isWalking&&_isGrounded) {
            if(_velocity.x<0&&_pSDashLeft!=null)_pSDashLeft.Play();
            if(_velocity.x>0&&_PSDashRight!=null)_PSDashRight.Play();
        }

        _isWalking = isWalking;
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

                if (_pSHit != null) Instantiate(_pSHit, ( col.transform.position) , Quaternion.identity);
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
