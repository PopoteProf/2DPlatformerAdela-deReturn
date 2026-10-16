using Unity.Cinemachine;
using UnityEngine;

public class triggerCam : MonoBehaviour
{
    
    public CinemachineCamera _camera;
    public GameObject _target;

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Coucou =)");
            _camera.Priority = 10;
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            _camera.Priority = 0;
        }
    }
}
