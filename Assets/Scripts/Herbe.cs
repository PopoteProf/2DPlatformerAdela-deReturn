using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herbe : MonoBehaviour, IDamagable {
    [SerializeField] private GameObject _prefabsHerbeDestroy;

    public void TakeDamage(int damage, Vector2 origin) {
        if (_prefabsHerbeDestroy != null) Instantiate(_prefabsHerbeDestroy, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
