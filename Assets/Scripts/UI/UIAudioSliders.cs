using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace UI
{
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
            
            _audioMixer.GetFloat("Master" ,out float masterVolume);
            _sliderGeneral.SetValueWithoutNotify(Mathf.Pow(10, masterVolume/20));
            _audioMixer.GetFloat("Music" ,out float musicVolume);
            _sliderMusic.SetValueWithoutNotify(Mathf.Pow(10, musicVolume/20));
            _audioMixer.GetFloat("Ambiance" ,out float ambianceVolume);
            _sliderAmbiance.SetValueWithoutNotify(Mathf.Pow(10, ambianceVolume/20));
            _audioMixer.GetFloat("SFX" ,out float sfxVolume);
            _sliderSfx.SetValueWithoutNotify(Mathf.Pow(10, sfxVolume/20));
        }

        private void ChangeGenrealValue(float value) {
            _audioMixer.SetFloat("Master", Mathf.Log10(_sliderGeneral.value) * 20);
        }
        private void ChangeMusicValue(float value) {
            _audioMixer.SetFloat("Music", Mathf.Log10(_sliderMusic.value) * 20);
        }
        private void ChangeAmbianceValue(float value) {
            _audioMixer.SetFloat("Ambiance", Mathf.Log10(_sliderAmbiance.value) * 20);
        }
        private void ChangeSfxValue(float value) {
            _audioMixer.SetFloat("SFX", Mathf.Log10(_sliderSfx.value) * 20);
        }
    }
}