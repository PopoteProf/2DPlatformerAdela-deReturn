using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UIExoLoadGame : MonoBehaviour
{
    [SerializeField] private UIExoMainPanel _uiMainMenuPanel;
    [SerializeField] private UIExoLoadSlotPanel _prefabSlotPanel;
    [SerializeField] private Transform _transformSlot1;
    [SerializeField] private Transform _transformSlot2;
    [SerializeField] private Transform _transformSlot3;
    [ Space(20),Header("Exercice 4"), SerializeField]
    private Selectable _firstSelectedButton;

    private bool _isSetUp;

    private void Awake() {
        if (_isSetUp) return;
        UIExoLoadSlotPanel panel = Instantiate(_prefabSlotPanel, _transformSlot1);
        panel.SetPanelData("Sauvegarede1", Random.Range(0,31)+"/"+Random.Range(0,12)+"/"+Random.Range(0,24));
        panel = Instantiate(_prefabSlotPanel, _transformSlot2);
        panel.SetPanelData("Sauvegarede2", Random.Range(0,31)+"/"+Random.Range(0,12)+"/"+Random.Range(0,24));
        panel = Instantiate(_prefabSlotPanel, _transformSlot3);
        panel.SetPanelData("Sauvegarede3", Random.Range(0,31)+"/"+Random.Range(0,12)+"/"+Random.Range(0,24));
        _isSetUp = true;
    }

    public void OpenPanel() {
        gameObject.SetActive(true);
        if(_firstSelectedButton!=null) _firstSelectedButton.Select();
    }

    public void UIReturn() {
        _uiMainMenuPanel.OpenPanel();
        gameObject.SetActive(false);
    }
    
}