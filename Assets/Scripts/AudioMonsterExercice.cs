using System;
using UnityEngine;

public class AudioMonsterExercice : MonoBehaviour
{
    [Header("Monster")]
    [SerializeField] private Monster _monster;

    [Header("SoundEffects"), Space(5)] 
    [SerializeField] private AudioSource _monsterDeath;
    [SerializeField] private AudioSource _monsterDamaged;
    [SerializeField] private AudioSource _monsterAttack;

    private void Start() {
        _monster.OnAttack+= MonsterOnOnAttack;
        _monster.OnDamaged+= MonsterOnOnDamaged;
        _monster.OnDeath+= MonsterOnOnDeath;
    }

    private void MonsterOnOnDeath(object sender, EventArgs e) {
        _monsterDeath.Play();
    }

    private void MonsterOnOnDamaged(object sender, EventArgs e) {
        _monsterDamaged.Play();
    }

    private void MonsterOnOnAttack(object sender, EventArgs e) {
        _monsterAttack.Play();
    }
}