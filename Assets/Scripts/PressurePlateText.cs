using UnityEngine;

public class PressurePlateText : MonoBehaviour
{
    [SerializeField] private GameObject text;
    private Rigidbody2D _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
        Destroy(gameObject);
    }
}
