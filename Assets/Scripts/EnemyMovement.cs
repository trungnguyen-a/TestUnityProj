using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;
    private Rigidbody2D rg;
    private Transform playerTransform;
    private float knockbackEndTime;
    
    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
    }

    private void FixedUpdate()
    {
        if (playerTransform == null)
        {
            return;
        }

        if (Time.time < knockbackEndTime)
        {
            return;
        }
        
        Vector2 direction = ((Vector2)playerTransform.position - rg.position).normalized;
        Vector2 targetPosition = rg.position + direction * moveSpeed * Time.deltaTime;
        rg.MovePosition(targetPosition);
    }

    public void ApplyKnockbackDelay(float duration)
    {
        knockbackEndTime = Time.time + duration;
    }
}
