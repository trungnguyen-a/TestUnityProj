using UnityEngine;

public class PlayerInteration : MonoBehaviour
{
    [SerializeField]
    private GameScore gameScore;

    private PlayerInventory playerInventory;

    void Awake()
    {
        playerInventory = GetComponent<PlayerInventory>();
    }

    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     if (col.gameObject.CompareTag("wall"))
    //     {
    //         Debug.Log("Hit: " + col.gameObject.name);
    //     }
    // }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("coin"))
        {
            return;
        }
        
        if (playerInventory == null || gameScore == null)
        {
            return;
        }

        var points = col.gameObject.name switch
        {
            "BronzeCoin" => 1,
            "SilverCoin" => 5,
            "GoldCoin" => 10,
            _ => 1,
        };
        gameScore.AddScore(points);
        playerInventory.AddCoin(1);
        Destroy(col.gameObject);
        
        // if (col.CompareTag("hazard_zone"))
        // {
        //     Debug.Log("Player entered hazard" );
        // }
    }

    // void OnTriggerExit2D(Collider2D col)
    // {
    //     if (col.CompareTag("hazard_zone"))
    //     {
    //         Debug.Log("Player left hazard" );
    //     }
    // }
}
