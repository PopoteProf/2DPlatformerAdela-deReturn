using UnityEngine;

public class Chess : Interactable {
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _isOpen;
    [SerializeField] private ParticleSystem _psCoindUp;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private int _goldGain = 5;
    [SerializeField] private UIInteractFeedBack _interactFeedBack;

    public override void Interact()
    {
        base.Interact();
        if (_isOpen) return;
        _animator.SetBool("Open", true);
        if (_psCoindUp != null) _psCoindUp.Play();
        if( _audioSource!=null) _audioSource.Play();
        StaticData.ChangePlayerGold(_goldGain);
        if(_interactFeedBack!=null) _interactFeedBack.DoInteractEffect();
        _isOpen = true;
        enabled = false;
    }
    
    
    //protected override  void OnTriggerEnter2D(Collider2D other) {
    //    if (_isInteractable) return;
    //    if (other.gameObject.GetComponent<PlayerController2D>() != null) {
    //        other.gameObject.GetComponent<PlayerController2D>().Chess = this;
    //        if(_interactFeedBack!=null) _interactFeedBack.OpenUpEffect();
    //    }
    //}
    //protected override void OnTriggerExit2D(Collider2D other) {
    //    if (_isInteractable) return;
    //    if (other.gameObject.GetComponent<PlayerController2D>() != null) {
    //        other.gameObject.GetComponent<PlayerController2D>().Chess = this;
    //        if(_interactFeedBack!=null) _interactFeedBack.CloseUpEffect();
    //    }
    //}
}