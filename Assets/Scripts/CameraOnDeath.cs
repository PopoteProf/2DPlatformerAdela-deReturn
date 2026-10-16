using System;
using Unity.Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineCamera))]
public class CameraOnDeath : MonoBehaviour {
    [SerializeField]private CinemachineCamera _vcam;
    private void  Awake() {
        _vcam = GetComponent<CinemachineCamera>();
        StaticData.OnPlayerDeath += StaticDataOnOnPlayerDeath;
    }

    private void StaticDataOnOnPlayerDeath(object sender, EventArgs e) {
        _vcam.enabled = false;
    }
}