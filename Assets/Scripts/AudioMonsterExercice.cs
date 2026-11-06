using System;
using UnityEngine;

public class AudioMonsterExercice : MonoBehaviour
{
    [SerializeField] private Monster _monster;
    [SerializeField] private AudioSource _audioSourceDeath;
    [SerializeField] private AudioSource _audioSourceAttack;
    [SerializeField] private AudioSource _audioSourceDamaged;

    private void Start() {
        _monster.OnAttack+= MonsterOnOnAttack;
        _monster.OnDamaged+= MonsterOnOnDamaged;
        _monster.OnDeath+= MonsterOnOnDeath;
    }

    private void MonsterOnOnDeath(object sender, EventArgs e) {
        _audioSourceDeath.Play();
    }

    private void MonsterOnOnDamaged(object sender, EventArgs e) {
        _audioSourceDamaged.Play();
    }

    private void MonsterOnOnAttack(object sender, EventArgs e) {
        _audioSourceAttack.Play();
    }
}