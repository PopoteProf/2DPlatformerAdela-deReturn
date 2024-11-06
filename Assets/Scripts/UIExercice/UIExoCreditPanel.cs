using UnityEngine;
using UnityEngine.UI;

public class UIExoCreditPanel : MonoBehaviour
{
    [SerializeField] private UIExoMainPanel _uiMainMenuPanel;
    [ Space(20),Header("Exercice 4"), SerializeField]
    private Selectable _firstSelectedButton;
    
    public void OpenPanel() {
        gameObject.SetActive(true);
        if(_firstSelectedButton!=null) _firstSelectedButton.Select();
    }
    
    public void UIReturn() {
            _uiMainMenuPanel.OpenPanel();
            gameObject.SetActive(false);
        }
}