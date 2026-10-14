using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private CoinCounterUI coinCounterUI;

    private int coinCount;
    public int CoinCount
    { 
        get { return coinCount; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (coinCounterUI != null)
        {
            coinCounterUI.SetCoinCount(coinCount);
        }
    }

    public void AddCoin(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        coinCount += amount;
        if (coinCounterUI != null)
        {
            coinCounterUI.SetCoinCount(coinCount);
        }
    }
}
