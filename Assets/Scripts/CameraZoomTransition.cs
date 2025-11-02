using Cinemachine;
using UnityEngine;


public class CameraZoomTransition : MonoBehaviour {
    [SerializeField] private CinemachineVirtualCamera _targetVirtualCamera;
    [SerializeField] private float _newCameraSize = 8;
    [SerializeField] private float _transitionTime = 0.5f;
    [SerializeField] private AnimationCurve _transitionCurve = AnimationCurve.EaseInOut(0,0,1,1);

    private float _startTransitionSize;
    public bool _doTransition;
    private float _timer;

    // Méthode à lancer pour faire la transition.
    public void DoTransition()
    {
        if (_targetVirtualCamera == null) {
            Debug.LogWarning("No target virtual camera", this);
            return;
        }

        _startTransitionSize = _targetVirtualCamera.m_Lens.OrthographicSize;
        _timer = 0;
        _doTransition = true;
    }
    void Update() {
        if (!_doTransition)return;

        _timer += Time.deltaTime;
        
        float t =_timer/_transitionTime;
        t = _transitionCurve.Evaluate(t);
        float newSize = Mathf.Lerp(_startTransitionSize, _newCameraSize, t);
        
        _targetVirtualCamera.m_Lens.OrthographicSize = newSize;

        if (_timer >= _transitionTime) {
            _doTransition = false;
            _targetVirtualCamera.m_Lens.OrthographicSize = _newCameraSize;
        }
    }
}
