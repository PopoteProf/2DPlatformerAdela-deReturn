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
    private float _volume;

    private void Awake()
    {
        _sliderGeneral.onValueChanged.AddListener(ChangeGeneralValue);
        _sliderMusic.onValueChanged.AddListener(ChangeMusicValue);
        _sliderAmbiance.onValueChanged.AddListener( ChangeAmbianceValue);
        _sliderSfx.onValueChanged.AddListener(ChangeSfxValue);

        
    }

    private void ChangeGeneralValue(float value)
    {
        _audioMixer.SetFloat("VolumeMaster", Mathf.Log10(value)* 20);
    }
    private void ChangeMusicValue(float value) 
    {
        _audioMixer.SetFloat("VolumeMusic", Mathf.Log10(value)* 20);
    }
    private void ChangeAmbianceValue(float value) 
    {
        _audioMixer.SetFloat("VolumeAmbiance", Mathf.Log10(value)* 20);
    }
    private void ChangeSfxValue(float value) 
    {
        _audioMixer.SetFloat("VolumeSFX", Mathf.Log10(value)* 20);
    }
}