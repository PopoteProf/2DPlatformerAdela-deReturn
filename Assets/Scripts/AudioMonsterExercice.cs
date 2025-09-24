using System;
using UnityEngine;

public class AudioMonsterExercice : MonoBehaviour
{
    [SerializeField] private Monster _monster;

    private void Start() {
        _monster.OnAttack+= MonsterOnOnAttack;
        _monster.OnDamaged+= MonsterOnOnDamaged;
        _monster.OnDeath+= MonsterOnOnDeath;
    }

    private void MonsterOnOnDeath(object sender, EventArgs e) {
        
    }

    private void MonsterOnOnDamaged(object sender, EventArgs e) {
        
    }

    private void MonsterOnOnAttack(object sender, EventArgs e) {
        
    }
}