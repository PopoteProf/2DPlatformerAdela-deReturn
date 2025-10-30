using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour {
    [SerializeField] private bool _usTagToTrigger; 
    [SerializeField] private string _triggerTag;
    [Space(5)]
    [SerializeField] private bool _deactivateOnTriggerEnter;
    [SerializeField] private bool _deactivateOnTriggerExit;

    [SerializeField] private UnityEvent _onTriggerEnter;
    [SerializeField] private UnityEvent _onTriggerExit;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (_usTagToTrigger && !other.CompareTag(_triggerTag)) return;
        _onTriggerEnter?.Invoke();
        if (_deactivateOnTriggerEnter)gameObject.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_usTagToTrigger && !other.CompareTag(_triggerTag)) return;
        _onTriggerExit?.Invoke();
        if (_deactivateOnTriggerExit)gameObject.SetActive(false);
    }
}
