using System;
using System.Collections;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //ajouter la rotation et la possibilité de faire "trembler" le ui
    
    private Sequence _sequence;
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
    void Start()
    {
        _sequence = DOTween.Sequence();
        _rt = gameObject.GetComponent<RectTransform>();

        if (_startingAnimation)
        {
            _sequence.Join(_rt.DOAnchorMin(_rt.anchorMin + _startingAnimationEndPos, _startingAnimationLenght).SetEase(_startingAnimationCurve));
            _sequence.Join(_rt.DOAnchorMax(_rt.anchorMax + _startingAnimationEndPos, _startingAnimationLenght).SetEase(_startingAnimationCurve));
        
            _sequence.Join(_rt.DOPivot(_startingPivotPoint, _startingAnimationLenght).SetEase(_startingAnimationCurve));

            _sequence.Join(_rt.DORotate(_startingRotation, _startingAnimationLenght).SetEase(_startingAnimationCurve));
            
            _sequence.Join(_rt.DOSizeDelta(_startingAnimationEndScale, _startingAnimationLenght).SetEase(_startingAnimationCurve).OnComplete(AfterStartAnimation));
        }
        else
            AfterStartAnimation();

        if (_shaking)
            StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        while (true)
        {
            _sequence.Join(_rt.DOShakePosition(_shakeDistance, _shakeDistance, _shakeStrength).SetEase(Ease.InOutSine));
            yield return new WaitForSeconds(1f);
        }

    }

    private void Update()
    {
        //_sequence.Join(_rt.DOShakePosition( 5, 10).SetEase(_animationCurve));
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
        _sequence = DOTween.Sequence();
        
        _sequence.Join(_rt.DOAnchorMin(_startAnchorPosMin + _animationEndPos, _animationLenght).SetEase(_animationCurve));
        _sequence.Join(_rt.DOAnchorMax(_startAnchorPosMax + _animationEndPos, _animationLenght).SetEase(_animationCurve));
        
        _sequence.Join(_rt.DOPivot(_pivotPoint, _animationLenght).SetEase(_animationCurve));

        _sequence.Join(_rt.DORotate(_animationRotation, _animationLenght, RotateMode.FastBeyond360).SetEase(_startingAnimationCurve));
        //_sequence.Join(_rt.DOPunchRotation(_animationRotation, _startingAnimationLenght).SetEase(_startingAnimationCurve));


        _sequence.Join(_rt.DOShakeRotation(1, new Vector3(0,0,_shakeDistance * 45), _shakeStrength));

        //DOTween.To(() => aa, x => aa = _animationEndScale, _animationLenght).SetEase(_animationCurve);
        
        _sequence.Join(_rt.DOSizeDelta(_animationEndScale, _animationLenght).SetEase(_animationCurve));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!_animation) return;
        
        _sequence = DOTween.Sequence().SetDelay(_mouseDelay);
        
        _sequence.Append(_rt.DOAnchorMin(_startAnchorPosMin, _animationLenght).SetEase(_animationCurve));
        _sequence.Join(_rt.DOAnchorMax(_startAnchorPosMax, _animationLenght).SetEase(_animationCurve));
        
        _sequence.Join(_rt.DOPivot(_startPivotPoint, _animationLenght).SetEase(_animationCurve));
        
        
        _sequence.Join(_rt.DORotate(_startRotation, _animationLenght).SetEase(_startingAnimationCurve));
        
        _sequence.Join(_rt.DOSizeDelta(_startScale, _animationLenght).SetEase(_animationCurve));
    }
}

[CustomEditor(typeof(TestButton))]
public class InspectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var script = (TestButton)target;

        EditorStyles.label.fontStyle = FontStyle.Bold;
        script._startingAnimation = EditorGUILayout.Toggle("Starting Animation", script._startingAnimation);
        EditorStyles.label.fontStyle = FontStyle.Normal;
        
        if (script._startingAnimation)
        {
           
            script._startingAnimationEndPos = EditorGUILayout.Vector2Field("Start Position", script._startingAnimationEndPos);
            script._startingAnimationEndScale = EditorGUILayout.Vector2Field("Start Scale", script._startingAnimationEndScale);
            script._startingRotation = EditorGUILayout.Vector3Field("Start Rotation", script._startingRotation);
            script._startingPivotPoint = EditorGUILayout.Vector2Field("Start Pivot Point", script._startingPivotPoint);
            script._startingAnimationLenght = EditorGUILayout.FloatField("Start Animation Lenght", script._startingAnimationLenght);
            script._startingAnimationCurve = EditorGUILayout.CurveField("Start AnimationCurve", script._startingAnimationCurve);
        }

        EditorGUILayout.Space();
        EditorStyles.label.fontStyle = FontStyle.Bold;
        script._animation = EditorGUILayout.Toggle("Playing Animation", script._animation);
        EditorStyles.label.fontStyle = FontStyle.Normal;

        if (script._animation)
        {
            script._animationEndPos = EditorGUILayout.Vector2Field("End Position", script._animationEndPos);
            script._animationEndScale = EditorGUILayout.Vector2Field("End Scale", script._animationEndScale);
            script._animationRotation = EditorGUILayout.Vector3Field("Start Rotation", script._animationRotation);
            script._pivotPoint = EditorGUILayout.Vector2Field("Pivot Point", script._pivotPoint);
            script._animationLenght = EditorGUILayout.FloatField("Animation Lenght", script._animationLenght);
            script._animationCurve = EditorGUILayout.CurveField("AnimationCurve", script._animationCurve);
            script._mouseDelay = EditorGUILayout.FloatField("Mouse Delay", script._mouseDelay);
        }

        script._shaking = EditorGUILayout.Toggle("Shaking", script._shaking);
        if (script._shaking)
        {
            script._shakeStrength = EditorGUILayout.IntField("Shake Strength", script._shakeStrength);
            script._shakeDistance = EditorGUILayout.IntField("Shake Distance", script._shakeDistance);
        }
            
        
    }
}