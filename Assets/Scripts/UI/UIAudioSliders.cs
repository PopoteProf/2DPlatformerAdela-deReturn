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
            
            //_sliderGeneral.value = Mathf.Pow(10, _audioMixer.GetFloat("Master", _audioMixer))
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