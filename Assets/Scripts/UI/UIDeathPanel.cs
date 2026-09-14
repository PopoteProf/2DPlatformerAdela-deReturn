using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIDeathPanel : MonoBehaviour {
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeInTime = 2;

    [SerializeField] private Button _bpMainMenu;
    [SerializeField] private Button _bpRestart;

    private void Start() {
        StaticData.OnPlayerDeath+= StaticDataOnOnPlayerDeath;
        _canvasGroup.alpha = 0;
        gameObject.SetActive(false);
        
        _bpMainMenu.onClick.AddListener(UIClickOnMainMenu);
        _bpRestart.onClick.AddListener(UIClickOnRestart);
    }

    private void OnDestroy() {
        StaticData.OnPlayerDeath-= StaticDataOnOnPlayerDeath;
    }

    private void StaticDataOnOnPlayerDeath(object sender, EventArgs e) {
        gameObject.SetActive(true);
        _canvasGroup.DOFade(1, _fadeInTime);
    }

    private void UIClickOnMainMenu()=> SceneManager.LoadScene(0);
    private void UIClickOnRestart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
}