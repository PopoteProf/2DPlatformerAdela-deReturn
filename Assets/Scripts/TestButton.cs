using System.Collections;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestButton : MonoBehaviour , IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Sequence _sequence;
    private RectTransform _rt;
    
    private Vector2 _startPivotPoint;
    private Vector2 _startAnchorPosMin;
    private Vector2 _startAnchorPosMax;
    private Vector2 _startScale;
    
    [Header("Start")] 
    [HideInInspector] public bool _startingAnimation;
    
    [HideInInspector] public Vector2 _startingAnimationEndPos;
    [HideInInspector] public Vector2 _startingAnimationEndScale;
    [HideInInspector] public Vector2 _startingPivotPoint = new Vector2(0.5f, 0.5f);
    
    [HideInInspector] public float _startingAnimationLenght;
    
    [HideInInspector] public AnimationCurve _startingAnimationCurve = AnimationCurve.EaseInOut(0,0,1,1);
    
    [Header("Playing")]
    [HideInInspector] public bool _animation;
    
    [HideInInspector] public Vector2 _animationEndPos;
    [HideInInspector] public Vector2 _animationEndScale;
    [HideInInspector] public Vector2 _pivotPoint = new Vector2(0.5f, 0.5f);
    
    [HideInInspector] public float _animationLenght;
    
    [HideInInspector] public AnimationCurve _animationCurve = AnimationCurve.EaseInOut(0,0,1,1);
    
    private Vector2 _afterStartPivotPoint;
    private Vector2 _afterStartAnchorPosMin;
    private Vector2 _afterStartAnchorPosMax;
    private Vector2 _afterStartScale;
    
    
    public MyEnum myDropDown = new MyEnum();
    
    public enum MyEnum
    {
        OutExpo,
        EaseInOut
    }
    
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
        
            _sequence.Join(_rt.DOSizeDelta(_rt.sizeDelta * _startingAnimationEndScale, _startingAnimationLenght).SetEase(_startingAnimationCurve).OnComplete(AfterStartAnimation));
        }
        else
            AfterStartAnimation();
    }

    private void AfterStartAnimation()
    {
        _startPivotPoint = _rt.pivot;
        _startAnchorPosMin = _rt.anchorMin;
        _startAnchorPosMax = _rt.anchorMax;
        
        _startScale = transform.localScale;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!_animation) return;
        
        _sequence = DOTween.Sequence();
        
        _sequence.Join(_rt.DOAnchorMin(_startAnchorPosMin + _animationEndPos, _animationLenght).SetEase(_animationCurve));
        _sequence.Join(_rt.DOAnchorMax(_startAnchorPosMax + _animationEndPos, _animationLenght).SetEase(_animationCurve));
        
        _sequence.Join(_rt.DOPivot(_pivotPoint, _animationLenght).SetEase(_animationCurve));
        
        _sequence.Join(_rt.DOSizeDelta(_startScale * _animationEndScale, _animationLenght).SetEase(_animationCurve));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!_animation) return;
        
        _sequence = DOTween.Sequence();
        
        _sequence.Join(_rt.DOAnchorMin(_startAnchorPosMin, _animationLenght).SetEase(_animationCurve));
        _sequence.Join(_rt.DOAnchorMax(_startAnchorPosMax, _animationLenght).SetEase(_animationCurve));
        
        _sequence.Join(_rt.DOPivot(_startPivotPoint, _animationLenght).SetEase(_animationCurve));
        
        _sequence.Join(_rt.DOSizeDelta(_startScale, _animationLenght).SetEase(_animationCurve));
    }
}

[CustomEditor(typeof(TestButton))]
public class InspectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var script = (TestButton)target;
        
        script._startingAnimation = EditorGUILayout.Toggle("Starting Animation", script._startingAnimation);

        if (script._startingAnimation)
        {
            script._startingAnimationEndPos = EditorGUILayout.Vector2Field("Start Position", script._startingAnimationEndPos);
            script._startingAnimationEndScale = EditorGUILayout.Vector2Field("Start Scale", script._startingAnimationEndScale);
            script._startingPivotPoint = EditorGUILayout.Vector2Field("Start Pivot Point", script._startingPivotPoint);
            script._startingAnimationLenght = EditorGUILayout.FloatField("Start Animation Lenght", script._startingAnimationLenght);
            script._startingAnimationCurve = EditorGUILayout.CurveField("Start AnimationCurve", script._startingAnimationCurve);
        }
        
        script._animation = EditorGUILayout.Toggle("Playing Animation", script._animation);

        if (!script._animation) return;
        
        script._animationEndPos = EditorGUILayout.Vector2Field("End Position", script._animationEndPos);
        script._animationEndScale = EditorGUILayout.Vector2Field("End Scale", script._animationEndScale);
        script._pivotPoint = EditorGUILayout.Vector2Field("Pivot Point", script._pivotPoint);
        script._animationLenght = EditorGUILayout.FloatField("Animation Lenght", script._animationLenght);
        script._animationCurve = EditorGUILayout.CurveField("AnimationCurve", script._animationCurve);
    }
}