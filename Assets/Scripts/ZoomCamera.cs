using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics.Geometry;

public class ZoomCamera : MonoBehaviour
{

    public bool ZoomActive;

    public Camera Cam;
    
    public float Speed;

    void Start()
    {
        Cam= Camera.main;
    }

    public void LateUpdate()
    {
        if (ZoomActive)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize,5,Speed);
        }

        else
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize,20,Speed);
        }
    }

}
