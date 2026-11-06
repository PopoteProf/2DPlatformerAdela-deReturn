using System;
using UnityEngine;

public class AudioMonsterExercice : MonoBehaviour
{
    [SerializeField] private Monster _monster;

    [Header("Audio Clips")] 
    [SerializeField] private AudioSource _attackAudio;
    [SerializeField] private AudioSource _damagedAudio;
    [SerializeField] private AudioSource _deathAudio;

    private void Start() {
        _monster.OnAttack+= MonsterOnOnAttack;
        _monster.OnDamaged+= MonsterOnOnDamaged;
        _monster.OnDeath+= MonsterOnOnDeath;
    }

    private void MonsterOnOnDeath(object sender, EventArgs e) => _deathAudio.Play();

    private void MonsterOnOnDamaged(object sender, EventArgs e)  => _damagedAudio.Play();

    private void MonsterOnOnAttack(object sender, EventArgs e) => _attackAudio.Play();
}