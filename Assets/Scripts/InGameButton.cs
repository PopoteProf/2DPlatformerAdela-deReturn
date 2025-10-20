using UnityEngine;
using UnityEngine.Events;

public class InGameButton : Interactable {
    [SerializeField] private bool _deactivatedOnInteract;
    public UnityEvent OnActivated;
    public UnityEvent OnEnterZone;
    public UnityEvent OnExitZone;

    public override void Interact() {
        if (_deactivatedOnInteract) _isInteractable = false;
        OnActivated.Invoke();
    }
    protected override void OnTriggerEnter2D(Collider2D other) {
        if (!_isInteractable) return;
        if (other.gameObject.GetComponent<PlayerController2D>() != null) {
            SubmitInteractable(other.gameObject.GetComponent<PlayerController2D>());
            OnEnterZone.Invoke();
        }
    }
    protected  override void OnTriggerExit2D(Collider2D other) {
        OnExitZone.Invoke();
        if (!_isInteractable) return;
        if (other.gameObject.GetComponent<PlayerController2D>() != null) {
            UnSubmitInteractable(other.gameObject.GetComponent<PlayerController2D>());
            
        }
    }
}