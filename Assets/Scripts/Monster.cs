using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour , IDamagable
{

    [SerializeField] private MonsterStat _monsterStat;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _hp =2;
    [Header("Move")]
    [SerializeField] private float _moveSpeedPower= 3;
    
    [Header("waiting"), SerializeField]
    private float _waitingtime=2;

    [Header("Attack"), SerializeField] 
    private LayerMask _playerLayerMask;
    [SerializeField]private float _attackTime =2;
    [SerializeField] private float _attackDamageDelay =1.5f;
    
    [Header("Damaged"),SerializeField] 
    private float _damagedFreezTime;
    [Header("GroundDetection"), Space(5)] 
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _groundDetectionLength = 0.75f;
    [SerializeField] private Transform _leftDetector, _rightDetectot;
    [SerializeField] private float _detectionDistance = 0.5f;
    [Space(10)] 
    [SerializeField] private bool _destroyOnDeath;
    [SerializeField] private GameObject _prefabPSDeath;
    [Space(10),Header("Debug"),SerializeField] private bool _diplayDebugGizmos;
    [SerializeField] private SpriteRenderer _leftTriggerZone, _rightTriggerZonne;
    [SerializeField] private float _damagedBumpForce = 7;
    

    private Vector3 _velocity;
    private bool _isGrounded;
    private bool _flip;
    private float _timer;
    private bool _hadAttack;
    private int _direction {
        get {
            if (_flip) return -1;
            return 1;
        }
    }

    private enum MonsterStat {
        waiting, walking , attacking, damaged, dead
    }

    private void FlipMonster() {
        _flip = !_flip;
        _spriteRenderer.flipX = _flip;
    }

    void Update() {

        CheckIfGrounded();
        switch (_monsterStat) {
            case MonsterStat.waiting:ManageWaiting(); break;
            case MonsterStat.walking: ManageMove(); break;
            case MonsterStat.attacking:ManagerAttack(); break;
            case MonsterStat.damaged:ManageDamaged(); break;
            case MonsterStat.dead:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void CheckIfGrounded() {
        _isGrounded = Physics2D.Raycast(transform.position, Vector3.down , _groundDetectionLength, _groundMask);
    }

    private bool CheckForBounds() {
        if (_flip) {
            if (Physics2D.Raycast(_leftDetector.position, Vector2.left, _detectionDistance, _groundMask)) return true;
            if (!Physics2D.Raycast(_leftDetector.position, Vector2.down, _detectionDistance, _groundMask)) return true;
        }
        else
        { 
            if (Physics2D.Raycast(_rightDetectot.position, Vector2.right, _detectionDistance, _groundMask)) return true;
            if (!Physics2D.Raycast(_rightDetectot.position, Vector2.down, _detectionDistance, _groundMask)) return true;
        }
        return false;
    }
    private bool CheckForPlayer() {
        if (_flip) { if (Physics2D.Raycast(_leftDetector.position, Vector2.left, _detectionDistance, _playerLayerMask)) return true; }
        else if (Physics2D.Raycast(_rightDetectot.position, Vector2.right, _detectionDistance, _playerLayerMask)) return true;
        
        return false;
    }
    

    private void ManageMove() {
        if (!_isGrounded) return;
        if (CheckForPlayer()) {
            StartAttack();
            return;
        }
        if (_animator)_animator.SetBool("IsWalking", true);
        
        
        _velocity = _rigidbody.velocity;
        _velocity.x =  _moveSpeedPower*_direction;
        _rigidbody.velocity = _velocity;
        if (CheckForBounds()) {
            _monsterStat = MonsterStat.waiting;
            _timer = 0;
            _velocity.x =  0;
            _rigidbody.velocity = _velocity;
            FlipMonster();
        }
    }

    private void ManageWaiting() {
        if (_animator)_animator.SetBool("IsWalking", false);
        if (CheckForPlayer()) {
            StartAttack();
            return;
        }
        _timer += Time.deltaTime;
        if (_timer >= _waitingtime) {
            _monsterStat = MonsterStat.walking;
        }
        
    } 
    private void ManageDamaged() {
        _timer += Time.deltaTime;
        if (_timer >= _damagedFreezTime) {
            _monsterStat = MonsterStat.walking;
            _timer = 0;
            if (_animator)_animator.SetBool("IsDamaged", false);
        }
        
        CheckIfGrounded();
    }
   

    private void ManagerAttack() {
        _timer += Time.deltaTime;
        if (_timer >= _attackDamageDelay && !_hadAttack) {
            if (_diplayDebugGizmos) {
                if (_flip) _leftTriggerZone.enabled = true;
                else _rightTriggerZonne.enabled = true;
            }
            DoAttackDamage();
            _hadAttack = true;
        }

        if (_timer >= _attackTime) {
            _leftTriggerZone.enabled = false;
            _rightTriggerZonne.enabled = false;

            _timer = 0;
            _monsterStat = MonsterStat.waiting;
            if (_animator)_animator.SetBool("Attack", false);
        }
        
    }

    private void DoAttackDamage() {
        Collider2D[] cols = new Collider2D[0];
        if (_flip) cols =Physics2D.OverlapBoxAll(_leftTriggerZone.transform.position, new Vector2(1,2), 0);
        else cols =Physics2D.OverlapBoxAll(_rightTriggerZonne.transform.position, new Vector2(1,2), 0);


        Debug.Log(cols.Length+" Targets");
        foreach (var col in cols) {
            if (col.transform.GetComponent<IDamagable>()!=null)
            {
                if (col.gameObject == gameObject) return;
                col.transform.GetComponent<IDamagable>().TakeDamage(1, transform.position);
            }
        }
    }

    private void StartAttack() {
        _timer = 0;
        _velocity.x =  0;
        _rigidbody.velocity = _velocity;
        _hadAttack = false;
        _monsterStat = MonsterStat.attacking;
        if (_animator)_animator.SetBool("Attack", true);
        if (_animator)_animator.SetBool("IsWalking", false);
    }

    
    private void OnDrawGizmos() {
        if (!_diplayDebugGizmos) return;
        
        if( _isGrounded)Gizmos.color = Color.yellow;
        else Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position+Vector3.down * _groundDetectionLength);

        Gizmos.color = Color.green;
        if (_flip) {
            Gizmos.DrawLine(_leftDetector.position, _leftDetector.position+Vector3.left * _detectionDistance);
            Gizmos.DrawLine(_leftDetector.position, _leftDetector.position+Vector3.down * _detectionDistance);
        }
        else
        { 
            Gizmos.DrawLine(_rightDetectot.position, _rightDetectot.position+Vector3.right * _detectionDistance);
            Gizmos.DrawLine(_rightDetectot.position, _rightDetectot.position+Vector3.down * _detectionDistance);
        }
    }

    public void TakeDamage(int damage, Vector2 origin) {
        Vector2 push = new Vector2(transform.position.x - origin.x, 1).normalized;
        _rigidbody.AddForce(push * _damagedBumpForce, ForceMode2D.Impulse);
        //_rigidbody.velocity = push * _damagedBumpForce;
        if (_animator)_animator.SetBool("IsWalking", false);
        if (_monsterStat == MonsterStat.attacking) {
            if (_animator)_animator.SetBool("Attack", false);
        }
        if (_animator)_animator.SetBool("IsDamaged", true);
        _timer = 0;
        _monsterStat = MonsterStat.damaged;
        
        _hp--;
        if (_hp <= 0) {
            if (_animator)_animator.SetBool("Dead", true);
            if (_animator)_animator.SetBool("IsDamaged", false);
            this.enabled = false;
            if (_destroyOnDeath) {
                if (_prefabPSDeath != null) Instantiate(_prefabPSDeath, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        
    }
}
