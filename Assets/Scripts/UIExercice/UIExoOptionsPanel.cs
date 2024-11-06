using UnityEngine;
using UnityEngine.UI;

public class UIExoOptionsPanel : MonoBehaviour
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


    public void UIChangeGeneralVolume(float value) {
        Debug.Log("Le volume generale a été a"+value);
    }
    public void UIChangeMusicVolume(float value) {
        Debug.Log("Le volume Musique a été a"+value);
    }
    public void UIChangeSoundVolume(float value) {
        Debug.Log("Le volume Son a été a"+value);
    }

    public void UIChangeResolution(int value) {
        if (value < 0 || value > 2)
        {
            Debug.Log(" Erreur du changement de résolution");
            return;
        }
        
        if( value==0) Debug.Log("Changé la résolution sur 800X600");
        if( value==1) Debug.Log("Changé la résolution sur 1366x768");
        if( value==2) Debug.Log("Changé la résolution sur 1920x1080");
    }

    public void UISetDifficultyEasy(bool value) {
        Debug.Log("Difficulté facile est mise sur "+ value);
    }
    public void UISetDifficultyMedium(bool value) {
        Debug.Log("Difficulté Moyen est mise sur "+ value);
    }
    public void UISetDifficultyHard(bool value) {
        Debug.Log("Difficulté Difficile est mise sur "+ value);
    }
}