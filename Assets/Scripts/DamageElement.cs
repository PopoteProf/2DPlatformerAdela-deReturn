using System;
using UnityEngine;

public class DamageElement : MonoBehaviour {
    [SerializeField]private int _damages;
    [SerializeField] private bool _damagesMonsters;
    [SerializeField] private GameObject _prfHit;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerController2D>().TakeDamage(_damages, transform.position);
            if (_prfHit != null) Instantiate(_prfHit, other.transform.position, Quaternion.identity);
        }

        if (!_damagesMonsters) return;
        if (other.gameObject.GetComponent<Monster>() != null) {
            other.gameObject.GetComponent<Monster>().TakeDamage(_damages, transform.position);
            if (_prfHit != null) Instantiate(_prfHit, other.transform.position, Quaternion.identity);
        }
    }
}