using System;
using UnityEngine;

public class AudioMonsterExercice : MonoBehaviour
{
    [SerializeField] private Monster _monster;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _deathClip;
    [SerializeField] private AudioClip _takeDamageClip;
    [SerializeField] private AudioClip _attackClip;
    

    private void Start() 
    {
        _monster.OnAttack+= MonsterOnOnAttack;
        _monster.OnDamaged+= MonsterOnOnDamaged;
        _monster.OnDeath+= MonsterOnOnDeath;
    }

    private void MonsterOnOnDeath(object sender, EventArgs e)
    {
        _audioSource.clip = _deathClip;
        _audioSource.Play();
    }

    private void MonsterOnOnDamaged(object sender, EventArgs e) 
    {
        _audioSource.clip = _takeDamageClip;
        _audioSource.Play();
    }

    private void MonsterOnOnAttack(object sender, EventArgs e)
    {
        _audioSource.clip = _attackClip;
        _audioSource.Play();
    }
}