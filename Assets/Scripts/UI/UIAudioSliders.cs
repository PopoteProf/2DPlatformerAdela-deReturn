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
        _sliderAmbiance.onValueChanged.AddListener(ChangeAmbianceValue);
        _sliderSfx.onValueChanged.AddListener(ChangeSfxValue);
        _sliderGeneral.minValue = -80;
        _sliderGeneral.maxValue = 20;
        
        _sliderMusic.minValue = -80;
        _sliderMusic.maxValue = 20;
        
        _sliderAmbiance.minValue = -80;
        _sliderAmbiance.maxValue = 20;
        
        _sliderSfx.minValue = -80;
        _sliderSfx.maxValue = 20;
        

    }

    private void ChangeGenrealValue(float value)
    { 
        _audioMixer.SetFloat("Master", value); 
    }
    private void ChangeMusicValue(float value) {
        _audioMixer.SetFloat("Music", value);
        
    }
    private void ChangeAmbianceValue(float value) {
        _audioMixer.SetFloat("Ambiance", value);
    }
    private void ChangeSfxValue(float value) {
        _audioMixer.SetFloat("SFX", value);
    }
}