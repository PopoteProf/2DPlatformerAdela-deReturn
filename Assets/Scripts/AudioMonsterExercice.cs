using System;
using UnityEngine;

public class AudioMonsterExercice : MonoBehaviour
{
    [SerializeField] private Monster _monster;
    [SerializeField] private AudioSource onHit;
    [SerializeField] private AudioSource onAttack;
    [SerializeField] private AudioSource onDeath;

    private void Start() {
        _monster.OnAttack+= MonsterOnOnAttack;
        _monster.OnDamaged+= MonsterOnOnDamaged;
        _monster.OnDeath+= MonsterOnOnDeath;
    }

    private void MonsterOnOnDeath(object sender, EventArgs e) {
        onDeath.Play();
    }

    private void MonsterOnOnDamaged(object sender, EventArgs e) {
        onHit.Play();
    }

    private void MonsterOnOnAttack(object sender, EventArgs e) {
        onAttack.Play();
    }
}