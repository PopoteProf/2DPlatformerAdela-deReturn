using System;
using UnityEngine;
using UnityEngine.Events;

public class PichUpItem : MonoBehaviour {
    [SerializeField] private int _goldGain=0;
    [SerializeField] private int _scoreGain=0;
    [SerializeField] private bool _destroyOnPickUp = true;
    [SerializeField] private GameObject _prfSpawnOnPickUp;
    [SerializeField] private UnityEvent _OnPickUp;
    [SerializeField] private AudioClip _pickUpSound;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.CompareTag("Player")) {
            StaticData.ChangePlayerScore(_scoreGain);
            StaticData.ChangePlayerGold(_goldGain);
            AudioManager.instance.PlaySFX(_pickUpSound);
            if (_destroyOnPickUp) {
                if (_prfSpawnOnPickUp!=null)Instantiate(_prfSpawnOnPickUp, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            _OnPickUp.Invoke();
        }
    }
}