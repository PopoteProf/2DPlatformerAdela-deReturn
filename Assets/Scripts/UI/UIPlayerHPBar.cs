using System;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHPBar : MonoBehaviour
{
    [SerializeField] private Image _imgHPBar;

    private void Start() {
        StaticData.OnPlayerHPChange+= StaticDataOnOnPlayerHPChange;
        _imgHPBar.fillAmount = StaticData.PlayerHP / (float)StaticData.PlayerMaxHP;
    }

    private void StaticDataOnOnPlayerHPChange(object sender, EventArgs e) {
        _imgHPBar.fillAmount = StaticData.PlayerHP / (float)StaticData.PlayerMaxHP;
    }
}