using Unity.Cinemachine;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private ActiveCameraManager _activeCameraManager;
    [SerializeField] private string _tag;
    [SerializeField] private CinemachineCamera _onEnterCamera;
    [SerializeField] private CinemachineCamera _onExitCamera;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_tag))
        {
            print($"Camera collided with {other.name}");
            if (_onEnterCamera) _activeCameraManager.SwitchCamera(_onEnterCamera);
            else _activeCameraManager.SwitchToDefaultCamera();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(_tag))
        {
            if (_onExitCamera) _activeCameraManager.SwitchCamera(_onExitCamera);
            else _activeCameraManager.SwitchToDefaultCamera();
        }
    }
}
