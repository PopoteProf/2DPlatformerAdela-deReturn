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
        ConfigureSlider(_sliderGeneral);
        ConfigureSlider(_sliderMusic);
        ConfigureSlider(_sliderAmbiance);
        ConfigureSlider(_sliderSfx);
    }

    private void Start()
    {
        SetSliderValueFromMixer(_sliderGeneral, "Master");
        SetSliderValueFromMixer(_sliderMusic, "Music");
        SetSliderValueFromMixer(_sliderAmbiance, "Ambiance");
        SetSliderValueFromMixer(_sliderSfx, "SFX");
    }

    private void ChangeGenrealValue(float value)
    {
        _audioMixer.SetFloat("Master", value);
    }
    private void ChangeMusicValue(float value) 
    {
        _audioMixer.SetFloat("Music", value);
    }
    
    private void ChangeAmbianceValue(float value) 
    {
        _audioMixer.SetFloat("Ambiance", value);
    }

    private void ChangeSfxValue(float value)
    {
        _audioMixer.SetFloat("SFX", value);
    }

    private void ConfigureSlider(Slider slider)
    {
        slider.minValue = -80;
        slider.maxValue = 20;
    }
    
    private void SetSliderValueFromMixer(Slider slider, string parameter)
    {
        if (_audioMixer.GetFloat(parameter, out float value))
        {
            slider.value = value;
        }
    }
}