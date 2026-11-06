using System;
using UnityEngine;

public class AudioMonsterExercice : MonoBehaviour
{
    [SerializeField] private Monster _monster;
    [SerializeField] private AudioSource _deathSound;
    [SerializeField] private AudioSource _hitSound;
    [SerializeField] private AudioSource _attackSound;

    private void Start() {
        _monster.OnAttack+= MonsterOnOnAttack;
        _monster.OnDamaged+= MonsterOnOnDamaged;
        _monster.OnDeath+= MonsterOnOnDeath;
    }

    private void MonsterOnOnDeath(object sender, EventArgs e)
    {
        _deathSound.Play();
    }

    private void MonsterOnOnDamaged(object sender, EventArgs e) {
        _hitSound.Play();
    }

    private void MonsterOnOnAttack(object sender, EventArgs e)
    {
        _attackSound.Play();
    }
}