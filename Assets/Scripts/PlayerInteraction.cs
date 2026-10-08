using UnityEngine;

public class PlayerInteration : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision Detected: " + col.gameObject.name);
        if (col.gameObject.CompareTag("enemy"))
        {
            EnemyHealth em = col.gameObject.GetComponent<EnemyHealth>();
            em.TakeDamage(30);
        }
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
