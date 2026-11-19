using System;
using UnityEngine;

public class AudioMonsterExercice : MonoBehaviour
{
    [SerializeField] private Monster _monster;
    public AudioSource _audioOnattack;
    public AudioSource _audioOndeath;
    public AudioSource _audioOnhit;

    private void Start() {
        _monster.OnAttack+= MonsterOnOnAttack;
        _monster.OnDamaged+= MonsterOnOnDamaged;
        _monster.OnDeath+= MonsterOnOnDeath;
    }

    private void MonsterOnOnDeath(object sender, EventArgs e) {
        _audioOndeath.Play();
    }

    private void MonsterOnOnDamaged(object sender, EventArgs e) {
        _audioOnhit.Play();
    }

    private void MonsterOnOnAttack(object sender, EventArgs e) {
        _audioOnattack.Play();
    }
}