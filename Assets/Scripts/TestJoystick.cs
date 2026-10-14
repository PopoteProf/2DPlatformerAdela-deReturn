using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TestJoystick : MonoBehaviour
{
    [SerializeField] private Image _Renderer;
    [SerializeField] private Sprite _neutralSprite;
    [SerializeField] private Sprite _leftSprite;
    [SerializeField] private Sprite _rightSprite;
    
    
    private Vector3 _oldPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Renderer = gameObject.GetComponent<Image>();

        StartCoroutine(Pos());
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (_oldPosition.x > transform.position.x)
            
            _Renderer.sprite = _leftSprite;
            
        else if (_oldPosition.x < transform.position.x)
            
            _Renderer.sprite = _rightSprite;
        
        else 
            _Renderer.sprite = _neutralSprite;
    }

    private IEnumerator Pos()
    {
        while (true)
        {
            _oldPosition.x = transform.position.x;
            
            yield return 1f;
        }
    }
}
