using UnityEngine;
using UnityEngine.Serialization;

public class HealingPickUp : MonoBehaviour { 
    [SerializeField] private int _healAmount=1;
    [SerializeField] private bool _destroyOnHeal = true;
    [SerializeField] private bool _chechIfNeedHeal = false;
    [SerializeField] private GameObject _prfSpawnOnPickUp;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.CompareTag("Player")) {
            if (_chechIfNeedHeal) {
                if (StaticData.PlayerHP == StaticData.PlayerMaxHP) return;
            }
            other.gameObject.GetComponent<PlayerController2D>().HealPlayer(_healAmount);
            if (_destroyOnHeal) {
                if (_prfSpawnOnPickUp!=null)Instantiate(_prfSpawnOnPickUp, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}