using UnityEngine;
using UnityEngine.UI;

public class UITopRightPanel : MonoBehaviour
{
    [SerializeField] private Button _bpMenu;
    [SerializeField] private UIPauseMenu _uiPauseMenu;

    private void Start() {
        _bpMenu.onClick.AddListener(OpenPauseMenu);
    }

    private void OpenPauseMenu() {
        _uiPauseMenu.OpenPauseMenu();
        
    }
}