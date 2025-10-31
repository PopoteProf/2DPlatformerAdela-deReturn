using UnityEngine;

public class TriggerStarSpawner : MonoBehaviour
{
    public GameObject shootingStarPrefab; 
    public Transform spawnPoint; 

    private bool hasTriggered = false; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player")) 
        {
            hasTriggered = true;

            Vector3 position = spawnPoint ? spawnPoint.position : transform.position;
            GameObject star = Instantiate(shootingStarPrefab, position, Quaternion.identity);

        
            Destroy(star, GetAnimationLength(star));
        }
    }

    float GetAnimationLength(GameObject star)
    {
        Animator animator = star.GetComponent<Animator>();
        if (animator == null) return 1f;

        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        if (ac == null) return 1f;

        AnimationClip clip = ac.animationClips[0];
        return clip.length;
    }
}
