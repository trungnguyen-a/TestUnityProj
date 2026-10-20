using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]   
    private int maxHealth = 50;
    [SerializeField]   
    private HealthBarUI healthBarUI;
    [SerializeField]   
    private GameManager gameManager;
    
    private int currentHealth;
    
    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        if (healthBarUI != null)
        {
            healthBarUI.SetMaxHealth(maxHealth);
        }
    }
    

    public void TakeDamage(int dmg)
    {
        if (dmg <= 0 || currentHealth == 0)
        {
            return;
        }

        currentHealth = Mathf.Max(currentHealth - dmg, 0);
        if (healthBarUI != null)
        {
            healthBarUI.SetHealth(currentHealth);
        }
        
        if (currentHealth == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died");
        if (gameManager != null)
        {
            gameManager.GameOver();
        }
        gameObject.SetActive(false);
    }

    public void Heal(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        if (healthBarUI != null)
        {
            healthBarUI.SetHealth(currentHealth);
        }
    }
}
