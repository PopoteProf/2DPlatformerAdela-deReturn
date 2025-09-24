using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMonsterEffect : MonoBehaviour
{
    [SerializeField] private Monster _monster;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    [SerializeField] private AudioElement _attackSound;
    [SerializeField] private AudioElement _damagedSound;
    [SerializeField] private AudioElement _DeathSound;

    private void Start()
    {
        _monster.OnAttack+= MonsterOnOnAttack;
        _monster.OnDamaged+= MonsterOnOnDamaged;
        _monster.OnDeath+= MonsterOnOnDeath;
    }

    private void MonsterOnOnDeath(object sender, EventArgs e)
    {
        AudioClip clip = _DeathSound.GetSound();
        if (clip == null) return;
        AudioSource audioSource = transform.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.pitch = _DeathSound.GetPitch();
        audioSource.outputAudioMixerGroup = _audioMixerGroup;
        audioSource.Play();
        Destroy(audioSource, clip.length+1);
    }

    private void MonsterOnOnDamaged(object sender, EventArgs e)
    {
        AudioClip clip = _damagedSound.GetSound();
        if (clip == null) return;
        AudioSource audioSource = transform.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.pitch = _damagedSound.GetPitch();
        audioSource.outputAudioMixerGroup = _audioMixerGroup;
        audioSource.Play();
        Destroy(audioSource, clip.length+1);
    }

    private void MonsterOnOnAttack(object sender, EventArgs e)
    {
        AudioClip clip = _attackSound.GetSound();
        if (clip == null) return;
        AudioSource audioSource = transform.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.pitch = _attackSound.GetPitch();
        audioSource.outputAudioMixerGroup = _audioMixerGroup;
        audioSource.Play();
        Destroy(audioSource, clip.length+1);
    }
}