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

        _audioMixer.GetFloat("VolumeMaster" ,out float masterVolume);
        _sliderGeneral.SetValueWithoutNotify(Mathf.Pow(10, masterVolume/20));
        _audioMixer.GetFloat("VolumeMusic" ,out float musicVolume);
        _sliderMusic.SetValueWithoutNotify(Mathf.Pow(10, musicVolume/20));
        _audioMixer.GetFloat("VolumeAmbiance" ,out float ambianceVolume);
        _sliderAmbiance.SetValueWithoutNotify(Mathf.Pow(10, ambianceVolume/20));
        _audioMixer.GetFloat("VolumeSFX" ,out float sfxVolume);
        _sliderSfx.SetValueWithoutNotify(Mathf.Pow(10, sfxVolume/20));
    }

    private void ChangeGenrealValue(float value)
    { 
        _audioMixer.SetFloat("VolumeMaster", Mathf.Log10(value) * 20);
    }
    private void ChangeMusicValue(float value) {
        _audioMixer.SetFloat("VolumeMusic", Mathf.Log10(value) * 20);
    }
    private void ChangeAmbianceValue(float value) {
        _audioMixer.SetFloat("VolumeAmbiance", Mathf.Log10(value) * 20);
    }
    private void ChangeSfxValue(float value) {
        _audioMixer.SetFloat("VolumeSFX", Mathf.Log10(value) * 20);
    }
}