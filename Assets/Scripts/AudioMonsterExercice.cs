using System;
using UnityEngine;

public class AudioMonsterExercice : MonoBehaviour
{
    [SerializeField] private Monster _monster;
    public AudioSource audioSourceDeath;
    public AudioSource audioSourceDamaged;
    public AudioSource audioSourceOnAttack;
    private void Start() {
        _monster.OnAttack+= MonsterOnOnAttack;
        _monster.OnDamaged+= MonsterOnOnDamaged;
        _monster.OnDeath+= MonsterOnOnDeath;
    }

    private void MonsterOnOnDeath(object sender, EventArgs e) {
        audioSourceDeath.Play();
    }

    private void MonsterOnOnDamaged(object sender, EventArgs e) {
        audioSourceDamaged.Play();
    }

    private void MonsterOnOnAttack(object sender, EventArgs e) {
        audioSourceOnAttack.Play();
    }
    
}