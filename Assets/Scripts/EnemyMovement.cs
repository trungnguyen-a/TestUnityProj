using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyAI))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float patrolSpeed = 1.5f;

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
        if (Time.time < knockbackEndTime) return;

        Transform player;
        float speed;
        bool isFoundPlayer;

        if (enemyAI.IsChasing)
        {
            player = enemyAI.Player;
            speed = moveSpeed;
        }
        else if (enemyAI.IsPatrolling)
        {
            player = enemyAI.CurrentPatrolPoint;
            speed = patrolSpeed;

            if (player == null) return;
            isFoundPlayer = Vector2
            .Distance(rg.position, player.position)
            <= enemyAI.ReachDistance;

            if (isFoundPlayer)
            {
                enemyAI.AdvancePatrolPoint();
                return;
            }
        }
        else { return; }

        Vector2 direction =
        ((Vector2)player.position - rg.position)
        .normalized;

        Vector2 targetPosition =
        rg.position +
        speed * Time.fixedDeltaTime * direction;

        rg.MovePosition(targetPosition);
    }

    public void ApplyKnockbackDelay(float duration)
    {
        knockbackEndTime = Time.time + duration;
    }
}
