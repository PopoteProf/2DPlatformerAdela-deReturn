using UnityEngine;

public class Interactable : MonoBehaviour
{
    
    [SerializeField]protected bool _isInteractable = true;

    public virtual void Interact() {
        _isInteractable = false;
    }

    protected virtual void SubmitInteractable(PlayerController2D player) {
        Debug.Log("Submitting interactable");
        player.SubmitNewInteractable(this);
    }

    protected virtual void UnSubmitInteractable(PlayerController2D player) {
        player.UnSubmitInteractable(this);
    }

    public void Unsubscribe() {
        
    }

    public bool CanInteract() {
        return _isInteractable;
    }
    protected virtual void OnTriggerEnter2D(Collider2D other) {
        if (!_isInteractable) return;
        if (other.gameObject.GetComponent<PlayerController2D>() != null) {
            SubmitInteractable(other.gameObject.GetComponent<PlayerController2D>());
            //other.gameObject.GetComponent<PlayerController2D>().Chess = this;
            //if(_interactFeedBack!=null) _interactFeedBack.OpenUpEffect();
        }
    }
    protected  virtual void OnTriggerExit2D(Collider2D other) {
        //if (!_isInteractable) return;
        if (other.gameObject.GetComponent<PlayerController2D>() != null) {
            UnSubmitInteractable(other.gameObject.GetComponent<PlayerController2D>());
            //other.gameObject.GetComponent<PlayerController2D>().Chess = this;
            //if(_interactFeedBack!=null) _interactFeedBack.CloseUpEffect();
        }
    }
}