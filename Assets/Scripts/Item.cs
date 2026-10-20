using UnityEngine;

public class Item
{
    public int id { get; set; }
    public string itemName;
    public int Quantity { get; set; }

    public Item(int id, string itemName, int quantity)
    {
        this.id = id;
        this.itemName = itemName;
        Quantity = quantity;
    }
}
