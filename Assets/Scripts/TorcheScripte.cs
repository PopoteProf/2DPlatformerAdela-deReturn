using UnityEngine;
using UnityEngine.Rendering.Universal;
[RequireComponent(typeof(Light2D))]
public class TorcheScripte : MonoBehaviour
{
    
    [SerializeField] private float _minTime =0.2f;
    [SerializeField] private float _maxTime =1f;
    [SerializeField] private float _minIntencity = 0.8f;
    [SerializeField] private float _maxIntencity = 1.2f;
    
    private Light2D _light;

    private float _previusIntencity;
    private float _nextIntencity;

    private float _maxTimer;
    private float _timer;
    void Start() {
        _light = GetComponent<Light2D>();
        _light.intensity = Random.Range(_minIntencity, _maxIntencity);
    }

    void Update() {
        if (_light == null) return;
        _timer += Time.deltaTime;
        _light.intensity = Mathf.Lerp(_previusIntencity, _nextIntencity, _timer / _nextIntencity);
        if (_timer >= _maxTimer) {
            SetNewTarget();
        }
    }

    private void SetNewTarget() {
        _timer = 0;
        _maxTimer = Random.Range(_minTime, _maxTime);
        _nextIntencity = Random.Range(_minIntencity, _maxIntencity);
        _previusIntencity = _light.intensity;
    }
}
