using UnityEngine;
using UnityEngine.Tilemaps;

public class Foreground2Dispawns : MonoBehaviour
{
    [SerializeField] private GameObject _fg;
    private Color _newcolor;

    private void Start()
    {
        _newcolor = _fg.GetComponent<Tilemap>().color;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _fg.SetActive(false);
            //_newcolor = new Color(_newcolor.r, _newcolor.g, _newcolor.b, 0);
        }
    }
}
