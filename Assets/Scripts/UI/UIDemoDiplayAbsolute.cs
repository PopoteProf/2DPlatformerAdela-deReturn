using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class UIDemoDiplayAbsolute : MonoBehaviour
{

    [SerializeField] private TMP_Text _txtDiplay;

    [SerializeField] private RectTransform _rectTransformTracked;
    [SerializeField, Range(0, 1)] private float _normalizePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

  
    void Update() {
        Debug.Log("Execute");
        if (_txtDiplay == null || _rectTransformTracked == null) return;
        _txtDiplay.text = (_rectTransformTracked.rect.width * _normalizePos).ToString();
    }
}
