using UnityEngine;

public enum EnemyState { Idle, Chase, Attack }

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    public Transform Player => player;
    [SerializeField] private float chaseRange = 6f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LineRenderer circle;

    private EnemyState currentState = EnemyState.Idle;
    public bool isChasing => currentState == EnemyState.Chase;
    private EnemyCombat enemyCombat;

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
    }

    private void Update()
    {
        if (player == null)
        {
            ChangeState(EnemyState.Idle);
            return;
        }
        UpdateState();
        switch (currentState)
        {
            case EnemyState.Idle:
                HandleIdle();
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

    }

    public void HandleChase()
    {

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
    }
}
