using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private CoinCounterUI coinCounterUI;
    [SerializeField]
    private InventoryUI inventoryUI;

    private int coinCount;
    public int CoinCount
    {
        get { return coinCount; }
    }

    private List<Item> items = new();
    public IReadOnlyList<Item> Items
    {
        get { return items; }
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

    public Item FindItem(int id)
    {
        foreach (Item item in items)
        {
            if (item.id == id)
            {
                return item;
            }
        }
        return null;
    }

    public void AddItem(Item new_item)
    {
        Item existItem = FindItem(new_item.id);
        if (existItem != null)
        {
            existItem.Quantity += new_item.Quantity;
        }
        else
        {
            items.Add(new_item);
        }
        RefreshUI();
    }

    public bool RemoveItem(int id, int amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        Item item = FindItem(id);
        if (item == null) return false;
        if (item.Quantity < amount) return false;

        item.Quantity -= amount;
        if (item.Quantity == 0)
        {
            items.Remove(item);
        }
        RefreshUI();
        return true;
    }

    public void UseHealthPotion(PlayerHealth playerHealth)
    {
        const int healthPotionId = 1;
        bool removed = RemoveItem(healthPotionId, 1);
        if (!removed)
        {
            return;
        }
        playerHealth.Heal(25);
    }

    private void RefreshUI()
    {
        if (inventoryUI != null)
        {
            inventoryUI.Refresh(items);
        }
    }
}
