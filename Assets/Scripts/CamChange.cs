using System;
using Unity.Cinemachine;
using UnityEngine;

public class CamChange : MonoBehaviour
{
    [SerializeField] private CinemachineCamera _mapCamera;
    [SerializeField] private CinemachineCamera _zoneCamera;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (_zoneCamera.Priority == 1)
            {
                _zoneCamera.Priority = 0;
                _mapCamera.Priority = 1;
            }
            else
            {
                _zoneCamera.Priority = 1;
                _mapCamera.Priority = 0;
            }
        }
    }
}
