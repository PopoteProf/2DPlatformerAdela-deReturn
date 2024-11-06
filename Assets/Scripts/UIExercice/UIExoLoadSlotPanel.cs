using TMPro;
using UnityEngine;

public class UIExoLoadSlotPanel : MonoBehaviour {
    [SerializeField] private TMP_Text _txtTitle;
    [SerializeField] private TMP_Text _txtTime;

    public void SetPanelData(string title , string time) {
        _txtTitle.text = title;
        _txtTime.text = time;
    }

    public void UILoadGame()
    {
        Debug.Log(_txtTitle.text+ " du "+ _txtTime.text + " de jeu est charger");
    }
    
}