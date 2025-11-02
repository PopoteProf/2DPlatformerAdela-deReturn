using UnityEngine;

public class WallDeactivated : MonoBehaviour
{
    [SerializeField] private GameObject wall; 
    [SerializeField] private GameObject torch;

    public void TorchActivated()
    {   
        torch.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 45);
        wall.SetActive(false);
        gameObject.SetActive(false);
    }
}
