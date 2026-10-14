using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestButton : MonoBehaviour , IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Sequence _sequence;
    private RectTransform _rt;

    private float _startPivotPointX;
    private float _startPivotPointY;
    private float _startAnchorPosX;
    private float _startAnchorPosY;
    private float _startScale;

    [SerializeField] private float _animationEndPosX;
    [SerializeField] private float _animationEndPosY;
    [SerializeField] private float _animationEndScale;
    [SerializeField] private float _animationLenght;

    [Range(0 ,1 )] [SerializeField] private float PivotPointX = 0.5f;
    [Range(0 ,1 )] [SerializeField] private float PivotPointY = 0.5f;
    
    [SerializeField] private AnimationCurve _animationCurve = AnimationCurve.EaseInOut(0,0,1,1);
    
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
        
        _startPivotPointX = _rt.pivot.x;
        _startPivotPointY = _rt.pivot.y;
        
        _startAnchorPosX = _rt.anchoredPosition.x;
        _startAnchorPosY = _rt.anchoredPosition.y;
        
        _startScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //DOTween.To(_rt.rect.position.x, )
        _sequence.Append(_rt.DOAnchorPos(new Vector2(_startAnchorPosX + _animationEndPosX, _startAnchorPosY + _animationEndPosY), _animationLenght).SetEase(_animationCurve));
        
        //_sequence.Append(_rt.DOAnchorPosX(_startAnchorPosX + _animationEndPosX, _animationLenght).SetEase(_animationCurve));
        //_sequence.Append(_rt.DOAnchorPosY(_startAnchorPosY + _animationEndPosY, _animationLenght).SetEase(_animationCurve));
        
        _sequence.Append(_rt.DOPivotX(PivotPointX,_animationEndScale).SetEase(_animationCurve));
        _sequence.Append(_rt.DOPivotY(PivotPointY,_animationEndScale).SetEase(_animationCurve));
        
        
        _sequence.Append(transform.DOScale(_animationEndScale,_animationLenght).SetEase(_animationCurve));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _sequence.Append(_rt.DOAnchorPosX(_startAnchorPosX, _animationLenght).SetEase(_animationCurve));
        _sequence.Append(_rt.DOAnchorPosY(_startAnchorPosY, _animationLenght).SetEase(_animationCurve));
        
        _sequence.Append(_rt.DOPivotX(PivotPointX,_animationEndScale).SetEase(_animationCurve));
        _sequence.Append(_rt.DOPivotY(PivotPointY,_animationEndScale).SetEase(_animationCurve));

        //changer par un sizedelta
        _sequence.Append(transform.DOScale(_startScale,_animationEndScale).SetEase(_animationCurve));
    }
}
