using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI inventoryText;

    public void Refresh(IReadOnlyList<Item> items)
    {
        StringBuilder builder = new();
        builder.AppendLine("Inventory");
        foreach (Item item in items)
        {
            builder.AppendLine(item.itemName + " x" + item.Quantity);
        }
        inventoryText.SetText(builder);
    }
}
