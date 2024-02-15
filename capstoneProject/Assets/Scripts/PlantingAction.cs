// Example: Player plants a seed
using UnityEngine;

public class PlantingAction : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item seedItem;

    private void Start()
    {
        inventoryManager = Object.FindFirstObjectByType<InventoryManager>();
    }

    public void PlantSeed()
    {
        // Perform planting logic here

        // Adjust inventory based on the action
        inventoryManager.RemoveItem(seedItem, 1);
    }
}

