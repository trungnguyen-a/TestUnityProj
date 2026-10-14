using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    private int attackDamage = 10;

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
