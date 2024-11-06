using System;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelCredits : MonoBehaviour {
    public event EventHandler OnCreditsPanelClose;
    
    [SerializeField] private Button _bpReturn;
    private void Start() {
        _bpReturn.onClick.AddListener(ClosePanel);
        
    }
    
    private void ClosePanel() {
        OnCreditsPanelClose.Invoke(this , EventArgs.Empty);
        gameObject.SetActive(false);
    }

    public void OpenPanel() {
        gameObject.SetActive(true);
        _bpReturn.Select();
    }
}