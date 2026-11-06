using System;
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

        if(_audioMixer.GetFloat("VolumeMaster",out float sliderGeneralValue))_sliderGeneral.value = Mathf.Pow(10, sliderGeneralValue/20);
        if(_audioMixer.GetFloat("VolumeMusic",out float sliderMusicValue))_sliderMusic.value = Mathf.Pow(10, sliderMusicValue/20);
        if(_audioMixer.GetFloat("VolumeAmbiance",out float sliderAmbianceValue))_sliderAmbiance.value = Mathf.Pow(10, sliderAmbianceValue/20);
        if(_audioMixer.GetFloat("VolumeSFX",out float sliderSfxValue))_sliderSfx.value = Mathf.Pow(10, sliderSfxValue/20);
        
    }

    private void ChangeGenrealValue(float value)
    {
        _audioMixer.SetFloat("VolumeMaster", value == 0 ? 0 : Mathf.Log(value) * 20);
    }
    private void ChangeMusicValue(float value) {
        _audioMixer.SetFloat("VolumeMusic", value == 0 ? 0 : Mathf.Log(value) * 20);
        
    }
    private void ChangeAmbianceValue(float value) {
        _audioMixer.SetFloat("VolumeAmbiance", value == 0 ? 0 : Mathf.Log(value) * 20);
        
    }
    private void ChangeSfxValue(float value) {
        _audioMixer.SetFloat("VolumeSFX", value == 0 ? 0 : Mathf.Log(value) * 20);
        
    }
}