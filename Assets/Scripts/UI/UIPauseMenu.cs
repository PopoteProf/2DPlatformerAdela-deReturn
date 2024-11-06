using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPauseMenu : MonoBehaviour {
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeTime = 1;
    [SerializeField] private Button _bpResume;
    [SerializeField] private Button _bpRestart;
    [SerializeField] private Button _bpOptions;
    [SerializeField] private Button _bpMaineMenu;
    [SerializeField] private UIPanelOption _uiPanelOption;
    
    private void Awake() {
        _bpResume.onClick.AddListener(ClosePauseMenu);
        _bpRestart.onClick.AddListener(ReStart);
        _bpOptions.onClick.AddListener(Options);
        _bpMaineMenu.onClick.AddListener(MainMenu);
        _uiPanelOption.OnOptionMenuClose += OnOptionClose;
    }
    public void OpenPauseMenu() {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        _canvasGroup.DOFade(1, _fadeTime).SetUpdate(true);
        _bpResume.Select();
    }
    private void ClosePauseMenu() {
        Time.timeScale = 1;
        //DOTween.defaultUpdateType = UpdateType.Fixed;
        _canvasGroup.DOFade(0, _fadeTime).OnComplete(delegate { gameObject.SetActive(false); });
        EventSystem.current.SetSelectedGameObject(null);
    }
    private void ReStart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Options() {
        _uiPanelOption?.OpenPanel();
    }
    private void MainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnOptionClose(object sender , EventArgs arg) {
        _bpOptions.Select();   
    }
}