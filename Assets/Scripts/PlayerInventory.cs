using System.Collections.Generic;
using System.Linq;
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
    public int ItemCount
    {
        get { return items.Count; }
    }
    public IReadOnlyList<Item> Items
    {
        get { return items; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadInventory();
        if (coinCounterUI != null)
        {
            coinCounterUI.SetCoinCount(coinCount);
        }
        RefreshUI();
    }

    public void AddCoin(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        coinCount += amount;
        SaveInventory();
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
        if (new_item == null)
        {
            return;
        }

        Item existItem = FindItem(new_item.id);
        if (existItem != null)
        {
            existItem.Quantity += new_item.Quantity;
        }
        else
        {
            //if (items.Count == MAX_SLOT)
            //{
            //    return;
            //}
            items.Add(new_item);
        }
        SaveInventory();
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
        SaveInventory();
        RefreshUI();
        return true;
    }

    public void UseHealthPotion(PlayerHealth playerHealth)
    {
        int itemID = 0;
        int[] healthPotionID = { 1, 4 };
        for (int i = 0; i < healthPotionID.Count(); i++)
        {
            Item item = FindItem(healthPotionID[i]);
            if (item != null)
            {
                itemID = item.id;
                break;
            }
        }
        bool removed = RemoveItem(itemID, 1);
        if (!removed)
        {
            return;
        }
        switch (itemID)
        {
            case 1:
                playerHealth.Heal(25);
                break;
            case 4:
                playerHealth.Heal(50);
                break;
            default:
                playerHealth.Heal(25);
                break;
        }
    }

    private void RefreshUI()
    {
        if (inventoryUI != null)
        {
            inventoryUI.Refresh(items);
        }
    }

    private void LoadInventory()
    {
        if (GameSession.Instance == null)
        {
            return;
        }

        coinCount = GameSession.Instance.CoinCount;
        items = GameSession.Instance.LoadItems();
    }

    private void SaveInventory()
    {
        if (GameSession.Instance == null)
        {
            return;
        }

        GameSession.Instance.CoinCount = coinCount;
        GameSession.Instance.SaveItems(items);
    }

    public ItemSaveData[] ExportItems()
    {
        ItemSaveData[] result = new ItemSaveData[items.Count];
        for (int i = 0; i < items.Count; i++)
        {
            ItemSaveData itemData = new()
            {
                id          =   items[i].id,
                itemName    =   items[i].itemName,
                quantity    =   items[i].Quantity
            };
            result[i] = itemData;
        }
        return result;
    }

    public void ImportItems(ItemSaveData[] savedItems)
    {
        items.Clear();
        if (savedItems == null)
        {
            RefreshUI();
            return;
        }
        foreach (ItemSaveData saveitem in savedItems)
        {
            if (saveitem.quantity <= 0)
            {
                continue;
            }
            Item item = new(
                saveitem.id,
                saveitem.itemName,
                saveitem.quantity
            );
            items.Add(item);
        }
        SaveInventory();
        RefreshUI();
    }

    public void SetCoinCount(int amount)
    {
        coinCount = Mathf.Max(amount, 0);
        SaveInventory();
        if (coinCounterUI != null)
        {
            coinCounterUI.SetCoinCount(coinCount);
        }
    }
}
