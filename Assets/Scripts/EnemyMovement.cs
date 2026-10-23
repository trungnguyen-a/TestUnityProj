using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyAI))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private EnemyAI enemyAI;
    private Rigidbody2D rg;
    private float knockbackEndTime;
    
    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        enemyAI = GetComponent<EnemyAI>();
    }

    private void FixedUpdate()
    {
        if (Time.time < knockbackEndTime)
        {
            return;
        }
        if (!enemyAI.isChasing)
        {
            return;
        }

        Transform player = enemyAI.Player;
        if (player == null)
        {
            return;
        }

        Vector2 direction = ((Vector2)player.position - rg.position).normalized;
        Vector2 targetPosition = rg.position + direction * moveSpeed * Time.deltaTime;
        rg.MovePosition(targetPosition);
    }

    public void ApplyKnockbackDelay(float duration)
    {
        knockbackEndTime = Time.time + duration;
    }
}
