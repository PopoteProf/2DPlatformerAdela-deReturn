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

        float volume;
        if (_audioMixer.GetFloat("VolumeMaster", out volume)) _sliderGeneral.value = DecibelToNormalized(volume);
        if (_audioMixer.GetFloat("VolumeMusic", out volume)) _sliderMusic.value = DecibelToNormalized(volume);
        if (_audioMixer.GetFloat("VolumeAmbiance", out volume)) _sliderAmbiance.value = DecibelToNormalized(volume);
        if (_audioMixer.GetFloat("VolumeSFX", out volume)) _sliderSfx.value = DecibelToNormalized(volume);
    }

    private void ChangeGenrealValue(float value)
    { 
       _audioMixer.SetFloat("VolumeMaster", NormalizedToDecibel(value));
    }
    private void ChangeMusicValue(float value) {
        _audioMixer.SetFloat("VolumeMusic", NormalizedToDecibel(value));
    }
    private void ChangeAmbianceValue(float value) {
        _audioMixer.SetFloat("VolumeAmbiance", NormalizedToDecibel(value));

    }
    private void ChangeSfxValue(float value) {
        _audioMixer.SetFloat("VolumeSFX", NormalizedToDecibel(value));

    }

    private float DecibelToNormalized(float decibel) => Mathf.Pow(10, decibel / 20);
    
    private float NormalizedToDecibel(float normalized) => Mathf.Log10(normalized) * 20;
}