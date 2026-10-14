using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int scoreReward = 20;
    [SerializeField]
    private GameScore gameScore;
    [SerializeField]
    private int maxHealth = 50;
    [SerializeField]
    private float knockbackForce = 5f;
    [SerializeField]
    private float knockbackDuration = .2f;

    private EnemyMovement enemyMovement;
    private int currentHealth;
    private EnemySpawner enemySpawner;
    private Rigidbody2D rb;
    
    [System.Obsolete]
    private void Awake()
    {
        currentHealth = maxHealth;
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
        rb = GetComponent<Rigidbody2D>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    void Start()
    {
        gameScore = GameObject.Find("GameManager").GetComponent<GameScore>();
    }
    
    private void ApplyKnockback(Vector2 attackerPos)
    {
        if (rb == null)
        {
            return;
        }
        Vector2 direction = (rb.position - attackerPos).normalized;

        if (enemyMovement != null)
        {
            enemyMovement.ApplyKnockbackDelay(knockbackDuration);
        }
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
    }
    
    public void TakeDamage(int dmg, Vector2 attackerPos)
    {
        if (dmg <= 0)
        {
            return;
        }
        currentHealth = Mathf.Max(currentHealth - dmg, 0);
        Debug.Log("Enemy Health: " + currentHealth);
        if (currentHealth == 0)
        {
            Die();
        }
        ApplyKnockback(attackerPos);
    }

    private void Die()
    {
        Destroy(gameObject);

        if (gameScore != null)
        {
            gameScore.AddScore(scoreReward);
        }
        
        if (enemySpawner != null)
        {
            enemySpawner.SpawnEnemy();
        }
    }
}
