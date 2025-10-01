using UnityEngine;
using UnityEngine.Rendering.Universal;
public class TorcheScripte : MonoBehaviour
{
    
    [SerializeField] private float _minTime =0.2f;
    [SerializeField] private float _maxTime =1f;
    [SerializeField] private float _minIntencity = 0.8f;
    [SerializeField] private float _maxIntencity = 1.2f;
    [SerializeField] private AnimationCurve _animationCurve = AnimationCurve.EaseInOut(0,0,1,1);
    private Light2D _light;

    private float _previusIntencity;
    private float _nextIntencity;

    private float _maxTimer;
    private float _timer;
    void Start() {
        _light = GetComponent<Light2D>();
        if( _light ==null) return;
        _light.intensity = Random.Range(_minIntencity, _maxIntencity);
    }

    void Update() {
        if (_light == null) return;
        _timer += Time.deltaTime;
        _light.intensity = Mathf.Lerp(_previusIntencity, _nextIntencity, _animationCurve.Evaluate(_timer / _nextIntencity));
        if (_timer >= _maxTimer) {
            SetNewTarget();
        }
    }

    private void SetNewTarget() {
        _timer = 0;
        _maxTimer = Random.Range(_minTime, _maxTime);
        if (_nextIntencity == _maxIntencity)
        {
            _nextIntencity = _minIntencity;
            _previusIntencity = _maxIntencity;
        }
        else
        {
            _nextIntencity = _maxIntencity;
            _previusIntencity = _minIntencity;
        }
        //_nextIntencity = Random.Range(_minIntencity, _maxIntencity);
        //_previusIntencity = _light.intensity;
    }
}
