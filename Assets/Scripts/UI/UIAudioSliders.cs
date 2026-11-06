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
    [SerializeField] private float _masterVolume;
    [SerializeField] private float _musicVolume;
    [SerializeField] private float _ambienceVolume;
    [SerializeField] private float _sfxVolume;

    private void Awake()
    {
        _sliderGeneral.onValueChanged.AddListener(ChangeGenrealValue);
        _sliderMusic.onValueChanged.AddListener(ChangeMusicValue);
        _sliderAmbiance.onValueChanged.AddListener( ChangeAmbianceValue);
        _sliderSfx.onValueChanged.AddListener(ChangeSfxValue);
        _audioMixer.GetFloat("VolumeMaster", out _masterVolume );
        _audioMixer.GetFloat("VolumeMusic", out _musicVolume );
        _audioMixer.GetFloat("VolumeAmbience", out _ambienceVolume );
        _audioMixer.GetFloat("VolumeSFX", out _sfxVolume );
        _sliderGeneral.value = Mathf.Pow(10, _masterVolume / 20);
        _sliderMusic.value = Mathf.Pow(10, _musicVolume / 20);
        _sliderAmbiance.value = Mathf.Pow(10, _ambienceVolume / 20);
        _sliderSfx.value = Mathf.Pow(10, _sfxVolume / 20);


    }

    private void ChangeGenrealValue(float value)
    {
        if (value != 0)
        {
            _audioMixer.SetFloat("VolumeMaster", Mathf.Log10(value) * 20);
        }
    }

    private void ChangeMusicValue(float value)
    {
        if (value != 0)
        {
            _audioMixer.SetFloat("VolumeMusic", Mathf.Log10(value) * 20);
        }
    }

    private void ChangeAmbianceValue(float value)
    {
        if (value != 0)
        {
            _audioMixer.SetFloat("VolumeAmbience", Mathf.Log10(value) * 20);
        }
    }

    private void ChangeSfxValue(float value)
    {
        if (value != 0)
        {
            _audioMixer.SetFloat("VolumeSFX", Mathf.Log10(value) * 20);
        }
    }
}