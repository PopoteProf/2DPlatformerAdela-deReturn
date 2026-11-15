using System;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraOnDeath : MonoBehaviour {
    [SerializeField]private CinemachineVirtualCamera _vcam;
    private void  Awake() {
        _vcam = GetComponent<CinemachineVirtualCamera>();
        StaticData.OnPlayerDeath += StaticDataOnOnPlayerDeath;
    }

    private void StaticDataOnOnPlayerDeath(object sender, EventArgs e) {
        _vcam.enabled = false;
    }
}