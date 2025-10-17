using UnityEngine;

public class LandMine : MonoBehaviour {
    [SerializeField] private float _explosionRadius = 3;
    [SerializeField] private float _explosionDelay = 2;
    [SerializeField] private int _explosionDamage = 2;
    [SerializeField] private bool _targetMonster = true;
    [SerializeField] private GameObject _prfWarUp;
    [SerializeField] private GameObject _prfExplosion;

    private bool _isTrigger;
    private float _timer;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.CompareTag("Player"))
        {
            if (!_isTrigger)
            {
                if (_prfWarUp != null) Instantiate(_prfWarUp, transform.position, Quaternion.identity);
                _isTrigger = true;
            }
        }
    }

    private void Update() {
        if (!_isTrigger)return;
        _timer += Time.deltaTime;
        if (_timer >= _explosionDelay) {
            RaycastHit2D[] hit2Ds = Physics2D.CircleCastAll(transform.position, _explosionRadius, Vector2.one);
            foreach (var hit in hit2Ds) { 
                if (hit.collider.gameObject.GetComponent<IDamagable>()!=null) {
                    hit.collider.gameObject.GetComponent<IDamagable>().TakeDamage(_explosionDamage, transform.position);
                }
            }
            if (_prfWarUp != null) Instantiate(_prfExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere( transform.position, _explosionRadius);
        Gizmos.DrawWireSphere( transform.position, (_timer/_explosionDelay)*_explosionRadius);
    }
}