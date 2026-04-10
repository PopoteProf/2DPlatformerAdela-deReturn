using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimationSpriteReader : MonoBehaviour
{
    public event EventHandler OnAnimationSpriteComplete;
    public event EventHandler OnChangeAnimationSprite;
    
    [SerializeField] public SOAnimationSprite _currentAnimationSprite;
    [SerializeField] private float _generalAniamtionSpeed = 1;

    [HideInInspector]public SpriteRenderer _spriteRenderer;
    private float _time;
    private int _currentFrame;

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayNewAnimationSprite(SOAnimationSprite animationSprite) {
        if (_currentAnimationSprite == animationSprite) return;
        _currentAnimationSprite = animationSprite;
        _time = 0;
        _currentFrame = 0;
        _spriteRenderer.sprite = _currentAnimationSprite.sprites[_currentFrame];
        OnChangeAnimationSprite?.Invoke(this, EventArgs.Empty);
    }

    private void Update() {
        if( _currentAnimationSprite!=null) ManagerAnimation();
    }

    private void ManagerAnimation() {
        if (_currentFrame >= _currentAnimationSprite.FrameCounts - 1 && !_currentAnimationSprite.AnimationLoop) {
            return;
        }
        _time += Time.deltaTime*_generalAniamtionSpeed;
        if (_currentAnimationSprite.TimeBetweenFame <= _time) {
            _currentFrame++;
            if (_currentAnimationSprite.FrameCounts <= _currentFrame) {
                OnAnimationSpriteComplete?.Invoke(this, EventArgs.Empty);
                if (!_currentAnimationSprite.AnimationLoop) return;
                _currentFrame = 0;
            }

            _time = 0;
            _spriteRenderer.sprite = _currentAnimationSprite.sprites[_currentFrame];
        }
    }
}