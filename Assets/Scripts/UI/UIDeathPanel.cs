using System;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEditor;
using UnityEngine;

public class UIDeathPanel : MonoBehaviour {
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeInTime = 2;

    private void Start() {
        StaticData.OnPlayerDeath+= StaticDataOnOnPlayerDeath;
        _canvasGroup.alpha = 0;
        gameObject.SetActive(false);
    }

    private void OnDestroy() {
        StaticData.OnPlayerDeath-= StaticDataOnOnPlayerDeath;
    }

    private void StaticDataOnOnPlayerDeath(object sender, EventArgs e) {
        gameObject.SetActive(true);
        _canvasGroup.DOFade(1, _fadeInTime);
    }
}