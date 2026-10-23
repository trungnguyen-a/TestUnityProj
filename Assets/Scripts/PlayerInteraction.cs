using UnityEngine;

public class PlayerInteration : MonoBehaviour
{
    [SerializeField]
    private GameScore gameScore;

    private PlayerInventory playerInventory;
    const int MAX_SLOT = 5;
    void Awake()
    {
        playerInventory = GetComponent<PlayerInventory>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerInventory == null)
        {
            return;
        }

        if (collision.CompareTag("coin"))
        {
            if (gameScore == null)
            {
                return;
            }

            var points = collision.gameObject.name switch
            {
                "BronzeCoin" => 1,
                "SilverCoin" => 5,
                "GoldCoin" => 10,
                _ => 1,
            };
            gameScore.AddScore(points);
            playerInventory.AddCoin(1);
            Destroy(collision.gameObject);
            return;
        }

        ItemPickup itemPickup = collision.GetComponent<ItemPickup>();
        if (itemPickup != null)
        {
            Item item = itemPickup.CreateItem();
            if (playerInventory.ItemCount == MAX_SLOT)
            {
                return;
            }
            playerInventory.AddItem(item);
            Debug.Log("Picked up: " + item.itemName);
            Destroy(collision.gameObject);
        }

        // if (col.CompareTag("hazard_zone"))
        // {
        //     Debug.Log("Player entered hazard" );
        // }
    }

//     // void OnTriggerExit2D(Collider2D col)
//     // {
//     //     if (col.CompareTag("hazard_zone"))
//     //     {
//     //         Debug.Log("Player left hazard" );
//     //     }
//     // }
}
