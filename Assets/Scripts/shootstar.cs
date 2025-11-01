using UnityEngine;
using System.Collections;

public class ShootingStarSingle : MonoBehaviour
{
    [Header("Paramètres de l'étoile filante")]
    public GameObject shootingStarPrefab;
    public Transform spawnPoint;
    public float destroyDelay = 0.2f;     
    public float fadeDuration = 1f;     

    private bool hasTriggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;

            Vector3 position = spawnPoint ? spawnPoint.position : transform.position;
            GameObject star = Instantiate(shootingStarPrefab, position, Quaternion.identity);
            star.SetActive(true); 


            StartCoroutine(FadeAndDestroy(star));
        }
    }

    IEnumerator FadeAndDestroy(GameObject star)
    {
        SpriteRenderer sr = star.GetComponent<SpriteRenderer>();

        yield return new WaitForSeconds(destroyDelay - fadeDuration);


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
}