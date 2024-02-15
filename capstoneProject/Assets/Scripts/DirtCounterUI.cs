using UnityEngine;
using TMPro;

public class DirtCounterUI : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public TextMeshProUGUI dirtCounterText;
    public Item dirtItem; // Reference to the dirt item

    private void Start()
    {
        inventoryManager = Object.FindFirstObjectByType<InventoryManager>();

        // Subscribe to the OnInventoryUpdated event
        inventoryManager.OnInventoryUpdated += UpdateDirtCounterText;

        // Update the dirt counter text
        UpdateDirtCounterText(dirtItem, inventoryManager.GetItemQuantity(dirtItem));
    }

    private void UpdateDirtCounterText(Item item, int quantity)
    {
        if (item == dirtItem)
        {
            dirtCounterText.text = " " + quantity.ToString();
        }
    }
}
