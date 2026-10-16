using System;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Cinemachine;
using UnityEngine;

public class ActiveCameraManager : MonoBehaviour
{
    [SerializeField] private int _activeCameraPriority;
    [SerializeField] private CinemachineCamera _defaultCamera;
    
    [HideInInspector] public CinemachineCamera activeCamera;

    private int _currentCameraOldPriority;
    
    public void Start()
    {
        SwitchCamera(_defaultCamera);
    }

    public bool SwitchCamera(CinemachineCamera camera)
    {
        if(activeCamera == camera) return false;
        if(activeCamera) activeCamera.Priority = _currentCameraOldPriority;
        
        _currentCameraOldPriority = camera.Priority.Value;
        camera.Priority.Value = _activeCameraPriority;
        activeCamera = camera;
        return true;
    }

    public bool SwitchToDefaultCamera()
    {
        return SwitchCamera(_defaultCamera);
    }
}
