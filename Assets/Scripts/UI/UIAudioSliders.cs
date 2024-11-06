using Unity.VisualScripting;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIAudioSliders : MonoBehaviour
{
    [SerializeField] private Slider _sliderGeneral;
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Slider _sliderAmbiance;
    [SerializeField] private Slider _sliderSfx;
    [SerializeField] private AudioMixer _audioMixer;

    private void Awake()
    {
        _sliderGeneral.onValueChanged.AddListener(ChangeGenrealValue);
        _sliderMusic.onValueChanged.AddListener(ChangeMusicValue);
        _sliderAmbiance.onValueChanged.AddListener( ChangeAmbianceValue);
        _sliderSfx.onValueChanged.AddListener(ChangeSfxValue);
    }

    private void ChangeGenrealValue(float value) {
        _audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }
    private void ChangeMusicValue(float value) {
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }
    private void ChangeAmbianceValue(float value) {
        _audioMixer.SetFloat("AmbianceVolume", Mathf.Log10(value) * 20);
    }
    private void ChangeSfxValue(float value) {
        _audioMixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
    }
}