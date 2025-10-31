using UnityEngine;

public class BatMovement : MonoBehaviour
{
    public float speed = 2f;
    public BoxCollider2D areaTrigger;
    private Vector2 targetPosition;
    private SpriteRenderer spriteRenderer;
    private Vector2 areaMin;
    private Vector2 areaMax;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (areaTrigger != null)
        {
            Vector2 center = areaTrigger.bounds.center;
            Vector2 size = areaTrigger.bounds.extents;
            areaMin = center - size;
            areaMax = center + size;
        }

        ChooseNewTarget();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            ChooseNewTarget();

        spriteRenderer.flipX = targetPosition.x < transform.position.x;
    }

    void ChooseNewTarget()
    {
        float x = Random.Range(areaMin.x, areaMax.x);
        float y = Random.Range(areaMin.y, areaMax.y);
        targetPosition = new Vector2(x, y);
    }

    void OnDrawGizmosSelected()
    {
        if (areaTrigger != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(areaTrigger.bounds.center, areaTrigger.bounds.size);
        }
    }
}