using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    private int attackDamage = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = col.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(attackDamage);
            }
        }
    }
}
