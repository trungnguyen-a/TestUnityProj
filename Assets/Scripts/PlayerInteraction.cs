using UnityEngine;

public class PlayerInteration : MonoBehaviour
{
    // [SerializeField]
    // private int attackDamage = 10;
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("wall"))
        {
            Debug.Log("Hit: " + col.gameObject.name);
        }
        // else if (col.gameObject.CompareTag("enemy"))
        // {
        //     EnemyHealth em = col.gameObject.GetComponent<EnemyHealth>();
        //     if (em != null)
        //     {
        //         em.TakeDamage(attackDamage);
        //     }
        // }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("coin"))
        {
            Debug.Log("you received a " + col.gameObject.name);
            Destroy(col.gameObject);
        }
    }
}
