using System;
using UnityEngine;

public class AudioMonsterExercice : MonoBehaviour
{
    [SerializeField] private Monster _monster;
    [SerializeField] private AudioSource _audioAttack;
    [SerializeField] private AudioSource _audioDamage;
    [SerializeField] private AudioSource _audioDeath;
    

    private void Start() {
        _monster.OnAttack+= MonsterOnOnAttack;
        _monster.OnDamaged+= MonsterOnOnDamaged;
        _monster.OnDeath+= MonsterOnOnDeath;
        
    }

    private void MonsterOnOnDeath(object sender, EventArgs e) {
        _audioDeath.Play();
    }

    private void MonsterOnOnDamaged(object sender, EventArgs e) {
        _audioDamage.Play();
    }

    private void MonsterOnOnAttack(object sender, EventArgs e) {
        _audioAttack.Play();
    }
}