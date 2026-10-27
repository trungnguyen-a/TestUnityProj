using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyAI))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    public bool isPatrol = true;

    private EnemyAI enemyAI;
    private Rigidbody2D rg;
    private float knockbackEndTime;
    //private Transform player;
    public Transform currentPoint;
    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        enemyAI = GetComponent<EnemyAI>();
    }

    private void Start()
    {
        currentPoint = enemyAI.PatrolPoints[0];
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
        //else if (enemyAI.isChasing)
        //{
        //    Vector2 dir = ((Vector2)currentPoint.position - rg.position).normalized;
        //    Vector2 target = rg.position + dir * moveSpeed * Time.deltaTime;
        //    rg.MovePosition(target);
        //}
        //else
        //{
        //    return;
        //}

        Debug.Log(currentPoint.name);


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

    public void PatrolArea()
    {
        Vector2 dir = ((Vector2)currentPoint.position - rg.position).normalized;
        Vector2 target = rg.position + dir * moveSpeed * Time.deltaTime;
        rg.MovePosition(target);
    }


}
