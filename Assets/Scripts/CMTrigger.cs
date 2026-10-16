using System;
using Unity.Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CMTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineCamera _cam;
    [SerializeField] private bool _isDefaultCam;
    public static CinemachineCamera currentCam;

    private void Start()
    {
        if (_isDefaultCam)
        {
            currentCam = _cam;
            SwitchCam();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        SwitchCam();
    }

    void SwitchCam()
    {
        currentCam.Priority = 0;
        currentCam = _cam;
        currentCam.Priority = 1;
    }
}
