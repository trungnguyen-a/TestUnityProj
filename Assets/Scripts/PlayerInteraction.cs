using UnityEngine;

public class PlayerInteration : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("wall"))
        {
            Debug.Log("Hit: " + col.gameObject.name);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("coin"))
        {
            Debug.Log("you received a " + col.gameObject.name);
            Destroy(col.gameObject);
        }
        if (col.CompareTag("hazard_zone"))
        {
            Debug.Log("Player entered hazard" );
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("hazard_zone"))
        {
            Debug.Log("Player left hazard" );
        }
    }
}
