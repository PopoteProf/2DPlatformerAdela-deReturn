using System;
using UnityEngine;

[SelectionBase]
public class DamageElement : MonoBehaviour {
    [SerializeField]private int _damages;
    [SerializeField] private bool _damagesMonsters;
    [Tooltip("Prefab of a Particul system that will be instanciated and center on the Player or monster that is damaged")
     ,SerializeField] private GameObject _prfHitImpact;
    [Tooltip("Particul system that would be center on the elements, it will PLAY it when something tush it.")
     ,SerializeField] private ParticleSystem _psHitRespons;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerController2D>().TakeDamage(_damages, transform.position);
            if (_prfHitImpact != null) Instantiate(_prfHitImpact, other.transform.position, Quaternion.identity);
            if( _psHitRespons != null)_psHitRespons.Play();
        }

        if (!_damagesMonsters) return;
        if (other.gameObject.GetComponent<Monster>() != null) {
            other.gameObject.GetComponent<Monster>().TakeDamage(_damages, transform.position);
            if (_prfHitImpact != null) Instantiate(_prfHitImpact, other.transform.position, Quaternion.identity);
            if( _psHitRespons != null)_psHitRespons.Play();
        }
    }
}