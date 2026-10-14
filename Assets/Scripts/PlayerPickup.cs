using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("gem"))
        {
            Debug.Log("gem pick up");
            Destroy(col.gameObject);
        }
    }
}
