using UnityEngine;

public class WorldItemManager : MonoBehaviour
{
    public void RestoreWorldItems(SaveData data)
    {
        WorldItem[] worldItems = FindObjectsByType<WorldItem>();

        if (data.remainWorldItemIds == null)
        {
            Debug.Log("No World Item data found.");
            return;
        }

        foreach (WorldItem item in worldItems)
        {
            bool shouldExists = false;
            foreach (string id in data.remainWorldItemIds)
            {
                if (item.UniqueId == id)
                {
                    shouldExists = true;
                    break;
                }
            }
            if (!shouldExists)
            {
                Destroy(item.gameObject);                
            }
        }
    }

    public string[] GetRemainingWorldItemIds()
    {
        WorldItem[] worldItems = FindObjectsByType<WorldItem>();
        string[] ids = new string[worldItems.Length];
        for (int i = 0; i < worldItems.Length; i++)
        {
            ids[i] = worldItems[i].UniqueId;
        }
        return ids;
    }
}
