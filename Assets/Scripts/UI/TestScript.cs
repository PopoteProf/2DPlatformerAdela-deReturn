using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    [SerializeField] private float _valueToLog;
    [SerializeField] private float _valueToEx;

    [ContextMenu("DoLog")]
    private void DoLog()
    {
        Debug.Log(Mathf.Log(_valueToLog)*20);
    }
    [ContextMenu("DoExp")]
    private void DoExp()
    {
        Debug.Log(Mathf.Exp(_valueToEx/20));
    }
}
