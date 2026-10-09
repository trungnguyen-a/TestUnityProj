using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]   
    private int maxHealth = 50;
    private int currentHealth;
    
    void Awake()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int dmg)
    {
        if (dmg <= 0)
        {
            return;
        }
        currentHealth = Mathf.Max(currentHealth - dmg, 0);
        Debug.Log("Player Health: " + currentHealth);
        if (currentHealth == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died");
        gameObject.SetActive(false);
    }
}
