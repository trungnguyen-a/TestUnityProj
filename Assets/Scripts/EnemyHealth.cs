using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 50;
    private int currentHealth;
    private EnemySpawner enemySpawner;
    
    [System.Obsolete]
    private void Awake()
    {
        currentHealth = maxHealth;
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
    }
    
    public void TakeDamage(int dmg)
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
    }

    private void Die()
    {
        enemySpawner.SpawnEnemy();
        Destroy(gameObject);
    }
}
