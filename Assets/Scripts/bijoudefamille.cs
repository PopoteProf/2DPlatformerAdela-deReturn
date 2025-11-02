using UnityEngine;

public class bijoudefamille : MonoBehaviour
{
    [SerializeField] private GameObject bizoudefamill;

    public void Bizourecup()
    {
        bizoudefamill.SetActive(true);
    }
}
