using UnityEngine;

public class CrowFlight : MonoBehaviour
{
    public Animator crowAnimator;
    public Rigidbody2D crowRb; 
    public Vector2 flightDirection = new Vector2(1f, 1f);
    public float flightSpeed = 5f;
    public float destroyAfterSeconds = 3f;
    private bool hasFlown = false;
    
    public void FlyCrow()
    {
        if (!hasFlown)
        {
            hasFlown = true;
            crowAnimator.SetTrigger("Fly"); // déclenche l’animation
            crowRb.linearVelocity = flightDirection.normalized * flightSpeed; // mouvement
            Destroy(gameObject, destroyAfterSeconds); // disparition après quelques secondes
        }
    }
}