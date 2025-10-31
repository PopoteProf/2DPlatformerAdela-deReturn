using UnityEngine;

public class BobbingAnimation : MonoBehaviour
{
    public float amplitude = 0.5f; // hauteur de l'oscillation
    public float speed = 2f;       // vitesse de montée/descente

    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        float offset = GetInstanceID() * 0.1f; // décalage unique par instance
        float newY = startY + Mathf.Sin(Time.time * speed + offset) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}