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
        
    }
    
    private void ChangeGenrealValue(float value) {
        
    }
    private void ChangeMusicValue(float value) {
        
    }
    private void ChangeAmbianceValue(float value) {
        
    }
    private void ChangeSfxValue(float value) {
        
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