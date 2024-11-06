using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIExoNewGamePanel : MonoBehaviour
{

    [SerializeField] private UIExoMainPanel _uiExoMainPanel;
    private string _playerName = "Player";
    private bool _isHardCoreMode = false;
    [ Space(20),Header("Exercice 4"), SerializeField]
    private Selectable _firstSelectedButton;
    
    public void OpenPanel() {
        gameObject.SetActive(true);
        if(_firstSelectedButton!=null) _firstSelectedButton.Select();
    }

    public void UIChangePlayerName(string newName) {
        _playerName = newName;
        Debug.Log("Nom du joueur changer pour "+ newName);
    }

    public void UIChangeHardCoreMode(bool value) {
        _isHardCoreMode = value;
        
        Debug.Log("Hardcore Mode passer en "+ value);
    }

    public void UILancer()
    {
        Debug.Log("Partir lancer avec le nom "+_playerName+ " et le mode Hardcore sur "+_isHardCoreMode);
    }

    public void UIReturn()
    {
        gameObject.SetActive(false);
        _uiExoMainPanel.OpenPanel();
    }
    
}