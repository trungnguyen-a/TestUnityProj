using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { Idle, Patrol, Chase, Attack }

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    public Transform Player => player;
    [SerializeField] private float chaseRange = 6f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private List<Transform> patrolPoints;
    [SerializeField] private float patrolRange = 2.5f;
    [SerializeField] private float nextPatrolTime = 3f;

    public List<Transform> PatrolPoints => patrolPoints;
    public float PatrolRange => patrolRange;
    public float NextPatrolTime => nextPatrolTime;
    public float patrolTime = 0;
    private EnemyState currentState = EnemyState.Patrol;
    public bool isChasing => currentState == EnemyState.Chase;
    public bool isPatrolling => currentState == EnemyState.Patrol;
    private EnemyCombat enemyCombat;
    private EnemyMovement enemyMovement;

    private void Awake()
    {
        enemyCombat = GetComponent<EnemyCombat>();
        enemyMovement = GetComponent<EnemyMovement>();
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }
    }

    private void Update()
    {
        if (player == null)
        {
            ChangeState(EnemyState.Patrol);
            return;
        }
        UpdateState();
        switch (currentState)
        {
            case EnemyState.Idle:
                HandleIdle();
                break;
            case EnemyState.Patrol:
                HandlePatrol();
                break;
            case EnemyState.Chase:
                HandleChase();
                break;
            case EnemyState.Attack:
                HandleAttack();
                break;
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState == newState)
        {
            return;
        }
        currentState = newState;
        Debug.Log(gameObject.name + " State: " + currentState);
    }

    private void UpdateState()
    {
        if (!isChasing)
        {
            ChangeState(EnemyState.Patrol);
        }

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > chaseRange)
        {
            ChangeState(EnemyState.Idle);
        }
        else if (distance <= attackRange)
        {
            ChangeState(EnemyState.Attack);
        }
        else
        {
            ChangeState(EnemyState.Chase);
        }
    }

    public void HandleIdle()
    {
        if (Time.time < nextPatrolTime)
        {
            enemyMovement.currentPoint = PatrolPoints[Random.Range(0, PatrolPoints.Count)];
            return;
        }
        ChangeState(EnemyState.Patrol);
        enemyMovement.PatrolArea();
        nextPatrolTime = Time.time + patrolTime;
    }

    public void HandlePatrol()
    {
        //if (Time.time < nextPatrolTime)
        //{
        //    ChangeState(EnemyState.Idle);
        //    enemyMovement.currentPoint = PatrolPoints[Random.Range(0, PatrolPoints.Count)];
        //    return;
        //}
        //enemyMovement.PatrolArea();
        //nextPatrolTime = Time.time + patrolTime;
    }

    public void HandleChase()
    {
        if (isChasing)
        {
            enemyMovement.isPatrol = false;
        }
    }

    public void HandleAttack()
    {
        enemyCombat.TryAttack(player);
    }

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, chaseRange);
        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, attackRange);
        //UnityEditor.Handles.color = Color.blue;
        //UnityEditor.Handles.DrawWireDisc(patrolPoint[].position, Vector3.forward, patrolRange);
    }
}
