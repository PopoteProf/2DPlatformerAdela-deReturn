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
    }

    private void Start()
    {
        _audioMixer.GetFloat("MasterVolume", out float generalVolume);
        _audioMixer.GetFloat("MusicVolume", out float musicVolume);
        _audioMixer.GetFloat("SFXVolume", out float sfxVolume);
        _audioMixer.GetFloat("AmbianceVolume", out float ambianceVolume);

        _sliderGeneral.value = (generalVolume + 80f) / 80f;
        _sliderMusic.value = (musicVolume + 80f) / 80f;
        _sliderSfx.value = (sfxVolume + 80f) / 80f;
        _sliderAmbiance.value = (ambianceVolume + 80f) / 80f;
    }

    private void ChangeGenrealValue(float value)
    {
        _audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80f, 0f, value));
    }

    private void ChangeMusicValue(float value)
    {
        _audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80f, 0f, value));
    }

    private void ChangeSfxValue(float value)
    {
        _audioMixer.SetFloat("SFXVolume", Mathf.Lerp(-80f, 0f, value));
    }

    private void ChangeAmbianceValue(float value)
    {
        _audioMixer.SetFloat("AmbianceVolume", Mathf.Lerp(-80f, 0f, value));
    }
}