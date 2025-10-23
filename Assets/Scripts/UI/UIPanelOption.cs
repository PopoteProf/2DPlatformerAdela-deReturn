using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIPanelOption : MonoBehaviour
{
    public event EventHandler OnOptionMenuClose;
    [SerializeField] private Slider _sliderGeneral;
    [SerializeField] private Slider _sliderSFX;
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Slider _sliderAmbiance;
    [SerializeField] private Button _closeButton;
    [SerializeField] private AudioMixer _audioMixer;

    private void Start() {
        if(_sliderGeneral!=null) _sliderGeneral.Select();
        SetUpVolumes();
        _sliderGeneral.onValueChanged.AddListener(ChangeGenrealValue);
        _sliderMusic.onValueChanged.AddListener(ChangeMusicValue);
        _sliderSFX.onValueChanged.AddListener(ChangeSfxValue);
        _sliderAmbiance.onValueChanged.AddListener(ChangeAmbianceValue);
        _closeButton.onClick.AddListener(ClosePanel);
        
    }

    private void SetUpVolumes() {
        _audioMixer.GetFloat("MasterVolume",out float masterValue);
        _audioMixer.GetFloat("MusicVolume",out float musicValue);
        _audioMixer.GetFloat("AmbianceVolume",out float ambianceValue);
        _audioMixer.GetFloat("SFXVolume",out float sfxValue);
        _sliderGeneral.value = Mathf.Exp(masterValue / 20);
        _sliderSFX.value = Mathf.Exp(sfxValue / 20);
        _sliderMusic.value = Mathf.Exp(musicValue / 20);
        _sliderAmbiance.value = Mathf.Exp(ambianceValue / 20);
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

    private void ClosePanel() {
        OnOptionMenuClose?.Invoke(this , EventArgs.Empty);
        gameObject.SetActive(false);
    }

    public void OpenPanel() {
        _sliderGeneral.Select();
        gameObject.SetActive(true);
    }
}