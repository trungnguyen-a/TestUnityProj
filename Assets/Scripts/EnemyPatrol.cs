using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public bool isPatrol = true;
    private EnemyMovement enemyMovement;
    private EnemyAI enemyAI;
    private Rigidbody2D rg;
    private Transform currentPoint;
    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        enemyAI = GetComponent<EnemyAI>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPoint = enemyAI.PatrolPoints[Random.Range(0, enemyAI.PatrolPoints.Count)];
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (!isPatrol)
    //    {
    //        return;
    //    }
    //    Vector2 dir = ((Vector2)currentPoint.position - rg.position).normalized;
    //    Vector2 target = rg.position + dir * moveSpeed * Time.deltaTime;
    //    rg.MovePosition(target);
    //}
}
