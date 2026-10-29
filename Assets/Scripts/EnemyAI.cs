using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { Idle, Patrol, Chase, Attack }

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    public Transform Player => player;
    [SerializeField] private float chaseRange = 6f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private Transform patrolPointA;
    [SerializeField] private Transform patrolPointB;
    [SerializeField] private float reachDistance = .1f;

    public float ReachDistance => reachDistance;
    private EnemyState currentState = EnemyState.Patrol;
    public bool IsChasing => currentState == EnemyState.Chase;
    public bool IsPatrolling => currentState == EnemyState.Patrol;
    private EnemyCombat enemyCombat;
    private Transform currentPatrolPoint;
    public Transform CurrentPatrolPoint => currentPatrolPoint;

    private void Awake()
    {
        enemyCombat = GetComponent<EnemyCombat>();
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }
        currentPatrolPoint = patrolPointA;
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
        if (player == null)
        {
            ChangeState(EnemyState.Patrol);
            return;
        }

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > chaseRange)
        {
            ChangeState(EnemyState.Patrol);
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
    }

    public void HandlePatrol()
    {
    }

    public void HandleChase()
    {
    }

    public void HandleAttack()
    {
        enemyCombat.TryAttack(player);
    }

    public void AdvancePatrolPoint()
    {
        if (patrolPointA == null || patrolPointB == null) return;
        currentPatrolPoint =
        (currentPatrolPoint == patrolPointA) ? patrolPointB : patrolPointA;
    }

    public void SetPatrolPoint(Transform a, Transform b)
    {
        patrolPointA = a;
        patrolPointB = b;
        currentPatrolPoint = patrolPointA;
    }

    private void OnValidate()
    {
        chaseRange = Mathf.Max(0f, chaseRange);
        attackRange = Mathf.Clamp(attackRange, 0f, chaseRange);
        reachDistance = Mathf.Max(.01f, reachDistance);
    }

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, chaseRange);
        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, attackRange);
        if (patrolPointA != null && patrolPointB != null)
        {
            UnityEditor.Handles.color = Color.green;

            UnityEditor.Handles.DrawLine(
            patrolPointA.position,
            patrolPointB.position
            );

            UnityEditor.Handles.DrawWireDisc(
            patrolPointA.position, Vector3.forward, 0.2f
            );

            UnityEditor.Handles.DrawWireDisc(
            patrolPointB.position, Vector3.forward, 0.2f
            );
        }
    }
}
