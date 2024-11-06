using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class UIExoMainPanel : MonoBehaviour
{

    [SerializeField] private UIExoNewGamePanel _uiExoNewGamePanel;
    [SerializeField] private UIExoLoadGame _uiExoLoadGame;
    [SerializeField] private UIExoOptionsPanel _uiExoOptionsPanel;
    [SerializeField] private UIExoCreditPanel _uiExoCreditPanel;

    [ Space(20),Header("Exercice 4"), SerializeField]
    private Selectable _firstSelectedButton;
    private void Start() {
        if(_firstSelectedButton!=null) _firstSelectedButton.Select();
    }

    public void OpenPanel() {
        
        gameObject.SetActive(true);
        if(_firstSelectedButton!=null) _firstSelectedButton.Select();
    }
    
    public void UINewGame() {
        _uiExoNewGamePanel.OpenPanel();
        gameObject.SetActive(false);
    }

    public void UILoadGame()
    {
        _uiExoLoadGame.OpenPanel();
        gameObject.SetActive(false);
    }

    public void UIOptions()
    {
        _uiExoOptionsPanel.OpenPanel();
        gameObject.SetActive(false);
    }

    public void UICredit()
    {
        _uiExoCreditPanel.OpenPanel();
        gameObject.SetActive(false);
    }

    public void UIQuit() {
        Debug.Log("Vous Quittez le jeu");
    }

}