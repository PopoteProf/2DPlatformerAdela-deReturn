using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerStarSpawner : MonoBehaviour
{
    [Header("Liste des prefabs d'étoiles filantes")]
    public List<GameObject> shootingStarPrefabs;

    [Header("Points d'apparition (optionnels)")]
    public List<Transform> spawnPoints;

    [Header("Délai entre chaque étoile (secondes)")]
    public float spawnDelay = 0.3f; 

    [Header("Durée du fondu avant destruction (secondes)")]
    public float fadeDuration = 1f;

    [Header("Temps après la fin de l'animation avant destruction")]
    public float postAnimationDelay = 0.2f; 

    private bool hasTriggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            StartCoroutine(SpawnStarsWithDelay());
        }
    }

    IEnumerator SpawnStarsWithDelay()
    {
        int count = Mathf.Max(shootingStarPrefabs.Count, spawnPoints.Count);

        for (int i = 0; i < count; i++)
        {
            GameObject prefab = shootingStarPrefabs[Mathf.Min(i, shootingStarPrefabs.Count - 1)];
            Vector3 position = (i < spawnPoints.Count) ? spawnPoints[i].position : transform.position;

            GameObject star = Instantiate(prefab, position, Quaternion.identity);
            star.SetActive(true);

            StartCoroutine(FadeAndDestroy(star));

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    IEnumerator FadeAndDestroy(GameObject star)
    {
        float animLength = GetAnimationLength(star);
        SpriteRenderer sr = star.GetComponent<SpriteRenderer>();


        yield return new WaitForSeconds(animLength - fadeDuration + postAnimationDelay);


        if (sr == null)
        {
            yield return new WaitForSeconds(fadeDuration);
            Destroy(star);
            yield break;
        }

   
        float elapsed = 0f;
        Color startColor = sr.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            sr.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        Destroy(star);
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
