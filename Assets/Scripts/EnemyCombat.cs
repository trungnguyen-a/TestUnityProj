using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField]
    private int attackDamage = 10;
    [SerializeField]
    private float attackCD = 1f;
    private float nextAttackTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (Time.time < nextAttackTime)
        {
            return;
        }
        PlayerHealth player = col.gameObject.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(attackDamage);
            nextAttackTime = Time.time + attackCD;
        }
    }
}
