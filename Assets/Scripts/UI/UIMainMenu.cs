using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour {
    [SerializeField] private Button _bpPlay;
    [SerializeField] private Button _bpOptions;
    [SerializeField] private Button _bpCredits;
    [SerializeField] private Button _bpQuite;

    [SerializeField] private UIPanelOption _uiPanelOption;
    [SerializeField] private UIPanelCredits _uiPanelCredits;

    private void Start() {
        _bpPlay.onClick.AddListener(UIClickPlay);
        _bpOptions.onClick .AddListener(UIClickOption);
        _bpCredits.onClick.AddListener(UIClickCredits);
        _bpQuite.onClick.AddListener(UIClickQuite);

        _uiPanelOption.OnOptionMenuClose += CloseOption;
        _uiPanelCredits.OnCreditsPanelClose += CloseCredit;
        
        _bpPlay.Select();
    }

    private void UIClickPlay() => SceneManager.LoadScene(1);
    private void UIClickOption() => _uiPanelOption.OpenPanel();
    private void UIClickCredits() => _uiPanelCredits.OpenPanel();
    private void UIClickQuite() => Application.Quit();
    private void CloseOption(object sender , EventArgs e) => _bpOptions.Select();
    private void CloseCredit(object sender , EventArgs e) => _bpCredits.Select();
}