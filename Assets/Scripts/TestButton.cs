using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //ajouter la rotation et la possibilité de faire "trembler" le ui
    
    private Sequence _sequence;
    private Sequence _sequence2;
    private RectTransform _rt;
    
    private Vector2 _startPivotPoint;
    private Vector2 _startAnchorPosMin;
    private Vector2 _startAnchorPosMax;
    private Vector3 _startRotation;
    private Vector2 _startScale;
    
    [Header("Start")] 
    [HideInInspector] public bool _startingAnimation;

    [HideInInspector] public bool _shaking;
    [HideInInspector] public int _shakeStrength;
    [HideInInspector] public int _shakeDistance;
    
    [HideInInspector] public Vector2 _startingAnimationEndPos;
    [HideInInspector] public Vector2 _startingAnimationEndScale;
    [HideInInspector] public Vector3 _startingRotation;
    [HideInInspector] public Vector2 _startingPivotPoint = new Vector2(0.5f, 0.5f);
    
    [HideInInspector] public float _startingAnimationLenght;
    
    [HideInInspector] public AnimationCurve _startingAnimationCurve = AnimationCurve.EaseInOut(0,0,1,1);

    private bool _gotMoved;
    
    [Header("Playing")]
    [HideInInspector] public bool _animation;
    
    [HideInInspector] public Vector2 _animationEndPos;
    [HideInInspector] public Vector2 _animationEndScale;
    [HideInInspector] public Vector3 _animationRotation;
    [HideInInspector] public Vector2 _pivotPoint = new Vector2(0.5f, 0.5f);
    
    [HideInInspector] public float _animationLenght;

    [HideInInspector] public float _mouseDelay;
    
    [HideInInspector] public AnimationCurve _animationCurve = AnimationCurve.EaseInOut(0,0,1,1);
    
    private Vector2 _afterStartPivotPoint;
    private Vector2 _afterStartAnchorPosMin;
    private Vector2 _afterStartAnchorPosMax;
    private Vector2 _afterStartScale;
    
    private float aa;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //AfterStartAnimation();
        
        _sequence = DOTween.Sequence().SetEase(_startingAnimationCurve).SetDelay(_mouseDelay).SetAutoKill(false);
        _sequence2 = DOTween.Sequence().SetEase(_startingAnimationCurve).SetAutoKill(false);
        _rt = gameObject.GetComponent<RectTransform>();

        _sequence2.Join(_rt.DOAnchorMin(_startingAnimationEndPos, _startingAnimationLenght));
        _sequence2.Join(_rt.DOAnchorMax(_startingAnimationEndPos, _startingAnimationLenght));
        _sequence2.Join(_rt.DOPivot(_startingPivotPoint, _startingAnimationLenght));
        _sequence2.Join(_rt.DORotate(_startingRotation, _startingAnimationLenght));
        _sequence2.Join(_rt.DOSizeDelta(_startingAnimationEndScale, _startingAnimationLenght).OnComplete(AfterStartAnimation));
        
        _sequence2.Pause();
        
        
        _sequence.Join(_rt.DOAnchorMin(_animationEndPos, _animationLenght));
        _sequence.Join(_rt.DOAnchorMax(_animationEndPos, _animationLenght));
        _sequence.Join(_rt.DOPivot(_pivotPoint, _animationLenght));
        _sequence.Join(_rt.DORotate(_animationRotation, _animationLenght, RotateMode.FastBeyond360));
        _sequence.Join(_rt.DOShakeRotation(1, new Vector3(0,0,_shakeDistance * 45), _shakeStrength));
        _sequence.Join(_rt.DOSizeDelta(_animationEndScale, _animationLenght));

        _sequence.Pause();
    }

    public void FirstAnimation()
    {

        if (_gotMoved) return;
        
        _gotMoved = true;
        Debug.Log("forward");
        
        _sequence2.PlayForward();
        
        
        if (_shaking)
            StartCoroutine(Shake());
    }

    public void Return()
    {
        if (!_gotMoved) return;
        
        _sequence2.PlayBackwards();
        _gotMoved = false;
    }

    private IEnumerator Shake()
    {
        while (true)
        {
            _sequence.Join(_rt.DOShakePosition(_shakeDistance, _shakeDistance, _shakeStrength).SetEase(Ease.InOutSine));
            yield return new WaitForSeconds(1f);
        }

    }

    private void AfterStartAnimation()
    {

        _startAnchorPosMin = _rt.anchorMin;
        _startAnchorPosMax = _rt.anchorMax;
        
        _startPivotPoint = _rt.pivot;
        
        _startRotation = transform.localRotation.eulerAngles;
        
        _startScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!_animation) return;
        _sequence.PlayForward();

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!_animation) return;
        _sequence2.PlayForward();
    }
}